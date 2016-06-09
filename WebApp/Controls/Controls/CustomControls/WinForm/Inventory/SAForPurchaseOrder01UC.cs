using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using System;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class SAForPurchaseOrder01UC : StockUserControl
    {
        #region Properties

        public override IDto ControlDto
        {
            get
            {
                if (!DesignMode)
                {
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.ArrivingDateCtrl = lblArrivingDate.Text;
                    dto.PersonInChangeCtrl = lblArrivingPerson.Text;
                    dto.SupplierCodeCtrl = lblSupplier.Text;
                    dto.WarehouseCodeCtrl = lblWarehouse.Text;
                    dto.DepartmentCodeCtrl = lblDepartment.Text;
                    dto.PostedDateCtrl = lblPostedDate.Text;
                    dto.PostedPersonCtrl = lblPostedPerson.Text;
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
                    dto.TransactionSubCode = CommonData.TransactionSubCode.SA_StockArrivingForPurchaseOrder;
                    dto.DocumentType = CommonData.DocumentType.Arriving;

                    dto.WarehouseName = CommonMethod.ParseString(this.cboWarehouse.Text);
                    dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPerson.EditValue);
                    //NPQuoc Edit 20131227
                    //dto.DocumentDate = CommonMethod.ParseDateTime(this.dtpArrivingDate.EditValue);
                    dto.ArrivingDate = CommonMethod.ParseDate(this.dtpArrivingDate.EditValue);

                    dto.PersonInChange = CommonMethod.ParseString(this.cboArrivingPerson.EditValue);

                    dto.LotNo = CommonMethod.ParseString(txtLotNo.Text);
                    //dto.PostingPerson = ;
                    dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDate.EditValue);
                    dto.CompanyCode = CommonMethod.ParseString(this.cboSupplier.EditValue);
                    //NPQuoc chkPrint Not Print
                    //dto.DeliverySheetPrintFlg = this.chkPrint.Checked ? CommonData.Status.Disable : CommonData.Status.Enable;

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
                            this.txtDocumentNo.Text = commonBl.GetDocumentNo(CommonData.TransactionSubCode.SA_StockArrivingForPurchaseOrder);
                            this.dtpPostedDate.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpArrivingDate.EditValue = CommonBl.GetSystemDate();
                        }
                        else
                        {
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = dto.PostedDate;
                            this.cboPostedPerson.EditValue = dto.PostedPerson;
                            this.dtpArrivingDate.EditValue = dto.ArrivingDate;
                        }
                        //this.cboPostedPerson.EditValue = dto.PostedPerson;
                        this.cboArrivingPerson.EditValue = dto.PersonInChange;
                        this.cboSupplier.EditValue = dto.CompanyCode;
                        //this.txtLotNo.Text = dto.LotNo;

                        //dto.DeliverySheetPrintFlg = dto.DeliverySheetPrintFlg == null ? CommonData.Status.Disable : dto.DeliverySheetPrintFlg;
                        //NPQuoc chkPrint Not Print
                        //if (!CommonMethod.IsNullOrEmpty(dto.DeliverySheetPrintFlg) && CommonMethod.ParseInt32(dto.DeliverySheetPrintFlg) > 1)
                        //{
                        //    this.chkPrint.Checked = true;
                        //}
                        //else
                        //{
                        //    this.chkPrint.Checked = false;
                        //}
                        this.txtDescription.Text = dto.Description;
                    }
                    else
                    {
                        this.cboSupplier.EditValue = CommonData.StringEmpty;
                        this.dtpArrivingDate.EditValue = CommonBl.GetSystemDate();
                        this.cboArrivingPerson.EditValue = CommonData.StringEmpty;
                        this.txtLotNo.Text = CommonData.StringEmpty;
                        this.txtDescription.Text = CommonData.StringEmpty;
                    }
                }
            }
        }

        #endregion Properties

        #region Contructions

        public SAForPurchaseOrder01UC()
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
            this.dtpArrivingDate.EditValueChanged += new EventHandler(dtpDate_EditValueChanged);
            #endregion
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox

            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboArrivingPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPostedPerson.Code = CommonData.FunctionGr.MS_Employee;

            //View mode: show all company
            this.cboSupplier.Status = this.ViewMode == CommonData.Mode.View ? CommonData.StringEmpty : CommonData.Status.Enable;
            this.cboSupplier.IsSupplier = this.ViewMode == CommonData.Mode.View ? CommonData.Status.Disable : CommonData.Status.Enable;
            this.cboSupplier.Code = CommonData.FunctionGr.MS_Suppliers;
            
            #endregion Set data to combobox
        }

      
        void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            IvsDateEdit dtpDate = (IvsDateEdit)sender;
            if (CommonMethod.ParseDate(dtpDate.EditValue) > CommonBl.GetSystemDate())
                dtpDate.EditValue = CommonBl.GetSystemDate();
        }

        /// <summary>
        /// Set controls
        /// </summary>
        public override void SetControl()
        {
            #region Clear error

            this.ClearError();

            #endregion Clear error

            #region Show/Hide controls

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                //NPQuoc chkPrint Not Print
                //this.chkPrint.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpArrivingDate.Enabled = false;
                this.cboArrivingPerson.Enabled = false;
                this.cboSupplier.Enabled = false;
                this.txtLotNo.Enabled = false;
                this.txtDescription.Enabled = false;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                //NPQuoc chkPrint Not Print
                //this.chkPrint.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpArrivingDate.Enabled = true;
                this.cboArrivingPerson.Enabled = true;
                this.cboSupplier.Enabled = true;
                this.txtLotNo.Enabled = true;
                this.txtDescription.Enabled = true;

                this.dtpArrivingDate.Select();
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPostedPerson.Enabled = false;
                //NPQuoc chkPrint Not Print
                //this.chkPrint.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                this.dtpArrivingDate.Enabled = true;
                this.cboArrivingPerson.Enabled = true;
                this.cboSupplier.Enabled = true;
                this.txtLotNo.Enabled = true;
                this.txtDescription.Enabled = true;

                this.dtpArrivingDate.Select();
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
            this.dtpArrivingDate.ClearErrors();
            this.cboArrivingPerson.ClearErrors();
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

                case CommonKey.VendorCode:
                    this.cboSupplier.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboSupplier.Focus();
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
            this.cboSupplier.Reset();
            this.cboArrivingPerson.Reset();
            this.dtpPostedDate.Reset();
            this.dtpArrivingDate.Reset();
            this.cboPostedPerson.Reset();
        }

        #endregion Methods

        #region Events

        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (!CommonMethod.IsNullOrEmpty(this.cboDepartment.EditValue))
            {
                this.cboArrivingPerson.DepartmentCode = CommonMethod.ParseString(this.cboDepartment.EditValue);
                this.cboArrivingPerson.Code = CommonData.FunctionGr.MS_Employee;
            }
        }

        #endregion
    }
}