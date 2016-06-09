namespace Ivs.Controls.Forms
{
    partial class InfomationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfomationForm));
            this.pnlErr = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.lblErrorMessage = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.pnlMain = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnOK = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.pnlErr.SuspendLayout();
            this.ivsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlErr
            // 
            this.pnlErr.Controls.Add(this.lblErrorMessage);
            resources.ApplyResources(this.pnlErr, "pnlErr");
            this.pnlErr.Name = "pnlErr";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.BorderColor")));
            this.lblErrorMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblErrorMessage.Appearance.Font")));
            this.lblErrorMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.ForeColor")));
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            this.lblErrorMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblErrorMessage.Name = "lblErrorMessage";
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.btnCancel);
            this.ivsPanel1.Controls.Add(this.btnOK);
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
            this.ivsPanel1.Name = "ivsPanel1";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            // 
            // InfomationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ivsPanel1);
            this.Controls.Add(this.pnlErr);
            this.MaximizeBox = false;
            this.Name = "InfomationForm";
            this.ShowIcon = false;
            this.pnlErr.ResumeLayout(false);
            this.ivsPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.WinForm.IvsPanel pnlErr;
        protected CustomControls.WinForm.IvsLabelControl lblErrorMessage;
        protected CustomControls.WinForm.IvsPanel pnlMain;
        private CustomControls.WinForm.IvsSimpleButton btnCancel;
        private CustomControls.WinForm.IvsSimpleButton btnOK;
        protected CustomControls.WinForm.IvsPanel ivsPanel1;
    }
}