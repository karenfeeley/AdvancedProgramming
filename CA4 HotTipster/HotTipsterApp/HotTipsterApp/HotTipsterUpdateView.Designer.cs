namespace HotTipsterApp
{
    partial class HotTipsterUpDateView
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
            this.grpExternalRecords = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnImportOrig = new System.Windows.Forms.Button();
            this.lblHotTipsterUpdateHeader = new System.Windows.Forms.Label();
            this.grpAdd_Modify = new System.Windows.Forms.GroupBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateRaceResult = new System.Windows.Forms.Button();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.btnAddNewRace = new System.Windows.Forms.Button();
            this.cboResult = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpRaceDate = new System.Windows.Forms.DateTimePicker();
            this.cboRaceCourse = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblRaceDate = new System.Windows.Forms.Label();
            this.lblRaceCourse = new System.Windows.Forms.Label();
            this.lstDisplayUpdateView = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRaceReports = new System.Windows.Forms.Button();
            this.grpExternalRecords.SuspendLayout();
            this.grpAdd_Modify.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpExternalRecords
            // 
            this.grpExternalRecords.Controls.Add(this.btnOpen);
            this.grpExternalRecords.Controls.Add(this.btnImportOrig);
            this.grpExternalRecords.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExternalRecords.ForeColor = System.Drawing.Color.Blue;
            this.grpExternalRecords.Location = new System.Drawing.Point(45, 56);
            this.grpExternalRecords.Name = "grpExternalRecords";
            this.grpExternalRecords.Size = new System.Drawing.Size(404, 156);
            this.grpExternalRecords.TabIndex = 0;
            this.grpExternalRecords.TabStop = false;
            this.grpExternalRecords.Text = "Race Records";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(228, 49);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(144, 83);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open from File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnImportOrig
            // 
            this.btnImportOrig.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportOrig.Location = new System.Drawing.Point(21, 51);
            this.btnImportOrig.Name = "btnImportOrig";
            this.btnImportOrig.Size = new System.Drawing.Size(144, 83);
            this.btnImportOrig.TabIndex = 0;
            this.btnImportOrig.Text = "Import Orig Data";
            this.btnImportOrig.UseVisualStyleBackColor = true;
            this.btnImportOrig.Click += new System.EventHandler(this.btnImportOrig_Click);
            // 
            // lblHotTipsterUpdateHeader
            // 
            this.lblHotTipsterUpdateHeader.AutoSize = true;
            this.lblHotTipsterUpdateHeader.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotTipsterUpdateHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHotTipsterUpdateHeader.Location = new System.Drawing.Point(364, 13);
            this.lblHotTipsterUpdateHeader.Name = "lblHotTipsterUpdateHeader";
            this.lblHotTipsterUpdateHeader.Size = new System.Drawing.Size(400, 29);
            this.lblHotTipsterUpdateHeader.TabIndex = 1;
            this.lblHotTipsterUpdateHeader.Text = "HotTipster - View Records and Update";
            // 
            // grpAdd_Modify
            // 
            this.grpAdd_Modify.Controls.Add(this.lblDisplay);
            this.grpAdd_Modify.Controls.Add(this.btnDelete);
            this.grpAdd_Modify.Controls.Add(this.btnUpdateRaceResult);
            this.grpAdd_Modify.Controls.Add(this.btnSelectItem);
            this.grpAdd_Modify.Controls.Add(this.btnAddNewRace);
            this.grpAdd_Modify.Controls.Add(this.cboResult);
            this.grpAdd_Modify.Controls.Add(this.txtAmount);
            this.grpAdd_Modify.Controls.Add(this.dtpRaceDate);
            this.grpAdd_Modify.Controls.Add(this.cboRaceCourse);
            this.grpAdd_Modify.Controls.Add(this.lblResult);
            this.grpAdd_Modify.Controls.Add(this.lblAmount);
            this.grpAdd_Modify.Controls.Add(this.lblRaceDate);
            this.grpAdd_Modify.Controls.Add(this.lblRaceCourse);
            this.grpAdd_Modify.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdd_Modify.ForeColor = System.Drawing.Color.Blue;
            this.grpAdd_Modify.Location = new System.Drawing.Point(509, 56);
            this.grpAdd_Modify.Name = "grpAdd_Modify";
            this.grpAdd_Modify.Size = new System.Drawing.Size(458, 419);
            this.grpAdd_Modify.TabIndex = 2;
            this.grpAdd_Modify.TabStop = false;
            this.grpAdd_Modify.Text = "Add New or Update Records";
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDisplay.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(28, 255);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(195, 44);
            this.lblDisplay.TabIndex = 12;
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(137, 369);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(195, 44);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Race Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateRaceResult
            // 
            this.btnUpdateRaceResult.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRaceResult.Location = new System.Drawing.Point(246, 316);
            this.btnUpdateRaceResult.Name = "btnUpdateRaceResult";
            this.btnUpdateRaceResult.Size = new System.Drawing.Size(195, 44);
            this.btnUpdateRaceResult.TabIndex = 10;
            this.btnUpdateRaceResult.Text = "Update Race Result";
            this.btnUpdateRaceResult.UseVisualStyleBackColor = true;
            this.btnUpdateRaceResult.Click += new System.EventHandler(this.btnUpdateRaceResult_Click);
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectItem.Location = new System.Drawing.Point(28, 316);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(195, 44);
            this.btnSelectItem.TabIndex = 9;
            this.btnSelectItem.Text = "Select Item for Update";
            this.btnSelectItem.UseVisualStyleBackColor = true;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // btnAddNewRace
            // 
            this.btnAddNewRace.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewRace.Location = new System.Drawing.Point(246, 255);
            this.btnAddNewRace.Name = "btnAddNewRace";
            this.btnAddNewRace.Size = new System.Drawing.Size(195, 44);
            this.btnAddNewRace.TabIndex = 8;
            this.btnAddNewRace.Text = "Add New Race";
            this.btnAddNewRace.UseVisualStyleBackColor = true;
            this.btnAddNewRace.Click += new System.EventHandler(this.btnAddNewRace_Click);
            // 
            // cboResult
            // 
            this.cboResult.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResult.FormattingEnabled = true;
            this.cboResult.Location = new System.Drawing.Point(241, 202);
            this.cboResult.Name = "cboResult";
            this.cboResult.Size = new System.Drawing.Size(200, 36);
            this.cboResult.TabIndex = 7;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(241, 150);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 35);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0";
            // 
            // dtpRaceDate
            // 
            this.dtpRaceDate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRaceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRaceDate.Location = new System.Drawing.Point(241, 97);
            this.dtpRaceDate.Name = "dtpRaceDate";
            this.dtpRaceDate.Size = new System.Drawing.Size(200, 35);
            this.dtpRaceDate.TabIndex = 5;
            // 
            // cboRaceCourse
            // 
            this.cboRaceCourse.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRaceCourse.FormattingEnabled = true;
            this.cboRaceCourse.Location = new System.Drawing.Point(241, 44);
            this.cboRaceCourse.Name = "cboRaceCourse";
            this.cboRaceCourse.Size = new System.Drawing.Size(200, 36);
            this.cboRaceCourse.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(27, 198);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(70, 28);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(27, 146);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(83, 28);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Amount";
            // 
            // lblRaceDate
            // 
            this.lblRaceDate.AutoSize = true;
            this.lblRaceDate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceDate.Location = new System.Drawing.Point(27, 97);
            this.lblRaceDate.Name = "lblRaceDate";
            this.lblRaceDate.Size = new System.Drawing.Size(106, 28);
            this.lblRaceDate.TabIndex = 1;
            this.lblRaceDate.Text = "Race Date";
            // 
            // lblRaceCourse
            // 
            this.lblRaceCourse.AutoSize = true;
            this.lblRaceCourse.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceCourse.Location = new System.Drawing.Point(27, 47);
            this.lblRaceCourse.Name = "lblRaceCourse";
            this.lblRaceCourse.Size = new System.Drawing.Size(126, 28);
            this.lblRaceCourse.TabIndex = 0;
            this.lblRaceCourse.Text = "Race Course";
            // 
            // lstDisplayUpdateView
            // 
            this.lstDisplayUpdateView.FormattingEnabled = true;
            this.lstDisplayUpdateView.ItemHeight = 28;
            this.lstDisplayUpdateView.Location = new System.Drawing.Point(45, 219);
            this.lstDisplayUpdateView.Name = "lstDisplayUpdateView";
            this.lstDisplayUpdateView.Size = new System.Drawing.Size(404, 256);
            this.lstDisplayUpdateView.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(148, 481);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(195, 44);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close Application";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRaceReports
            // 
            this.btnRaceReports.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaceReports.ForeColor = System.Drawing.Color.Black;
            this.btnRaceReports.Location = new System.Drawing.Point(614, 481);
            this.btnRaceReports.Name = "btnRaceReports";
            this.btnRaceReports.Size = new System.Drawing.Size(281, 44);
            this.btnRaceReports.TabIndex = 11;
            this.btnRaceReports.Text = "Race Reports";
            this.btnRaceReports.UseVisualStyleBackColor = true;
            this.btnRaceReports.Click += new System.EventHandler(this.btnRaceReports_Click);
            // 
            // HotTipsterUpDateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 532);
            this.Controls.Add(this.btnRaceReports);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstDisplayUpdateView);
            this.Controls.Add(this.grpAdd_Modify);
            this.Controls.Add(this.lblHotTipsterUpdateHeader);
            this.Controls.Add(this.grpExternalRecords);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HotTipsterUpDateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotTipster Results Update View";
            this.grpExternalRecords.ResumeLayout(false);
            this.grpAdd_Modify.ResumeLayout(false);
            this.grpAdd_Modify.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExternalRecords;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnImportOrig;
        private System.Windows.Forms.Label lblHotTipsterUpdateHeader;
        private System.Windows.Forms.GroupBox grpAdd_Modify;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateRaceResult;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.Button btnAddNewRace;
        private System.Windows.Forms.ComboBox cboResult;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpRaceDate;
        private System.Windows.Forms.ComboBox cboRaceCourse;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblRaceDate;
        private System.Windows.Forms.Label lblRaceCourse;
        private System.Windows.Forms.ListBox lstDisplayUpdateView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRaceReports;
    }
}

