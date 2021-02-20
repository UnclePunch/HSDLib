﻿using HSDRaw.Common;
using HSDRaw.Common.Animation;
using HSDRaw.Melee.Gr;
using HSDRaw.Melee.Mn;
using HSDRaw.Melee.Pl;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using HSDRaw.AirRide.Vc;
using HSDRaw.Melee.Ef;
using HSDRaw.AirRide.Gr;
using HSDRaw.AirRide.Gr.Data;
using System.Diagnostics;
using HSDRaw.Melee;
using HSDRaw.MEX;
using HSDRaw.MEX.Stages;
using HSDRaw.MEX.Menus;

namespace HSDRaw
{
    /// <summary>
    /// 
    /// </summary>
    public class HSDRootNode
    {
        public string Name { get; set; }
        public HSDAccessor Data { get; set; }
    }

    /// <summary>
    /// Holds raw HSD DAT structure information
    /// </summary>
    public class HSDRawFile
    {
        private char[] VersionChars = new char[4];

        public List<HSDRootNode> Roots = new List<HSDRootNode>();
        public List<HSDRootNode> References = new List<HSDRootNode>();

        /// <summary>
        /// Trying to keep the order of structs intact if possible
        /// </summary>
        private readonly List<HSDStruct> _structCache = new List<HSDStruct>();
        private readonly Dictionary<HSDStruct, int> _structCacheToOffset = new Dictionary<HSDStruct, int>();

        public HSDRootNode this[string i]
        {
            get
            {
                return Roots.Find(e => e.Name == i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HSDRawFile()
        {

        }

        /// <summary>
        /// Loads dat data from file path
        /// </summary>
        /// <param name="filePath"></param>
        public HSDRawFile(string filePath)
        {
            Open(filePath);
        }

        /// <summary>
        /// Loads dat data from byte array
        /// </summary>
        /// <param name="data"></param>
        public HSDRawFile(byte[] data)
        {
            Open(new MemoryStream(data));
        }

        /// <summary>
        /// Opens dat file from path
        /// </summary>
        /// <param name="filePath"></param>
        public void Open(string filePath)
        {
            Open(new FileStream(filePath, FileMode.Open));
        }

        /// <summary>
        /// Opens dat file from stream
        /// </summary>
        /// <param name="stream"></param>
        public void Open(Stream stream)
        {
            using (BinaryReaderExt r = new BinaryReaderExt(stream))
            {
                r.BigEndian = true;

                Stopwatch sw = new Stopwatch();

                sw.Start();

                // Parse Header -----------------------------
                var fsize = r.ReadInt32(); // dat size
                int relocOffset = r.ReadInt32() + 0x20;
                int relocCount = r.ReadInt32();
                int rootCount = r.ReadInt32();
                int refCount = r.ReadInt32();
                VersionChars = r.ReadChars(4);
                
                // Parse Relocation Table -----------------------------
                List<int> Offsets = new List<int>();
                HashSet<int> OffsetContain = new HashSet<int>();
                Dictionary<int, int> relocOffsets = new Dictionary<int, int>();
                Offsets.Add(relocOffset);

                for (int i = 0; i < relocCount; i++)
                {
                    r.BaseStream.Position = relocOffset + 4 * i;
                    int offset = r.ReadInt32() + 0x20;

                    r.BaseStream.Position = offset;

                    var objectOff = r.ReadInt32() + 0x20;

                    // if we need to read past end of file then we need to include filesize as an offset
                    // this fixes files that had previously been manually relocated to end of file
                    if(objectOff > relocOffset && !OffsetContain.Contains(fsize))
                        Offsets.Add(fsize);

                    // alternate null pointer
                    if (objectOff < 0)
                        continue;

                    relocOffsets.Add(offset, objectOff);

                    if (!OffsetContain.Contains(objectOff))
                    {
                        OffsetContain.Add(objectOff);
                        Offsets.Add(objectOff);
                    }

                }

                Debug.WriteLine("Relocate Parsed: " + sw.ElapsedMilliseconds);
                sw.Restart();

                // Parse Roots---------------------------------
                r.BaseStream.Position = relocOffset + relocCount * 4;
                List<int> rootOffsets = new List<int>();
                List<string> rootStrings = new List<string>();
                List<int> refOffsets = new List<int>();
                List<string> refStrings = new List<string>();
                var stringStart = r.BaseStream.Position + (refCount + rootCount) * 8;
                for (int i = 0; i < rootCount; i++)
                {
                    rootOffsets.Add(r.ReadInt32() + 0x20);
                    rootStrings.Add(r.ReadString((int)stringStart + r.ReadInt32(), -1));
                }
                for (int i = 0; i < refCount; i++)
                {
                    var refp = r.ReadInt32() + 0x20;
                    refOffsets.Add(refp);
                    refStrings.Add(r.ReadString((int)stringStart + r.ReadInt32(), -1));

                    var temp = r.Position;

                    var special = refp;
                    while (true)
                    {
                        r.Seek((uint)special);
                        special = r.ReadInt32();

                        if (special == 0 || special == -1 )
                            break;

                        special += 0x20;

                        relocOffsets.Add(refp, special);

                        refp = special;

                        if (!OffsetContain.Contains(special))
                        {
                            OffsetContain.Add(special);
                            Offsets.Add(special);
                        }
                    }

                    r.Seek(temp);

                }
                foreach (var v in rootOffsets)
                    if (!OffsetContain.Contains(v))
                    {
                        OffsetContain.Add(v);
                        Offsets.Add(v);
                    }
                foreach (var v in refOffsets)
                    if (!OffsetContain.Contains(v))
                    {
                        OffsetContain.Add(v);
                        Offsets.Add(v);
                    }


                Debug.WriteLine("Roots Parsed: " + sw.ElapsedMilliseconds);
                sw.Restart();
                // Split Raw Struct Data--------------------------
                Offsets.Sort();

                Debug.WriteLine("Sorted: " + sw.ElapsedMilliseconds);
                sw.Restart();

                Dictionary<int, HSDStruct> offsetToStruct = new Dictionary<int, HSDStruct>();
                Dictionary<int, List<int>> offsetToOffsets = new Dictionary<int, List<int>>();
                Dictionary<int, List<int>> offsetToInnerOffsets = new Dictionary<int, List<int>>();

                var relockeys = relocOffsets.Keys.ToList();
                relockeys.Sort();
                for (int i = 0; i < Offsets.Count - 1; i++)
                {
                    r.BaseStream.Position = Offsets[i];
                    byte[] data = r.ReadBytes(Offsets[i + 1] - Offsets[i]);

                    if (!offsetToOffsets.ContainsKey(Offsets[i]))
                    {
                        var relocKets = new List<int>();
                        var list = new List<int>();
                        var min = BinarySearch(relockeys, Offsets[i]);
                        var max = BinarySearch(relockeys, Offsets[i + 1]) + 1;

                        if (min != -1 && max != -1)
                        {
                            for (int v = min; v < max; v++)
                            {
                                if (relockeys[v] >= Offsets[i] && relockeys[v] < Offsets[i + 1])
                                {
                                    relocKets.Add(relockeys[v]);
                                    list.Add(relocOffsets[relockeys[v]]);
                                }
                            }
                        }

                        offsetToOffsets.Add(Offsets[i], list);
                        offsetToInnerOffsets.Add(Offsets[i], relocKets);
                    }

                    if (!offsetToStruct.ContainsKey(Offsets[i]))
                    {
                        var struture = new HSDStruct(data);

                        offsetToStruct.Add(Offsets[i], struture);
                    }
                }
                Debug.WriteLine("Find All Parsed: " + sw.ElapsedMilliseconds);
                sw.Restart();

                HashSet<HSDStruct> orphans = new HashSet<HSDStruct>();

                foreach (var str in offsetToStruct)
                    orphans.Add(str.Value);

                // set references-------------------------
                foreach (var str in offsetToStruct)
                {
                    var _o = str.Key;
                    var _s = str.Value;

                    var offsets = offsetToOffsets[_o];
                    var innerOffsets = offsetToInnerOffsets[_o];

                    // set references in struct
                    for (int i = 0; i < offsets.Count; i++)
                    {
                        if (offsetToStruct.ContainsKey(offsets[i]) && _s.Length >= innerOffsets[i] - _o + 4)
                        {
                            var refstruct = offsetToStruct[offsets[i]];

                            _s.SetReferenceStruct(innerOffsets[i] - _o, refstruct);

                            // this not is not an orphan
                            if (refstruct != _s && orphans.Contains(refstruct))
                                orphans.Remove(refstruct);
                        }
                    }

                    _structCache.Add(str.Value);
                    _structCacheToOffset.Add(str.Value, str.Key);
                }

                Debug.WriteLine("Set References: " + sw.ElapsedMilliseconds);
                sw.Restart();

                // set roots
                for (int i = 0; i < rootOffsets.Count; i++)
                {
                    HSDStruct str = offsetToStruct[rootOffsets[i]];
                    HSDAccessor a = GuessAccessor(rootStrings[i], str);

                    Roots.Add(new HSDRootNode() { Name = rootStrings[i], Data = a });

                    if (orphans.Contains(str))
                        orphans.Remove(str);
                }


                // set references
                for (int i = 0; i < refOffsets.Count; i++)
                {
                    HSDStruct str = offsetToStruct[refOffsets[i]];
                    HSDAccessor a = new HSDAccessor();
                    a._s = str;
                    References.Add(new HSDRootNode() { Name = refStrings[i], Data = a });

                    if (orphans.Contains(str))
                        orphans.Remove(str);
                }

                // process special orphans
                foreach (var orphan in orphans)
                {
                    HSDStruct str = orphan;
                    HSDAccessor a = new HSDAccessor() { _s = str };

                    // hack: if this is a subaction append it to previous struct
                    if(str.References.Count > 0)
                    {
                        var maxkey = str.References.Keys.Max();
                        if (str.References[maxkey] == str && maxkey >= 8 && str.GetInt32(maxkey - 4) == 0x1C000000)
                        {
                            // get previous struct
                            var prev = GetPreviousStruct(str);

                            // add goto pointer to subaction
                            if (prev != null)
                            {
                                var len = prev.Length;
                                prev.Resize(prev.Length + 8);
                                prev.SetInt32(len, 0x1C000000);
                                prev.SetReferenceStruct(len + 4, str);
                                continue;
                            }
                        }
                    }

#if DEBUG
                    // add orphans for debugging
                    Roots.Add(new HSDRootNode() { Name = "Orphan0x" + _structCacheToOffset[orphan].ToString("X"), Data = a });
#endif

                }

                Debug.WriteLine("Finish: " + sw.ElapsedMilliseconds);
                sw.Restart();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private HSDStruct GetPreviousStruct(HSDStruct str)
        {
            for(int i = 0; i < _structCache.Count - 1; i++)
            {
                if (_structCache[i + 1] == str)
                    return _structCache[i];
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int BinarySearch(List<int> a, int item)
        {
            if (a.Count == 0)
                return -1;

            int first = 0;
            int last = a.Count - 1;
            int mid = 0;
            do
            {
                mid = first + (last - first) / 2;
                if (item > a[mid])
                    first = mid + 1;
                else
                    last = mid - 1;
                if (a[mid] == item)
                    return mid;
            } while (first <= last);
            return mid;
        }

        /// <summary>
        /// Saves dat data to filepath
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName, bool bufferAlign = true, bool optimize = true, bool trim = false)
        {
            Save(new FileStream(fileName, FileMode.Create), bufferAlign, optimize, trim);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool IsBuffer(HSDStruct a)
        {
            if (!a.CanBeBuffer)
                return false;

            return (a.References.Count == 0 && a.Length > 0x40) || a.IsBufferAligned;
        }

        //https://stackoverflow.com/questions/16340/how-do-i-generate-a-hashcode-from-a-byte-array-in-c/16381
        public static int ComputeHash(params byte[] data)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;

                for (int i = 0; i < data.Length; i++)
                    hash = (hash ^ data[i]) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsRoot(HSDStruct s)
        {
            foreach (var v in Roots)
                if (v.Data._s == s)
                    return true;

            foreach (var v in References)
                if (v.Data._s == s)
                    return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RemoveDuplicateBuffers()
        {
            Dictionary<int, HSDStruct> hashToStruct = new Dictionary<int, HSDStruct>();
            var toRemove = new List<HSDStruct>();
            foreach (var v in _structCache)
            {
                if (v.CanBeDuplicate && IsBuffer(v) && !IsRoot(v))
                {
                    var hash = ComputeHash(v.GetData());
                    if (hashToStruct.ContainsKey(hash))
                    {
                        // correct references and remove this hash
                        foreach (var s in _structCache)
                        {
                            var keys = s.References.Keys.ToArray();
                            foreach (var re in keys)
                            {
                                if (s.References[re] == v)
                                    s.References[re] = hashToStruct[hash];
                            }
                        }
                        toRemove.Add(v);
                    }
                    else
                    {
                        hashToStruct.Add(hash, v);
                    }
                }
            }
            foreach (var v in toRemove)
                _structCache.Remove(v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<HSDStruct> GetAllStructs()
        {
            var allStructs = new List<HSDStruct>();
            foreach (var r in Roots)
            {
                foreach (var sub in r.Data._s.GetSubStructs())
                    if (!allStructs.Contains(sub))
                        allStructs.Add(sub);
            }
            foreach (var r in References)
            {
                foreach (var sub in r.Data._s.GetSubStructs())
                    if (!allStructs.Contains(sub))
                        allStructs.Add(sub);
            }
            return allStructs;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<HSDStruct> GetReferenceStructs()
        {
            var allStructs = new List<HSDStruct>();
            foreach (var r in References)
            {
                var s = r.Data._s;
                allStructs.Add(s);
                while(s.GetReference<HSDAccessor>(0) != null)
                {
                    s = s.GetReference<HSDAccessor>(0)._s;
                    allStructs.Add(s);
                }
            }
            return allStructs;
        }

        /// <summary>
        /// 
        /// </summary>
        public void TrimData()
        {
            foreach (var r in Roots)
                r.Data.Optimize();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetStructFlags()
        {
            foreach (var r in Roots)
                r.Data.SetStructFlags();
        }

        /// <summary>
        /// saves dat data to stream with optional alignment
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bufferAlign"></param>
        public void Save(Stream stream, bool bufferAlign = true, bool optimize = true, bool trim = false)
        {
            if (Roots.Count > 0 && Roots[0].Data is MEX_Data)
                bufferAlign = false;

            if (trim)
                TrimData();

            // TODO:
            //SetStructFlags();

            // gather all structs--------------------------------------------------------------------------
            var allStructs = GetAllStructs();

            // struct cache cleanup
            // remove unused structs--------------------------------------------------------------------------
            var unused = new List<HSDStruct>();

            foreach (var s in _structCache)
            {
                if (!allStructs.Contains(s))
                    unused.Add(s);
            }
            if (optimize)
                foreach (var s in unused)
                {
                    //TODO: this may be bugged?
                    if (_structCache.Contains(s))
                    {
                        System.Diagnostics.Debug.WriteLine("Removing " + s.Length.ToString("X") + " " + GetOffsetFromStruct(s).ToString("X"));
                        _structCache.Remove(s);
                    }
                }
            // add missing structs--------------------------------------------------------------------------
            foreach (var s in allStructs)
            {
                if (!_structCache.Contains(s))
                {
                    if (IsBuffer(s))
                        _structCache.Insert(0, s);
                    else
                        _structCache.Add(s);
                }
            }
            allStructs.Clear();

            // remove duplicate buffers--------------------------------------------------------------------------
            if(optimize && Roots.Count > 0 && !(Roots[0].Data is SBM_FighterData) && !(Roots[0].Data is MEX_Data))
                RemoveDuplicateBuffers();

            // build file --------------------------------------------------------------------------
            using (BinaryWriterExt writer = new BinaryWriterExt(stream))
            {
                writer.BigEndian = true;

                writer.Write(new byte[0x20]);

                Dictionary<HSDStruct, int> structToOffset = new Dictionary<HSDStruct, int>(); 
                
                // write structs
                foreach (var s in _structCache)
                {
                    // align buffers and general alignment
                    // TODO: trim extra data? Not a problem aside from potential filesize
                    // no refereneces = buffer?
                    // textures need to be 0x20 aligned... but there is no way to detect which structures are textures
                    // this can result in unnessecary padding
                    if (IsBuffer(s) && bufferAlign) 
                        writer.Align(0x20);
                    else
                        if(s.Align)
                            writer.Align(4);

                    structToOffset.Add(s, (int)writer.BaseStream.Position - 0x20);
                    writer.Write(s.GetData());
                }
                
                writer.Align(4);
                var relocationOffset = writer.BaseStream.Position;

                List<int> relocationOffsets = new List<int>();

                var refStructs = GetReferenceStructs();

                // fix references
                foreach (var s in _structCache)
                {
                    var offset = structToOffset[s];
                    foreach(var v in s.References)
                    {
                        if(!refStructs.Contains(s) || 
                            (refStructs.Contains(s) && v.Key != 0))
                            
                            relocationOffsets.Add(offset + v.Key);
                        writer.Seek(offset + v.Key + 0x20, SeekOrigin.Begin);
                        writer.Write(structToOffset[v.Value]);
                    }
                }

                // write reloc table
                writer.Seek((int)relocationOffset, SeekOrigin.Begin);
                foreach (var v in relocationOffsets)
                {
                    writer.Write(v);
                }

                // write root and reference node info
                MemoryStream stringstream = new MemoryStream();
                Dictionary<string, uint> stringToOffset = new Dictionary<string, uint>();
                List<string> strings = new List<string>();

                foreach (var root in Roots)
                    strings.Add(root.Name);
                foreach (var root in References)
                    strings.Add(root.Name);

                //strings.Sort();

                byte[] stringbuf;
                using (BinaryWriterExt stringWriter = new BinaryWriterExt(stringstream))
                {
                    foreach(var s in strings)
                    {
                        stringToOffset.Add(s, (uint)stringstream.Position);
                        stringWriter.Write(s);
                    }
                    stringbuf = (stringstream.ToArray());
                }

                foreach (var root in Roots)
                {
                    writer.Write(structToOffset[root.Data._s]);
                    writer.Write(stringToOffset[root.Name]);
                }
                foreach (var root in References)
                {
                    writer.Write(structToOffset[root.Data._s]);
                    writer.Write(stringToOffset[root.Name]);
                }

                writer.Write(stringbuf);

                // finalize
                writer.Seek(0, SeekOrigin.Begin);
                writer.Write((uint)writer.Length);
                writer.Write((uint)relocationOffset - 0x20);
                writer.Write(relocationOffsets.Count);
                writer.Write(Roots.Count);
                writer.Write(References.Count);
                writer.Write(VersionChars);
            }
        }


        /// <summary>
        /// Returns the cached offset for <see cref="HSDStruct"/> for this file.
        /// If struct is not cached then returns -1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetOffsetFromStruct(HSDStruct str)
        {
            if (_structCacheToOffset.ContainsKey(str))
                return _structCacheToOffset[str];

            return -1;
        }


        /// <summary>
        /// Returns a list of all structs that reference the given struct
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<HSDStruct> GetAllStructsThatReference(HSDStruct str)
        {
            var structs = GetAllStructs();

            var found = new List<HSDStruct>();

            foreach(var v in structs)
            {
                if (v.References.ContainsValue(str))
                    found.Add(v);
            }

            return found;
        }


        private readonly static Func<string, HSDAccessor>[] symbol_identificators = new Func<string, HSDAccessor>[]
        {
                x => x.EndsWith("shapeanim_joint") ? new HSDAccessor() : null,
                x => x.EndsWith("matanim_joint") ? new HSD_MatAnimJoint() : null,
                x => x.EndsWith("_joint") ?  new HSD_JOBJ() : null,
                x => x.EndsWith("_animjoint") ?  new HSD_AnimJoint() : null,
                x => x.EndsWith("_texanim") ?  new HSD_TexAnim() : null,
                x => x.EndsWith("_figatree") ?  new HSD_FigaTree() : null,
                x => x.EndsWith("_scene_models") ||
                    x.Equals("Stc_rarwmdls") ||
                    x.Equals("Stc_scemdls") ||
                    x.Equals("lupe") ||
                    x.Equals("tdsce") ?  new HSDNullPointerArrayAccessor<HSD_JOBJDesc>() : null,
                x => x.StartsWith("ftData") && !x.Contains("Copy") ?  new SBM_FighterData() : null,
                x => x.EndsWith("MnSelectChrDataTable") ?  new SBM_SelectChrDataTable() : null,
                x => x.EndsWith("MnSelectStageDataTable") ?  new SBM_MnSelectStageDataTable() : null,
                x => x.EndsWith("coll_data") ?  new SBM_Coll_Data() : null,
                x => x.EndsWith("scene_data") ||
                    x.Equals("pnlsce") ||
                    x.Equals("flmsce") ||
                    x.StartsWith("Sc") ?  new HSD_SOBJ() : null,
                x => x.StartsWith("map_plit") ?  new HSDNullPointerArrayAccessor<HSD_Light>() : null,
                x => x.StartsWith("map_head") ?  new SBM_Map_Head() : null,
                x => x.StartsWith("grGroundParam") ?  new SBM_GroundParam() : null,
                x => x.StartsWith("vcDataStar") ?  new KAR_vcDataStar() : null,
                x => x.StartsWith("vcDataWheel") ?  new KAR_vcDataWheel() : null,
                x => x.StartsWith("grModelMotion") ?  new KAR_grModelMotion() : null,
                x => x.StartsWith("grModel") ?  new KAR_grModel() : null,
                x => x.StartsWith("grData") ?  new KAR_grData() : null,
                x => x.EndsWith("_texg") ?  new HSD_TEXGraphicBank() : null,
                x => x.EndsWith("_ptcl") ?  new HSD_ParticleGroup() : null,
                x => x.StartsWith("effBehaviorTable") ?  new MEX_EffectTypeLookup() : null,
                x => x.StartsWith("eff") ?  new SBM_EffectTable() : null,
                x => x.StartsWith("itPublicData") ?  new itPublicData() : null,
                x => x.StartsWith("itemdata") ?  new HSDNullPointerArrayAccessor<SBM_MapItem>() : null,
                x => x.StartsWith("smSoundTestLoadData") ?  new smSoundTestLoadData() : null,
                x => x.StartsWith("ftLoadCommonData") ?  new SBM_ftLoadCommonData() : null,
                x => x.StartsWith("quake_model_set") ?  new SBM_Quake_Model_Set() : null,
                x => x.StartsWith("mexData") ?  new MEX_Data() : null,
                x => x.StartsWith("mexMapData") ?  new MEX_mexMapData() : null,
                x => x.StartsWith("mexSelectChr") ?  new MEX_mexSelectChr() : null,
                x => x.StartsWith("mobj") ?  new HSD_MOBJ() : null,
                x => x.StartsWith("SIS_") ?  new SBM_SISData() : null,
                x => x.Equals("lbBgFlashColAnimData") ?  new HSDArrayAccessor<ftCommonColorEffect>() : null,
                x => x.Equals("ftcmd") ?  new SBM_FighterCommandTable() : null,
                x => x.Equals("Stc_icns") ?  new MEX_Stock() : null,
                x => x.Equals("mexMenu") ?  new MEX_Menu() : null,
                x => x.Equals("bgm") ?  new MEX_BGMModel() : null,
                x => x.Equals("evMenu") ?  new SBM_TM_EventMenu() : null,
                x => x.Equals("labData") ?  new SBM_TM_LabData() : null,
                x => x.Equals("importData") ?  new SBM_TM_ImportData() : null, 
                x => x.Equals("lclData") ?  new SBM_TM_LCancelData() : null,
                x => x.Equals("ldshData") ?  new SBM_TM_LedgedashData() : null,
                x => x.Equals("wdshData") ?  new SBM_TM_WavedashhData() : null,
                x => x.Equals("MnEvSlData") ?  new SBM_TM_MenuEventSelectData() : null,
                x => x.Equals("mexCostume") ?  new MEX_CostumeSymbol() : null,
                x => x.StartsWith("mnName") ?  new HSDFixedLengthPointerArrayAccessor<HSD_ShiftJIS_String>() : null,
                x => x.EndsWith("move_logic") ?  new HSDArrayAccessor<MEX_MoveLogic>() : null,
                x => new HSDAccessor(),
        };

        private readonly static Func<string, HSDAccessor> @symbol_switch = symbol_identificators.Aggregate((x, y) => z => x(z) ?? y(z));

        /// <summary>
        /// Attempts to guess the structure type based on the root name
        /// </summary>
        /// <param name="rootString"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private HSDAccessor GuessAccessor(string rootString, HSDStruct str)
        {
            HSDAccessor acc = @symbol_switch(rootString);
            acc._s = str;
            return acc;
        }
    }
}
