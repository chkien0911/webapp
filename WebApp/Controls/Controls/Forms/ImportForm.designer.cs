
using Ivs.Controls.CustomControls.WinForm;
namespace Ivs.Controls.Forms
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.lblPath_Import = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblName = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.chkOverWire = new Ivs.Controls.CustomControls.WinForm.IvsCheckEdit();
            this.btnChoosePath = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.txtPath = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.ivsPanel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnOK = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.ivsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkOverWire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.ivsPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPath_Import
            // 
            resources.ApplyResources(this.lblPath_Import, "lblPath_Import");
            this.lblPath_Import.Name = "lblPath_Import";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.chkOverWire);
            this.ivsPanel1.Controls.Add(this.btnChoosePath);
            this.ivsPanel1.Controls.Add(this.txtPath);
            this.ivsPanel1.Controls.Add(this.lblName);
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
            this.ivsPanel1.Name = "ivsPanel1";
            // 
            // chkOverWire
            // 
            resources.ApplyResources(this.chkOverWire, "chkOverWire");
            this.chkOverWire.Name = "chkOverWire";
            this.chkOverWire.Properties.Caption = resources.GetString("chkOverWire.Properties.Caption");
            // 
            // btnChoosePath
            // 
            resources.ApplyResources(this.btnChoosePath, "btnChoosePath");
            this.btnChoosePath.Name = "btnChoosePath";
            // 
            // txtPath
            // 
            this.txtPath.IsCurrency = false;
            this.txtPath.IsNumberic = false;
            this.txtPath.IsNumOfDay = false;
            this.txtPath.IsPositiveNumber = false;
            this.txtPath.IsPositivePercentage = false;
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            this.txtPath.NumOfDecimalPlaces = 0;
            // 
            // ivsPanel2
            // 
            this.ivsPanel2.Controls.Add(this.btnOK);
            this.ivsPanel2.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.ivsPanel2, "ivsPanel2");
            this.ivsPanel2.Name = "ivsPanel2";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // ImportForm
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ImportForm.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CloseBox = false;
            this.Controls.Add(this.ivsPanel1);
            this.Controls.Add(this.ivsPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.ShowIcon = false;
            this.ivsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkOverWire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ivsPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected IvsLabelControl lblPath_Import;
        protected IvsLabelControl lblName;
        protected IvsPanel ivsPanel1;
        protected IvsButton btnChoosePath;
        protected IvsTextEdit txtPath;
        protected IvsPanel ivsPanel2;
        protected IvsButton btnCancel;
        protected IvsButton btnOK;
        protected IvsCheckEdit chkOverWire;
    }
}