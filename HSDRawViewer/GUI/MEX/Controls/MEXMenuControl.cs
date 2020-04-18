﻿using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HSDRaw.MEX;
using HSDRawViewer.Rendering;
using HSDRaw.MEX.Menus;

namespace HSDRawViewer.GUI.MEX.Controls
{
    public partial class MEXMenuControl : UserControl, IMEXControl, IDrawableInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public MEX_Data MexData
        {
            get
            {
                var c = Parent;
                while (c != null && !(c is MexDataEditor)) c = c.Parent;
                if (c is MexDataEditor e) return e._data;
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MexDataEditor MexDataEditor
        {
            get
            {
                var c = Parent;
                while (c != null && !(c is MexDataEditor)) c = c.Parent;
                if (c is MexDataEditor e) return e;
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public DrawOrder DrawOrder => DrawOrder.Last;

        /// <summary>
        /// 
        /// </summary>
        private ViewportControl viewport;

        private bool CSSSelected => tabControl.SelectedIndex == 0;

        private MEXMenuCSSControl CSS = new MEXMenuCSSControl();
        private MEXMenuSSSControl SSS = new MEXMenuSSSControl();
        
        public MEXMenuControl()
        {
            InitializeComponent();
            
            viewport = new ViewportControl();
            viewport.Dock = DockStyle.Fill;
            viewport.AnimationTrackEnabled = false;
            viewport.AddRenderer(this);
            viewport.EnableFloor = false;
            viewport.MaxFrame = 1600;
            groupBox2.Controls.Add(viewport);
            viewport.RefreshSize();
            viewport.BringToFront();

            CSS.Enabled = false;
            SSS.Enabled = false;
            CSS.Dock = DockStyle.Fill;
            SSS.Dock = DockStyle.Fill;
            tabControl.TabPages[0].Controls.Add(CSS);
            tabControl.TabPages[1].Controls.Add(SSS);

            HandleDestroyed += (sender, args) =>
            {
                viewport.Dispose();
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetControlName()
        {
            return "Menus";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void LoadData(MEX_Data data)
        {
            CSS.Icons = new MEX_CSSIconEntry[data.MenuTable.CSSIconData.Icons.Length];
            for (int i = 0; i < CSS.Icons.Length; i++)
                CSS.Icons[i] = MEX_CSSIconEntry.FromIcon(data.MenuTable.CSSIconData.Icons[i]);
            CSS.cssIconEditor.SetArrayFromProperty(CSS, "Icons");

            SSS.StageIcons = data.MenuTable.SSSIconData.Array.Select(e => new MEXStageIconEntry() { IconData = e }).ToArray();
            SSS.sssEditor.SetArrayFromProperty(SSS, "StageIcons");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SaveData(MEX_Data data)
        {
            data.MetaData.NumOfCSSIcons = CSS.Icons.Length;
            MEX_CSSIcon[] ico = new MEX_CSSIcon[CSS.Icons.Length];
            for (int i = 0; i < ico.Length; i++)
                ico[i] = CSS.Icons[i].ToIcon();
            data.MenuTable.CSSIconData.Icons = ico;

            data.MetaData.NumOfSSSIcons = SSS.StageIcons.Length;
            data.MenuTable.SSSIconData.Array = SSS.StageIcons.Select(e => e.IconData).ToArray();

            SaveMenuFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetDataBindings()
        {

        }

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveCSS_Click(object sender, EventArgs e)
        {
            SaveData(MexData);
        }

        #endregion

        #region Rendering

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="windowWidth"></param>
        /// <param name="windowHeight"></param>
        public void Draw(Camera cam, int windowWidth, int windowHeight)
        {
            if (!viewport.Visible)
                return;

            // camera view
            DrawShape.DrawRectangle(32.51167f, -24.38375f, -32.51167f, 24.38375f, Color.Transparent);
            
            if (CSSSelected)
                CSS.Render(cam);
            else
                SSS.Render(cam, viewport.Frame);

        }

        #endregion

        #region Viewport Controls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button"></param>
        /// <param name="pick"></param>
        public void ScreenClick(MouseButtons button, PickInformation pick)
        {
            if (CSSSelected)
                CSS.ScreenClick(button, pick);
            else
                SSS.ScreenClick(button, pick);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pick"></param>
        public void ScreenDoubleClick(PickInformation pick)
        {
            if (CSSSelected)
                CSS.ScreenDoubleClick(pick);
            else
                SSS.ScreenDoubleClick(pick);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public void ScreenDrag(PickInformation pick, float deltaX, float deltaY)
        {
            if (CSSSelected)
                CSS.ScreenDrag(viewport, pick, deltaX, deltaY);
            else
                SSS.ScreenDrag(viewport, pick, deltaX, deltaY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void ScreenSelectArea(PickInformation start, PickInformation end)
        {

        }


        #endregion


        /// <summary>
        /// 
        /// </summary>
        private void SaveMenuFiles()
        {
            CSS.SaveFile();
            SSS.SaveFile();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void CloseMenuFiles()
        {
            CSS.CloseFile();
            SSS.CloseFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImportMnSlMap_Click(object sender, EventArgs e)
        {
            SSS.LoadFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImportMnSlcChr_Click(object sender, EventArgs e)
        {
            CSS.LoadFile();
        }
    }
}
