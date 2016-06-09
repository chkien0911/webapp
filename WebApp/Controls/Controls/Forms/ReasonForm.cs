using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.BLL.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.DTO.Common;

namespace Ivs.Controls.Forms
{
    public partial class ReasonForm : Ivs.Controls.Forms.MasterEditForm
    {
        #region Properties

        public string Reason { get; set; }
        public DateTime Date { get; set; }

        #endregion

        #region Override properties

        /// <summary>
        /// Override Function Id
        /// </summary>
        protected override string FunctionId
        {
            get
            {
                return CommonData.FunctionId.ReasonForm;
            }
        }

        protected override string  FunctionGr
        {
            get
            {
                return CommonData.FunctionGr.Reason;
            }
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = base.LstControls;
                lstControls.Add(this.lblInfomation, lblInfomation.Name);
                lstControls.Add(this.lblReason, lblReason.Name);
                lstControls.Add(this.lblDate, lblDate.Name);
                lstControls.Add(this.btnOK, btnOK.Name);
                lstControls.Add(this.btnCancel, btnCancel.Name);
                
                return lstControls;

            }
        }

        /// <summary>
        /// override Dto in MasterSearchForm
        /// return MSOF00Dto
        /// set OfficeCode in MSOFDto = txtCode.Text
        /// set OfficeNameVn in MSOFDto = txtName1.Text
        /// set OfficeNameEn in MSOFDto = txtName2.Text
        /// set OfficeNameJp in MSOFDto = txtName3.Text
        /// </summary>
        protected override IDto Dto
        {
            get
            {
                ST_StockTransactionMasterDetailDto dto = new ST_StockTransactionMasterDetailDto();
                return dto;
            }
            set
            {
                ;
            }
        }

        public override void SetLanguage()
        {
            base.SetLanguage();

            this.dtpDate.Reset();
        }

        #endregion

        public ReasonForm()
        {
            InitializeComponent();

            this.InitControl();
        }

        #region Override methods

        protected override void InitControl()
        {
            base.InitControl();
            this.bar2.Visible = false;
            this.bar3.Visible = false;
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            this.dtpDate.EditValue = CommonBl.GetSystemDate();
            this.txtReason.Focus();
        }

        protected override bool IsFormChanged()
        {
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }
            if (keyData == System.Windows.Forms.Keys.F11)
            {
                this.btnOK.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.MsgTypeResult = CommonData.MessageTypeResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == CommonData.IsValid.Failed)
            {
                return;
            }

            this.Date = CommonMethod.ParseDateTime(this.dtpDate.EditValue);
            this.Reason = this.txtReason.Text;
            this.MsgTypeResult = CommonData.MessageTypeResult.OK;
            this.Close();
        }

        protected override CommonData.IsValid ValidateData()
        {
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;

            this.txtReason.ClearErrors();

            if (CommonMethod.IsNullOrEmpty(this.txtReason.Text))
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, this.lblReason.Text);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.txtReason.SetError(message.MessageText);
                this.txtReason.Focus();
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return CommonData.IsValid.Failed;
            }
            return CommonData.IsValid.Successful;
        }
        #endregion
    }
}
