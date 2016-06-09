using System.Windows.Forms;
using Ivs.Core.Common;

namespace Ivs.Controls.Forms
{
    public partial class RestoreForm : Ivs.Controls.Forms.BackupForm
    {
        public RestoreForm()
        {
            InitializeComponent();
            this.Name = "SYRT00Form";
            this.btnAdvance.Visible = false;
            this.SetLanguage();
            SetAuthorityControlOnlyThis();
        }

        protected override bool isBackup
        {
            get
            {
                return false;
            }
        }

        protected override string FunctionId
        {
            get
            {
                return CommonData.FunctionId.SYRT00;
            }
        }

        protected override string FunctionGr
        {
            get
            {
                return CommonData.FunctionGr.Syrt;
            }
        }

        /// <summary>
        /// Override ChooosePath method in BackupForm
        /// </summary>
        protected override void ChoosePath()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = this.GetFilterFile();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = file.FileName;
            }
        }

        private void SetAuthorityControlOnlyThis()
        {
            if (this.IsAuthority(CommonData.OperId.Restore) == CommonData.IsAuthority.Deny)
            {
                btnOK.Enabled = false;
            }
        }
    }
}