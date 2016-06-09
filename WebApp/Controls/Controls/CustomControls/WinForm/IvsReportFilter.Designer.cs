namespace Ivs.Controls.CustomControls.WinForm
{
    partial class IvsReportFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.SuspendLayout();
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivsPanel1.Location = new System.Drawing.Point(0, 0);
            this.ivsPanel1.Name = "ivsPanel1";
            this.ivsPanel1.Size = new System.Drawing.Size(850, 70);
            this.ivsPanel1.TabIndex = 0;
            // 
            // IvsFilterReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ivsPanel1);
            this.Name = "IvsFilterReports";
            this.Size = new System.Drawing.Size(850, 70);
            this.ResumeLayout(false);

        }

        #endregion

        protected IvsPanel ivsPanel1;
    }
}
