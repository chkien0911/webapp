using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using Ivs.Core.Common;
using Ivs.BLL.Common;
using Ivs.Controls.Forms;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class SHAdjustment01UC : StockUserControl
    {
        #region Private variables

        public string ProcessType { get; set; }
        #endregion

        #region Contructions
        public SHAdjustment01UC()
        {
            InitializeComponent();
            //Set language for controls
            this.SetLanguage();
        }
        #endregion

        #region Properties

        public override IDto ControlDto
        {
            get
            {

                if (!DesignMode)
                {
                    this.Reset();
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.ShippingDateCtrl = lblDocumentDate.Text;
                    dto.PersonInChangeCtrl = lblPIC.Text;
                    dto.DepartmentCodeCtrl = lblDepartment.Text;
                    return dto;
                }
                return null;
            }
        }

        /// <summary>
        /// override Dto in IvsUserControl
        /// Get: assign value of input control to members of dto
        /// return ST_StockTransactionMasterDto
        /// Set: assign value from members of dto to input control
        /// </summary>
        public override IDto Dto
        {
            get
            {
                if (!DesignMode)
                {
                    #region Reset control

                    //this.Reset();

                    #endregion

                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.DocumentNumber = this.txtDocumentNo.Text;
                    dto.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                    dto.WarehouseCode = CommonMethod.ParseString(this.cboWarehouse.EditValue);
                    dto.WarehouseName = CommonMethod.ParseString(this.cboWarehouse.Text);
                    //dto.DocumentType = ViewMode == CommonData.Mode.New ? CommonData.DocumentType.Shipping : CommonData.DocumentType.Arriving;
                    dto.DocumentType = CommonData.DocumentType.Adjustment;
                    //dto.TransactionSubCode = ViewMode == CommonData.Mode.New ? CommonData.TransactionSubCode.SH_StockShippingAdjustment : CommonData.TransactionSubCode.SA_StockArrivingAdjustment;
                    dto.TransactionSubCode = this.IsMinus ? CommonData.TransactionSubCode.SH_StockShippingAdjustment : CommonData.TransactionSubCode.SA_StockArrivingAdjustment;
                    dto.ArrivingDate = ViewMode == CommonData.Mode.New ? null : CommonMethod.ParseDateAllowNull(this.dtpDocumentDate.EditValue);
                    dto.ShippingDate = ViewMode == CommonData.Mode.Edit ? null : CommonMethod.ParseDateAllowNull(this.dtpDocumentDate.EditValue);

                    //dto.ShippingDate = CommonMethod.ParseDate(this.dtpDocumentDate.EditValue);
                    dto.PersonInChange = CommonMethod.ParseString(this.cboPIC.EditValue);
                    dto.WarehouseName = CommonMethod.ParseString(this.cboWarehouse.Text);
                    dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPerson.EditValue);
                    dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDate.EditValue);
                    dto.Description = txtRemark.Text;
                   
                    return dto;
                }
                return null;
                //return this.Dto;
            }
            set
            {
                if (!DesignMode)
                {
                    if (value != null)
                    {
                        ST_StockTransactionMasterDto dto = (ST_StockTransactionMasterDto)value;
                        this.cboDepartment.EditValue = dto.DepartmentCode;
                        this.cboWarehouse.EditValue = dto.WarehouseCode;
                        //if (this.ViewMode == CommonData.Mode.New || this.ViewMode == CommonData.Mode.Edit)
                        //{
                        //    CommonBl commonBl = new CommonBl();
                        //    //this.txtDocumentNo.Text = commonBl.GetDocumentNo(CommonMethod.ParseString(this.cboDocumentType.EditValue));
                        //    this.txtDocumentNo.Text = CommonData.StringEmpty;
                        //    this.dtpPostedDate.EditValue = CommonBl.GetSystemDate();
                        //    this.dtpDocumentDate.EditValue = CommonBl.GetSystemDate();
                        //    this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                        //}
                        //else 
                        //{
                        this.txtDocumentNo.Text = dto.DocumentNumber;
                        this.dtpPostedDate.EditValue = dto.PostedDate;
                        this.dtpDocumentDate.EditValue = dto.TransactionSubCode == CommonData.TransactionSubCode.SH_StockShippingAdjustment ? dto.ShippingDate : dto.ArrivingDate;
                        this.cboPostedPerson.EditValue = dto.PostedPerson;
                       
                
                        //}

                        this.cboPIC.EditValue = dto.PersonInChange;
                        this.txtRemark.Text = dto.Description;
                    }
                    else
                    {
                        this.cboPIC.EditValue = CommonData.StringEmpty;

                        this.dtpDocumentDate.EditValue = CommonData.StringEmpty;
                        this.cboPIC.EditValue = CommonData.StringEmpty;
                        this.txtRemark.Text = CommonData.StringEmpty;
                    }
                }
            }
        }

        public MasterSearchForm FormItem { get; set; }

        private bool _isMinus;
        public bool IsMinus { get { return _isMinus; } set {
            _isMinus = value;
            rdoPlus.Checked = !value;
            rdoMinus.Checked = value;
        } }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();

            #region Events

            this.cboDepartment.EditValueChanged += new EventHandler(cboDepartment_EditValueChanged);
          
            btnAddItem.Click += new EventHandler(AddItem);
            this.dtpDocumentDate.Properties.MaxValue = CommonBl.GetSystemDate();
            this.SetControl();

            #endregion

            ProcessType = CommonData.ProcessType.RM;
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox
            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboPostedPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPIC.Code = CommonData.FunctionGr.MS_Employee;
            #endregion
        }
        //void dtpDate_EditValueChanged(object sender, EventArgs e)
        //{
        //    IvsDateEdit dtpDate = (IvsDateEdit)sender;
        //    if (CommonMethod.ParseDate(dtpDate.EditValue) > CommonBl.GetSystemDate())
        //        dtpDate.EditValue = CommonBl.GetSystemDate();
        //}

        /// <summary>
        /// Set controls
        /// </summary>
        public override void SetControl()
        {
            #region Clear error
            ClearError();
            #endregion

            #region Show/Hide controls
            txtDocumentType.Visible =IsMinus;
            txtDocumentType2.Visible = !IsMinus;
            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPIC.Enabled = false;
                this.rdoPlus.Enabled = false;
                this.rdoMinus.Enabled = false;
                this.txtDocumentNo.Enabled = false;
                this.cboPostedPerson.Enabled = false;

                if (IsMinus)
                {
                    this.rdoMinus.Checked = true;
                    this.rdoPlus.Checked = false;

                }
                else
                {
                    this.rdoPlus.Checked = true;
                    this.rdoMinus.Checked = false;
                }

                this.pnlType.Enabled = false;
                this.dtpDocumentDate.Enabled = false;
                this.txtRemark.Enabled = false;
              
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.rdoPlus.Enabled = false;
                this.rdoMinus.Enabled = false;
                this.txtDocumentNo.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                if (IsMinus)
                {
                    this.rdoMinus.Checked = true;
                    this.rdoPlus.Checked = false;

                }
                else
                {
                    this.rdoPlus.Checked = true;
                    this.rdoMinus.Checked = false;
                }

               
                this.pnlType.Enabled = false;
                this.dtpDocumentDate.Enabled = true;
                this.cboPIC.Enabled = true;
                this.txtRemark.Enabled = true;

               
            }
            else
            {
              
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.rdoPlus.Enabled = false;
                this.rdoMinus.Enabled = false;
                this.txtDocumentNo.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                if (IsMinus)
                {
                    this.rdoMinus.Checked = true;
                    this.rdoPlus.Checked = false;

                }
                else
                {
                    this.rdoPlus.Checked = true;
                    this.rdoMinus.Checked = false;
                }

                this.pnlType.Enabled = true;
                this.dtpDocumentDate.Enabled = true;
                this.cboPIC.Enabled = true;
                this.txtRemark.Enabled = true;

               
            }

            #endregion
        }

        /// <summary>
        /// Clear error for controls
        /// </summary>
        public override void ClearError()
        {
            this.cboDepartment.ClearErrors();
            this.cboWarehouse.ClearErrors();
            this.txtDocumentNo.ClearErrors();
            this.dtpDocumentDate.ClearErrors();
            this.cboPIC.ClearErrors();
        }

        /// <summary>
        /// Set error for controls
        /// </summary>
        public override void SetError(string errorFieldName, string errorText)
        {
            switch (errorFieldName)
            {
                case CommonKey.AdjustedDate:
                    this.dtpDocumentDate.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.dtpDocumentDate.Focus();
                        this.IsFocusControl = true;
                    }
                    break;
                case CommonKey.AdjustedPerson:
                    this.cboPIC.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboPIC.Focus();
                        this.IsFocusControl = true;
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Set language for controls
        /// </summary>
        public override void SetLanguage()
        {
            this.Reset();
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        public override void Reset()
        {
            this.cboDepartment.Reset();
            this.cboWarehouse.Reset();
            this.txtDocumentType.Reset();
            this.dtpPostedDate.Reset();
            this.dtpDocumentDate.Reset();
        }

        protected void AddItem(object sender, EventArgs e)
        {
            if (FormItem != null)
                FormItem.ShowDialog();
        }
        #endregion

        #region Events

        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (!CommonMethod.IsNullOrEmpty(this.cboDepartment.EditValue))
            {
                this.cboPIC.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                this.cboPIC.Code = CommonData.FunctionGr.MS_Employee;
            }
        }

        #endregion

    }
}
