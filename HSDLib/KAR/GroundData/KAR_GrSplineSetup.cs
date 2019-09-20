﻿using HSDLib.Common;
using System;
using System.Collections.Generic;

namespace HSDLib.KAR
{
    public class KAR_GrSplineList : IHSDNode
    {
        public List<HSD_Spline> Paths = new List<HSD_Spline>();

        public override void Open(HSDReader Reader)
        {
            var offset = Reader.ReadUInt32();
            var count = Reader.ReadInt32();

            uint[] offsets = new uint[count];
            Reader.Seek(offset);
            for (int i = 0; i < count; i++)
            {
                offsets[i] = Reader.ReadUInt32();
            }

            for (int i = 0; i < count; i++)
            {
                if (offsets[i] == 0)
                    continue;
                Reader.Seek(offsets[i]);
                var path = new HSD_Spline();
                path.Open(Reader);
                Paths.Add(path);
            }
        }

        public override void Save(HSDWriter Writer)
        {
            foreach (var p in Paths)
            {
                p.Save(Writer);
            }

            Writer.AddObject(Paths);
            foreach (var p in Paths)
            {
                Writer.WritePointer(p);
            }

            if (Paths.Count == 0)
                Writer.Write(0);

            Writer.AddObject(this);
            Writer.WritePointer(Paths);
            Writer.Write(Paths.Count == 0 ? 1 : Paths.Count);
        }
    }


    public class KAR_GrCourseSplineTable : IHSDNode
    {
        public List<int> Indices = new List<int>();

        public override void Open(HSDReader Reader)
        {
            var offset = Reader.ReadUInt32();
            var count = Reader.ReadInt32();

            if (offset == 0)
                return;

            Reader.Seek(offset);
            for (int i = 0; i < count; i++)
            {
                Indices.Add(Reader.ReadInt32());
            }
        }

        public void WriteData(HSDWriter Writer)
        {
            Writer.AddObject(Indices);
            foreach (var p in Indices)
            {
                Writer.Write(p);
            }
        }

        public void WriteObject(HSDWriter Writer)
        {
            Writer.AddObject(this);
            Writer.WritePointer(Indices);
            Writer.Write(Indices.Count);
        }

        public override void Save(HSDWriter Writer)
        {
            WriteData(Writer);
            WriteObject(Writer);
        }
    }

    public class KAR_GrSplineSetup : IHSDNode
    {
        public List<KAR_GrSpline> Splines { get; set; } = new List<KAR_GrSpline>();

        public override void Open(HSDReader Reader)
        {
            var offset = Reader.ReadUInt32();
            var count = Reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Reader.Seek(offset + (uint)(i * 0x18));
                var spline = new KAR_GrSpline();
                spline.Open(Reader);
                Splines.Add(spline);
            }
        }

        public override void Save(HSDWriter Writer)
        {
            foreach (var p in Splines)
            {
                p.WriteData(Writer);
            }

            Writer.AddObject(Splines);
            foreach (var p in Splines)
            {
                p.Save(Writer);
            }

            Writer.AddObject(this);
            Writer.WritePointer(Splines);
            Writer.Write(Splines.Count == 0 ? 1 : Splines.Count);
            Writer.Write(0);
        }
    }


    public class KAR_GrSpline : IHSDNode
    {
        public HSD_Spline Unknown1 { get; set; }
        public HSD_Spline Unknown2 { get; set; }
        public int Unknown3 { get; set; } = -1;
        public int Unknown4 { get; set; } = -1;
        public int Unknown5 { get; set; } = -1;
        public int Unknown6 { get; set; } = 0;

        public void WriteData(HSDWriter Writer)
        {
            Unknown1.WriteData(Writer);
            Unknown2.WriteData(Writer);
            Unknown1.WriteObject(Writer);
            Unknown2.WriteObject(Writer);
        }
    }

    public class KAR_GrFlowSetup : IHSDNode
    {
        public KAR_GrSplineList Spline { get; set; }
        public int Unknown { get; set; }
    }

    public class KAR_GrCourseSplineSetup : IHSDNode
    {
        public KAR_GrSplineList CourseSplineList { get; set; }
        public KAR_GrCourseSplineTable UnknownTable { get; set; }
        public KAR_GrCourseSpineTableList UnknownTableList1 { get; set; }
        public KAR_GrCourseSpineTableList UnknownTableList2 { get; set; }
        public int Loop { get; set; } = 1;
        public int UnknownPointer { get; set; }
        public int Unknown3 { get; set; }
        public KAR_GrCourseUnknownFloats UnknownFloats { get; set; }
        public int UnknownRuntime1 { get; set; } // runtime variable
        public int UnknownRuntime2 { get; set; } // runtime variable
        public int Unknown7 { get; set; }
        public int UnknownRuntime3 { get; set; } // runtime variable
        public int UnknownRuntime4 { get; set; } // runtime variable
        public int UnknownRuntime5 { get; set; } // runtime variable
    }

    public class KAR_GrCourseSpineTableList : IHSDNode
    {
        public List<KAR_GrCourseSplineTable> Tables = new List<KAR_GrCourseSplineTable>();

        public override void Open(HSDReader Reader)
        {
            var start = Reader.Position();
            for(int i = 0; i < 4; i++)
            {
                Reader.Seek(start + (uint)(8 * i));
                KAR_GrCourseSplineTable table = new KAR_GrCourseSplineTable();
                if (table.Indices.Count == 0)
                    break;
                table.Open(Reader);
                Tables.Add(table);
            }
        }

        public override void Save(HSDWriter Writer)
        {
            foreach (var table in Tables)
                table.WriteData(Writer);

            Writer.AddObject(this);
            foreach (var table in Tables)
                table.WriteObject(Writer);
        }
    }

    public class KAR_GrCourseUnknownFloats : IHSDNode
    {
        public float V1 { get; set; }
        public float V2 { get; set; }
        public float V3 { get; set; }
        public float V4 { get; set; }
    }
}