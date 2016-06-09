namespace Ivs.Controls.Forms
{
    partial class SYBK01Form
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
            this.grcFrequency = new Ivs.Controls.CustomControls.WinForm.IvsGroupControl();
            this.chkListMonth = new Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl();
            this.chkListDaily = new Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl();
            this.rdoDaily = new Ivs.Controls.CustomControls.WinForm.IvsRadioGroup();
            this.grcTimeFrequency = new Ivs.Controls.CustomControls.WinForm.IvsGroupControl();
            this.tedTime = new Ivs.Controls.CustomControls.WinForm.IvsTimeEdit();
            this.lblTime = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDescription = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblDescription = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnStop = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnOk = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.ivsPanel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnFolderPath = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.txtFolderPath = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblFolder = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcFrequency)).BeginInit();
            this.grcFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDaily.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTimeFrequency)).BeginInit();
            this.grcTimeFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.ivsPanel1.SuspendLayout();
            this.ivsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolderPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcFrequency
            // 
            this.grcFrequency.Controls.Add(this.chkListMonth);
            this.grcFrequency.Controls.Add(this.chkListDaily);
            this.grcFrequency.Controls.Add(this.rdoDaily);
            this.grcFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcFrequency.Location = new System.Drawing.Point(0, 0);
            this.grcFrequency.Name = "grcFrequency";
            this.grcFrequency.Size = new System.Drawing.Size(528, 212);
            this.grcFrequency.TabIndex = 0;
            this.grcFrequency.Text = "Frequency";
            // 
            // chkListMonth
            // 
            this.chkListMonth.CheckOnClick = true;
            //this.chkListMonth.Code = global::ScreenDisplay_JP.HRCT01Form_lblPlaceOfWrk;
            this.chkListMonth.Enabled = false;
            this.chkListMonth.Location = new System.Drawing.Point(263, 70);
            this.chkListMonth.Name = "chkListMonth";
            this.chkListMonth.Size = new System.Drawing.Size(253, 125);
            this.chkListMonth.TabIndex = 2;
            // 
            // chkListDaily
            // 
            this.chkListDaily.CheckOnClick = true;
            //this.chkListDaily.Code = global::ScreenDisplay_JP.HRCT01Form_lblPlaceOfWrk;
            this.chkListDaily.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("M", "Monday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("T", "Tuesday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("W", "Wednesday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("TH", "Thursday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("F", "Friday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("S", "Saturday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("SU", "Sunday")});
            this.chkListDaily.Location = new System.Drawing.Point(12, 70);
            this.chkListDaily.Name = "chkListDaily";
            this.chkListDaily.Size = new System.Drawing.Size(236, 125);
            this.chkListDaily.TabIndex = 1;
            // 
            // rdoDaily
            // 
            this.rdoDaily.Location = new System.Drawing.Point(12, 35);
            this.rdoDaily.Name = "rdoDaily";
            this.rdoDaily.Properties.Appearance.Options.UseBorderColor = true;
            this.rdoDaily.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.rdoDaily.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Daily"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Month")});
            this.rdoDaily.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdoDaily.Size = new System.Drawing.Size(505, 29);
            this.rdoDaily.TabIndex = 0;
            // 
            // grcTimeFrequency
            // 
            this.grcTimeFrequency.Controls.Add(this.tedTime);
            this.grcTimeFrequency.Controls.Add(this.lblTime);
            this.grcTimeFrequency.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grcTimeFrequency.Location = new System.Drawing.Point(0, 212);
            this.grcTimeFrequency.Name = "grcTimeFrequency";
            this.grcTimeFrequency.Size = new System.Drawing.Size(528, 61);
            this.grcTimeFrequency.TabIndex = 1;
            this.grcTimeFrequency.Text = "Daily Frequency";
            // 
            // tedTime
            // 
            this.tedTime.EditValue = new System.DateTime(2012, 11, 18, 0, 0, 0, 0);
            this.tedTime.Location = new System.Drawing.Point(93, 30);
            this.tedTime.Name = "tedTime";
            this.tedTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.tedTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tedTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.tedTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedTime.Properties.EditFormat.FormatString = "HH:mm";
            this.tedTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedTime.Size = new System.Drawing.Size(155, 20);
            this.tedTime.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(12, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(22, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(92, 39);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(424, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 42);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.btnStop);
            this.ivsPanel1.Controls.Add(this.btnCancel);
            this.ivsPanel1.Controls.Add(this.btnOk);
            this.ivsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ivsPanel1.Location = new System.Drawing.Point(0, 349);
            this.ivsPanel1.Name = "ivsPanel1";
            this.ivsPanel1.Size = new System.Drawing.Size(528, 36);
            this.ivsPanel1.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(361, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.Enabled = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(442, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(280, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Start";
            this.btnOk.Enabled = false;
            // 
            // ivsPanel2
            // 
            this.ivsPanel2.Controls.Add(this.btnFolderPath);
            this.ivsPanel2.Controls.Add(this.txtFolderPath);
            this.ivsPanel2.Controls.Add(this.lblFolder);
            this.ivsPanel2.Controls.Add(this.lblDescription);
            this.ivsPanel2.Controls.Add(this.txtDescription);
            this.ivsPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ivsPanel2.Location = new System.Drawing.Point(0, 273);
            this.ivsPanel2.Name = "ivsPanel2";
            this.ivsPanel2.Size = new System.Drawing.Size(528, 76);
            this.ivsPanel2.TabIndex = 2;
            // 
            // btnFolderPath
            // 
            this.btnFolderPath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFolderPath.Location = new System.Drawing.Point(442, 13);
            this.btnFolderPath.Name = "btnFolderPath";
            this.btnFolderPath.Size = new System.Drawing.Size(75, 20);
            this.btnFolderPath.TabIndex = 0;
            this.btnFolderPath.Text = "...";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(92, 13);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Properties.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(344, 20);
            this.txtFolderPath.TabIndex = 5;
            this.txtFolderPath.TabStop = false;
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(12, 16);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(30, 13);
            this.lblFolder.TabIndex = 4;
            this.lblFolder.Text = "Folder";
            // 
            // SYBK01Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 385);
            this.Controls.Add(this.grcFrequency);
            this.Controls.Add(this.grcTimeFrequency);
            this.Controls.Add(this.ivsPanel2);
            this.Controls.Add(this.ivsPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SYBK01Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupSchedulingForm";
            ((System.ComponentModel.ISupportInitialize)(this.grcFrequency)).EndInit();
            this.grcFrequency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkListMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDaily.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTimeFrequency)).EndInit();
            this.grcTimeFrequency.ResumeLayout(false);
            this.grcTimeFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ivsPanel1.ResumeLayout(false);
            this.ivsPanel2.ResumeLayout(false);
            this.ivsPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolderPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ivs.Controls.CustomControls.WinForm.IvsGroupControl grcFrequency;
        private Ivs.Controls.CustomControls.WinForm.IvsGroupControl grcTimeFrequency;
        private Ivs.Controls.CustomControls.WinForm.IvsPanel ivsPanel1;
        private Ivs.Controls.CustomControls.WinForm.IvsButton btnCancel;
        private Ivs.Controls.CustomControls.WinForm.IvsButton btnOk;
        private Ivs.Controls.CustomControls.WinForm.IvsRadioGroup rdoDaily;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lblDescription;
        private Ivs.Controls.CustomControls.WinForm.IvsTimeEdit tedTime;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lblTime;
        private Ivs.Controls.CustomControls.WinForm.IvsTextEdit txtDescription;
        private Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl chkListDaily;
        private Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl chkListMonth;
        private Ivs.Controls.CustomControls.WinForm.IvsPanel ivsPanel2;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lblFolder;
        private Ivs.Controls.CustomControls.WinForm.IvsButton btnFolderPath;
        private Ivs.Controls.CustomControls.WinForm.IvsTextEdit txtFolderPath;
        private Ivs.Controls.CustomControls.WinForm.IvsButton btnStop;
    }
}