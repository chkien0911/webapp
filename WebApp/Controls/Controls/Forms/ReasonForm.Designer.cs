namespace Ivs.Controls.Forms
{
    partial class ReasonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReasonForm));
            this.dtpDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.ivsLabelControl1 = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblInfomation = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnOK = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.txtReason = new Ivs.Controls.CustomControls.WinForm.IvsMemoEdit();
            this.lblReason = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.ivsLabelControl1);
            this.panel2.Controls.Add(this.lblInfomation);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.txtReason);
            this.panel2.Controls.Add(this.lblReason);
            resources.ApplyResources(this.panel2, "panel2");
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.BorderColor")));
            this.lblErrorMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblErrorMessage.Appearance.Font")));
            this.lblErrorMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.ForeColor")));
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            // 
            // dtpDate
            // 
            resources.ApplyResources(this.dtpDate, "dtpDate");
            this.dtpDate.IsFormatDate = false;
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpDate.Properties.Buttons"))))});
            this.dtpDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // ivsLabelControl1
            // 
            this.ivsLabelControl1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("ivsLabelControl1.Appearance.ForeColor")));
            resources.ApplyResources(this.ivsLabelControl1, "ivsLabelControl1");
            this.ivsLabelControl1.Name = "ivsLabelControl1";
            // 
            // lblInfomation
            // 
            resources.ApplyResources(this.lblInfomation, "lblInfomation");
            this.lblInfomation.Name = "lblInfomation";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            // 
            // txtReason
            // 
            resources.ApplyResources(this.txtReason, "txtReason");
            this.txtReason.Name = "txtReason";
            this.txtReason.Properties.MaxLength = 200;
            // 
            // lblReason
            // 
            resources.ApplyResources(this.lblReason, "lblReason");
            this.lblReason.Name = "lblReason";
            // 
            // ReasonForm
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ReasonForm.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ReasonForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.WinForm.IvsDateEdit dtpDate;
        private CustomControls.WinForm.IvsLabelControl lblDate;
        private CustomControls.WinForm.IvsLabelControl ivsLabelControl1;
        private CustomControls.WinForm.IvsLabelControl lblInfomation;
        private CustomControls.WinForm.IvsButton btnCancel;
        private CustomControls.WinForm.IvsButton btnOK;
        private CustomControls.WinForm.IvsMemoEdit txtReason;
        private CustomControls.WinForm.IvsLabelControl lblReason;

    }
}