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
      System.Windows.Forms.Label lblPics;
      System.Windows.Forms.Label lblFirstIndex;
      System.Windows.Forms.Label lblScheme;
      System.Windows.Forms.Label lblNamingScheme;
      System.Windows.Forms.Label lblX;
      System.Windows.Forms.Label lblResizeRename;
      System.Windows.Forms.ColumnHeader colGroupName;
      System.Windows.Forms.ToolStripMenuItem newGroupMenuItem;
      System.Windows.Forms.Label lblGroups;
      System.Windows.Forms.Label lblNewSize;
      this.listView = new System.Windows.Forms.ToolStripButton();
      this.iconView = new System.Windows.Forms.ToolStripButton();
      this.vsplit = new System.Windows.Forms.SplitContainer();
      this.lblStatus = new System.Windows.Forms.Label();
      this.progress = new System.Windows.Forms.ProgressBar();
      this.lstFiles = new System.Windows.Forms.ListView();
      this.colName = new System.Windows.Forms.ColumnHeader();
      this.picture = new System.Windows.Forms.PictureBox();
      this.hsplit = new System.Windows.Forms.SplitContainer();
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
      lblPics = new System.Windows.Forms.Label();
      lblFirstIndex = new System.Windows.Forms.Label();
      lblScheme = new System.Windows.Forms.Label();
      lblNamingScheme = new System.Windows.Forms.Label();
      lblX = new System.Windows.Forms.Label();
      lblResizeRename = new System.Windows.Forms.Label();
      colGroupName = new System.Windows.Forms.ColumnHeader();
      newGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      lblGroups = new System.Windows.Forms.Label();
      lblNewSize = new System.Windows.Forms.Label();
      tools.SuspendLayout();
      this.vsplit.Panel1.SuspendLayout();
      this.vsplit.Panel2.SuspendLayout();
      this.vsplit.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
      this.hsplit.Panel1.SuspendLayout();
      this.hsplit.Panel2.SuspendLayout();
      this.hsplit.SuspendLayout();
      this.groupMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tools
      // 
      tools.Dock = System.Windows.Forms.DockStyle.None;
      tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listView,
            this.iconView});
      tools.Location = new System.Drawing.Point(55, 0);
      tools.Name = "tools";
      tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      tools.Size = new System.Drawing.Size(144, 25);
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
      lblFirstIndex.Location = new System.Drawing.Point(4, 313);
      lblFirstIndex.Name = "lblFirstIndex";
      lblFirstIndex.Size = new System.Drawing.Size(58, 16);
      lblFirstIndex.TabIndex = 13;
      lblFirstIndex.Text = "1st Index:";
      // 
      // lblScheme
      // 
      lblScheme.Location = new System.Drawing.Point(5, 357);
      lblScheme.Name = "lblScheme";
      lblScheme.Size = new System.Drawing.Size(185, 29);
      lblScheme.TabIndex = 15;
      lblScheme.Text = "%f = filename, %e = extension,\r\n%d = directory, %n = index #, %% = %";
      // 
      // lblNamingScheme
      // 
      lblNamingScheme.Location = new System.Drawing.Point(4, 287);
      lblNamingScheme.Name = "lblNamingScheme";
      lblNamingScheme.Size = new System.Drawing.Size(58, 16);
      lblNamingScheme.TabIndex = 12;
      lblNamingScheme.Text = "Name:";
      // 
      // lblX
      // 
      lblX.Location = new System.Drawing.Point(94, 262);
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
      lblResizeRename.Location = new System.Drawing.Point(3, 239);
      lblResizeRename.Name = "lblResizeRename";
      lblResizeRename.Size = new System.Drawing.Size(185, 17);
      lblResizeRename.TabIndex = 6;
      lblResizeRename.Text = "Resize / Rename Images";
      lblResizeRename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // colGroupName
      // 
      colGroupName.Text = "Name";
      colGroupName.Width = 100;
      // 
      // newGroupMenuItem
      // 
      newGroupMenuItem.Name = "newGroupMenuItem";
      newGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      newGroupMenuItem.Text = "&New Group";
      newGroupMenuItem.Click += new System.EventHandler(this.newGroupMenuItem_Click);
      // 
      // lblGroups
      // 
      lblGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblGroups.Location = new System.Drawing.Point(4, 4);
      lblGroups.Name = "lblGroups";
      lblGroups.Size = new System.Drawing.Size(185, 17);
      lblGroups.TabIndex = 0;
      lblGroups.Text = "Groups";
      lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblNewSize
      // 
      lblNewSize.Location = new System.Drawing.Point(4, 263);
      lblNewSize.Name = "lblNewSize";
      lblNewSize.Size = new System.Drawing.Size(58, 16);
      lblNewSize.TabIndex = 7;
      lblNewSize.Text = "&New size:";
      // 
      // vsplit
      // 
      this.vsplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.vsplit.Location = new System.Drawing.Point(0, 0);
      this.vsplit.Name = "vsplit";
      this.vsplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // vsplit.Panel1
      // 
      this.vsplit.Panel1.Controls.Add(this.lblStatus);
      this.vsplit.Panel1.Controls.Add(this.progress);
      this.vsplit.Panel1.Controls.Add(tools);
      this.vsplit.Panel1.Controls.Add(lblPics);
      this.vsplit.Panel1.Controls.Add(this.lstFiles);
      // 
      // vsplit.Panel2
      // 
      this.vsplit.Panel2.Controls.Add(this.picture);
      this.vsplit.Size = new System.Drawing.Size(536, 558);
      this.vsplit.SplitterDistance = 338;
      this.vsplit.TabIndex = 0;
      // 
      // lblStatus
      // 
      this.lblStatus.Location = new System.Drawing.Point(202, 3);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(98, 20);
      this.lblStatus.TabIndex = 11;
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // progress
      // 
      this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progress.Location = new System.Drawing.Point(306, 3);
      this.progress.Name = "progress";
      this.progress.Size = new System.Drawing.Size(228, 20);
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
      this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstFiles.HideSelection = false;
      this.lstFiles.LabelEdit = true;
      this.lstFiles.Location = new System.Drawing.Point(3, 26);
      this.lstFiles.Name = "lstFiles";
      this.lstFiles.ShowItemToolTips = true;
      this.lstFiles.Size = new System.Drawing.Size(532, 310);
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
      this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picture.Location = new System.Drawing.Point(0, 0);
      this.picture.Name = "picture";
      this.picture.Size = new System.Drawing.Size(536, 216);
      this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.picture.TabIndex = 0;
      this.picture.TabStop = false;
      this.picture.SizeChanged += new System.EventHandler(this.picture_SizeChanged);
      // 
      // hsplit
      // 
      this.hsplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hsplit.Location = new System.Drawing.Point(0, 0);
      this.hsplit.Name = "hsplit";
      // 
      // hsplit.Panel1
      // 
      this.hsplit.Panel1.Controls.Add(this.vsplit);
      // 
      // hsplit.Panel2
      // 
      this.hsplit.Panel2.Controls.Add(this.txtIndex);
      this.hsplit.Panel2.Controls.Add(lblFirstIndex);
      this.hsplit.Panel2.Controls.Add(this.chkCreateThumbnails);
      this.hsplit.Panel2.Controls.Add(lblScheme);
      this.hsplit.Panel2.Controls.Add(this.txtNamingScheme);
      this.hsplit.Panel2.Controls.Add(lblNamingScheme);
      this.hsplit.Panel2.Controls.Add(this.btnResize);
      this.hsplit.Panel2.Controls.Add(this.txtHeight);
      this.hsplit.Panel2.Controls.Add(lblX);
      this.hsplit.Panel2.Controls.Add(this.txtWidth);
      this.hsplit.Panel2.Controls.Add(lblResizeRename);
      this.hsplit.Panel2.Controls.Add(this.chkLowQuality);
      this.hsplit.Panel2.Controls.Add(this.chkLowerCase);
      this.hsplit.Panel2.Controls.Add(this.chkCreateGroupDirs);
      this.hsplit.Panel2.Controls.Add(this.chkAutoRename);
      this.hsplit.Panel2.Controls.Add(this.lstGroups);
      this.hsplit.Panel2.Controls.Add(lblGroups);
      this.hsplit.Panel2.Controls.Add(lblNewSize);
      this.hsplit.Size = new System.Drawing.Size(735, 558);
      this.hsplit.SplitterDistance = 536;
      this.hsplit.TabIndex = 0;
      // 
      // txtIndex
      // 
      this.txtIndex.Location = new System.Drawing.Point(59, 311);
      this.txtIndex.Name = "txtIndex";
      this.txtIndex.Size = new System.Drawing.Size(32, 20);
      this.txtIndex.TabIndex = 13;
      this.txtIndex.Text = "0";
      // 
      // chkCreateThumbnails
      // 
      this.chkCreateThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateThumbnails.Location = new System.Drawing.Point(7, 336);
      this.chkCreateThumbnails.Name = "chkCreateThumbnails";
      this.chkCreateThumbnails.Size = new System.Drawing.Size(181, 18);
      this.chkCreateThumbnails.TabIndex = 14;
      this.chkCreateThumbnails.Text = "Create &thumbnails";
      this.chkCreateThumbnails.UseVisualStyleBackColor = true;
      // 
      // txtNamingScheme
      // 
      this.txtNamingScheme.Location = new System.Drawing.Point(59, 285);
      this.txtNamingScheme.Name = "txtNamingScheme";
      this.txtNamingScheme.Size = new System.Drawing.Size(129, 20);
      this.txtNamingScheme.TabIndex = 12;
      this.txtNamingScheme.Text = "%d%f%e";
      // 
      // btnResize
      // 
      this.btnResize.Location = new System.Drawing.Point(143, 258);
      this.btnResize.Name = "btnResize";
      this.btnResize.Size = new System.Drawing.Size(45, 23);
      this.btnResize.TabIndex = 11;
      this.btnResize.Text = "&Go";
      this.btnResize.UseVisualStyleBackColor = true;
      this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
      // 
      // txtHeight
      // 
      this.txtHeight.Location = new System.Drawing.Point(106, 259);
      this.txtHeight.Name = "txtHeight";
      this.txtHeight.Size = new System.Drawing.Size(31, 20);
      this.txtHeight.TabIndex = 10;
      this.txtHeight.Text = "768";
      this.txtHeight.TextChanged += new System.EventHandler(this.txtDimensions_TextChanged);
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(59, 259);
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
      this.chkLowQuality.Location = new System.Drawing.Point(3, 213);
      this.chkLowQuality.Name = "chkLowQuality";
      this.chkLowQuality.Size = new System.Drawing.Size(186, 18);
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
      this.chkLowerCase.Location = new System.Drawing.Point(3, 193);
      this.chkLowerCase.Name = "chkLowerCase";
      this.chkLowerCase.Size = new System.Drawing.Size(186, 18);
      this.chkLowerCase.TabIndex = 4;
      this.chkLowerCase.Text = "Use &lowercase group file names";
      this.chkLowerCase.UseVisualStyleBackColor = true;
      // 
      // chkCreateGroupDirs
      // 
      this.chkCreateGroupDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkCreateGroupDirs.Location = new System.Drawing.Point(3, 173);
      this.chkCreateGroupDirs.Name = "chkCreateGroupDirs";
      this.chkCreateGroupDirs.Size = new System.Drawing.Size(186, 18);
      this.chkCreateGroupDirs.TabIndex = 3;
      this.chkCreateGroupDirs.Text = "Create &subdirectories for groups";
      this.chkCreateGroupDirs.UseVisualStyleBackColor = true;
      // 
      // chkAutoRename
      // 
      this.chkAutoRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chkAutoRename.Checked = true;
      this.chkAutoRename.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAutoRename.Location = new System.Drawing.Point(2, 153);
      this.chkAutoRename.Name = "chkAutoRename";
      this.chkAutoRename.Size = new System.Drawing.Size(186, 18);
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
      this.lstGroups.Location = new System.Drawing.Point(2, 24);
      this.lstGroups.MultiSelect = false;
      this.lstGroups.Name = "lstGroups";
      this.lstGroups.ShowItemToolTips = true;
      this.lstGroups.Size = new System.Drawing.Size(190, 126);
      this.lstGroups.TabIndex = 1;
      this.lstGroups.UseCompatibleStateImageBehavior = false;
      this.lstGroups.View = System.Windows.Forms.View.Details;
      this.lstGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGroups_MouseDoubleClick);
      this.lstGroups.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstGroups_AfterLabelEdit);
      this.lstGroups.SizeChanged += new System.EventHandler(this.lstGroups_SizeChanged);
      this.lstGroups.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstGroups_BeforeLabelEdit);
      this.lstGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstGroups_KeyDown);
      // 
      // groupMenu
      // 
      this.groupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newGroupMenuItem,
            this.deleteGroupMenuItem,
            this.renameGroupMenuItem});
      this.groupMenu.Name = "groupMenu";
      this.groupMenu.Size = new System.Drawing.Size(146, 70);
      this.groupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.groupMenu_Opening);
      // 
      // deleteGroupMenuItem
      // 
      this.deleteGroupMenuItem.Name = "deleteGroupMenuItem";
      this.deleteGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      this.deleteGroupMenuItem.Text = "&Delete Group";
      // 
      // renameGroupMenuItem
      // 
      this.renameGroupMenuItem.Name = "renameGroupMenuItem";
      this.renameGroupMenuItem.Size = new System.Drawing.Size(145, 22);
      this.renameGroupMenuItem.Text = "&Rename Group";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(735, 558);
      this.Controls.Add(this.hsplit);
      this.Enabled = false;
      this.HelpButton = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "MainForm";
      this.Text = "Picture Sorter";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
      tools.ResumeLayout(false);
      tools.PerformLayout();
      this.vsplit.Panel1.ResumeLayout(false);
      this.vsplit.Panel1.PerformLayout();
      this.vsplit.Panel2.ResumeLayout(false);
      this.vsplit.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
      this.hsplit.Panel1.ResumeLayout(false);
      this.hsplit.Panel2.ResumeLayout(false);
      this.hsplit.Panel2.PerformLayout();
      this.hsplit.ResumeLayout(false);
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
    private System.Windows.Forms.SplitContainer hsplit;
    private System.Windows.Forms.SplitContainer vsplit;


  }
}