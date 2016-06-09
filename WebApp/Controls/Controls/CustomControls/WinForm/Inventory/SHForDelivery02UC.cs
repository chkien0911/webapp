using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class SHForDelivery02UC : StockUserControl
    {
        #region Construction

        public SHForDelivery02UC()
        {
            InitializeComponent();
            //Initalize controls on SIForDelivery UserControl
            this.SetControl();
            //Set language for controls
            this.SetLanguage();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initalize controls
        /// </summary>
        public override void SetControl()
        {
            #region Clear error
            this.cboDepartment.ClearErrors();
            this.cboWarehouse.ClearErrors();
            this.cboDocumentType.ClearErrors();
            this.txtDocumentNo.ClearErrors();
            this.dtpStockDate.ClearErrors();
            this.txtStockPerson.ClearErrors();
            this.cboCustomer.ClearErrors();
            #endregion

            #region Show/Hide controls

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.cboDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.txtPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = false;
                this.dtpStockDate.Enabled = false;
                this.txtStockPerson.Enabled = false;
                this.cboCustomer.Enabled = false;
                this.txtRemark.Enabled = false;
            }
            else if (this.ViewMode == CommonData.Mode.Edit)
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.cboDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.txtPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = false;
                this.dtpStockDate.Enabled = true;
                this.txtStockPerson.Enabled = true;
                this.cboCustomer.Enabled = true;
                this.txtRemark.Enabled = true;

                this.dtpStockDate.Select();
            }
            else
            {
                this.cboDepartment.Enabled = false;
                this.cboWarehouse.Enabled = false;
                this.cboDocumentType.Enabled = false;
                this.dtpPostedDate.Enabled = false;
                this.txtPostedPerson.Enabled = false;

                this.txtDocumentNo.Enabled = true;
                this.dtpStockDate.Enabled = true;
                this.txtStockPerson.Enabled = true;
                this.cboCustomer.Enabled = true;
                this.txtRemark.Enabled = true;

                this.txtDocumentNo.Select();
            }

            #endregion
        }

        /// <summary>
        /// Set language for controls
        /// </summary>
        public override void SetLanguage()
        {

        }

        public override void InitControl()
        {
            base.InitControl();

            #region Set data to combobox
            this.cboDepartment.Code = CommonData.FunctionGr.MS_Departments;
            this.cboWarehouse.Code = CommonData.FunctionGr.MS_Warehouses;
            this.cboDocumentType.Code = CommonData.FunctionGr.MS_DocumentType;
            this.cboCustomer.Code = CommonData.FunctionGr.MS_Customers;
            #endregion

            #region Set default value
            //this.cboDepartment.EditValue = this.DepartmentCode;
            //this.cboWarehouse.EditValue = this.WarehouseCode;
            //this.cboDocumentType.EditValue = CommonData.DocumentType.SH_StockIssueForDelivery_Sample;

            ////this.dtpPostedDate.EditValue = Ivs.BLL.Common.CommonBl.GetSystemDate();
            //this.txtPostedPerson.Text = UserSession.UserName;
            #endregion
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        public override void Reset()
        {
            this.cboDepartment.Reset();
            this.cboWarehouse.Reset();
            this.cboCustomer.Reset();
            this.cboDocumentType.Reset();
            this.dtpPostedDate.Reset();
            this.dtpStockDate.Reset();
        }

        #endregion
    }
}
