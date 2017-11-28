namespace StreamsIntro
{
    partial class Form1
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
            this.rtbFileContents = new System.Windows.Forms.RichTextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.txtStreamProperties = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtbFileContents
            // 
            this.rtbFileContents.Location = new System.Drawing.Point(0, 3);
            this.rtbFileContents.Name = "rtbFileContents";
            this.rtbFileContents.ReadOnly = true;
            this.rtbFileContents.Size = new System.Drawing.Size(284, 152);
            this.rtbFileContents.TabIndex = 0;
            this.rtbFileContents.Text = "";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(30, 190);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Enabled = false;
            this.btnReadFile.Location = new System.Drawing.Point(175, 190);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(75, 23);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // txtStreamProperties
            // 
            this.txtStreamProperties.Location = new System.Drawing.Point(0, 234);
            this.txtStreamProperties.Multiline = true;
            this.txtStreamProperties.Name = "txtStreamProperties";
            this.txtStreamProperties.ReadOnly = true;
            this.txtStreamProperties.Size = new System.Drawing.Size(284, 83);
            this.txtStreamProperties.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 318);
            this.Controls.Add(this.txtStreamProperties);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.rtbFileContents);
            this.Name = "Form1";
            this.Text = "Streams Intro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbFileContents;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.TextBox txtStreamProperties;
    }
}

