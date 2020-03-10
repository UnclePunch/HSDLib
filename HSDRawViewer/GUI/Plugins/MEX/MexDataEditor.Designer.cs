﻿namespace HSDRawViewer.GUI.Plugins.MEX
{
    partial class MexDataEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageFighter = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fighterList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveFightersButton = new System.Windows.Forms.ToolStripButton();
            this.exportFighter = new System.Windows.Forms.ToolStripButton();
            this.importFighter = new System.Windows.Forms.ToolStripButton();
            this.cloneButton = new System.Windows.Forms.ToolStripButton();
            this.deleteFighter = new System.Windows.Forms.ToolStripButton();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.itemTabs = new System.Windows.Forms.TabControl();
            this.tabPageItemCommon = new System.Windows.Forms.TabPage();
            this.commonItemEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPageItemFighter = new System.Windows.Forms.TabPage();
            this.fighterItemEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPageItemPokemon = new System.Windows.Forms.TabPage();
            this.pokemonItemEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPageItemStages = new System.Windows.Forms.TabPage();
            this.stageItemEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPageMexItems = new System.Windows.Forms.TabPage();
            this.mexItemEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.saveItemButton = new System.Windows.Forms.ToolStripButton();
            this.mexItemCloneButton = new System.Windows.Forms.ToolStripButton();
            this.itemExportButton = new System.Windows.Forms.ToolStripButton();
            this.tabPageEffects = new System.Windows.Forms.TabPage();
            this.effectEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.saveEffectButton = new System.Windows.Forms.ToolStripButton();
            this.tabPageCSS = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLoadPlSl = new System.Windows.Forms.Button();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.buttonSaveCSS = new System.Windows.Forms.ToolStripButton();
            this.cssIconEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPageMusic = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.musicListEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.menuPlaylistEditor = new HSDRawViewer.GUI.ArrayMemberEditor();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.saveMusicButton = new System.Windows.Forms.ToolStripButton();
            this.createHPSButton = new System.Windows.Forms.ToolStripButton();
            this.musicDSPPlayer = new HSDRawViewer.GUI.Extra.DSPViewer();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.saveAllChangesButton = new System.Windows.Forms.ToolStripButton();
            this.installFighterButton = new System.Windows.Forms.ToolStripButton();
            this.uninstallFighterButton = new System.Windows.Forms.ToolStripButton();
            this.mnslchrToolStrip = new System.Windows.Forms.ToolStrip();
            this.mainTabControl.SuspendLayout();
            this.tabPageFighter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.itemTabs.SuspendLayout();
            this.tabPageItemCommon.SuspendLayout();
            this.tabPageItemFighter.SuspendLayout();
            this.tabPageItemPokemon.SuspendLayout();
            this.tabPageItemStages.SuspendLayout();
            this.tabPageMexItems.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.tabPageEffects.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPageCSS.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tabPageMusic.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPageFighter);
            this.mainTabControl.Controls.Add(this.tabPageItem);
            this.mainTabControl.Controls.Add(this.tabPageEffects);
            this.mainTabControl.Controls.Add(this.tabPageCSS);
            this.mainTabControl.Controls.Add(this.tabPageMusic);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 25);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(799, 308);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPageFighter
            // 
            this.tabPageFighter.Controls.Add(this.tabControl1);
            this.tabPageFighter.Controls.Add(this.groupBox1);
            this.tabPageFighter.Controls.Add(this.toolStrip1);
            this.tabPageFighter.Location = new System.Drawing.Point(4, 22);
            this.tabPageFighter.Name = "tabPageFighter";
            this.tabPageFighter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFighter.Size = new System.Drawing.Size(791, 282);
            this.tabPageFighter.TabIndex = 0;
            this.tabPageFighter.Text = "Fighters";
            this.tabPageFighter.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(203, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 251);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(577, 225);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(571, 219);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.propertyGrid2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(577, 225);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Functions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid2.Size = new System.Drawing.Size(571, 219);
            this.propertyGrid2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fighterList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fighters";
            // 
            // fighterList
            // 
            this.fighterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fighterList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fighterList.FormattingEnabled = true;
            this.fighterList.Location = new System.Drawing.Point(3, 16);
            this.fighterList.Name = "fighterList";
            this.fighterList.Size = new System.Drawing.Size(194, 232);
            this.fighterList.TabIndex = 0;
            this.fighterList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fighterList_DrawItem);
            this.fighterList.SelectedIndexChanged += new System.EventHandler(this.fighterList_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFightersButton,
            this.exportFighter,
            this.importFighter,
            this.cloneButton,
            this.deleteFighter});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveFightersButton
            // 
            this.saveFightersButton.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.saveFightersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFightersButton.Name = "saveFightersButton";
            this.saveFightersButton.Size = new System.Drawing.Size(140, 22);
            this.saveFightersButton.Text = "Save Fighter Changes";
            this.saveFightersButton.Click += new System.EventHandler(this.saveFightersButton_Click);
            // 
            // exportFighter
            // 
            this.exportFighter.Image = global::HSDRawViewer.Properties.Resources.ts_exportfile;
            this.exportFighter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportFighter.Name = "exportFighter";
            this.exportFighter.Size = new System.Drawing.Size(101, 22);
            this.exportFighter.Text = "Export Fighter";
            this.exportFighter.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // importFighter
            // 
            this.importFighter.Image = global::HSDRawViewer.Properties.Resources.ts_importfile;
            this.importFighter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importFighter.Name = "importFighter";
            this.importFighter.Size = new System.Drawing.Size(103, 22);
            this.importFighter.Text = "Import Fighter";
            this.importFighter.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.Image = global::HSDRawViewer.Properties.Resources.ts_clone;
            this.cloneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(98, 22);
            this.cloneButton.Text = "Clone Fighter";
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // deleteFighter
            // 
            this.deleteFighter.Image = global::HSDRawViewer.Properties.Resources.ts_subtract;
            this.deleteFighter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteFighter.Name = "deleteFighter";
            this.deleteFighter.Size = new System.Drawing.Size(100, 22);
            this.deleteFighter.Text = "Delete Fighter";
            this.deleteFighter.Click += new System.EventHandler(this.deleteFighter_Click);
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.itemTabs);
            this.tabPageItem.Controls.Add(this.toolStrip5);
            this.tabPageItem.Location = new System.Drawing.Point(4, 22);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItem.Size = new System.Drawing.Size(791, 282);
            this.tabPageItem.TabIndex = 5;
            this.tabPageItem.Text = "Items";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // itemTabs
            // 
            this.itemTabs.Controls.Add(this.tabPageItemCommon);
            this.itemTabs.Controls.Add(this.tabPageItemFighter);
            this.itemTabs.Controls.Add(this.tabPageItemPokemon);
            this.itemTabs.Controls.Add(this.tabPageItemStages);
            this.itemTabs.Controls.Add(this.tabPageMexItems);
            this.itemTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemTabs.Location = new System.Drawing.Point(3, 28);
            this.itemTabs.Name = "itemTabs";
            this.itemTabs.SelectedIndex = 0;
            this.itemTabs.Size = new System.Drawing.Size(785, 251);
            this.itemTabs.TabIndex = 2;
            // 
            // tabPageItemCommon
            // 
            this.tabPageItemCommon.Controls.Add(this.commonItemEditor);
            this.tabPageItemCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemCommon.Name = "tabPageItemCommon";
            this.tabPageItemCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemCommon.Size = new System.Drawing.Size(777, 225);
            this.tabPageItemCommon.TabIndex = 0;
            this.tabPageItemCommon.Text = "Common";
            this.tabPageItemCommon.UseVisualStyleBackColor = true;
            // 
            // commonItemEditor
            // 
            this.commonItemEditor.CanAdd = false;
            this.commonItemEditor.CanClone = false;
            this.commonItemEditor.CanMove = false;
            this.commonItemEditor.CanRemove = false;
            this.commonItemEditor.DisplayItemIndices = true;
            this.commonItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonItemEditor.EnablePropertyViewDescription = true;
            this.commonItemEditor.EnableToolStrip = false;
            this.commonItemEditor.ItemIndexOffset = 0;
            this.commonItemEditor.Location = new System.Drawing.Point(3, 3);
            this.commonItemEditor.Name = "commonItemEditor";
            this.commonItemEditor.Size = new System.Drawing.Size(771, 219);
            this.commonItemEditor.TabIndex = 1;
            // 
            // tabPageItemFighter
            // 
            this.tabPageItemFighter.Controls.Add(this.fighterItemEditor);
            this.tabPageItemFighter.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemFighter.Name = "tabPageItemFighter";
            this.tabPageItemFighter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemFighter.Size = new System.Drawing.Size(777, 225);
            this.tabPageItemFighter.TabIndex = 1;
            this.tabPageItemFighter.Text = "Fighter";
            this.tabPageItemFighter.UseVisualStyleBackColor = true;
            // 
            // fighterItemEditor
            // 
            this.fighterItemEditor.CanAdd = false;
            this.fighterItemEditor.CanClone = false;
            this.fighterItemEditor.CanMove = false;
            this.fighterItemEditor.CanRemove = false;
            this.fighterItemEditor.DisplayItemIndices = true;
            this.fighterItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fighterItemEditor.EnablePropertyViewDescription = true;
            this.fighterItemEditor.EnableToolStrip = false;
            this.fighterItemEditor.ItemIndexOffset = 0;
            this.fighterItemEditor.Location = new System.Drawing.Point(3, 3);
            this.fighterItemEditor.Name = "fighterItemEditor";
            this.fighterItemEditor.Size = new System.Drawing.Size(771, 219);
            this.fighterItemEditor.TabIndex = 2;
            // 
            // tabPageItemPokemon
            // 
            this.tabPageItemPokemon.Controls.Add(this.pokemonItemEditor);
            this.tabPageItemPokemon.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemPokemon.Name = "tabPageItemPokemon";
            this.tabPageItemPokemon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemPokemon.Size = new System.Drawing.Size(777, 225);
            this.tabPageItemPokemon.TabIndex = 2;
            this.tabPageItemPokemon.Text = "Pokemon";
            this.tabPageItemPokemon.UseVisualStyleBackColor = true;
            // 
            // pokemonItemEditor
            // 
            this.pokemonItemEditor.CanAdd = false;
            this.pokemonItemEditor.CanClone = false;
            this.pokemonItemEditor.CanMove = false;
            this.pokemonItemEditor.CanRemove = false;
            this.pokemonItemEditor.DisplayItemIndices = true;
            this.pokemonItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonItemEditor.EnablePropertyViewDescription = true;
            this.pokemonItemEditor.EnableToolStrip = false;
            this.pokemonItemEditor.ItemIndexOffset = 0;
            this.pokemonItemEditor.Location = new System.Drawing.Point(3, 3);
            this.pokemonItemEditor.Name = "pokemonItemEditor";
            this.pokemonItemEditor.Size = new System.Drawing.Size(771, 219);
            this.pokemonItemEditor.TabIndex = 2;
            // 
            // tabPageItemStages
            // 
            this.tabPageItemStages.Controls.Add(this.stageItemEditor);
            this.tabPageItemStages.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemStages.Name = "tabPageItemStages";
            this.tabPageItemStages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemStages.Size = new System.Drawing.Size(777, 225);
            this.tabPageItemStages.TabIndex = 3;
            this.tabPageItemStages.Text = "Stages";
            this.tabPageItemStages.UseVisualStyleBackColor = true;
            // 
            // stageItemEditor
            // 
            this.stageItemEditor.CanAdd = false;
            this.stageItemEditor.CanClone = false;
            this.stageItemEditor.CanMove = false;
            this.stageItemEditor.CanRemove = false;
            this.stageItemEditor.DisplayItemIndices = true;
            this.stageItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stageItemEditor.EnablePropertyViewDescription = true;
            this.stageItemEditor.EnableToolStrip = false;
            this.stageItemEditor.ItemIndexOffset = 0;
            this.stageItemEditor.Location = new System.Drawing.Point(3, 3);
            this.stageItemEditor.Name = "stageItemEditor";
            this.stageItemEditor.Size = new System.Drawing.Size(771, 219);
            this.stageItemEditor.TabIndex = 2;
            // 
            // tabPageMexItems
            // 
            this.tabPageMexItems.Controls.Add(this.mexItemEditor);
            this.tabPageMexItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageMexItems.Name = "tabPageMexItems";
            this.tabPageMexItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMexItems.Size = new System.Drawing.Size(777, 225);
            this.tabPageMexItems.TabIndex = 4;
            this.tabPageMexItems.Text = "MEX Items";
            this.tabPageMexItems.UseVisualStyleBackColor = true;
            // 
            // mexItemEditor
            // 
            this.mexItemEditor.CanMove = false;
            this.mexItemEditor.DisplayItemIndices = true;
            this.mexItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mexItemEditor.EnablePropertyViewDescription = true;
            this.mexItemEditor.ItemIndexOffset = 0;
            this.mexItemEditor.Location = new System.Drawing.Point(3, 3);
            this.mexItemEditor.Name = "mexItemEditor";
            this.mexItemEditor.Size = new System.Drawing.Size(771, 219);
            this.mexItemEditor.TabIndex = 3;
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveItemButton,
            this.mexItemCloneButton,
            this.itemExportButton});
            this.toolStrip5.Location = new System.Drawing.Point(3, 3);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(785, 25);
            this.toolStrip5.TabIndex = 0;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // saveItemButton
            // 
            this.saveItemButton.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.saveItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveItemButton.Name = "saveItemButton";
            this.saveItemButton.Size = new System.Drawing.Size(127, 22);
            this.saveItemButton.Text = "Save Item Changes";
            this.saveItemButton.Click += new System.EventHandler(this.saveItemButton_Click);
            // 
            // mexItemCloneButton
            // 
            this.mexItemCloneButton.Image = global::HSDRawViewer.Properties.Resources.ts_clone;
            this.mexItemCloneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mexItemCloneButton.Name = "mexItemCloneButton";
            this.mexItemCloneButton.Size = new System.Drawing.Size(146, 22);
            this.mexItemCloneButton.Text = "Clone Selected to MEX";
            this.mexItemCloneButton.Click += new System.EventHandler(this.mexItemCloneButton_Click);
            // 
            // itemExportButton
            // 
            this.itemExportButton.Image = global::HSDRawViewer.Properties.Resources.ts_exportfile;
            this.itemExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemExportButton.Name = "itemExportButton";
            this.itemExportButton.Size = new System.Drawing.Size(95, 22);
            this.itemExportButton.Text = "Export YAML";
            this.itemExportButton.Click += new System.EventHandler(this.itemExportButton_Click);
            // 
            // tabPageEffects
            // 
            this.tabPageEffects.Controls.Add(this.effectEditor);
            this.tabPageEffects.Controls.Add(this.toolStrip3);
            this.tabPageEffects.Location = new System.Drawing.Point(4, 22);
            this.tabPageEffects.Name = "tabPageEffects";
            this.tabPageEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEffects.Size = new System.Drawing.Size(791, 282);
            this.tabPageEffects.TabIndex = 3;
            this.tabPageEffects.Text = "Effects";
            this.tabPageEffects.UseVisualStyleBackColor = true;
            // 
            // effectEditor
            // 
            this.effectEditor.DisplayItemIndices = true;
            this.effectEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectEditor.EnablePropertyViewDescription = true;
            this.effectEditor.ItemIndexOffset = 0;
            this.effectEditor.Location = new System.Drawing.Point(3, 28);
            this.effectEditor.Name = "effectEditor";
            this.effectEditor.Size = new System.Drawing.Size(785, 251);
            this.effectEditor.TabIndex = 1;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveEffectButton});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(785, 25);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // saveEffectButton
            // 
            this.saveEffectButton.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.saveEffectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveEffectButton.Name = "saveEffectButton";
            this.saveEffectButton.Size = new System.Drawing.Size(133, 22);
            this.saveEffectButton.Text = "Save Effect Changes";
            this.saveEffectButton.Click += new System.EventHandler(this.saveEffectButton_Click);
            // 
            // tabPageCSS
            // 
            this.tabPageCSS.Controls.Add(this.groupBox2);
            this.tabPageCSS.Controls.Add(this.toolStrip4);
            this.tabPageCSS.Controls.Add(this.cssIconEditor);
            this.tabPageCSS.Location = new System.Drawing.Point(4, 22);
            this.tabPageCSS.Name = "tabPageCSS";
            this.tabPageCSS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCSS.Size = new System.Drawing.Size(791, 282);
            this.tabPageCSS.TabIndex = 2;
            this.tabPageCSS.Text = "CSS";
            this.tabPageCSS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mnslchrToolStrip);
            this.groupBox2.Controls.Add(this.buttonLoadPlSl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(211, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 251);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // buttonLoadPlSl
            // 
            this.buttonLoadPlSl.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLoadPlSl.Location = new System.Drawing.Point(3, 16);
            this.buttonLoadPlSl.Name = "buttonLoadPlSl";
            this.buttonLoadPlSl.Size = new System.Drawing.Size(571, 23);
            this.buttonLoadPlSl.TabIndex = 0;
            this.buttonLoadPlSl.Text = "Load MnSlChr";
            this.buttonLoadPlSl.UseVisualStyleBackColor = true;
            this.buttonLoadPlSl.Click += new System.EventHandler(this.buttonLoadPlSl_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSaveCSS});
            this.toolStrip4.Location = new System.Drawing.Point(211, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(577, 25);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // buttonSaveCSS
            // 
            this.buttonSaveCSS.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.buttonSaveCSS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSaveCSS.Name = "buttonSaveCSS";
            this.buttonSaveCSS.Size = new System.Drawing.Size(123, 22);
            this.buttonSaveCSS.Text = "Save CSS Changes";
            this.buttonSaveCSS.Click += new System.EventHandler(this.buttonSaveCSS_Click);
            // 
            // cssIconEditor
            // 
            this.cssIconEditor.DisplayItemIndices = false;
            this.cssIconEditor.Dock = System.Windows.Forms.DockStyle.Left;
            this.cssIconEditor.EnablePropertyViewDescription = true;
            this.cssIconEditor.ItemIndexOffset = 0;
            this.cssIconEditor.Location = new System.Drawing.Point(3, 3);
            this.cssIconEditor.Name = "cssIconEditor";
            this.cssIconEditor.Size = new System.Drawing.Size(208, 276);
            this.cssIconEditor.TabIndex = 0;
            // 
            // tabPageMusic
            // 
            this.tabPageMusic.Controls.Add(this.tabControl2);
            this.tabPageMusic.Controls.Add(this.splitter1);
            this.tabPageMusic.Controls.Add(this.toolStrip2);
            this.tabPageMusic.Controls.Add(this.musicDSPPlayer);
            this.tabPageMusic.Location = new System.Drawing.Point(4, 22);
            this.tabPageMusic.Name = "tabPageMusic";
            this.tabPageMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMusic.Size = new System.Drawing.Size(791, 282);
            this.tabPageMusic.TabIndex = 4;
            this.tabPageMusic.Text = "Music";
            this.tabPageMusic.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 28);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(413, 251);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.musicListEditor);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(405, 225);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Music Files";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // musicListEditor
            // 
            this.musicListEditor.DisplayItemIndices = true;
            this.musicListEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.musicListEditor.EnablePropertyViewDescription = true;
            this.musicListEditor.ItemIndexOffset = 0;
            this.musicListEditor.Location = new System.Drawing.Point(3, 3);
            this.musicListEditor.Name = "musicListEditor";
            this.musicListEditor.Size = new System.Drawing.Size(399, 219);
            this.musicListEditor.TabIndex = 4;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.menuPlaylistEditor);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(405, 225);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Menu Playlist";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // menuPlaylistEditor
            // 
            this.menuPlaylistEditor.DisplayItemIndices = true;
            this.menuPlaylistEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPlaylistEditor.EnablePropertyViewDescription = true;
            this.menuPlaylistEditor.ItemIndexOffset = 0;
            this.menuPlaylistEditor.Location = new System.Drawing.Point(3, 3);
            this.menuPlaylistEditor.Name = "menuPlaylistEditor";
            this.menuPlaylistEditor.Size = new System.Drawing.Size(399, 219);
            this.menuPlaylistEditor.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(416, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 251);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMusicButton,
            this.createHPSButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(416, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // saveMusicButton
            // 
            this.saveMusicButton.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.saveMusicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveMusicButton.Name = "saveMusicButton";
            this.saveMusicButton.Size = new System.Drawing.Size(135, 22);
            this.saveMusicButton.Text = "Save Music Changes";
            this.saveMusicButton.Click += new System.EventHandler(this.saveMusicButton_Click);
            // 
            // createHPSButton
            // 
            this.createHPSButton.Image = global::HSDRawViewer.Properties.Resources.ts_importfile;
            this.createHPSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createHPSButton.Name = "createHPSButton";
            this.createHPSButton.Size = new System.Drawing.Size(151, 22);
            this.createHPSButton.Text = "Create HPS From File(s)";
            this.createHPSButton.Click += new System.EventHandler(this.createHPSButton_Click);
            // 
            // musicDSPPlayer
            // 
            this.musicDSPPlayer.Dock = System.Windows.Forms.DockStyle.Right;
            this.musicDSPPlayer.DSP = null;
            this.musicDSPPlayer.Location = new System.Drawing.Point(419, 3);
            this.musicDSPPlayer.Name = "musicDSPPlayer";
            this.musicDSPPlayer.ReplaceButtonVisible = false;
            this.musicDSPPlayer.Size = new System.Drawing.Size(369, 276);
            this.musicDSPPlayer.TabIndex = 5;
            // 
            // toolStrip6
            // 
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllChangesButton,
            this.installFighterButton,
            this.uninstallFighterButton});
            this.toolStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(799, 25);
            this.toolStrip6.TabIndex = 9;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // saveAllChangesButton
            // 
            this.saveAllChangesButton.Image = global::HSDRawViewer.Properties.Resources.ico_save;
            this.saveAllChangesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAllChangesButton.Name = "saveAllChangesButton";
            this.saveAllChangesButton.Size = new System.Drawing.Size(117, 22);
            this.saveAllChangesButton.Text = "Save All Changes";
            this.saveAllChangesButton.Click += new System.EventHandler(this.saveAllChangesButton_Click);
            // 
            // installFighterButton
            // 
            this.installFighterButton.Image = global::HSDRawViewer.Properties.Resources.ts_importfile;
            this.installFighterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.installFighterButton.Name = "installFighterButton";
            this.installFighterButton.Size = new System.Drawing.Size(98, 22);
            this.installFighterButton.Text = "Install Fighter";
            this.installFighterButton.Click += new System.EventHandler(this.installFighterButton_Click);
            // 
            // uninstallFighterButton
            // 
            this.uninstallFighterButton.Image = global::HSDRawViewer.Properties.Resources.ts_subtract;
            this.uninstallFighterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uninstallFighterButton.Name = "uninstallFighterButton";
            this.uninstallFighterButton.Size = new System.Drawing.Size(113, 22);
            this.uninstallFighterButton.Text = "Uninstall Fighter";
            this.uninstallFighterButton.Click += new System.EventHandler(this.uninstallFighterButton_Click);
            // 
            // mnslchrToolStrip
            // 
            this.mnslchrToolStrip.Location = new System.Drawing.Point(3, 39);
            this.mnslchrToolStrip.Name = "mnslchrToolStrip";
            this.mnslchrToolStrip.Size = new System.Drawing.Size(571, 25);
            this.mnslchrToolStrip.TabIndex = 1;
            this.mnslchrToolStrip.Text = "toolStrip7";
            this.mnslchrToolStrip.Visible = false;
            // 
            // MexDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 333);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.toolStrip6);
            this.Name = "MexDataEditor";
            this.TabText = "MexDataEditor";
            this.Text = "MexDataEditor";
            this.mainTabControl.ResumeLayout(false);
            this.tabPageFighter.ResumeLayout(false);
            this.tabPageFighter.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageItem.ResumeLayout(false);
            this.tabPageItem.PerformLayout();
            this.itemTabs.ResumeLayout(false);
            this.tabPageItemCommon.ResumeLayout(false);
            this.tabPageItemFighter.ResumeLayout(false);
            this.tabPageItemPokemon.ResumeLayout(false);
            this.tabPageItemStages.ResumeLayout(false);
            this.tabPageMexItems.ResumeLayout(false);
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tabPageEffects.ResumeLayout(false);
            this.tabPageEffects.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPageCSS.ResumeLayout(false);
            this.tabPageCSS.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabPageMusic.ResumeLayout(false);
            this.tabPageMusic.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPageFighter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox fighterList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabPageEffects;
        private System.Windows.Forms.TabPage tabPageCSS;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveFightersButton;
        private ArrayMemberEditor effectEditor;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton saveEffectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private ArrayMemberEditor cssIconEditor;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.Button buttonLoadPlSl;
        private System.Windows.Forms.ToolStripButton buttonSaveCSS;
        private System.Windows.Forms.ToolStripButton cloneButton;
        private System.Windows.Forms.ToolStripButton exportFighter;
        private System.Windows.Forms.ToolStripButton importFighter;
        private System.Windows.Forms.ToolStripButton deleteFighter;
        private System.Windows.Forms.TabPage tabPageMusic;
        private ArrayMemberEditor musicListEditor;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton saveMusicButton;
        private Extra.DSPViewer musicDSPPlayer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private ArrayMemberEditor menuPlaylistEditor;
        private System.Windows.Forms.ToolStripButton createHPSButton;
        private System.Windows.Forms.TabPage tabPageItem;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton saveItemButton;
        private ArrayMemberEditor commonItemEditor;
        private System.Windows.Forms.TabControl itemTabs;
        private System.Windows.Forms.TabPage tabPageItemCommon;
        private System.Windows.Forms.TabPage tabPageItemFighter;
        private System.Windows.Forms.TabPage tabPageItemPokemon;
        private System.Windows.Forms.TabPage tabPageItemStages;
        private ArrayMemberEditor fighterItemEditor;
        private ArrayMemberEditor pokemonItemEditor;
        private ArrayMemberEditor stageItemEditor;
        private System.Windows.Forms.TabPage tabPageMexItems;
        private ArrayMemberEditor mexItemEditor;
        private System.Windows.Forms.ToolStripButton mexItemCloneButton;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton saveAllChangesButton;
        private System.Windows.Forms.ToolStripButton itemExportButton;
        private System.Windows.Forms.ToolStripButton installFighterButton;
        private System.Windows.Forms.ToolStripButton uninstallFighterButton;
        private System.Windows.Forms.ToolStrip mnslchrToolStrip;
    }
}