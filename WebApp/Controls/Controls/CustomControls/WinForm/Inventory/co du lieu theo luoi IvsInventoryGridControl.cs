using System;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using Ivs.DTO.Master;
using DevExpress.XtraEditors;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsInventoryGridControl : IvsUserControl
    {
        protected CommonBl _commonBl = new CommonBl();
        #region Properties

        #region Transaction
        public string Warehouse { get; set; }

        public string QuanlityStatus { get; set; }

        public string ItemType { get; set; } //use to view combobox ItemType in gridview

        #endregion
        public bool ShowTransferType { get; set; }



        public bool ShowNo { get; set; }

        public bool ShowOrderNo { get; set; }

        public bool ShowDocument { get; set; }

        public bool ShowItemType { get; set; }

        public bool ShowItemCode { get; set; }

        public bool ShowStatus { get; set; }

        public bool ShowQuantity { get; set; }

        public bool ShowUnit { get; set; }

        public bool ShowAmount { get; set; }

        public bool ShowUnitPrice { get; set; }

        public bool ShowProductionLine { get; set; }

        public bool ShowQuanlityStatus { get; set; }

        public bool ShowErrorReason { get; set; }

        public bool ShowRemark { get; set; }

        public bool ShowLotNo { get; set; }

        #endregion Properties



        /// <summary>
        /// override Dto in IvsInventoryGridControl
        /// Get: assign value of input control to members of dto
        /// return ST_StockTransactionDetailDto
        /// Set: assign value from members of dto to input control
        /// </summary>
        public override IDto Dto
        {
            get
            {
                if (!DesignMode)
                {
                    #region Reset control

                    this.Reset();

                    #endregion Reset control

                    dgvInventory.FocusedRowHandle = -1;
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
                    dto.Details = dgcInventory.GetOnlyChangedRowsWithState<ST_StockTransactionDetailDto>();

                    //Get caption column to validate
                    if (dto.Details.Count > 0)
                    {
                        foreach (ST_StockTransactionDetailDto detailDto in dto.Details)
                        {
                            detailDto.ItemCodeCtrl = dgvInventory.Columns[CommonKey.ItemCode].Caption;
                            detailDto.QuantityCtrl = dgvInventory.Columns[CommonKey.Quantity].Caption;
                            detailDto.UnitCtrl = dgvInventory.Columns[CommonKey.Unit].Caption;
                        }
                    }

                    return dto;
                }
                return null;
                //return this.Dto;
            }
            set
            {
                if (!DesignMode)
                {
                    dgcInventory.BindDataForEdit();
                    ST_StockTransactionMasterDto dto = (ST_StockTransactionMasterDto)value;

                    if (dto != null && dto.Details != null && dto.Details.Count > 0)
                    {
                        dgcInventory.SetAllRows<ST_StockTransactionDetailDto>(dto.Details);
                    }
                }
            }
        }

        public IvsInventoryGridControl()
        {
            InitializeComponent();
        }

        #region Public Methods

        /// <summary>
        /// Initilize controls 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <param name="quanlityStatus"></param>
        /// <param name="itemType"></param>
        public void InitControl(string warehouse, string quanlityStatus = "", string itemType = "")
        {
            this.InitControl();
            this.Warehouse = warehouse;
            this.QuanlityStatus = quanlityStatus;
            this.ItemType = itemType;
        }

        /// <summary>
        /// Intalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();

            #region Show/Hide column

            this.colLineNumber.Visible = this.ShowNo;
            this.colOrderNo.Visible = this.ShowOrderNo;
            this.colTransferType.Visible = this.ShowTransferType;
            this.colDocumentDate.Visible = this.ShowDocument;
            this.colDocumentNo.Visible = this.ShowDocument;
            this.colItemType.Visible = this.ShowItemType;
            this.colItemCode.Visible = this.ShowItemCode;
            this.colItemName.Visible = this.ShowItemCode;
            this.colUnit.Visible = this.ShowUnit;
            this.colQuantity.Visible = this.ShowQuantity;
            this.colUnitPrice.Visible = this.ShowUnitPrice;
            this.colAmount.Visible = this.ShowAmount;
            this.colPruductionLine.Visible = this.ShowProductionLine;
            this.colQuanlityStatus.Visible = this.ShowQuanlityStatus;
            this.colErrorReason.Visible = this.ShowErrorReason;
            this.colRemark.Visible = this.ShowRemark;
            this.colLotNo.Visible = this.ShowLotNo;

            #endregion Show/Hide column

            #region Set data

            this.resDocumentNo.HasNull = true;
            this.resItemType.HasNull = true;
            this.resTransferType.HasNull = true;
            this.resItem.HasNull = true;
            //this.resUnit.HasNull = true;
            this.resProductionLine.HasNull = true;
            this.resErrorReason.HasNull = true;
            this.resQualityStatus.HasNull = true;

            this.resDocumentNo.Code = this.ShowDocument ? CommonData.FunctionGr.ST_StockTransactionMaster : CommonData.StringEmpty;
            this.resItemType.Code = this.ShowItemType ? CommonData.Code.ItemType : CommonData.StringEmpty;
            this.resTransferType.Code = this.ShowTransferType ? CommonData.Code.TransferStatusType : CommonData.StringEmpty;
            this.resItem.Code = this.ShowItemCode ? CommonData.FunctionGr.MS_Items : CommonData.StringEmpty;
            this.resUnit.Code = this.ShowUnit ? CommonData.FunctionGr.MS_Units : CommonData.StringEmpty;
            this.resProductionLine.Code = CommonData.FunctionGr.MS_ProductionLines;
            this.resQualityStatus.Code = CommonData.Code.QualityStatus;
            this.resErrorReason.Code = this.ShowErrorReason ? CommonData.FunctionGr.MS_ErrorReasons : CommonData.StringEmpty;


            this.resQuantity.NumOfDecimalPlaces = 2;
            this.resQuantity.IsNumberic = true;
            this.resUnitPrice.NumOfDecimalPlaces = 6;
            this.resUnitPrice.IsNumberic = true;
            this.resAmount.NumOfDecimalPlaces = 6;
            this.resAmount.IsNumberic = true;

            #endregion Set data

            #region Events

            this.dgvInventory.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(dgvInventory_CellValueChanged);
            //this.resItem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resItem_EditValueChanging);
            this.resQuantity.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resQuantity_EditValueChanging);
            this.resUnitPrice.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resUnitPrice_EditValueChanging);
            //this.resItem.EditValueChanged += new EventHandler(resItem_EditValueChanged);
            this.resItemGrid.EditValueChanged += new EventHandler(resItem_EditValueChanged);
            this.dgvInventory.ShownEditor += new EventHandler(ShowEditor);


            #endregion Events

            InitGridLookup();

        }

        /// <summary>
        /// Reset controls
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            if (this.ShowDocument)
            {
                this.resDocumentNo.Reset();
            }
            if (this.ShowItemType)
            {
                this.resItemType.Reset();
            }
            if (this.ShowTransferType)
            {
                this.resTransferType.Reset();
            }
            if (this.ShowItemCode)
            {
                this.resItem.Reset();
            }
            if (this.ShowUnit)
            {
                this.resUnit.Reset();
            }
            if (this.ShowProductionLine)
            {
                this.resProductionLine.Reset();
            }
            if (this.ShowQuanlityStatus)
            {
                this.resQualityStatus.Reset();
            }
            if (this.ShowErrorReason)
            {
                this.resErrorReason.Reset();
            }
        }

        /// <summary>
        /// Set language for controls
        /// </summary>
        public override void SetLanguage()
        {
            base.SetLanguage();

            this.Reset();
        }

        /// <summary>
        /// Set controls
        /// </summary>
        public override void SetControl()
        {
            base.SetControl();

            this.ClearError();
            if (this.ViewMode == CommonData.Mode.View)
            {
                this.dgvInventory.OptionsBehavior.Editable = false;
            }
            else
            {
                this.dgvInventory.OptionsBehavior.Editable = true;
            }
        }

        /// <summary>
        /// Clear error for controls
        /// </summary>
        public override void ClearError()
        {
            base.ClearError();

            this.dgcInventory.ClearAllErrors();
        }

        public

        #endregion Methods

        #region Events

       
         void dgvInventory_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();

            //Set auto value for column No
            dgcInventory.SetRowCellValue(CommonKey.LineNumber, CommonMethod.ParseString(e.RowHandle + 1));

            #region Set validate

            dgcInventory.ClearErrors();

            /// <summary>
            /// Item Code must be fill in
            ///</summary>
            if (string.IsNullOrEmpty(detailDto.ItemCode))
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colItemCode.Caption);
                dgcInventory.SetColumnError(colItemCode.FieldName, msg.MessageText);
                return;
            }

            /// <summary>
            /// Quantity must be greater than 0
            ///</summary>
            if (detailDto.Quantity == null || detailDto.Quantity <= 0)
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colQuantity.Caption);
                dgcInventory.SetColumnError(colQuantity.FieldName, msg.MessageText);
                return;
            }

            #endregion Set validate

            #region Add new row if focus to last row

            if (dgcInventory.IsFocusedLastRow())
            {
                dgcInventory.AddNewRow();
            }

            #endregion Add new row if focus to last row
        }

        private void resUnitPrice_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();
            decimal amount = CommonMethod.ParseDecimal(detailDto.Quantity) * CommonMethod.ParseDecimal(e.NewValue);
            dgcInventory.SetRowCellValue(CommonKey.Amount, CommonMethod.ParseString(amount));
            dgvInventory.RefreshData();

        }

        private void resQuantity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();
            decimal amount = CommonMethod.ParseDecimal(detailDto.UnitPrice) * CommonMethod.ParseDecimal(e.NewValue);
            dgcInventory.SetRowCellValue(CommonKey.Amount, CommonMethod.ParseString(amount));
            dgvInventory.RefreshData();
        }

        private void resItem_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit LookupEdit = sender as GridLookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();

            if (SelectedDataRow != null)
            {
                dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonMethod.ParseString(SelectedDataRow["Name"]));
                dgcInventory.SetRowCellValue("Unit", CommonMethod.ParseString(SelectedDataRow["InvUnitCode"]));
                dgcInventory.SetRowCellValue("QualityStatus", SelectedDataRow["QuanlityStatus"].ToString());
                if (ShowProductionLine)
                    dgcInventory.SetRowCellValue("ProductionLine", CommonMethod.ParseString(SelectedDataRow["Line"]));
                dgcInventory.FocusedView.PostEditor();
            }

        }

        #endregion Events

        #region Private methods

        private void SetRelatedItemData(string itemCode)
        {
            //Set defalt valur
            dgcInventory.SetRowCellValue("ItemName", CommonData.StringEmpty);
            dgcInventory.SetRowCellValue("Unit", CommonData.StringEmpty);
            if (!CommonMethod.IsNullOrEmpty(itemCode))
            {
                DataTable dtResult = new DataTable();
                _commonBl.SelectCurrentItemInRepositoryControl(out dtResult, ShowProductionLine, ShowDocument, itemCode);

                MS_ItemDto itemDto = new MS_ItemDto()
                {
                    Code = itemCode,
                };

                //Set data for relational column
                if (dtResult.Rows.Count > 0)
                {
                    dgcInventory.SetRowCellValue("ItemCode", CommonMethod.ParseString(dtResult.Rows[0]["Code"]));
                    dgcInventory.SetRowCellValue("ItemName", CommonMethod.ParseString(dtResult.Rows[0]["Name"]));
                    dgcInventory.SetRowCellValue("Unit", CommonMethod.ParseString(dtResult.Rows[0]["InvUnitCode"]));

                    if(CommonMethod.IsNullOrEmpty(dtResult.Rows[0]["QuanlityStatus"]))
                    {
                        dgcInventory.SetRowCellValue("QualityStatus", CommonMethod.ParseString(dtResult.Rows[0]["QuanlityStatus"]));
                    }
                    if (ShowProductionLine)
                    {
                        dgcInventory.SetRowCellValue("ProductionLine", CommonMethod.ParseString(dtResult.Rows[0]["Line"]));
                    }
                }
            }

            dgvInventory.RefreshData();
        }

        #endregion Private methods

        private void InitGridLookup()
        {

            resItemGrid.View.Columns.Clear();
            // The field for the editor's display text.
            resItemGrid.DisplayMember = "Code";
            // The field matching the edit value.
            resItemGrid.ValueMember = "Code";
            resItemGrid.View.OptionsBehavior.AutoPopulateColumns = false;

            var col1 = resItemGrid.View.Columns.AddField("Code");
            col1.VisibleIndex = 0;
            col1.Caption = "Item Code";

            col1 = resItemGrid.View.Columns.AddField("Name");
            col1.VisibleIndex = 1;
            col1.Caption = "Item Name";

            col1 = resItemGrid.View.Columns.AddField(CommonKey.InvUnitCode);
            col1.VisibleIndex = 3;
            col1.Caption = "Unit";


            col1 = resItemGrid.View.Columns.AddField("QuanlityStatus");
            col1.VisibleIndex = 4;
            col1.ColumnEdit = this.resQualityStatus;
            col1.Caption = "QuanlityStatus";

            if (ShowDocument)
            {
                col1 = resItemGrid.View.Columns.AddField("DocumentNo");
                col1.Caption = "DocumentNo";

            }

            if (ShowProductionLine)
            {
                col1 = resItemGrid.View.Columns.AddField("Line");
                col1.Caption = "Production Line";
                col1.ColumnEdit = this.resProductionLine;

            }

            resItemGrid.View.OptionsView.ShowAutoFilterRow = true;
            // Set column widths according to their contents.
            resItemGrid.View.BestFitColumns();
            // Specify the total dropdown width.
            resItemGrid.PopupFormWidth = 750;

            DataTable table = new DataTable();
            _commonBl.SelectDataForStockRepositoryItemControl(out table, ShowProductionLine, ShowDocument,
                "", Warehouse,
                QuanlityStatus);
            resItemGrid.DataSource = table;
        }
        public void ShowEditor(object sender, EventArgs e)
        {

            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
           
            if (view.ActiveEditor is DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)view.ActiveEditor;


                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) return;
                if (view.FocusedColumn.FieldName == CommonKey.ItemCode && (DevExpress.XtraEditors.GridLookUpEdit)view.ActiveEditor is DevExpress.XtraEditors.GridLookUpEdit)
                {

                    DataTable table = new DataTable();
                    _commonBl.SelectDataForStockRepositoryItemControl(out table, ShowProductionLine, ShowDocument,
                        ShowItemType ? CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ItemType"]) : ItemType, Warehouse,
                        QuanlityStatus, CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["DocumentNo"]),
                        CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProductionLine"]));

                    if (resItem.HasNull)
                    {
                        table.Rows.InsertAt(table.NewRow(), 0);
                    }

                    edit.Properties.DataSource = table;

                }
            }
            else if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {

                DevExpress.XtraEditors.LookUpEdit edit;
                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;


                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) return;
                if (view.FocusedColumn.FieldName == CommonKey.ItemType && (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
                {
                   DataTable table= edit.Properties.DataSource as DataTable;
                 

                    if (resItem.HasNull)
                    {
                        table.Rows.InsertAt(table.NewRow(), 0);
                    }

                    edit.Properties.DataSource = table;

                }

            }

        }


    }


}
