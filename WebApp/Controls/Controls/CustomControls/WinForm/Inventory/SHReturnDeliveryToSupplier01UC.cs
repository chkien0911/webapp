using System;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DTO.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class SHReturnDeliveryToSupplier01UC : StockUserControl
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
                    dto.ShippingDateCtrl = lblShippingDate.Text;
                    dto.PersonInChangeCtrl = lblShippingPerson.Text;
                    dto.SupplierCodeCtrl = lblSupplier.Text;
                    dto.QualityStatusCtrl = lblQualityStatus.Text;
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
                    dto.DocumentType = CommonData.DocumentType.Shipping;
                    dto.TransactionSubCode = CommonData.TransactionSubCode.SH_ReturnDeliveryToSupplier;
                    dto.ShippingDate = CommonMethod.ParseDate(this.dtpShippingDate.EditValue);
                    dto.PersonInChange = CommonMethod.ParseString(this.cboShippingPerson.EditValue);
                    dto.WarehouseName = CommonMethod.ParseString(this.cboWarehouse.Text);
                    dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPerson.EditValue);
                    dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDate.EditValue);
                    dto.CompanyCode = CommonMethod.ParseString(this.cboSupplier.EditValue);
                    dto.Description = this.txtDescription.Text;
                    dto.QualityStatus = CommonMethod.ParseString(this.cboQualityStatus.EditValue);

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
                            //this.txtDocumentNo.Text = commonBl.GetDocumentNo(CommonMethod.ParseString(this.cboDocumentType.EditValue));
                            //this.txtDocumentNo.Text = CommonData.StringEmpty;
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpShippingDate.EditValue = CommonBl.GetSystemDate();
                        }
                        else
                        {
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = dto.PostedDate;
                            this.cboPostedPerson.EditValue = dto.PostedPerson;
                            this.dtpShippingDate.EditValue = dto.ShippingDate;
                        }
                        this.cboQualityStatus.EditValue = dto.QualityStatus;//(dto.Details != null && dto.Details.Count > 0) ? dto.Details[0].QualityStatus : dto.QualityStatus;


                        this.cboShippingPerson.EditValue = dto.PersonInChange;
                        this.cboSupplier.EditValue = dto.CompanyCode;
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
                        this.dtpShippingDate.EditValue = CommonBl.GetSystemDate();
                        this.cboShippingPerson.EditValue = CommonData.StringEmpty;
                        this.cboSupplier.EditValue = CommonData.StringEmpty;
                        this.txtDescription.Text = CommonData.StringEmpty;
                        this.cboQualityStatus.EditValue = CommonData.StringEmpty;
                    }
                }
            }
        }

        #endregion Properties

        #region Contructions

        public SHReturnDeliveryToSupplier01UC()
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
            this.cboSupplier.EditValueChanged += new EventHandler(cboSupplier_EditValueChanged);
            this.cboQualityStatus.EditValueChanged += new EventHandler(cboQualityStatus_EditValueChanged);

            this.dtpShippingDate.Properties.MaxValue = CommonBl.GetSystemDate();
            #endregion Events
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox

            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboShippingPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPostedPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboQualityStatus.Code = CommonData.Code.QualityStatus;

            //View mode: show all company
            this.cboSupplier.Status = this.ViewMode == CommonData.Mode.View ? CommonData.StringEmpty : CommonData.Status.Enable;
            this.cboSupplier.IsSupplier = this.ViewMode == CommonData.Mode.View ? CommonData.Status.Disable : CommonData.Status.Enable;
            this.cboSupplier.Code = CommonData.FunctionGr.MS_Suppliers;

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
            //this.txtPrintReason.Visible = (this.ViewMode == CommonData.Mode.View);
            this.txtPrintCount.Visible = !(this.ViewMode == CommonData.Mode.Edit);

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = false;

                this.dtpShippingDate.Enabled = false;
                this.cboShippingPerson.Enabled = false;
                this.cboSupplier.Enabled = false;

                this.txtDescription.Enabled = false;
                this.cboQualityStatus.Enabled = false;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = false;

                this.dtpShippingDate.Enabled = true;
                this.cboShippingPerson.Enabled = true;
                this.cboSupplier.Enabled = true;
                this.txtDescription.Enabled = true;
                this.cboQualityStatus.Enabled = true;
                this.dtpShippingDate.Select();
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = false;

                this.dtpShippingDate.Enabled = true;
                this.cboShippingPerson.Enabled = true;
                this.cboSupplier.Enabled = true;
                this.txtDescription.Enabled = true;
                this.cboQualityStatus.Enabled = true;
                this.dtpShippingDate.Select();
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
            this.cboQualityStatus.ClearErrors();
            this.txtDocumentNo.ClearErrors();
            this.dtpShippingDate.ClearErrors();
            this.cboShippingPerson.ClearErrors();
            this.cboSupplier.ClearErrors();
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
                    this.dtpShippingDate.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.dtpShippingDate.Focus();
                        this.IsFocusControl = true;
                    }
                    break;

                case CommonKey.ShippingPerson:
                    this.cboShippingPerson.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboShippingPerson.Focus();
                        this.IsFocusControl = true;
                    }
                    break;

                case CommonKey.SupplierCode:
                    this.cboSupplier.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboSupplier.Focus();
                        this.IsFocusControl = true;
                    }
                    break;
                case CommonKey.QualityStatus:
                    this.cboQualityStatus.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboQualityStatus.Focus();
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
            this.cboQualityStatus.Reset();
            this.cboDepartment.Reset();
            this.cboWarehouse.Reset();
            this.cboSupplier.Reset();
            this.dtpPostedDate.Reset();
            this.dtpShippingDate.Reset();
            this.cboShippingPerson.Reset();
        }

        public event EventHandler<EventArgs> Supplier_Changed;

        // Raises a custom event, Moved
        protected void Supplier_OnChanged(object sender, EventArgs e)
        {
            var handler = Supplier_Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            Supplier_OnChanged(sender, e);
        }

        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (!CommonMethod.IsNullOrEmpty(this.cboDepartment.EditValue))
            {
                this.cboShippingPerson.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                this.cboShippingPerson.Code = CommonData.FunctionGr.MS_Employee;
            }
        }

        #endregion Methods


        #region Define a custom user control that raises an event to subscribers on move

        public event EventHandler<EventArgs> QuanlityStatus_Changed;

        // Raises a custom event, Moved
        protected void QuanlityStatus_OnChanged(object sender, EventArgs e)
        {
            var handler = QuanlityStatus_Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        protected virtual void cboQualityStatus_EditValueChanged(object sender, EventArgs e)
        {
            QuanlityStatus_OnChanged(sender, e);
        }

        #endregion Define a custom user control that raises an event to subscribers on moved
    }
}