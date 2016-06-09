using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.BLL.Common;
using Ivs.Core.Interface;
using Ivs.Controls.Forms;
using Ivs.DTO.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class SHForDelivery01UC : StockUserControl
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
                    dto.ShippingDateCtrl = lblDocumentDate.Text;
                    dto.PersonInChangeCtrl = lblPIC.Text;
                    dto.CustomerCodeCtrl = lblCustomer.Text;
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
                    dto.WarehouseCode = CommonMethod.ParseString(cboWarehouse.EditValue);
                    //==Updated
                    dto.WarehouseName = CommonMethod.ParseString(cboWarehouse.Text);
                    //=========
                    dto.DocumentType = CommonData.DocumentType.Shipping;
                    dto.TransactionSubCode = CommonData.TransactionSubCode.SH_StockShippingForDelivery;                  
                    //dto.DocumentDate = CommonMethod.ParseDateTime(this.dtpDocumentDate.EditValue);
                    dto.ShippingDate = CommonMethod.ParseDate(this.dtpDocumentDate.EditValue);
                    dto.PersonInChange = CommonMethod.ParseString(this.cboPIC.EditValue);
                    dto.PostedPerson = CommonMethod.ParseString(this.cboPostedPerson.EditValue);
                    dto.PostedDate = CommonMethod.ParseDate(this.dtpPostedDate.EditValue);
                    dto.CompanyCode = CommonMethod.ParseString(this.cboCustomer.EditValue);
                    //dto.CustomerCode = CommonMethod.ParseString(this.cboCustomer.EditValue);
                    dto.SampleShippingFlg = CommonMethod.ParseString(this.rdgType.EditValue); //this.rdoShipping.Checked ? CommonData.SampleShippingFlg.Shipping : CommonData.SampleShippingFlg.Sample;
                    dto.Description = txtDescription.Text;
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
                        if (this.ViewMode == CommonData.Mode.New)
                        {
                            CommonBl commonBl = new CommonBl();
                            //this.txtDocumentNo.Text = commonBl.GetDocumentNo(CommonMethod.ParseString(this.cboDocumentType.EditValue));
                            //this.txtDocumentNo.Text = CommonData.StringEmpty;
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = CommonBl.GetSystemDate();
                            this.cboPostedPerson.EditValue = Ivs.Core.Data.UserSession.EmployeeID;
                            this.dtpDocumentDate.EditValue = CommonBl.GetSystemDate();
                            this.rdgType.EditValue = CommonData.SampleShippingFlg.Shipping;
                        }
                        else
                        {
                            this.txtDocumentNo.Text = dto.DocumentNumber;
                            this.dtpPostedDate.EditValue = dto.PostedDate;
                            this.cboPostedPerson.EditValue = dto.PostedPerson;
                            this.dtpDocumentDate.EditValue = dto.ShippingDate;
                            if (dto.SampleShippingFlg == null)
                            {
                                this.rdgType.EditValue = CommonData.SampleShippingFlg.Shipping;
                            }
                            else
                            {
                                this.rdgType.EditValue = dto.SampleShippingFlg;
                                //if (dto.SampleShippingFlg.Equals(CommonData.SampleShippingFlg.Shipping))
                                //{
                                //    rdoShipping.Checked = true;
                                //}
                                //else if (dto.SampleShippingFlg.Equals(CommonData.SampleShippingFlg.Sample))
                                //{
                                //    rdoSample.Checked = true;
                                //}
                            }
                        }

                        this.cboPIC.EditValue = dto.PersonInChange;
                        this.cboCustomer.EditValue = dto.CompanyCode;
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

                        this.txtDescription.Text = dto.Description;
                    }
                    else
                    {
                        this.dtpDocumentDate.EditValue = CommonBl.GetSystemDate();
                        this.cboPIC.EditValue = CommonData.StringEmpty;
                        this.cboCustomer.EditValue = CommonData.StringEmpty;
                        this.rdgType.EditValue = CommonData.SampleShippingFlg.Shipping;
                        this.txtDescription.Text = CommonData.StringEmpty;
                    }
                }
            }
        }

        #endregion Properties

        #region Contructions

        public SHForDelivery01UC()
        {
            InitializeComponent();

            //Set language for controls
            this.SetLanguage();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Initalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();

            #region Events

            this.cboDepartment.EditValueChanged += new EventHandler(cboDepartment_EditValueChanged);
            //this.rdoShipping.CheckedChanged += new EventHandler(rdoShipping_CheckedChanged);
            this.dtpDocumentDate.Properties.MaxValue = CommonBl.GetSystemDate();
            #endregion
        }

        public override void LoadControlData()
        {
            base.LoadControlData();

            #region Set data to combobox
            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboPostedPerson.Code = CommonData.FunctionGr.MS_Employee;
            this.cboPIC.Code = CommonData.FunctionGr.MS_Employee;

            //View mode: show all company
            this.cboCustomer.Status = this.ViewMode == CommonData.Mode.View ? CommonData.StringEmpty : CommonData.Status.Enable;
            this.cboCustomer.IsCustomer = this.ViewMode == CommonData.Mode.View ? CommonData.Status.Disable : CommonData.Status.Enable;
            this.cboCustomer.Code = CommonData.FunctionGr.MS_Customers;

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

            this.lblPrinted.Visible = !(this.ViewMode == CommonData.Mode.Edit);
            this.txtPrintCount.Visible = !(this.ViewMode == CommonData.Mode.Edit);

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPIC.Enabled = false;

                this.txtDocumentNo.Enabled = false;

                //this.pnlType.Enabled = false;
                this.rdgType.Enabled = false;
                this.dtpDocumentDate.Enabled = false;
                this.cboPIC.Enabled = false;
                this.cboCustomer.Enabled = false;
                this.txtDescription.Enabled = false;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPIC.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                //this.pnlType.Enabled = false;
                this.rdgType.Enabled = false;
                this.dtpDocumentDate.Enabled = true;
                this.cboPIC.Enabled = true;
                this.cboCustomer.Enabled = true;
                this.txtDescription.Enabled = true;

                this.rdgType.Select();
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.txtDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.cboPIC.Enabled = false;
                this.txtDocumentNo.Enabled = false;

                //this.pnlType.Enabled = true;
                this.rdgType.Enabled = true;
                this.dtpDocumentDate.Enabled = true;
                this.cboPIC.Enabled = true;
                this.cboCustomer.Enabled = true;
                this.txtDescription.Enabled = true;

                this.rdgType.Select();
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
            this.cboCustomer.ClearErrors();
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
                    this.dtpDocumentDate.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.dtpDocumentDate.Focus();
                        this.IsFocusControl = true;
                    }
                    break;
                case CommonKey.ShippingPerson:
                    this.cboPIC.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboPIC.Focus();
                        this.IsFocusControl = true;
                    }
                    break;
                case CommonKey.CustomerCode:
                    this.cboCustomer.SetError(errorText);
                    if (!this.IsFocusControl)
                    {
                        this.cboCustomer.Focus();
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
            this.cboCustomer.Reset();
            this.txtDocumentType.Reset();
            this.dtpPostedDate.Reset();
            this.dtpDocumentDate.Reset();
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
