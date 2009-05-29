namespace PictureSorter
{
  partial class CropImageForm
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
      System.Windows.Forms.Label lblHelp;
      System.Windows.Forms.Button btnCancel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropImageForm));
      this.btnDone = new System.Windows.Forms.Button();
      this.overlay = new PictureSorter.CropImageForm.OverlayControl();
      this.btnCrop = new System.Windows.Forms.Button();
      this.btnUndo = new System.Windows.Forms.Button();
      lblHelp = new System.Windows.Forms.Label();
      btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblHelp
      // 
      lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblHelp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblHelp.Location = new System.Drawing.Point(7, 7);
      lblHelp.Name = "lblHelp";
      lblHelp.Size = new System.Drawing.Size(615, 30);
      lblHelp.TabIndex = 0;
      lblHelp.Text = "First, press your mouse button and drag a rectangle around the area you want to k" +
    "eep. Then click \"Crop\" to crop the image. When you\'re done, click \"Done\". If you" +
    " make a mistake, you can click \"Undo\".";
      lblHelp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
      lblHelp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
      lblHelp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
      // 
      // btnCancel
      // 
      btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(178, 525);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(60, 23);
      btnCancel.TabIndex = 6;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnDone
      // 
      this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDone.Enabled = false;
      this.btnDone.Location = new System.Drawing.Point(121, 525);
      this.btnDone.Name = "btnDone";
      this.btnDone.Size = new System.Drawing.Size(51, 23);
      this.btnDone.TabIndex = 5;
      this.btnDone.Text = "&Done";
      this.btnDone.UseVisualStyleBackColor = true;
      this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
      // 
      // overlay
      // 
      this.overlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.overlay.ImageRect = ((System.Drawing.RectangleF)(resources.GetObject("overlay.ImageRect")));
      this.overlay.Location = new System.Drawing.Point(7, 40);
      this.overlay.Name = "overlay";
      this.overlay.OverlayRect = ((System.Drawing.RectangleF)(resources.GetObject("overlay.OverlayRect")));
      this.overlay.Size = new System.Drawing.Size(615, 479);
      this.overlay.TabIndex = 0;
      this.overlay.TabStop = false;
      this.overlay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
      this.overlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
      this.overlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
      // 
      // btnCrop
      // 
      this.btnCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCrop.Enabled = false;
      this.btnCrop.Location = new System.Drawing.Point(7, 525);
      this.btnCrop.Name = "btnCrop";
      this.btnCrop.Size = new System.Drawing.Size(51, 23);
      this.btnCrop.TabIndex = 1;
      this.btnCrop.Text = "&Crop";
      this.btnCrop.UseVisualStyleBackColor = true;
      this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
      // 
      // btnUndo
      // 
      this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnUndo.Enabled = false;
      this.btnUndo.Location = new System.Drawing.Point(64, 525);
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Size = new System.Drawing.Size(51, 23);
      this.btnUndo.TabIndex = 2;
      this.btnUndo.Text = "&Undo";
      this.btnUndo.UseVisualStyleBackColor = true;
      this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
      // 
      // CropImageForm
      // 
      this.AcceptButton = this.btnDone;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(628, 553);
      this.Controls.Add(this.overlay);
      this.Controls.Add(btnCancel);
      this.Controls.Add(this.btnDone);
      this.Controls.Add(this.btnUndo);
      this.Controls.Add(this.btnCrop);
      this.Controls.Add(lblHelp);
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(636, 320);
      this.Name = "CropImageForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Crop Image";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CropImageForm_KeyDown);
      this.ResumeLayout(false);

    }

    #endregion

    private OverlayControl overlay;
    private System.Windows.Forms.Button btnCrop;
    private System.Windows.Forms.Button btnUndo;
    private System.Windows.Forms.Button btnDone;
  }
}