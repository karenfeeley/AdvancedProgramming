namespace HotTipsterApp
{
    partial class HotTipsterReports
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
            this.lstReportsData = new System.Windows.Forms.ListBox();
            this.btnResultsByYear = new System.Windows.Forms.Button();
            this.btnMostPopular = new System.Windows.Forms.Button();
            this.btnSortedByDate = new System.Windows.Forms.Button();
            this.btnHigh_Low = new System.Windows.Forms.Button();
            this.btnBettingStats = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdatesPending = new System.Windows.Forms.Button();
            this.lstUpdatesDue = new System.Windows.Forms.ListBox();
            this.lblHotTipsterReportsHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstReportsData
            // 
            this.lstReportsData.FormattingEnabled = true;
            this.lstReportsData.ItemHeight = 28;
            this.lstReportsData.Location = new System.Drawing.Point(29, 58);
            this.lstReportsData.Name = "lstReportsData";
            this.lstReportsData.Size = new System.Drawing.Size(409, 424);
            this.lstReportsData.TabIndex = 0;
            // 
            // btnResultsByYear
            // 
            this.btnResultsByYear.ForeColor = System.Drawing.Color.Blue;
            this.btnResultsByYear.Location = new System.Drawing.Point(481, 58);
            this.btnResultsByYear.Name = "btnResultsByYear";
            this.btnResultsByYear.Size = new System.Drawing.Size(186, 56);
            this.btnResultsByYear.TabIndex = 1;
            this.btnResultsByYear.Text = "Results by Year";
            this.btnResultsByYear.UseVisualStyleBackColor = true;
            this.btnResultsByYear.Click += new System.EventHandler(this.btnResultsByYear_Click);
            // 
            // btnMostPopular
            // 
            this.btnMostPopular.ForeColor = System.Drawing.Color.Blue;
            this.btnMostPopular.Location = new System.Drawing.Point(481, 151);
            this.btnMostPopular.Name = "btnMostPopular";
            this.btnMostPopular.Size = new System.Drawing.Size(186, 56);
            this.btnMostPopular.TabIndex = 2;
            this.btnMostPopular.Text = "Most Popular";
            this.btnMostPopular.UseVisualStyleBackColor = true;
            this.btnMostPopular.Click += new System.EventHandler(this.btnMostPopular_Click);
            // 
            // btnSortedByDate
            // 
            this.btnSortedByDate.ForeColor = System.Drawing.Color.Blue;
            this.btnSortedByDate.Location = new System.Drawing.Point(481, 242);
            this.btnSortedByDate.Name = "btnSortedByDate";
            this.btnSortedByDate.Size = new System.Drawing.Size(186, 56);
            this.btnSortedByDate.TabIndex = 3;
            this.btnSortedByDate.Text = "Sorted by Date";
            this.btnSortedByDate.UseVisualStyleBackColor = true;
            this.btnSortedByDate.Click += new System.EventHandler(this.btnSortedByDate_Click);
            // 
            // btnHigh_Low
            // 
            this.btnHigh_Low.ForeColor = System.Drawing.Color.Blue;
            this.btnHigh_Low.Location = new System.Drawing.Point(481, 428);
            this.btnHigh_Low.Name = "btnHigh_Low";
            this.btnHigh_Low.Size = new System.Drawing.Size(186, 54);
            this.btnHigh_Low.TabIndex = 4;
            this.btnHigh_Low.Text = "Highest, Lowest";
            this.btnHigh_Low.UseVisualStyleBackColor = true;
            this.btnHigh_Low.Click += new System.EventHandler(this.btnHigh_Low_Click);
            // 
            // btnBettingStats
            // 
            this.btnBettingStats.ForeColor = System.Drawing.Color.Blue;
            this.btnBettingStats.Location = new System.Drawing.Point(481, 336);
            this.btnBettingStats.Name = "btnBettingStats";
            this.btnBettingStats.Size = new System.Drawing.Size(186, 56);
            this.btnBettingStats.TabIndex = 5;
            this.btnBettingStats.Text = "Result Stats";
            this.btnBettingStats.UseVisualStyleBackColor = true;
            this.btnBettingStats.Click += new System.EventHandler(this.btnBettingStats_Click);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(732, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close Reports";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdatesPending
            // 
            this.btnUpdatesPending.ForeColor = System.Drawing.Color.Blue;
            this.btnUpdatesPending.Location = new System.Drawing.Point(732, 336);
            this.btnUpdatesPending.Name = "btnUpdatesPending";
            this.btnUpdatesPending.Size = new System.Drawing.Size(240, 56);
            this.btnUpdatesPending.TabIndex = 7;
            this.btnUpdatesPending.Text = "Races Pending Updates";
            this.btnUpdatesPending.UseVisualStyleBackColor = true;
            this.btnUpdatesPending.Click += new System.EventHandler(this.btnUpdatesPending_Click);
            // 
            // lstUpdatesDue
            // 
            this.lstUpdatesDue.FormattingEnabled = true;
            this.lstUpdatesDue.ItemHeight = 28;
            this.lstUpdatesDue.Location = new System.Drawing.Point(732, 58);
            this.lstUpdatesDue.Name = "lstUpdatesDue";
            this.lstUpdatesDue.Size = new System.Drawing.Size(240, 228);
            this.lstUpdatesDue.TabIndex = 8;
            // 
            // lblHotTipsterReportsHeader
            // 
            this.lblHotTipsterReportsHeader.AutoSize = true;
            this.lblHotTipsterReportsHeader.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotTipsterReportsHeader.Location = new System.Drawing.Point(342, 9);
            this.lblHotTipsterReportsHeader.Name = "lblHotTipsterReportsHeader";
            this.lblHotTipsterReportsHeader.Size = new System.Drawing.Size(292, 33);
            this.lblHotTipsterReportsHeader.TabIndex = 9;
            this.lblHotTipsterReportsHeader.Text = "HotTipster Reports View";
            // 
            // HotTipsterReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 502);
            this.Controls.Add(this.lblHotTipsterReportsHeader);
            this.Controls.Add(this.lstUpdatesDue);
            this.Controls.Add(this.btnUpdatesPending);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBettingStats);
            this.Controls.Add(this.btnHigh_Low);
            this.Controls.Add(this.btnSortedByDate);
            this.Controls.Add(this.btnMostPopular);
            this.Controls.Add(this.btnResultsByYear);
            this.Controls.Add(this.lstReportsData);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HotTipsterReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotTipster Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstReportsData;
        private System.Windows.Forms.Button btnResultsByYear;
        private System.Windows.Forms.Button btnMostPopular;
        private System.Windows.Forms.Button btnSortedByDate;
        private System.Windows.Forms.Button btnHigh_Low;
        private System.Windows.Forms.Button btnBettingStats;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdatesPending;
        private System.Windows.Forms.ListBox lstUpdatesDue;
        private System.Windows.Forms.Label lblHotTipsterReportsHeader;
    }
}