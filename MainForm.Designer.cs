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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.ToolStripButton openImagesTool;
      System.Windows.Forms.Label lblPics;
      System.Windows.Forms.Label lblFirstIndex;
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
      System.Windows.Forms.ToolStripMenuItem selectGroupMenuItem;
      System.Windows.Forms.Label lblToolHack;
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Uncategorized", System.Windows.Forms.HorizontalAlignment.Left);
      this.listView = new System.Windows.Forms.ToolStripButton();
      this.iconView = new System.Windows.Forms.ToolStripButton();
      this.hsplit = new System.Windows.Forms.SplitContainer();
      this.lblStatus = new System.Windows.Forms.Label();
      this.progress = new System.Windows.Forms.ProgressBar();
      this.lstFiles = new System.Windows.Forms.ListView();
      this.colName = new System.Windows.Forms.ColumnHeader();
      this.picture = new System.Windows.Forms.PictureBox();
      this.vsplit = new System.Windows.Forms.SplitContainer();
      this.chkOverwriteThumbnails = new System.Windows.Forms.CheckBox();
      this.chkSaveInBackground = new System.Windows.Forms.CheckBox();
      this.chkSkipSmaller = new System.Windows.Forms.CheckBox();
      this.chkDetectRotated = new System.Windows.Forms.CheckBox();
      this.chkConfirmConvert = new System.Windows.Forms.CheckBox();
      this.txtIndex = new System.Windows.Forms.TextBox();
      this.chkCreateThumbnails = new System.Windows.Forms.CheckBox();
      this.txtNamingScheme = new System.Windows.Forms.TextBox();
      this.btnResize = new System.Windows.Forms.Button();
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
      tools = new System.Windows.Forms.ToolStrip();
      openImagesTool = new System.Windows.Forms.ToolStripButton();
      lblPics = new System.Windows.Forms.Label();
      lblFirstIndex = new System.Windows.Forms.Label();
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
      selectGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      lblToolHack = new System.Windows.Forms.Label();
      tools.SuspendLayout();
      this.hsplit.Panel1.SuspendLayout();
      this.hsplit.Panel2.SuspendLayout();
      this.hsplit.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
      this.vsplit.Panel1.SuspendLayout();
      this.vsplit.Panel2.SuspendLayout();
      this.vsplit.SuspendLayout();
      this.groupMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tools
      // 
      tools.Dock = System.Windows.Forms.DockStyle.None;
      tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listView,
            this.iconView,
            openImagesTool});
      tools.Location = new System.Drawing.Point(55, 0);
      tools.Name = "tools";
      tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      tools.Size = new System.Drawing.Size(197, 25);
      tools.TabIndex = 1;
      // 
      // listView
      // 
      this.listView.Image = ((System.Drawing.Image)(resources.GetObject("listView.Image")));
      this.listView.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(68, 22);
      this.listView.Text = "List View";
      this.listView.Click += new System.EventHandler(this.listView_Click);
      // 
      // iconView
      // 
      this.iconView.Checked = true;
      this.iconView.CheckState = System.Windows.Forms.CheckState.Checked;
      this.iconView.Image = ((System.Drawing.Image)(resources.GetObject("iconView.Image")));
      this.iconView.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.iconView.Name = "iconView";
      this.iconView.Size = new System.Drawing.Size(73, 22);
      this.iconView.Text = "Icon View";
      this.iconView.Click += new System.EventHandler(this.iconView_Click);
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
      // lblFirstIndex
      // 
      lblFirstIndex.Location = new System.Drawing.Point(4, 357);
      lblFirstIndex.Name = "lblFirstIndex";
      lblFirstIndex.Size = new System.Drawing.Size(58, 16);
      lblFirstIndex.TabIndex = 14;
      lblFirstIndex.Text = "1st &Index:";
      // 
      // lblScheme
      // 
      lblScheme.Location = new System.Drawing.Point(4, 457);
      lblScheme.Name = "lblScheme";
      lblScheme.Size = new System.Drawing.Size(185, 29);
      lblScheme.TabIndex = 20;
      lblScheme.Text = "%f = filename, %e = extension,\r\n%d = directory, %n = index #, %% = %";
      // 
      // lblNamingScheme
      // 
      lblNamingScheme.Location = new System.Drawing.Point(4, 331);
      lblNamingScheme.Name = "lblNamingScheme";
      lblNamingScheme.Size = new System.Drawing.Size(58, 16);
      lblNamingScheme.TabIndex = 12;
      lblNamingScheme.Text = "&Name:";
      // 
      // lblX
      // 
      lblX.Location = new System.Drawing.Point(94, 306);
      lblX.Name = "lblX";
      lblX.Size = new System.Drawing.Size(10, 14);
      lblX.TabIndex = 9;
      lblX.Text = "x";
      lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblResizeRename
      // 
      lblResizeRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblResizeRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblResizeRename.Location = new System.Drawing.Point(3, 283);
      lblResizeRename.Name = "lblResizeRename";
      lblResizeRename.Size = new System.Drawing.Size(188, 17);
      lblResizeRename.TabIndex = 6;
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
      newGroupMenuItem.Size = new System.Drawing.Size(145, 22);
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
      lblNewSize.Location = new System.Drawing.Point(4, 307);
      lblNewSize.Name = "lblNewSize";
      lblNewSize.Size = new System.Drawing.Size(58, 16);
      lblNewSize.TabIndex = 7;
      lblNewSize.Text = "New &size:";
      // 
      // lblConvert
      // 
      lblConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblConvert.Location = new System.Drawing.Point(3, 492);
      lblConvert.Name = "lblConvert";
      lblConvert.Size = new System.Drawing.Size(188, 17);
      lblConvert.TabIndex = 21;
      lblConvert.Text = "Change Image Format";
      lblConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnJPEG
      // 
      btnJPEG.Location = new System.Drawing.Point(8, 513);
      btnJPEG.Name = "btnJPEG";
      btnJPEG.Size = new System.Drawing.Size(75, 23);
      btnJPEG.TabIndex = 22;
      btnJPEG.Text = "To &JPEG";
      btnJPEG.UseVisualStyleBackColor = true;
      btnJPEG.Click += new System.EventHandler(this.btnJPEG_Click);
      // 
      // btnPNG
      // 
      btnPNG.Location = new System.Drawing.Point(89, 512);
      btnPNG.Name = "btnPNG";
      btnPNG.Size = new System.Drawing.Size(75, 23);
      btnPNG.TabIndex = 23;
      btnPNG.Text = "To &PNG";
      btnPNG.UseVisualStyleBackColor = true;
      btnPNG.Click += new System.EventHandler(this.btnPNG_Click);
      // 
      // lblGroups
      // 
      lblGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblGroups.Location = new System.Drawing.Point(4, 69);
      lblGroups.Name = "lblGroups";
      lblGroups.Size = new System.Drawing.Size(188, 17);
      lblGroups.TabIndex = 22;
      lblGroups.Text = "Groups";
      lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // selectGroupMenuItem
      // 
      selectGroupMenuItem.Name = "selectGroupMenuItem";
      selectGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      selectGroupMenuItem.Text = "&Select Group";
      selectGroupMenuItem.Click += new System.EventHandler(this.selectGroupMenuItem_Click);
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
      this.hsplit.Panel1.Controls.Add(this.lblStatus);
      this.hsplit.Panel1.Controls.Add(this.progress);
      this.hsplit.Panel1.Controls.Add(tools);
      this.hsplit.Panel1.Controls.Add(lblPics);
      this.hsplit.Panel1.Controls.Add(this.lstFiles);
      // 
      // hsplit.Panel2
      // 
      this.hsplit.Panel2.Controls.Add(this.picture);
      this.hsplit.Size = new System.Drawing.Size(592, 573);
      this.hsplit.SplitterDistance = 346;
      this.hsplit.TabIndex = 0;
      // 
      // lblToolHack
      // 
      lblToolHack.Location = new System.Drawing.Point(55, 23);
      lblToolHack.Name = "lblToolHack";
      lblToolHack.Size = new System.Drawing.Size(200, 2);
      lblToolHack.TabIndex = 12;
      // 
      // lblStatus
      // 
      this.lblStatus.Location = new System.Drawing.Point(253, 3);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(98, 20);
      this.lblStatus.TabIndex = 11;
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // progress
      // 
      this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progress.Location = new System.Drawing.Point(355, 3);
      this.progress.Name = "progress";
      this.progress.Size = new System.Drawing.Size(237, 20);
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
      listViewGroup2.Header = "Uncategorized";
      listViewGroup2.Name = "Uncategorized";
      this.lstFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
      this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstFiles.HideSelection = false;
      this.lstFiles.LabelEdit = true;
      this.lstFiles.Location = new System.Drawing.Point(3, 26);
      this.lstFiles.Name = "lstFiles";
      this.lstFiles.ShowItemToolTips = true;
      this.lstFiles.Size = new System.Drawing.Size(589, 320);
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
      // picture
      // 
      this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picture.Location = new System.Drawing.Point(3, 0);
      this.picture.Name = "picture";
      this.picture.Size = new System.Drawing.Size(589, 220);
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
      this.vsplit.Panel2.Controls.Add(this.btnResize);
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
      this.vsplit.Size = new System.Drawing.Size(792, 573);
      this.vsplit.SplitterDistance = 592;
      this.vsplit.TabIndex = 0;
      // 
      // chkOverwriteThumbnails
      // 
      this.chkOverwriteThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkOverwriteThumbnails.Checked = true;
      this.chkOverwriteThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOverwriteThumbnails.Enabled = false;
      this.chkOverwriteThumbnails.Location = new System.Drawing.Point(7, 436);
      this.chkOverwriteThumbnails.Name = "chkOverwriteThumbnails";
      this.chkOverwriteThumbnails.Size = new System.Drawing.Size(184, 18);
      this.chkOverwriteThumbnails.TabIndex = 19;
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
      this.chkSaveInBackground.TabIndex = 21;
      this.chkSaveInBackground.Text = "Save changes in the &background";
      this.chkSaveInBackground.UseVisualStyleBackColor = true;
      // 
      // chkSkipSmaller
      // 
      this.chkSkipSmaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkSkipSmaller.Checked = true;
      this.chkSkipSmaller.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSkipSmaller.Location = new System.Drawing.Point(7, 396);
      this.chkSkipSmaller.Name = "chkSkipSmaller";
      this.chkSkipSmaller.Size = new System.Drawing.Size(184, 18);
      this.chkSkipSmaller.TabIndex = 17;
      this.chkSkipSmaller.Text = "Skip s&maller images";
      this.chkSkipSmaller.UseVisualStyleBackColor = true;
      // 
      // chkDetectRotated
      // 
      this.chkDetectRotated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkDetectRotated.Checked = true;
      this.chkDetectRotated.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkDetectRotated.Location = new System.Drawing.Point(7, 376);
      this.chkDetectRotated.Name = "chkDetectRotated";
      this.chkDetectRotated.Size = new System.Drawing.Size(184, 18);
      this.chkDetectRotated.TabIndex = 16;
      this.chkDetectRotated.Text = "&Detect rotated images";
      this.chkDetectRotated.UseVisualStyleBackColor = true;
      // 
      // chkConfirmConvert
      // 
      this.chkConfirmConvert.Checked = true;
      this.chkConfirmConvert.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkConfirmConvert.Location = new System.Drawing.Point(8, 541);
      this.chkConfirmConvert.Name = "chkConfirmConvert";
      this.chkConfirmConvert.Size = new System.Drawing.Size(181, 18);
      this.chkConfirmConvert.TabIndex = 24;
      this.chkConfirmConvert.Text = "&Confirm con&version";
      this.chkConfirmConvert.UseVisualStyleBackColor = true;
      // 
      // txtIndex
      // 
      this.txtIndex.Location = new System.Drawing.Point(59, 355);
      this.txtIndex.Name = "txtIndex";
      this.txtIndex.Size = new System.Drawing.Size(32, 20);
      this.txtIndex.TabIndex = 15;
      this.txtIndex.Text = "0";
      // 
      // chkCreateThumbnails
      // 
      this.chkCreateThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateThumbnails.Location = new System.Drawing.Point(7, 416);
      this.chkCreateThumbnails.Name = "chkCreateThumbnails";
      this.chkCreateThumbnails.Size = new System.Drawing.Size(184, 18);
      this.chkCreateThumbnails.TabIndex = 18;
      this.chkCreateThumbnails.Text = "Create &thumbnails";
      this.chkCreateThumbnails.UseVisualStyleBackColor = true;
      this.chkCreateThumbnails.CheckedChanged += new System.EventHandler(this.chkCreateThumbnails_CheckedChanged);
      // 
      // txtNamingScheme
      // 
      this.txtNamingScheme.Location = new System.Drawing.Point(59, 329);
      this.txtNamingScheme.Name = "txtNamingScheme";
      this.txtNamingScheme.Size = new System.Drawing.Size(129, 20);
      this.txtNamingScheme.TabIndex = 13;
      this.txtNamingScheme.Text = "%d\\%f%e";
      // 
      // btnResize
      // 
      this.btnResize.Location = new System.Drawing.Point(143, 302);
      this.btnResize.Name = "btnResize";
      this.btnResize.Size = new System.Drawing.Size(45, 23);
      this.btnResize.TabIndex = 11;
      this.btnResize.Text = "&Go";
      this.btnResize.UseVisualStyleBackColor = true;
      this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
      // 
      // txtHeight
      // 
      this.txtHeight.Location = new System.Drawing.Point(106, 303);
      this.txtHeight.Name = "txtHeight";
      this.txtHeight.Size = new System.Drawing.Size(31, 20);
      this.txtHeight.TabIndex = 10;
      this.txtHeight.Text = "768";
      this.txtHeight.TextChanged += new System.EventHandler(this.txtDimensions_TextChanged);
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(59, 303);
      this.txtWidth.Name = "txtWidth";
      this.txtWidth.Size = new System.Drawing.Size(31, 20);
      this.txtWidth.TabIndex = 8;
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
      this.chkLowQuality.TabIndex = 5;
      this.chkLowQuality.Text = "Use low &quality icons (faster)";
      this.chkLowQuality.UseVisualStyleBackColor = true;
      // 
      // chkLowerCase
      // 
      this.chkLowerCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkLowerCase.Checked = true;
      this.chkLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkLowerCase.Location = new System.Drawing.Point(7, 257);
      this.chkLowerCase.Name = "chkLowerCase";
      this.chkLowerCase.Size = new System.Drawing.Size(184, 18);
      this.chkLowerCase.TabIndex = 4;
      this.chkLowerCase.Text = "Use &lowercase group file names";
      this.chkLowerCase.UseVisualStyleBackColor = true;
      // 
      // chkCreateGroupDirs
      // 
      this.chkCreateGroupDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateGroupDirs.Location = new System.Drawing.Point(7, 237);
      this.chkCreateGroupDirs.Name = "chkCreateGroupDirs";
      this.chkCreateGroupDirs.Size = new System.Drawing.Size(184, 18);
      this.chkCreateGroupDirs.TabIndex = 3;
      this.chkCreateGroupDirs.Text = "&Create subdirectories for groups";
      this.chkCreateGroupDirs.UseVisualStyleBackColor = true;
      // 
      // chkAutoRename
      // 
      this.chkAutoRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkAutoRename.Location = new System.Drawing.Point(7, 217);
      this.chkAutoRename.Name = "chkAutoRename";
      this.chkAutoRename.Size = new System.Drawing.Size(184, 18);
      this.chkAutoRename.TabIndex = 2;
      this.chkAutoRename.Text = "&Rename pictures when grouped";
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
      this.lstGroups.Location = new System.Drawing.Point(2, 88);
      this.lstGroups.MultiSelect = false;
      this.lstGroups.Name = "lstGroups";
      this.lstGroups.ShowGroups = false;
      this.lstGroups.ShowItemToolTips = true;
      this.lstGroups.Size = new System.Drawing.Size(190, 126);
      this.lstGroups.TabIndex = 1;
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
            selectGroupMenuItem});
      this.groupMenu.Name = "groupMenu";
      this.groupMenu.Size = new System.Drawing.Size(146, 92);
      this.groupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.groupMenu_Opening);
      // 
      // deleteGroupMenuItem
      // 
      this.deleteGroupMenuItem.Name = "deleteGroupMenuItem";
      this.deleteGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      this.deleteGroupMenuItem.Text = "&Delete Group";
      this.deleteGroupMenuItem.Click += new System.EventHandler(this.deleteGroupMenuItem_Click);
      // 
      // renameGroupMenuItem
      // 
      this.renameGroupMenuItem.Name = "renameGroupMenuItem";
      this.renameGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      this.renameGroupMenuItem.Text = "&Rename Group";
      this.renameGroupMenuItem.Click += new System.EventHandler(this.renameGroupMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 573);
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
    private System.Windows.Forms.ToolStripButton listView;
    private System.Windows.Forms.ToolStripButton iconView;
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
    private System.Windows.Forms.TextBox txtIndex;
    private System.Windows.Forms.SplitContainer vsplit;
    private System.Windows.Forms.SplitContainer hsplit;
    private System.Windows.Forms.CheckBox chkConfirmConvert;
    private System.Windows.Forms.CheckBox chkDetectRotated;
    private System.Windows.Forms.CheckBox chkSkipSmaller;
    private System.Windows.Forms.CheckBox chkSaveInBackground;
    private System.Windows.Forms.CheckBox chkOverwriteThumbnails;


  }
}