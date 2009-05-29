namespace PictureSorter
{
  partial class ZoomImageForm
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
      this.pictureBox = new System.Windows.Forms.PictureBox();
      lblHelp = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // lblHelp
      // 
      lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblHelp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      lblHelp.Location = new System.Drawing.Point(8, 8);
      lblHelp.Name = "lblHelp";
      lblHelp.Size = new System.Drawing.Size(632, 30);
      lblHelp.TabIndex = 1;
      lblHelp.Text = "Press the left and right arrow keys to move between the selected images, or press" +
    " escape to close this window and return to the main view.";
      // 
      // pictureBox
      // 
      this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox.Location = new System.Drawing.Point(11, 39);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(629, 471);
      this.pictureBox.TabIndex = 2;
      this.pictureBox.TabStop = false;
      // 
      // ZoomImageForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(652, 522);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(lblHelp);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ZoomImageForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Full size view";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZoomImageForm_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox;
  }
}