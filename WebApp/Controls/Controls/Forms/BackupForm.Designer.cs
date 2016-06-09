namespace Ivs.Controls.Forms
{
    partial class BackupForm
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
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnChoosePath = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.txtPath = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblPath = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.ivsPanel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnViewLog = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnAdvance = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.btnOK = new Ivs.Controls.CustomControls.WinForm.IvsButton();
            this.ivsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.ivsPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.btnChoosePath);
            this.ivsPanel1.Controls.Add(this.txtPath);
            this.ivsPanel1.Controls.Add(this.lblPath);
            this.ivsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivsPanel1.Location = new System.Drawing.Point(0, 0);
            this.ivsPanel1.Name = "ivsPanel1";
            this.ivsPanel1.Size = new System.Drawing.Size(696, 50);
            this.ivsPanel1.TabIndex = 0;
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(606, 12);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(75, 20);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "...";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(116, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(484, 20);
            this.txtPath.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(14, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(22, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path";
            // 
            // ivsPanel2
            // 
            this.ivsPanel2.Controls.Add(this.btnViewLog);
            this.ivsPanel2.Controls.Add(this.btnAdvance);
            this.ivsPanel2.Controls.Add(this.btnCancel);
            this.ivsPanel2.Controls.Add(this.btnOK);
            this.ivsPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ivsPanel2.Location = new System.Drawing.Point(0, 50);
            this.ivsPanel2.Name = "ivsPanel2";
            this.ivsPanel2.Size = new System.Drawing.Size(696, 38);
            this.ivsPanel2.TabIndex = 1;
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(116, 6);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(75, 23);
            this.btnViewLog.TabIndex = 3;
            this.btnViewLog.Text = "View log";
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(14, 6);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(96, 23);
            this.btnAdvance.TabIndex = 2;
            this.btnAdvance.Text = "Scheduled Backup";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(606, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(525, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(696, 88);
            this.Controls.Add(this.ivsPanel1);
            this.Controls.Add(this.ivsPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BackupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupForm";
            this.ivsPanel1.ResumeLayout(false);
            this.ivsPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ivsPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Ivs.Controls.CustomControls.WinForm.IvsPanel ivsPanel1;
        protected Ivs.Controls.CustomControls.WinForm.IvsPanel ivsPanel2;
        protected Ivs.Controls.CustomControls.WinForm.IvsTextEdit txtPath;
        protected Ivs.Controls.CustomControls.WinForm.IvsLabelControl lblPath;
        protected Ivs.Controls.CustomControls.WinForm.IvsButton btnChoosePath;
        protected Ivs.Controls.CustomControls.WinForm.IvsButton btnCancel;
        protected Ivs.Controls.CustomControls.WinForm.IvsButton btnOK;
        protected Ivs.Controls.CustomControls.WinForm.IvsButton btnAdvance;
        protected Ivs.Controls.CustomControls.WinForm.IvsButton btnViewLog;
    }
}