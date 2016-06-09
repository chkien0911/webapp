using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using System;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class STNGRecycleMaterial01UC : StockUserControl
    {
        #region Properties

        public override IDto ControlDto
        {
            get
            {
                if (!DesignMode)
                {
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.DepartmentCodeCtrl = lblDepartment.Text;
                    dto.WarehouseCodeCtrl = lblWarehouse.Text;
                    dto.PostedDateCtrl = lblPostedDate.Text;
                    dto.PostedPersonCtrl = lblPostedPerson.Text;
                    //dto.ShippingDateCtrl = lblTransferDate.Text;
                    dto.TransferDateCtrl = lblTransferDate.Text;
                    dto.PersonInChangeCtrl = lblTransferPerson.Text;                                        
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

                    #endregion Reset control

                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.DocumentNumber = this.txtDocumentNo.Text;
                    dto.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                    dto.WarehouseCode = CommonMethod.ParseString(this.cboWarehouse.EditValue);
                    dto.DocumentType = CommonData.DocumentType.Transfer;
                    dto.TransactionSubCode = CommonData.TransactionSubCode.ST_NGRecycledMaterials;
                    //dto.DocumentDate = CommonMethod.ParseDateTime(this.dtpTransferDate.EditValue);
                    dto.ShippingDate = CommonMethod.ParseDate(this.dtpTransferDate.EditValue);
                    dto.PersonInChange = CommonMethod.ParseString(this.cboTransferPerson.EditValue);
                    dto.WarehouseName = CommonMethod.ParseString(this.cboWarehouse.Text);
                    dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPerson.EditValue);
                    dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDate.EditValue);
                    dto.Description = this.txtDescription.Text;

                    return dto;
                }
                return null;
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

                        if (this.ViewMode == CommonData.Mode.New)
                        {
                            CommonBl commonBl = new CommonBl();
                            this.txtDocumentNo.Text = commonBl.GetDocumentNo(CommonData.TransactionSubCode.ST_NGRecycledMaterials);
                            this.dtpPostedDate.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpTransferDate.EditValue = CommonBl.GetSystemDate();                  
                        }
                        else
                        {
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = dto.PostedDate;
                            this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpTransferDate.EditValue = dto.ShippingDate;                        
                        }
                        
                        this.cboTransferPerson.EditValue = dto.PersonInChange;

                        //if (!CommonMethod.IsNullOrEmpty(dto.DeliverySheetPrintFlg))
                        //{
                        int intCount = (dto.DeliverySheetPrintCount ?? 0);
                        this.txtPrintCount.Text = CommonMethod.ParseString(intCount);
                        if (intCount > 1)
                        {
                            this.txtPrintReason.Visible = true;
                            this.txtPrintReason.Text = dto.DeliverySheetRePrintReason;
                        }
                        else
                        {
                            this.txtPrintReason.Visible = false;
                        }
                        //}
                        //else
                        //{
                        //    this.txtPrintCount.Text = "0";
                        //    this.txtPrintReason.Visible = false;
                        //}
                        
                        this.txtDescription.Text = dto.Description;
                    }
                    else
                    {
                        this.dtpTransferDate.EditValue = CommonBl.GetSystemDate();
                        this.cboTransferPerson.EditValue = CommonData.StringEmpty;
                        this.txtDescription.Text = CommonData.StringEmpty;
                    }
                }
            }
        }

        #endregion Properties

        #region Contructions

        public STNGRecycleMaterial01UC()
        {
            InitializeComponent();

            //Set language for controls
            this.SetLanguage();
        }

        #endregion Contructions

        #region Methods

        /// <summary>
        /// Initalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();
            #region Events

            this.cboDepartment.EditValueChanged += new EventHandler(cboDepartment_EditValueChanged);
            this.dtpTransferDate.Properties.MaxValue = CommonBl.GetSystemDate();
            #endregion
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox
            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboTransferPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPostedPerson.Code = CommonData.FunctionGr.MS_Employee;
            #endregion Set data to combobox
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

            this.ClearError();

            #endregion Clear error

            #region Show/Hide controls

            this.lblPrinted.Visible = !(this.ViewMode == CommonData.Mode.Edit);
            this.txtPrintReason.Visible = (this.ViewMode == CommonData.Mode.View);
            this.txtPrintCount.Visible = !(this.ViewMode == CommonData.Mode.Edit);
            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpTransferDate.Enabled = false;
                this.cboTransferPerson.Enabled = false;
                this.txtDescription.Enabled = false;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpTransferDate.Enabled = true;
                this.cboTransferPerson.Enabled = true;
                this.txtDescription.Enabled = true;

                this.dtpTransferDate.Select();
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpTransferDate.Enabled = true;
                this.cboTransferPerson.Enabled = true;
                this.txtDescription.Enabled = true;

                this.dtpTransferDate.Select();
            }

            #endregion Show/Hide controls
        }

        /// <summary>
        /// Clear error for controls
        /// </summary>
        public override void ClearError()
        {
            this.cboDepartment.ClearErrors();
            this.cboWarehouse.ClearErrors();

            this.txtDocumentNo.ClearErrors();
            this.dtpTransferDate.ClearErrors();
            this.cboTransferPerson.ClearErrors();
        }

        /// <summary>
        /// Set error for controls
        /// </summary>
        public override void SetError(string errorFieldName, string errorText)
        {
            switch (errorFieldName)
            {
                case CommonKey.DocumentNumber:
                    this.txtDocumentNo.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.txtDocumentNo.Focus();
                        this.IsFocusControl = true;
                    }
                    break;

                case CommonKey.ShippingDate:
                    this.dtpTransferDate.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.dtpTransferDate.Focus();
                        this.IsFocusControl = true;
                    }
                    break;

                case CommonKey.ShippingPerson:
                    this.cboTransferPerson.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboTransferPerson.Focus();
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
            this.dtpPostedDate.Reset();
            this.dtpTransferDate.Reset();
            this.cboTransferPerson.Reset();
            this.cboPostedPerson.Reset();
        }

        #endregion Methods

        #region Events

        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (!CommonMethod.IsNullOrEmpty(this.cboDepartment.EditValue))
            {
                this.cboTransferPerson.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                this.cboTransferPerson.Code = CommonData.FunctionGr.MS_Employee;
            }
        }

        #endregion
    }
}