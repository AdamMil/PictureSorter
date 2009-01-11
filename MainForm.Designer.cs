namespace PictureSorter
{
  partial class MainForm
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
      if(disposing && (components != null))
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStrip tools;
      System.Windows.Forms.ToolStripButton openImagesTool;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.Label lblPics;
      System.Windows.Forms.Label lblScheme;
      System.Windows.Forms.Label lblNamingScheme;
      System.Windows.Forms.Label lblX;
      System.Windows.Forms.Label lblResizeRename;
      System.Windows.Forms.ColumnHeader colGroupName;
      System.Windows.Forms.ToolStripMenuItem newGroupMenuItem;
      System.Windows.Forms.Label lblSettings;
      System.Windows.Forms.Label lblNewSize;
      System.Windows.Forms.Label lblConvert;
      System.Windows.Forms.Button btnJPEG;
      System.Windows.Forms.Button btnPNG;
      System.Windows.Forms.Label lblGroups;
      System.Windows.Forms.Label lblToolHack;
      System.Windows.Forms.Label lblCacheSize;
      System.Windows.Forms.Label lblFirstIndex;
      System.Windows.Forms.ToolStripSeparator menuSep1;
      System.Windows.Forms.PictureBox sizeDropPic;
      System.Windows.Forms.ToolStripMenuItem size1MenuItem;
      System.Windows.Forms.ToolStripMenuItem size3MenuItem;
      System.Windows.Forms.ToolStripMenuItem size2MenuItem;
      System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Uncategorized", System.Windows.Forms.HorizontalAlignment.Left);
      this.iconTool = new System.Windows.Forms.ToolStripButton();
      this.selectGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.hsplit = new System.Windows.Forms.SplitContainer();
      this.progress = new System.Windows.Forms.ProgressBar();
      this.lstFiles = new System.Windows.Forms.ListView();
      this.colName = new System.Windows.Forms.ColumnHeader();
      this.lblStatus = new System.Windows.Forms.Label();
      this.picture = new System.Windows.Forms.PictureBox();
      this.vsplit = new System.Windows.Forms.SplitContainer();
      this.btnResize = new System.Windows.Forms.Button();
      this.txtCacheSize = new System.Windows.Forms.TextBox();
      this.chkOverwriteThumbnails = new System.Windows.Forms.CheckBox();
      this.chkSaveInBackground = new System.Windows.Forms.CheckBox();
      this.chkSkipSmaller = new System.Windows.Forms.CheckBox();
      this.chkDetectRotated = new System.Windows.Forms.CheckBox();
      this.chkConfirmConvert = new System.Windows.Forms.CheckBox();
      this.txtIndex = new System.Windows.Forms.TextBox();
      this.chkCreateThumbnails = new System.Windows.Forms.CheckBox();
      this.txtNamingScheme = new System.Windows.Forms.TextBox();
      this.txtHeight = new System.Windows.Forms.TextBox();
      this.txtWidth = new System.Windows.Forms.TextBox();
      this.chkLowQuality = new System.Windows.Forms.CheckBox();
      this.chkLowerCase = new System.Windows.Forms.CheckBox();
      this.chkCreateGroupDirs = new System.Windows.Forms.CheckBox();
      this.chkAutoRename = new System.Windows.Forms.CheckBox();
      this.lstGroups = new System.Windows.Forms.ListView();
      this.groupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.deleteGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.renameGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignSelectedImagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sizeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuSep2 = new System.Windows.Forms.ToolStripSeparator();
      this.size4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
      tools = new System.Windows.Forms.ToolStrip();
      openImagesTool = new System.Windows.Forms.ToolStripButton();
      lblPics = new System.Windows.Forms.Label();
      lblScheme = new System.Windows.Forms.Label();
      lblNamingScheme = new System.Windows.Forms.Label();
      lblX = new System.Windows.Forms.Label();
      lblResizeRename = new System.Windows.Forms.Label();
      colGroupName = new System.Windows.Forms.ColumnHeader();
      newGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      lblSettings = new System.Windows.Forms.Label();
      lblNewSize = new System.Windows.Forms.Label();
      lblConvert = new System.Windows.Forms.Label();
      btnJPEG = new System.Windows.Forms.Button();
      btnPNG = new System.Windows.Forms.Button();
      lblGroups = new System.Windows.Forms.Label();
      lblToolHack = new System.Windows.Forms.Label();
      lblCacheSize = new System.Windows.Forms.Label();
      lblFirstIndex = new System.Windows.Forms.Label();
      menuSep1 = new System.Windows.Forms.ToolStripSeparator();
      sizeDropPic = new System.Windows.Forms.PictureBox();
      size1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
      size3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
      size2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
      tools.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(sizeDropPic)).BeginInit();
      this.hsplit.Panel1.SuspendLayout();
      this.hsplit.Panel2.SuspendLayout();
      this.hsplit.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
      this.vsplit.Panel1.SuspendLayout();
      this.vsplit.Panel2.SuspendLayout();
      this.vsplit.SuspendLayout();
      this.groupMenu.SuspendLayout();
      this.sizeMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tools
      // 
      tools.Dock = System.Windows.Forms.DockStyle.None;
      tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            openImagesTool,
            this.iconTool});
      tools.Location = new System.Drawing.Point(55, 0);
      tools.Name = "tools";
      tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      tools.Size = new System.Drawing.Size(133, 25);
      tools.TabIndex = 1;
      // 
      // openImagesTool
      // 
      openImagesTool.Image = ((System.Drawing.Image)(resources.GetObject("openImagesTool.Image")));
      openImagesTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      openImagesTool.Name = "openImagesTool";
      openImagesTool.Size = new System.Drawing.Size(53, 22);
      openImagesTool.Text = "Open";
      openImagesTool.Click += new System.EventHandler(this.openImagesTool_Click);
      // 
      // iconTool
      // 
      this.iconTool.Image = ((System.Drawing.Image)(resources.GetObject("iconTool.Image")));
      this.iconTool.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.iconTool.Name = "iconTool";
      this.iconTool.Size = new System.Drawing.Size(77, 22);
      this.iconTool.Text = "Hide Icons";
      this.iconTool.Click += new System.EventHandler(this.iconTool_Click);
      // 
      // lblPics
      // 
      lblPics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblPics.Location = new System.Drawing.Point(3, 4);
      lblPics.Name = "lblPics";
      lblPics.Size = new System.Drawing.Size(57, 17);
      lblPics.TabIndex = 0;
      lblPics.Text = "Pictures";
      lblPics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblScheme
      // 
      lblScheme.Location = new System.Drawing.Point(4, 480);
      lblScheme.Name = "lblScheme";
      lblScheme.Size = new System.Drawing.Size(150, 29);
      lblScheme.TabIndex = 34;
      lblScheme.Text = "%f = filename, %e = extension,\r\n%n = serial #, %% = %";
      // 
      // lblNamingScheme
      // 
      lblNamingScheme.Location = new System.Drawing.Point(4, 353);
      lblNamingScheme.Name = "lblNamingScheme";
      lblNamingScheme.Size = new System.Drawing.Size(58, 16);
      lblNamingScheme.TabIndex = 26;
      lblNamingScheme.Text = "&Name:";
      // 
      // lblX
      // 
      lblX.Location = new System.Drawing.Point(94, 328);
      lblX.Name = "lblX";
      lblX.Size = new System.Drawing.Size(10, 14);
      lblX.TabIndex = 23;
      lblX.Text = "x";
      lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblResizeRename
      // 
      lblResizeRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblResizeRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblResizeRename.Location = new System.Drawing.Point(3, 305);
      lblResizeRename.Name = "lblResizeRename";
      lblResizeRename.Size = new System.Drawing.Size(188, 17);
      lblResizeRename.TabIndex = 20;
      lblResizeRename.Text = "Resize / Rename Images";
      lblResizeRename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // colGroupName
      // 
      colGroupName.Text = "Name";
      // 
      // newGroupMenuItem
      // 
      newGroupMenuItem.Name = "newGroupMenuItem";
      newGroupMenuItem.Size = new System.Drawing.Size(188, 22);
      newGroupMenuItem.Text = "&New Group";
      newGroupMenuItem.Click += new System.EventHandler(this.newGroupMenuItem_Click);
      // 
      // lblSettings
      // 
      lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblSettings.Location = new System.Drawing.Point(4, 4);
      lblSettings.Name = "lblSettings";
      lblSettings.Size = new System.Drawing.Size(185, 17);
      lblSettings.TabIndex = 0;
      lblSettings.Text = "Settings";
      lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblNewSize
      // 
      lblNewSize.Location = new System.Drawing.Point(4, 329);
      lblNewSize.Name = "lblNewSize";
      lblNewSize.Size = new System.Drawing.Size(58, 16);
      lblNewSize.TabIndex = 21;
      lblNewSize.Text = "New &size:";
      // 
      // lblConvert
      // 
      lblConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblConvert.Location = new System.Drawing.Point(3, 515);
      lblConvert.Name = "lblConvert";
      lblConvert.Size = new System.Drawing.Size(188, 17);
      lblConvert.TabIndex = 40;
      lblConvert.Text = "Change Image Format";
      lblConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnJPEG
      // 
      btnJPEG.Location = new System.Drawing.Point(8, 536);
      btnJPEG.Name = "btnJPEG";
      btnJPEG.Size = new System.Drawing.Size(75, 23);
      btnJPEG.TabIndex = 41;
      btnJPEG.Text = "To &JPEG";
      btnJPEG.UseVisualStyleBackColor = true;
      btnJPEG.Click += new System.EventHandler(this.btnJPEG_Click);
      // 
      // btnPNG
      // 
      btnPNG.Location = new System.Drawing.Point(89, 535);
      btnPNG.Name = "btnPNG";
      btnPNG.Size = new System.Drawing.Size(75, 23);
      btnPNG.TabIndex = 42;
      btnPNG.Text = "To &PNG";
      btnPNG.UseVisualStyleBackColor = true;
      btnPNG.Click += new System.EventHandler(this.btnPNG_Click);
      // 
      // lblGroups
      // 
      lblGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblGroups.Location = new System.Drawing.Point(4, 91);
      lblGroups.Name = "lblGroups";
      lblGroups.Size = new System.Drawing.Size(188, 17);
      lblGroups.TabIndex = 10;
      lblGroups.Text = "Groups";
      lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblToolHack
      // 
      lblToolHack.Location = new System.Drawing.Point(55, 23);
      lblToolHack.Name = "lblToolHack";
      lblToolHack.Size = new System.Drawing.Size(200, 2);
      lblToolHack.TabIndex = 12;
      // 
      // lblCacheSize
      // 
      lblCacheSize.Location = new System.Drawing.Point(5, 65);
      lblCacheSize.Name = "lblCacheSize";
      lblCacheSize.Size = new System.Drawing.Size(86, 16);
      lblCacheSize.TabIndex = 3;
      lblCacheSize.Text = "Cache size (mb):";
      // 
      // lblFirstIndex
      // 
      lblFirstIndex.Location = new System.Drawing.Point(4, 379);
      lblFirstIndex.Name = "lblFirstIndex";
      lblFirstIndex.Size = new System.Drawing.Size(58, 16);
      lblFirstIndex.TabIndex = 28;
      lblFirstIndex.Text = "1st Serial:";
      // 
      // menuSep1
      // 
      menuSep1.Name = "menuSep1";
      menuSep1.Size = new System.Drawing.Size(185, 6);
      // 
      // sizeDropPic
      // 
      sizeDropPic.Image = ((System.Drawing.Image)(resources.GetObject("sizeDropPic.Image")));
      sizeDropPic.Location = new System.Drawing.Point(139, 329);
      sizeDropPic.Name = "sizeDropPic";
      sizeDropPic.Size = new System.Drawing.Size(17, 10);
      sizeDropPic.TabIndex = 44;
      sizeDropPic.TabStop = false;
      sizeDropPic.Click += new System.EventHandler(this.sizeDropPic_Click);
      // 
      // size1MenuItem
      // 
      size1MenuItem.Name = "size1MenuItem";
      size1MenuItem.Size = new System.Drawing.Size(122, 22);
      size1MenuItem.Text = "800x600";
      size1MenuItem.Click += new System.EventHandler(this.sizeMenuItem_Click);
      // 
      // size3MenuItem
      // 
      size3MenuItem.Name = "size3MenuItem";
      size3MenuItem.Size = new System.Drawing.Size(122, 22);
      size3MenuItem.Text = "1024x768";
      size3MenuItem.Click += new System.EventHandler(this.sizeMenuItem_Click);
      // 
      // size2MenuItem
      // 
      size2MenuItem.Name = "size2MenuItem";
      size2MenuItem.Size = new System.Drawing.Size(122, 22);
      size2MenuItem.Text = "1280x960";
      size2MenuItem.Click += new System.EventHandler(this.sizeMenuItem_Click);
      // 
      // selectGroupMenuItem
      // 
      this.selectGroupMenuItem.Name = "selectGroupMenuItem";
      this.selectGroupMenuItem.Size = new System.Drawing.Size(188, 22);
      this.selectGroupMenuItem.Text = "&Select Group";
      this.selectGroupMenuItem.Click += new System.EventHandler(this.selectGroupMenuItem_Click);
      // 
      // hsplit
      // 
      this.hsplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hsplit.Location = new System.Drawing.Point(0, 0);
      this.hsplit.Name = "hsplit";
      this.hsplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // hsplit.Panel1
      // 
      this.hsplit.Panel1.Controls.Add(lblToolHack);
      this.hsplit.Panel1.Controls.Add(this.progress);
      this.hsplit.Panel1.Controls.Add(tools);
      this.hsplit.Panel1.Controls.Add(lblPics);
      this.hsplit.Panel1.Controls.Add(this.lstFiles);
      this.hsplit.Panel1.Controls.Add(this.lblStatus);
      // 
      // hsplit.Panel2
      // 
      this.hsplit.Panel2.Controls.Add(this.picture);
      this.hsplit.Size = new System.Drawing.Size(592, 588);
      this.hsplit.SplitterDistance = 355;
      this.hsplit.TabIndex = 0;
      // 
      // progress
      // 
      this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progress.Location = new System.Drawing.Point(289, 3);
      this.progress.Name = "progress";
      this.progress.Size = new System.Drawing.Size(303, 20);
      this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.progress.TabIndex = 2;
      // 
      // lstFiles
      // 
      this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
      listViewGroup1.Header = "Uncategorized";
      listViewGroup1.Name = "Uncategorized";
      this.lstFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
      this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstFiles.HideSelection = false;
      this.lstFiles.LabelEdit = true;
      this.lstFiles.Location = new System.Drawing.Point(3, 26);
      this.lstFiles.Name = "lstFiles";
      this.lstFiles.ShowItemToolTips = true;
      this.lstFiles.Size = new System.Drawing.Size(589, 329);
      this.lstFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.lstFiles.TabIndex = 0;
      this.lstFiles.UseCompatibleStateImageBehavior = false;
      this.lstFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstFiles_AfterLabelEdit);
      this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
      this.lstFiles.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstFiles_BeforeLabelEdit);
      this.lstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFiles_KeyDown);
      // 
      // colName
      // 
      this.colName.Text = "Name";
      this.colName.Width = 200;
      // 
      // lblStatus
      // 
      this.lblStatus.Location = new System.Drawing.Point(191, 3);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(95, 20);
      this.lblStatus.TabIndex = 11;
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // picture
      // 
      this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picture.Location = new System.Drawing.Point(3, 0);
      this.picture.Name = "picture";
      this.picture.Size = new System.Drawing.Size(589, 226);
      this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.picture.TabIndex = 0;
      this.picture.TabStop = false;
      this.picture.SizeChanged += new System.EventHandler(this.picture_SizeChanged);
      // 
      // vsplit
      // 
      this.vsplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.vsplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.vsplit.Location = new System.Drawing.Point(0, 0);
      this.vsplit.Name = "vsplit";
      // 
      // vsplit.Panel1
      // 
      this.vsplit.Panel1.Controls.Add(this.hsplit);
      // 
      // vsplit.Panel2
      // 
      this.vsplit.Panel2.Controls.Add(sizeDropPic);
      this.vsplit.Panel2.Controls.Add(this.btnResize);
      this.vsplit.Panel2.Controls.Add(this.txtCacheSize);
      this.vsplit.Panel2.Controls.Add(lblCacheSize);
      this.vsplit.Panel2.Controls.Add(this.chkOverwriteThumbnails);
      this.vsplit.Panel2.Controls.Add(lblGroups);
      this.vsplit.Panel2.Controls.Add(this.chkSaveInBackground);
      this.vsplit.Panel2.Controls.Add(this.chkSkipSmaller);
      this.vsplit.Panel2.Controls.Add(this.chkDetectRotated);
      this.vsplit.Panel2.Controls.Add(this.chkConfirmConvert);
      this.vsplit.Panel2.Controls.Add(btnPNG);
      this.vsplit.Panel2.Controls.Add(btnJPEG);
      this.vsplit.Panel2.Controls.Add(lblConvert);
      this.vsplit.Panel2.Controls.Add(this.txtIndex);
      this.vsplit.Panel2.Controls.Add(lblFirstIndex);
      this.vsplit.Panel2.Controls.Add(this.chkCreateThumbnails);
      this.vsplit.Panel2.Controls.Add(lblScheme);
      this.vsplit.Panel2.Controls.Add(this.txtNamingScheme);
      this.vsplit.Panel2.Controls.Add(lblNamingScheme);
      this.vsplit.Panel2.Controls.Add(this.txtHeight);
      this.vsplit.Panel2.Controls.Add(lblX);
      this.vsplit.Panel2.Controls.Add(this.txtWidth);
      this.vsplit.Panel2.Controls.Add(lblResizeRename);
      this.vsplit.Panel2.Controls.Add(this.chkLowQuality);
      this.vsplit.Panel2.Controls.Add(this.chkLowerCase);
      this.vsplit.Panel2.Controls.Add(this.chkCreateGroupDirs);
      this.vsplit.Panel2.Controls.Add(this.chkAutoRename);
      this.vsplit.Panel2.Controls.Add(this.lstGroups);
      this.vsplit.Panel2.Controls.Add(lblSettings);
      this.vsplit.Panel2.Controls.Add(lblNewSize);
      this.vsplit.Panel2.Layout += new System.Windows.Forms.LayoutEventHandler(this.vsplit_Panel2_Layout);
      this.vsplit.Size = new System.Drawing.Size(792, 588);
      this.vsplit.SplitterDistance = 592;
      this.vsplit.TabIndex = 0;
      // 
      // btnResize
      // 
      this.btnResize.Location = new System.Drawing.Point(97, 376);
      this.btnResize.Name = "btnResize";
      this.btnResize.Size = new System.Drawing.Size(45, 23);
      this.btnResize.TabIndex = 25;
      this.btnResize.Text = "&Go";
      this.btnResize.UseVisualStyleBackColor = true;
      this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
      // 
      // txtCacheSize
      // 
      this.txtCacheSize.Location = new System.Drawing.Point(91, 62);
      this.txtCacheSize.Name = "txtCacheSize";
      this.txtCacheSize.Size = new System.Drawing.Size(46, 20);
      this.txtCacheSize.TabIndex = 4;
      this.txtCacheSize.Text = "100";
      this.txtCacheSize.Leave += new System.EventHandler(this.txtCacheSize_Leave);
      // 
      // chkOverwriteThumbnails
      // 
      this.chkOverwriteThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkOverwriteThumbnails.Checked = true;
      this.chkOverwriteThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOverwriteThumbnails.Enabled = false;
      this.chkOverwriteThumbnails.Location = new System.Drawing.Point(7, 459);
      this.chkOverwriteThumbnails.Name = "chkOverwriteThumbnails";
      this.chkOverwriteThumbnails.Size = new System.Drawing.Size(184, 18);
      this.chkOverwriteThumbnails.TabIndex = 33;
      this.chkOverwriteThumbnails.Text = "&Overwrite existing thumbnails";
      this.chkOverwriteThumbnails.UseVisualStyleBackColor = true;
      // 
      // chkSaveInBackground
      // 
      this.chkSaveInBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkSaveInBackground.Checked = true;
      this.chkSaveInBackground.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSaveInBackground.Location = new System.Drawing.Point(7, 42);
      this.chkSaveInBackground.Name = "chkSaveInBackground";
      this.chkSaveInBackground.Size = new System.Drawing.Size(184, 18);
      this.chkSaveInBackground.TabIndex = 2;
      this.chkSaveInBackground.Text = "Save changes in the &background";
      this.chkSaveInBackground.UseVisualStyleBackColor = true;
      // 
      // chkSkipSmaller
      // 
      this.chkSkipSmaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkSkipSmaller.Checked = true;
      this.chkSkipSmaller.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSkipSmaller.Location = new System.Drawing.Point(7, 419);
      this.chkSkipSmaller.Name = "chkSkipSmaller";
      this.chkSkipSmaller.Size = new System.Drawing.Size(184, 18);
      this.chkSkipSmaller.TabIndex = 31;
      this.chkSkipSmaller.Text = "Skip s&maller images";
      this.chkSkipSmaller.UseVisualStyleBackColor = true;
      // 
      // chkDetectRotated
      // 
      this.chkDetectRotated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkDetectRotated.Checked = true;
      this.chkDetectRotated.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkDetectRotated.Location = new System.Drawing.Point(7, 399);
      this.chkDetectRotated.Name = "chkDetectRotated";
      this.chkDetectRotated.Size = new System.Drawing.Size(184, 18);
      this.chkDetectRotated.TabIndex = 30;
      this.chkDetectRotated.Text = "&Detect rotated images";
      this.chkDetectRotated.UseVisualStyleBackColor = true;
      // 
      // chkConfirmConvert
      // 
      this.chkConfirmConvert.Checked = true;
      this.chkConfirmConvert.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkConfirmConvert.Location = new System.Drawing.Point(8, 564);
      this.chkConfirmConvert.Name = "chkConfirmConvert";
      this.chkConfirmConvert.Size = new System.Drawing.Size(181, 18);
      this.chkConfirmConvert.TabIndex = 43;
      this.chkConfirmConvert.Text = "&Confirm con&version";
      this.chkConfirmConvert.UseVisualStyleBackColor = true;
      // 
      // txtIndex
      // 
      this.txtIndex.Location = new System.Drawing.Point(59, 377);
      this.txtIndex.Name = "txtIndex";
      this.txtIndex.Size = new System.Drawing.Size(32, 20);
      this.txtIndex.TabIndex = 29;
      this.txtIndex.Text = "0";
      // 
      // chkCreateThumbnails
      // 
      this.chkCreateThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateThumbnails.Location = new System.Drawing.Point(7, 439);
      this.chkCreateThumbnails.Name = "chkCreateThumbnails";
      this.chkCreateThumbnails.Size = new System.Drawing.Size(184, 18);
      this.chkCreateThumbnails.TabIndex = 32;
      this.chkCreateThumbnails.Text = "Create &thumbnails";
      this.chkCreateThumbnails.UseVisualStyleBackColor = true;
      this.chkCreateThumbnails.CheckedChanged += new System.EventHandler(this.chkCreateThumbnails_CheckedChanged);
      // 
      // txtNamingScheme
      // 
      this.txtNamingScheme.Location = new System.Drawing.Point(59, 351);
      this.txtNamingScheme.Name = "txtNamingScheme";
      this.txtNamingScheme.Size = new System.Drawing.Size(129, 20);
      this.txtNamingScheme.TabIndex = 27;
      this.txtNamingScheme.Text = "%f%e";
      // 
      // txtHeight
      // 
      this.txtHeight.Location = new System.Drawing.Point(106, 325);
      this.txtHeight.Name = "txtHeight";
      this.txtHeight.Size = new System.Drawing.Size(31, 20);
      this.txtHeight.TabIndex = 24;
      this.txtHeight.Text = "768";
      this.txtHeight.TextChanged += new System.EventHandler(this.txtDimensions_TextChanged);
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(59, 325);
      this.txtWidth.Name = "txtWidth";
      this.txtWidth.Size = new System.Drawing.Size(31, 20);
      this.txtWidth.TabIndex = 22;
      this.txtWidth.Text = "1024";
      this.txtWidth.TextChanged += new System.EventHandler(this.txtDimensions_TextChanged);
      // 
      // chkLowQuality
      // 
      this.chkLowQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkLowQuality.Location = new System.Drawing.Point(7, 22);
      this.chkLowQuality.Name = "chkLowQuality";
      this.chkLowQuality.Size = new System.Drawing.Size(184, 18);
      this.chkLowQuality.TabIndex = 1;
      this.chkLowQuality.Text = "Use low &quality icons (faster)";
      this.chkLowQuality.UseVisualStyleBackColor = true;
      // 
      // chkLowerCase
      // 
      this.chkLowerCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkLowerCase.Checked = true;
      this.chkLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkLowerCase.Location = new System.Drawing.Point(7, 279);
      this.chkLowerCase.Name = "chkLowerCase";
      this.chkLowerCase.Size = new System.Drawing.Size(184, 18);
      this.chkLowerCase.TabIndex = 14;
      this.chkLowerCase.Text = "Use &lowercase group file names";
      this.chkLowerCase.UseVisualStyleBackColor = true;
      // 
      // chkCreateGroupDirs
      // 
      this.chkCreateGroupDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateGroupDirs.Location = new System.Drawing.Point(7, 259);
      this.chkCreateGroupDirs.Name = "chkCreateGroupDirs";
      this.chkCreateGroupDirs.Size = new System.Drawing.Size(184, 18);
      this.chkCreateGroupDirs.TabIndex = 13;
      this.chkCreateGroupDirs.Text = "&Create subdirectories for groups";
      this.chkCreateGroupDirs.UseVisualStyleBackColor = true;
      // 
      // chkAutoRename
      // 
      this.chkAutoRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkAutoRename.Location = new System.Drawing.Point(7, 239);
      this.chkAutoRename.Name = "chkAutoRename";
      this.chkAutoRename.Size = new System.Drawing.Size(184, 18);
      this.chkAutoRename.TabIndex = 12;
      this.chkAutoRename.Text = "&Rename images when grouped";
      this.chkAutoRename.UseVisualStyleBackColor = true;
      // 
      // lstGroups
      // 
      this.lstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colGroupName});
      this.lstGroups.ContextMenuStrip = this.groupMenu;
      this.lstGroups.FullRowSelect = true;
      this.lstGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstGroups.LabelEdit = true;
      this.lstGroups.Location = new System.Drawing.Point(2, 110);
      this.lstGroups.MultiSelect = false;
      this.lstGroups.Name = "lstGroups";
      this.lstGroups.ShowGroups = false;
      this.lstGroups.ShowItemToolTips = true;
      this.lstGroups.Size = new System.Drawing.Size(190, 126);
      this.lstGroups.TabIndex = 11;
      this.lstGroups.UseCompatibleStateImageBehavior = false;
      this.lstGroups.View = System.Windows.Forms.View.Details;
      this.lstGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGroups_MouseDoubleClick);
      this.lstGroups.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstGroups_AfterLabelEdit);
      this.lstGroups.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstGroups_BeforeLabelEdit);
      this.lstGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstGroups_KeyDown);
      // 
      // groupMenu
      // 
      this.groupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newGroupMenuItem,
            this.deleteGroupMenuItem,
            this.renameGroupMenuItem,
            this.selectGroupMenuItem,
            menuSep1,
            this.assignSelectedImagesMenuItem});
      this.groupMenu.Name = "groupMenu";
      this.groupMenu.Size = new System.Drawing.Size(189, 120);
      this.groupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.groupMenu_Opening);
      // 
      // deleteGroupMenuItem
      // 
      this.deleteGroupMenuItem.Name = "deleteGroupMenuItem";
      this.deleteGroupMenuItem.Size = new System.Drawing.Size(188, 22);
      this.deleteGroupMenuItem.Text = "&Delete Group";
      this.deleteGroupMenuItem.Click += new System.EventHandler(this.deleteGroupMenuItem_Click);
      // 
      // renameGroupMenuItem
      // 
      this.renameGroupMenuItem.Name = "renameGroupMenuItem";
      this.renameGroupMenuItem.Size = new System.Drawing.Size(188, 22);
      this.renameGroupMenuItem.Text = "&Rename Group";
      this.renameGroupMenuItem.Click += new System.EventHandler(this.renameGroupMenuItem_Click);
      // 
      // assignSelectedImagesMenuItem
      // 
      this.assignSelectedImagesMenuItem.Name = "assignSelectedImagesMenuItem";
      this.assignSelectedImagesMenuItem.Size = new System.Drawing.Size(188, 22);
      this.assignSelectedImagesMenuItem.Text = "&Assign Images to Group";
      this.assignSelectedImagesMenuItem.Click += new System.EventHandler(this.assignSelectedImagesMenuItem_Click);
      // 
      // sizeMenu
      // 
      this.sizeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            size1MenuItem,
            size3MenuItem,
            size2MenuItem,
            this.menuSep2,
            this.size4MenuItem});
      this.sizeMenu.Name = "sizeMenu";
      this.sizeMenu.Size = new System.Drawing.Size(123, 98);
      // 
      // menuSep2
      // 
      this.menuSep2.Name = "menuSep2";
      this.menuSep2.Size = new System.Drawing.Size(119, 6);
      this.menuSep2.Click += new System.EventHandler(this.sizeMenuItem_Click);
      // 
      // size4MenuItem
      // 
      this.size4MenuItem.Name = "size4MenuItem";
      this.size4MenuItem.Size = new System.Drawing.Size(122, 22);
      this.size4MenuItem.Text = "0x160";
      this.size4MenuItem.Click += new System.EventHandler(this.sizeMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 588);
      this.Controls.Add(this.vsplit);
      this.Enabled = false;
      this.HelpButton = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(600, 590);
      this.Name = "MainForm";
      this.Text = "Picture Sorter";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
      tools.ResumeLayout(false);
      tools.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(sizeDropPic)).EndInit();
      this.hsplit.Panel1.ResumeLayout(false);
      this.hsplit.Panel1.PerformLayout();
      this.hsplit.Panel2.ResumeLayout(false);
      this.hsplit.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
      this.vsplit.Panel1.ResumeLayout(false);
      this.vsplit.Panel2.ResumeLayout(false);
      this.vsplit.Panel2.PerformLayout();
      this.vsplit.ResumeLayout(false);
      this.groupMenu.ResumeLayout(false);
      this.sizeMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView lstFiles;
    private System.Windows.Forms.PictureBox picture;
    private System.Windows.Forms.ListView lstGroups;
    private System.Windows.Forms.CheckBox chkAutoRename;
    private System.Windows.Forms.ContextMenuStrip groupMenu;
    private System.Windows.Forms.ToolStripMenuItem deleteGroupMenuItem;
    private System.Windows.Forms.ToolStripMenuItem renameGroupMenuItem;
    private System.Windows.Forms.ColumnHeader colName;
    private System.Windows.Forms.CheckBox chkCreateGroupDirs;
    private System.Windows.Forms.CheckBox chkLowerCase;
    private System.Windows.Forms.CheckBox chkLowQuality;
    private System.Windows.Forms.Button btnResize;
    private System.Windows.Forms.TextBox txtHeight;
    private System.Windows.Forms.TextBox txtWidth;
    private System.Windows.Forms.ProgressBar progress;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.TextBox txtNamingScheme;
    private System.Windows.Forms.CheckBox chkCreateThumbnails;
    private System.Windows.Forms.SplitContainer vsplit;
    private System.Windows.Forms.SplitContainer hsplit;
    private System.Windows.Forms.CheckBox chkConfirmConvert;
    private System.Windows.Forms.CheckBox chkDetectRotated;
    private System.Windows.Forms.CheckBox chkSkipSmaller;
    private System.Windows.Forms.CheckBox chkSaveInBackground;
    private System.Windows.Forms.CheckBox chkOverwriteThumbnails;
    private System.Windows.Forms.ToolStripButton iconTool;
    private System.Windows.Forms.TextBox txtCacheSize;
    private System.Windows.Forms.TextBox txtIndex;
    private System.Windows.Forms.ToolStripMenuItem selectGroupMenuItem;
    private System.Windows.Forms.ToolStripMenuItem assignSelectedImagesMenuItem;
    private System.Windows.Forms.ContextMenuStrip sizeMenu;
    private System.Windows.Forms.ToolStripSeparator menuSep2;
    private System.Windows.Forms.ToolStripMenuItem size4MenuItem;


  }
}