using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.Core.Data;

namespace Ivs.Controls.Forms
{
    public partial class InfomationForm : IVSForm
    {
        #region Properties

        protected virtual IDto Dto
        {
            get;
            set;
        }

        protected virtual MessageBoxs MessageBox
        {
            get;
            set;
        }

        protected override string FunctionId
        {
            get;
            set;
        }

        public virtual CommonData.MessageTypeResult MsgTypeResult
        {
            get;
            set;
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = new Dictionary<object, string>();
                lstControls.Add(this.btnOK, btnOK.Name);
                lstControls.Add(this.btnCancel, btnCancel.Name);
                return lstControls;
            }
        }

        #endregion Properties

        public InfomationForm()
        {
            InitializeComponent();
        }

        #region Methods

        protected virtual void InitControl()
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;

            #region Events

            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            #endregion
        }

        public override void InitLanguage(string lang, bool isSetCulture = true)
        {
            base.InitLanguage(lang, isSetCulture);
            SetLanguage();
        }

        /// <summary>
        /// Set language for Title, Path, Grid
        /// </summary>
        public virtual void SetLanguage()
        {
            if (this.MessageBox != null)
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;

            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.F11)
            {
                this.btnOK.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Events


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.MsgTypeResult = CommonData.MessageTypeResult.Cancel;
            this.Close();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == CommonData.IsValid.Successful)
            {
                this.lblErrorMessage.Text = CommonData.StringEmpty;
                this.MsgTypeResult = CommonData.MessageTypeResult.OK;
                this.Close();
            }
        }

        #endregion
    }
}
