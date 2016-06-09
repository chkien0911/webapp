using System;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DTO.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class STStockTransfer01UC : StockUserControl
    {
        #region Properties

        public override IDto ControlDto
        {
            get
            {
                if (!DesignMode)
                {
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.ShippingDateCtrl = lblShippingDate.Text;
                    dto.PersonInChangeCtrl = lblShippingPerson.Text;
                    dto.ArrivingDateCtrl = lblArrivingDate.Text;
                    dto.PersonInChange2Ctrl = lblArrivingPerson.Text;
                    dto.WarehouseCode2Ctrl = lblWarehouseTo.Text + " " + gcTo.Text;
                    dto.WarehouseCodeCtrl = lblWarehouseFrom.Text + " " + gcFrom.Text;
                    dto.DocumentNumberCtrl = lblDocumentNo.Text;
                    dto.QualityStatusCtrl = lblQualityStatus.Text;
                    dto.PostedPersonCtrl = lblPostedPersonFrom.Text;
                    dto.PostedPersonCtrl1 = lblPostedPersonTo.Text;
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
                    dto.DocumentNumber = txtNo2.Text;
                    //dto.DocumentNumber = CommonMethod.ParseString(this.cboDocumentNo.EditValue);
                    dto.DocumentType = CommonData.DocumentType.Transfer;
                    dto.TransactionSubCode = CommonData.TransactionSubCode.ST_StockTransfer_WH2WH;

                    dto.QualityStatus = CommonMethod.ParseString(this.cboQualityStatus.EditValue);
                    dto.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                    dto.DocumentDate = CommonMethod.ParseDate(this.dtpArrivingDate.EditValue);

                    dto.WarehouseCode = CommonMethod.ParseString(this.cboWarehouseFrom.EditValue);
                    dto.ShippingDate = CommonMethod.ParseDateAllowNull(this.dtpShippingDate.EditValue);
                    dto.PersonInChange = CommonMethod.ParseString(this.cboShippingPerson.EditValue);

                    dto.DepartmentCode2 = CommonMethod.ParseString((this.ViewMode == CommonData.Mode.New || this.ViewMode == CommonData.Mode.View) ? CommonData.StringEmpty : this.cboDepartment.EditValue);
                    dto.WarehouseCode2 = CommonMethod.ParseString(this.cboWarehouseTo.EditValue);
                    dto.ArrivingDate = ViewMode == CommonData.Mode.New ? null : CommonMethod.ParseDateAllowNull(this.dtpArrivingDate.EditValue);
                    dto.PersonInChange2 = CommonMethod.ParseString(this.cboArrivingPerson.EditValue);

                    dto.WarehouseName = CommonMethod.ParseString((this.ViewMode == CommonData.Mode.New || this.ViewMode == CommonData.Mode.View) ? this.cboWarehouseFrom.Text : this.cboWarehouseTo.Text);
                    if (this.ViewMode == CommonData.Mode.New || this.ViewMode == CommonData.Mode.View)
                        dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPersonFrom.EditValue);
                    if (this.ViewMode == CommonData.Mode.New || this.ViewMode == CommonData.Mode.View)
                        dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDateFrom.EditValue);
                    dto.PostedDate1 = CommonMethod.ParseDateAllowNull(this.dtpPostedDateTo.EditValue);
                    dto.PostedPerson1 = CommonMethod.ParseString(this.cboPostedPersonTo.EditValue);

                    dto.Description = txtRemark.Text;

                    dto.ShippingDateCtrl = lblShippingDate.Text;                   
                    dto.ArrivingDateCtrl = lblArrivingDate.Text;
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
                        this.cboDepartment.EditValue = dto.DepartmentCode;//this.ViewMode == CommonData.Mode.New ? dto.DepartmentCode : dto.DepartmentCode2;
                        this.cboWarehouseFrom.EditValue = dto.WarehouseCode;
                        this.cboWarehouseTo.EditValue = dto.WarehouseCode2;

                        this.cboQualityStatus.EditValue = (dto.Details != null && dto.Details.Count > 0) ? dto.Details[0].QualityStatus : dto.QualityStatus;

                        CommonBl commonBl = new CommonBl();

                        this.txtDocumentNo.Text = dto.DocumentNumber;//commonBl.GetDocumentNo(CommonData.TransactionSubCode.ST_StockTransfer_ShippingFromStorage);
                        //this.cboDocumentNo.EditValue = dto.DocumentNumber ?? CommonData.StringEmpty;
                        this.txtNo2.Text = dto.DocumentNumber;
                        this.dtpPostedDateFrom.EditValue = dto.PostedDate;
                        this.cboPostedPersonFrom.EditValue = dto.PostedPerson;
                        this.dtpPostedDateTo.EditValue = dto.PostedDate1;
                        this.cboPostedPersonTo.EditValue = dto.PostedPerson1;
                        this.dtpShippingDate.EditValue = dto.ShippingDate;
                        this.cboShippingPerson.EditValue = dto.PersonInChange;
                        this.dtpArrivingDate.EditValue = dto.ArrivingDate;
                        this.cboArrivingPerson.EditValue = dto.PersonInChange2;
                        this.txtRemark.Text = dto.Description;

                        cboDocumentNo.TransactionSubCode = CommonData.TransactionSubCode.ST_StockTransfer_WH2WH;
                        cboDocumentNo.Warehouse = ((ST_StockTransactionMasterDto)Dto).WarehouseCode2;
                        //this.cboDocumentNo = CommonData.FunctionGr.ST_StockOverview;
                        //this.cboDocumentNo.Code = CommonData.FunctionGr.ST_StockOverview;


                        //if (!CommonMethod.IsNullOrEmpty(dto.DeliverySheetPrintFlg))
                        //{
                            int intCount = CommonMethod.ParseInt32(dto.DeliverySheetPrintCount);
                            this.txtPrintCount.Text = CommonMethod.ParseString(intCount);
                            if (intCount > 1)
                            {
                                if(ViewMode!=CommonData.Mode.Edit)
                                    this.txtPrintReason.Visible = true;
                                this.txtPrintReason.Text = dto.DeliverySheetRePrintReason;
                            }
                            else
                                this.txtPrintReason.Visible = false;
                        //}
                        //else
                        //{
                        //    this.txtPrintCount.Text = "0";
                        //    this.txtPrintReason.Visible = false;
                        //}
                    }
                    else
                    {
                        if (this.ViewMode == CommonData.Mode.New)
                        {
                            //this.txtDocumentNo.Text = CommonData.StringEmpty;//commonBl.GetDocumentNo(CommonData.TransactionSubCode.ST_StockTransfer_ShippingFromStorage);
                            this.dtpPostedDateFrom.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPersonFrom.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpShippingDate.EditValue = CommonBl.GetSystemDate();
                            this.cboShippingPerson.EditValue = CommonData.StringEmpty;
                           // this.cboDocumentNo.EditValue = CommonData.StringEmpty;
                            this.txtNo2.Text = CommonData.StringEmpty;
                            this.dtpPostedDateTo.EditValue = CommonData.StringEmpty;
                            this.cboPostedPersonTo.EditValue = CommonData.StringEmpty;
                            this.dtpArrivingDate.EditValue = CommonData.StringEmpty;
                            this.cboArrivingPerson.EditValue = CommonData.StringEmpty;
                            this.cboWarehouseTo.EditValue = CommonData.StringEmpty;
                            this.txtRemark.Text = CommonData.StringEmpty;
                        }
                        else
                        {
                            this.cboWarehouseFrom.EditValue = CommonData.StringEmpty;
                            this.dtpPostedDateFrom.EditValue = CommonData.StringEmpty;
                            this.cboPostedPersonFrom.EditValue = CommonData.StringEmpty;
                            this.dtpShippingDate.EditValue = CommonData.StringEmpty;
                            this.cboShippingPerson.EditValue = CommonData.StringEmpty;
                            //this.cboDocumentNo.EditValue = CommonData.StringEmpty;
                            this.txtNo2.Text = CommonData.StringEmpty;
                            this.dtpPostedDateTo.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPersonTo.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpArrivingDate.EditValue = CommonBl.GetSystemDate();
                            this.cboArrivingPerson.EditValue = CommonData.StringEmpty;
                            this.txtRemark.Text = CommonData.StringEmpty;
                        }
                    }
                }
            }
        }

        #endregion Properties

        #region Contructions

        public STStockTransfer01UC()
        {
            InitializeComponent();

            this.SetLanguage();
        }

        #endregion Contructions

        #region Methods

   
        /// <summary>
        /// Initalize controls
        /// </summary>
        public override void SetControl()
        {
            #region Clear error

            this.ClearError();

            #endregion Clear error

            #region Show/Hide controls

            this.txtDocumentType.Visible = this.ViewMode == CommonData.Mode.New;
            this.txtDocumentType2.Visible = !(this.ViewMode == CommonData.Mode.New);

            this.txtDocumentNo.Visible = !(this.ViewMode == CommonData.Mode.Edit);
            this.cboDocumentNo.Visible = false;
            this.txtNo2.Visible = (this.ViewMode == CommonData.Mode.Edit);
            this.btnSearch.Visible = (this.ViewMode == CommonData.Mode.Edit);

            //this.chkPrint.Enabled = false;
            //this.lblPrinted.Visible = !(this.ViewMode == CommonData.Mode.New);
            this.lblPrinted.Visible = true;
            //this.txtPrintReason.Visible = (this.ViewMode == CommonData.Mode.View);
            this.txtPrintCount.Visible = true;
            //this.chkPrint.Visible = !(this.ViewMode == CommonData.Mode.New);
            //this.chkPrint.Visible = (this.ViewMode == CommonData.Mode.New);

            this.lblMandatoryShippingDate.Visible = this.ViewMode == CommonData.Mode.New;
            this.lblMandatoryShippingPerson.Visible = this.ViewMode == CommonData.Mode.New;
            this.lblMandatoryWHTo.Visible = this.ViewMode == CommonData.Mode.New;
            this.lblMandatoryQuanlityStatus.Visible = this.ViewMode == CommonData.Mode.New;
            this.lblMandatoryArrivingDate.Visible = this.ViewMode == CommonData.Mode.Edit;
            this.lblMandatoryArrivingPerson.Visible = this.ViewMode == CommonData.Mode.Edit;
            this.lblMandatoryDocumentNo.Visible = this.ViewMode == CommonData.Mode.Edit;
            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDateFrom.Enabled = false;
                this.cboPostedPersonFrom.Enabled = false;
                this.dtpPostedDateTo.Enabled = false;
                this.cboPostedPersonTo.Enabled = false;
                this.txtDocumentNo.Enabled = false;
                this.cboDocumentNo.Enabled = false;
                this.cboQualityStatus.Enabled = false;

                this.cboWarehouseFrom.Enabled = false;
                this.cboWarehouseTo.Enabled = false;

                this.dtpShippingDate.Enabled = false;
                this.cboShippingPerson.Enabled = false;
                this.dtpArrivingDate.Enabled = false;
                this.cboArrivingPerson.Enabled = false;
                this.txtRemark.Enabled = false;
                this.lblPrinted.Visible = true;
                //this.chkPrint.Visible = true;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDateFrom.Enabled = false;
                this.cboPostedPersonFrom.Enabled = false;
                this.dtpPostedDateTo.Enabled = false;
                this.cboPostedPersonTo.Enabled = false;
                this.cboQualityStatus.Enabled = false;
                this.txtRemark.Enabled = false;
                if (this.ViewMode == CommonData.Mode.New)
                {
                    this.txtDocumentNo.Enabled = false;
                    this.cboWarehouseFrom.Enabled = false;
                    this.cboWarehouseTo.Enabled = true;

                    this.dtpShippingDate.Enabled = true;
                    this.cboShippingPerson.Enabled = true;
                    this.dtpArrivingDate.Enabled = false;
                    this.cboArrivingPerson.Enabled = false;

                    this.cboQualityStatus.Select();
                }
                else
                {
                    this.cboDocumentNo.Enabled = true;
                    this.cboWarehouseFrom.Enabled = false;
                    this.cboWarehouseTo.Enabled = false;

                    this.dtpShippingDate.Enabled = false;
                    this.cboShippingPerson.Enabled = false;
                    this.dtpArrivingDate.Enabled = true;
                    this.cboArrivingPerson.Enabled = true;

                    this.txtNo2.Select();
                }
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.txtDocumentType2.Enabled = false;
                this.dtpPostedDateFrom.Enabled = false;
                this.cboPostedPersonFrom.Enabled = false;
                this.dtpPostedDateTo.Enabled = false;
                this.cboPostedPersonTo.Enabled = false;
                this.cboQualityStatus.Enabled = true;
                this.txtRemark.Enabled = true;
                if (this.ViewMode == CommonData.Mode.New)
                {
                    this.txtDocumentNo.Enabled = false;
                    this.cboWarehouseFrom.Enabled = false;
                    this.cboWarehouseTo.Enabled = true;

                    this.dtpShippingDate.Enabled = true;
                    this.cboShippingPerson.Enabled = true;
                    this.dtpArrivingDate.Enabled = false;
                    this.cboArrivingPerson.Enabled = false;

                    this.cboQualityStatus.Select();
                }
                else
                {
                    this.cboDocumentNo.Enabled = true;
                    this.cboWarehouseFrom.Enabled = false;
                    this.cboWarehouseTo.Enabled = false;

                    this.dtpShippingDate.Enabled = false;
                    this.cboShippingPerson.Enabled = false;
                    this.dtpArrivingDate.Enabled = true;
                    this.cboArrivingPerson.Enabled = true;

                    this.cboDocumentNo.Select();
                }
            }

            #endregion Show/Hide controls

            cboDepartment.EditValueChanged += new EventHandler(cboDepartment_EditValueChanged);
           
        }

        void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ViewMode == CommonData.Mode.View)
            {
                return;
            }
            if (!CommonMethod.IsNullOrEmpty(this.cboDepartment.EditValue))
            {
                if (this.ViewMode == CommonData.Mode.New)
                {
                    this.cboShippingPerson.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                    this.cboShippingPerson.Code = CommonData.FunctionGr.MS_Employee;
                }
                else
                {
                    this.cboArrivingPerson.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                    this.cboArrivingPerson.Code = CommonData.FunctionGr.MS_Employee;
                }
            }
        }

        /// <summary>
        /// Clear error for controls
        /// </summary>
        public override void ClearError()
        {
            base.ClearError();
            this.cboDepartment.ClearErrors();
            this.txtDocumentNo.ClearErrors();
            this.cboDocumentNo.ClearErrors();
            this.txtNo2.ClearErrors();
            this.cboWarehouseFrom.ClearErrors();
            this.cboWarehouseTo.ClearErrors();
            this.dtpShippingDate.ClearErrors();
            this.cboShippingPerson.ClearErrors();
            this.dtpArrivingDate.ClearErrors();
            this.cboArrivingPerson.ClearErrors();
            this.cboQualityStatus.ClearErrors();
        }

        /// <summary>
        /// Set language for controls
        /// </summary>
        public override void SetLanguage()
        {
            this.Reset();
        }

        /// <summary>
        /// Set error for controls
        /// </summary>
        public override void SetError(string errorFieldName, string errorText)
        {
            if (this.ViewMode == CommonData.Mode.New)
            {
                switch (errorFieldName)
                {
                    case CommonKey.QualityStatus:
                        this.cboQualityStatus.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboQualityStatus.Focus();
                            this.IsFocusControl = true;
                        }
                        break;
                    case CommonKey.PostedPerson:
                        this.cboPostedPersonFrom.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboPostedPersonFrom.Focus();
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

                    case CommonKey.Warehouse:
                        this.cboWarehouseTo.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboWarehouseTo.Focus();
                            this.IsFocusControl = true;
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (errorFieldName)
                {
                    case CommonKey.DocumentNumber:
                        this.txtNo2.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboDocumentNo.Focus();
                            this.IsFocusControl = true;
                        }
                        break;
                    case CommonKey.PostedPerson1:
                        this.cboPostedPersonTo.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboPostedPersonTo.Focus();
                            this.IsFocusControl = true;
                        }
                        break;
                    case CommonKey.ArrivingDate:
                        this.dtpArrivingDate.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.dtpArrivingDate.Focus();
                            this.IsFocusControl = true;
                        }
                        break;

                    case CommonKey.ArrivingPerson:
                        this.cboArrivingPerson.SetError(errorText);
                        if (!this.IsFocusControl)
                        {
                            this.cboArrivingPerson.Focus();
                            this.IsFocusControl = true;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        public override void Reset()
        {
            this.cboDepartment.Reset();
            this.cboQualityStatus.Reset();
            this.cboWarehouseFrom.Reset();
            this.cboWarehouseTo.Reset();
            this.cboShippingPerson.Reset();
            this.cboArrivingPerson.Reset();
            this.dtpPostedDateFrom.Reset();
            this.dtpShippingDate.Reset();
            this.dtpPostedDateTo.Reset();
            this.dtpArrivingDate.Reset();
            this.cboPostedPersonFrom.Reset();
            this.cboPostedPersonTo.Reset();
        }

        public override void InitControl()
        {
            base.InitControl();

            SetControl();

            #region Events

            cboQualityStatus.EditValueChanged += new EventHandler(cboQualityStatus_EditValueChanged);
            cboDocumentNo.EditValueChanged += new EventHandler(cboDocumentNo_EditValueChanged);
            btnSearch.Click += new EventHandler(cboDocumentNo_EditValueChanged);

            this.dtpShippingDate.Properties.MaxValue = CommonBl.GetSystemDate();
            this.dtpArrivingDate.Properties.MaxValue = CommonBl.GetSystemDate();

            #endregion Events
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox

            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboShippingPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboArrivingPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboQualityStatus.Code = CommonData.Code.QualityStatus;
            this.cboPostedPersonFrom.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPostedPersonTo.Code = CommonData.FunctionGr.MS_Employee;

            this.cboWarehouseFrom.Status = this.ViewMode == CommonData.Mode.View ? CommonData.StringEmpty : CommonData.Status.Enable;
            this.cboWarehouseFrom.Code = CommonData.FunctionGr.MS_Warehouses;

            this.cboWarehouseTo.Status = this.ViewMode == CommonData.Mode.View ? CommonData.StringEmpty : CommonData.Status.Enable;
            this.cboWarehouseTo.Code = CommonData.FunctionGr.MS_Warehouses;

            if (ViewMode == CommonData.Mode.Edit)
                this.cboQualityStatus.HasNull = true;
            #endregion Set data to combobox
        }


        //void dtpDate_EditValueChanged(object sender, EventArgs e)
        //{
        //    IvsDateEdit dtpDate = (IvsDateEdit)sender;
        //    if (CommonMethod.ParseDate(dtpDate.EditValue) > CommonBl.GetSystemDate())
        //        dtpDate.EditValue = CommonBl.GetSystemDate();
        //}

        public void SetDefaultQualityStatus()
        {
            this.cboQualityStatus.EditValue = "";
            this.txtNo2.EditValue = "";
        }

        #endregion Methods

        #region Define a custom user control that raises an event to subscribers on move

        public event EventHandler<EventArgs> QuanlityStatus_Changed;

        public event EventHandler<EventArgs> DocumentNo_Changed;

        // Raises a custom event, Moved
        protected void QuanlityStatus_OnChanged(object sender, EventArgs e)
        {
            var handler = QuanlityStatus_Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void DocumentNo_OnChanged(object sender, EventArgs e)
        {
            var handler = DocumentNo_Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void cboQualityStatus_EditValueChanged(object sender, EventArgs e)
        {
            QuanlityStatus_OnChanged(sender, e);
        }

        protected virtual void cboDocumentNo_EditValueChanged(object sender, EventArgs e)
        {
            DocumentNo_OnChanged(sender, e);
        }

        #endregion Define a custom user control that raises an event to subscribers on moved
    }
}