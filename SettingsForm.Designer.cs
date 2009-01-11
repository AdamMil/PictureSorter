namespace PictureSorter
{
  partial class SettingsForm
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
      System.Windows.Forms.Label lblPics;
      System.Windows.Forms.Button btnBrowsePics;
      System.Windows.Forms.Button btnBrowseOutput;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Button btnCancel;
      this.btnOK = new System.Windows.Forms.Button();
      this.txtPics = new System.Windows.Forms.TextBox();
      this.txtOutputDir = new System.Windows.Forms.TextBox();
      this.chkCopyAll = new System.Windows.Forms.CheckBox();
      lblPics = new System.Windows.Forms.Label();
      btnBrowsePics = new System.Windows.Forms.Button();
      btnBrowseOutput = new System.Windows.Forms.Button();
      label1 = new System.Windows.Forms.Label();
      btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblPics
      // 
      lblPics.Location = new System.Drawing.Point(7, 7);
      lblPics.Name = "lblPics";
      lblPics.Size = new System.Drawing.Size(80, 17);
      lblPics.TabIndex = 0;
      lblPics.Text = "&Pictures to edit:";
      lblPics.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnBrowsePics
      // 
      btnBrowsePics.Location = new System.Drawing.Point(415, 4);
      btnBrowsePics.Name = "btnBrowsePics";
      btnBrowsePics.Size = new System.Drawing.Size(75, 23);
      btnBrowsePics.TabIndex = 2;
      btnBrowsePics.Text = "&Browse";
      btnBrowsePics.UseVisualStyleBackColor = true;
      btnBrowsePics.Click += new System.EventHandler(this.btnBrowsePics_Click);
      // 
      // btnBrowseOutput
      // 
      btnBrowseOutput.Location = new System.Drawing.Point(415, 33);
      btnBrowseOutput.Name = "btnBrowseOutput";
      btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
      btnBrowseOutput.TabIndex = 5;
      btnBrowseOutput.Text = "B&rowse";
      btnBrowseOutput.UseVisualStyleBackColor = true;
      btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
      // 
      // label1
      // 
      label1.Location = new System.Drawing.Point(-1, 36);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(88, 17);
      label1.TabIndex = 3;
      label1.Text = "Output &directory:";
      label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(415, 63);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(334, 63);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 6;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // txtPics
      // 
      this.txtPics.Location = new System.Drawing.Point(88, 5);
      this.txtPics.Name = "txtPics";
      this.txtPics.ReadOnly = true;
      this.txtPics.Size = new System.Drawing.Size(321, 20);
      this.txtPics.TabIndex = 1;
      // 
      // txtOutputDir
      // 
      this.txtOutputDir.Location = new System.Drawing.Point(88, 34);
      this.txtOutputDir.Name = "txtOutputDir";
      this.txtOutputDir.Size = new System.Drawing.Size(321, 20);
      this.txtOutputDir.TabIndex = 4;
      // 
      // chkCopyAll
      // 
      this.chkCopyAll.Location = new System.Drawing.Point(88, 60);
      this.chkCopyAll.Name = "chkCopyAll";
      this.chkCopyAll.Size = new System.Drawing.Size(201, 19);
      this.chkCopyAll.TabIndex = 8;
      this.chkCopyAll.Text = "&Copy all images to output directory";
      this.chkCopyAll.UseVisualStyleBackColor = true;
      // 
      // SettingsForm
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(495, 91);
      this.Controls.Add(this.chkCopyAll);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(btnCancel);
      this.Controls.Add(btnBrowseOutput);
      this.Controls.Add(this.txtOutputDir);
      this.Controls.Add(label1);
      this.Controls.Add(btnBrowsePics);
      this.Controls.Add(this.txtPics);
      this.Controls.Add(lblPics);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SettingsForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Open Images";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtPics;
    private System.Windows.Forms.TextBox txtOutputDir;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.CheckBox chkCopyAll;
  }
}