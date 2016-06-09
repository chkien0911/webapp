namespace Ivs.Controls.Forms
{
    partial class ProcessingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessingForm));
            this.listViewProgress = new Ivs.Controls.CustomControls.WinForm.IvsListView();
            this.colProgress = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // listViewProgress
            // 
            this.listViewProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDate,
            this.colProgress});
            this.listViewProgress.Location = new System.Drawing.Point(12, 12);
            this.listViewProgress.Name = "listViewProgress";
            this.listViewProgress.Size = new System.Drawing.Size(605, 364);
            this.listViewProgress.TabIndex = 0;
            this.listViewProgress.UseCompatibleStateImageBehavior = false;
            this.listViewProgress.View = System.Windows.Forms.View.Details;
            // 
            // colProgress
            // 
            this.colProgress.Text = "Process";
            this.colProgress.Width = 150;
            this.colProgress.Name = "colProgress";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 250;
            this.colName.Name = "colName";
            // 
            // colDate
            // 
            this.colDate.Text = "Create date";
            this.colDate.Width = 200;
            this.colDate.Name = "colDate";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Server Processing";
            this.notifyIcon1.BalloonTipTitle = "Server Task";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("icon")));
            this.notifyIcon1.Text = "Server Processing";
            this.notifyIcon1.Visible = true;
            // 
            // ProcessingForm
            // 
            this.ClientSize = new System.Drawing.Size(629, 388);
            this.Controls.Add(this.listViewProgress);
            this.Name = "ProcessingForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colProgress;
        private Ivs.Controls.CustomControls.WinForm.IvsListView listViewProgress;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ColumnHeader colDate;


    }
}
