using System;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using Ivs.DTO.Master;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;


namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsInventoryGridControl : IvsUserControl
    {
        private int selectedRowIndex = 0;
        private bool isValid = true;
        protected CommonBl _commonBl = new CommonBl();

        #region Properties

        #region Transaction
        public string Warehouse { get; set; }

        public string QuanlityStatus { get; set; }

        public string ItemType { get; set; } //use to view combobox ItemType in gridview

        public string Supplier { get; set; }

        public string ProcessType { get; set; }

        public string DefaultQualityStatus { get; set; }

        public string Customer { get; set; }

        public bool IsSAReturnCustomer { get; set; }

        public bool IsFull { get; set; }

        #endregion

        private bool _allowAddNewRow = true;
        [DefaultValue(true)]
        public bool AllowAddNewRow
        {
            get
            {
                return _allowAddNewRow;
            }
            set
            {
                _allowAddNewRow = value;
            }
        }

        private bool _columnAutoWidth = true;
        [DefaultValue(true)]
        public bool ColumnAutoWidth
        {
            get
            {
                return _columnAutoWidth;
            }
            set
            {
                _columnAutoWidth = value;
            }
        }


        private int _gridNumnber = 1;
        [DefaultValue(1)]
        public int GridNumber
        {
            get
            {
                return _gridNumnber;
            }
            set
            {
                _gridNumnber = value;
            }
        }

        public bool ShowSelect { get; set; }

        public bool ShowTransferType { get; set; }

        public bool ShowNo { get; set; }

        public bool ShowOrderNo { get; set; }

        public bool ShowDocument { get; set; }

        public bool ShowItemType { get; set; }

        public bool ShowItemCode { get; set; }

        public bool ShowStatus { get; set; }

        public bool ShowStockQuantity { get; set; }

        public bool ShowQuantity { get; set; }

        public bool ShowUnit { get; set; }

        public bool ShowAmount { get; set; }

        public bool ShowUnitPrice { get; set; }

        public bool ShowProductionLine { get; set; }

        public bool ShowQuanlityStatus { get; set; }

        public bool ShowErrorReason { get; set; }

        public bool ShowRemark { get; set; }

        public bool ShowLotNo { get; set; }

        public bool ShowProcessType { get; set; }

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

                    //this.Reset();

                    #endregion Reset control

                    dgvInventory.FocusedRowHandle = -1;
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();

                    List<ST_StockTransactionDetailDto> detail = dgcInventory.GetAllRowWithState<ST_StockTransactionDetailDto>();
                    //2014/03/14 Convert ProductionLine No-Processing to null
                    //dto.Details = detail;
                    dto.Details = detail.ConvertLineBlankToNull();


                    dto.CheckDetails = dgcInventory.GetOnlyChangedRowsWithState<ST_StockTransactionDetailDto>();
                    if (this.ShowSelect)
                    {
                        dto.SelectedDetails = dgcInventory.GetCheckedRows<ST_StockTransactionDetailDto>("Select").ConvertLineBlankToNull();
                    }

                    #region Get caption column to validate

                    if (dto.Details.Count > 0)
                    {
                        foreach (ST_StockTransactionDetailDto detailDto in dto.Details)
                        {
                            detailDto.ItemCodeCtrl = dgvInventory.Columns[CommonKey.ItemCode].Caption;
                            detailDto.QuantityCtrl = dgvInventory.Columns[CommonKey.InputQuantity].Caption;
                            detailDto.UnitCtrl = dgvInventory.Columns[CommonKey.InputUnit].Caption;
                            detailDto.QualityStatusCtrl = dgvInventory.Columns[CommonKey.QualityStatus].Caption;
                            detailDto.TransferTypeCtrl = dgvInventory.Columns[CommonKey.TransferType].Caption;
                            detailDto.ProductionLineCtrl = dgvInventory.Columns[CommonKey.ProductionLine].Caption;
                            detailDto.ErrorReasonCtrl = dgvInventory.Columns[CommonKey.ErrorReason].Caption;
                            detailDto.OrderNoCtrl = dgvInventory.Columns[CommonKey.OrderNo].Caption;
                            detailDto.DocumentNoCtrl = dgvInventory.Columns[CommonKey.RelatedDocumentNo].Caption;
                        }
                        foreach (ST_StockTransactionDetailDto detailDto in dto.SelectedDetails)
                        {
                            detailDto.ItemCodeCtrl = dgvInventory.Columns[CommonKey.ItemCode].Caption;
                            detailDto.QuantityCtrl = dgvInventory.Columns[CommonKey.InputQuantity].Caption;
                            detailDto.UnitCtrl = dgvInventory.Columns[CommonKey.InputUnit].Caption;
                            detailDto.QualityStatusCtrl = dgvInventory.Columns[CommonKey.QualityStatus].Caption;
                            detailDto.TransferTypeCtrl = dgvInventory.Columns[CommonKey.TransferType].Caption;
                            detailDto.ProductionLineCtrl = dgvInventory.Columns[CommonKey.ProductionLine].Caption;
                            detailDto.ErrorReasonCtrl = dgvInventory.Columns[CommonKey.ErrorReason].Caption;
                            detailDto.OrderNoCtrl = dgvInventory.Columns[CommonKey.OrderNo].Caption;
                            detailDto.DocumentNoCtrl = dgvInventory.Columns[CommonKey.RelatedDocumentNo].Caption;
                        }
                    }

                    #endregion

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

                    if (dto != null)
                    {
                        //Set for detailgrid
                        if (this.GridNumber == 1 && dto.Details != null && dto.Details.Count > 0)
                        {

                            //2014/03/14 Convert ProductionLine  null to No-Processing 
                            //dgcInventory.SetAllRowsWithAutoNumber<ST_StockTransactionDetailDto>(dto.Details, CommonKey.LineNumber);
                            dgcInventory.SetAllRowsWithAutoNumber<ST_StockTransactionDetailDto>(dto.Details.ConvertLineNullToBlank(), CommonKey.LineNumber);
                        }
                        //Set for detailgrid2
                        else if (this.GridNumber == 2 && dto.Details1 != null && dto.Details1.Count > 0)
                        {
                            //2014/03/14 Convert ProductionLine  null to No-Processing 
                            //dgcInventory.SetAllRowsWithAutoNumber<ST_StockTransactionDetailDto>(dto.Details1, CommonKey.LineNumber);                           
                            dgcInventory.SetAllRowsWithAutoNumber<ST_StockTransactionDetailDto>(dto.Details1.ConvertLineNullToBlank(), CommonKey.LineNumber);
                        }
                        //Set for more detailgrid
                        //...
                    }
                    else
                    {
                        dgvInventory.FocusedRowHandle = -1;

                    }
                }
            }
        }

        public IvsInventoryGridControl()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void ClearGrid()
        {

            this.Dto = null;
            dgvInventory.FocusedRowHandle = -1;
            this.InitLookupEdit();
        }

        public void SetEdit(bool isEdit)
        {
            colSelect.OptionsColumn.AllowEdit = isEdit;
            colLineNumber.OptionsColumn.AllowEdit = isEdit;
            colOrderNo.OptionsColumn.AllowEdit = isEdit;
            colItemCode.OptionsColumn.AllowEdit = isEdit;
            colUnit.OptionsColumn.AllowEdit = isEdit;
            colQuantity.OptionsColumn.AllowEdit = isEdit;
            colRemark.OptionsColumn.AllowEdit = isEdit;
            colDocumentNo.OptionsColumn.AllowEdit = isEdit;
            colErrorReason.OptionsColumn.AllowEdit = isEdit;
            colDocumentDate.OptionsColumn.AllowEdit = isEdit;
            colTransferType.OptionsColumn.AllowEdit = isEdit;
            colItemType.OptionsColumn.AllowEdit = isEdit;
            colPruductionLine.OptionsColumn.AllowEdit = isEdit;
            colQualityStatus.OptionsColumn.AllowEdit = isEdit;
            colLotNo.OptionsColumn.AllowEdit = isEdit;
            colProcessType.OptionsColumn.AllowEdit = isEdit;

            colLineNumber.OptionsColumn.AllowFocus = isEdit;
            colOrderNo.OptionsColumn.AllowFocus = isEdit;
            colItemCode.OptionsColumn.AllowFocus = isEdit;
            colUnit.OptionsColumn.AllowFocus = isEdit;
            colStockQty.OptionsColumn.AllowEdit = isEdit;
            colQuantity.OptionsColumn.AllowFocus = isEdit;
            colRemark.OptionsColumn.AllowFocus = isEdit;
            colDocumentNo.OptionsColumn.AllowFocus = isEdit;
            colErrorReason.OptionsColumn.AllowFocus = isEdit;
            colDocumentDate.OptionsColumn.AllowFocus = isEdit;
            colTransferType.OptionsColumn.AllowFocus = isEdit;

            colItemType.OptionsColumn.AllowFocus = isEdit;
            colPruductionLine.OptionsColumn.AllowFocus = isEdit;
            colQualityStatus.OptionsColumn.AllowFocus = isEdit;
            colLotNo.OptionsColumn.AllowFocus = isEdit;
            colProcessType.OptionsColumn.AllowFocus = isEdit;


        }
        /// <summary>
        /// Initilize controls 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <param name="quanlityStatus"></param>
        /// <param name="itemType"></param>
        public void InitControl(string warehouse, string quanlityStatus = "", string itemType = "", string supplier = "", string processType = "",string customer="")
        {
            this.InitControl();
            this.Warehouse = warehouse;
            this.QuanlityStatus = quanlityStatus;
            this.ItemType = itemType;
            this.Supplier = supplier;
            this.ProcessType = processType;
            this.Customer = customer;
            this.InitLookupEdit();
        }

        private void InitLookupEdit()
        {
            resItem.Columns.Clear();
            var col1 = new IvsLookUpColumnInfo("Code");

            col1.Caption = "";
            col1.Width = 130;
            resItem.Columns.Add(col1);

            col1 = new IvsLookUpColumnInfo("Name");
            col1.Caption = "";
            col1.Width = 300;
            resItem.Columns.Add(col1);
            resItem.PopupWidth = 430;
        }

        /// <summary>
        /// Intalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();

            this.dgvInventory.OptionsView.ColumnAutoWidth = this.ColumnAutoWidth;

            #region Show/Hide column

            this.ShowGridColumn();

            #endregion Show/Hide column

            #region Set data
            if (this.ViewMode == CommonData.Mode.View)
            {
                this.resItem.HasNull = true;
                this.resUnit.HasNull = true;
                this.resErrorReason.HasNull = true;
                this.resQualityStatus.HasNull = true;
                this.resTransferType.HasNull = true;
                this.resProcessType.HasNull = true;
            }
            else
            {
                this.resItem.HasNull = false;
                this.resUnit.HasNull = false;
                this.resErrorReason.HasNull = false;
                this.resQualityStatus.HasNull = false;
                this.resTransferType.HasNull = false;
                this.resProcessType.HasNull = false;
            }
            this.resDocumentNo.HasNull = true;
            this.resItemType.HasNull = true;
            this.resProductionLine.HasNull = true;

            //this.resDocumentNo.Code = ShowDocument ? CommonData.FunctionGr.ST_StockTransactionMaster : string.Empty;
            //this.resItemType.Code = ShowItemType ? CommonData.Code.ItemType : string.Empty;
            //this.resTransferType.Code = ShowTransferType ? CommonData.Code.TransferStatusType : string.Empty;
            //this.resItem.Code = ShowItemCode ? CommonData.FunctionGr.MS_Items : string.Empty;
            //this.resUnit.Code = ShowUnit ? CommonData.FunctionGr.MS_Units : string.Empty;
            //this.resProductionLine.ShowBlank = true;
            //this.resProductionLine.Code = ShowProductionLine ? CommonData.FunctionGr.MS_ProductionLines : string.Empty;
            
            //this.resQualityStatus.Code = ShowQuanlityStatus ? CommonData.Code.QualityStatus : string.Empty;
            //this.resErrorReason.Code = ShowErrorReason ? CommonData.FunctionGr.MS_ErrorReasons : string.Empty;
            //this.resProcessType.Code = CommonData.FunctionGr.ProcessType;

            this.resQuantity.NumOfDecimalPlaces = 2;
            this.resQuantity.IsNumberic = true;
            this.resUnitPrice.NumOfDecimalPlaces = 2;
            this.resUnitPrice.IsNumberic = true;
            this.resAmount.NumOfDecimalPlaces = 2;
            this.resAmount.IsNumberic = true;

            #endregion Set data

            #region Events

            //this.dgvInventory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(dgvInventory_FocusedRowChanged);
            this.dgvInventory.ShownEditor -= new EventHandler(ShowEditor);
            this.dgvInventory.ShownEditor += new EventHandler(ShowEditor);

            this.dgvInventory.ShowingEditor -= new CancelEventHandler(ShowingEditor);
            this.dgvInventory.ShowingEditor += new CancelEventHandler(ShowingEditor);

            this.dgvInventory.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(dgvInventory_CellValueChanged);
            this.dgvInventory.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(dgvInventory_CellValueChanged);

            this.dgvInventory.LostFocus -= new System.EventHandler(this.dgvInventory_LostFocus);
            this.dgvInventory.LostFocus += new System.EventHandler(this.dgvInventory_LostFocus);

            //this.resItem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resItem_EditValueChanging);
            this.resQuantity.EditValueChanging -= new DevExpress.XtraEditors.Controls.ChangingEventHandler(resQuantity_EditValueChanging);
            this.resQuantity.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resQuantity_EditValueChanging);

            this.resUnitPrice.EditValueChanging -= new DevExpress.XtraEditors.Controls.ChangingEventHandler(resUnitPrice_EditValueChanging);
            this.resUnitPrice.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resUnitPrice_EditValueChanging);

            //this.resItemGrid.EditValueChanged += new EventHandler(resItem_EditValueChanged);
            this.chkSelect.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.chkSelect.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resDocumentNo.EditValueChanged -= new EventHandler(resParentItem_EditValueChanged);
            this.resDocumentNo.EditValueChanged += new EventHandler(resParentItem_EditValueChanged);

            this.resItemType.EditValueChanged -= new EventHandler(resParentItem_EditValueChanged);
            this.resItemType.EditValueChanged += new EventHandler(resParentItem_EditValueChanged);

            this.resQuantity.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resQuantity.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resTransferType.EditValueChanged -= new EventHandler(TransferType_EditValueChanged);
            this.resTransferType.EditValueChanged += new EventHandler(TransferType_EditValueChanged);

            this.resRemark.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resRemark.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resProductionLine.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resProductionLine.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resUnitPrice.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resUnitPrice.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resQualityStatus.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resQualityStatus.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resOrderNo.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resOrderNo.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resLotNo.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resLotNo.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resProcessType.EditValueChanged -= new EventHandler(resProcessType_EditValueChanged);
            this.resProcessType.EditValueChanged += new EventHandler(resProcessType_EditValueChanged);

            this.resErrorReason.EditValueChanged -= new EventHandler(resErrorReason_EditValueChanged);
            this.resErrorReason.EditValueChanged += new EventHandler(resErrorReason_EditValueChanged);

            //this.resUnit.EditValueChanged += new EventHandler(resUnit_EditValueChanged);
            this.dgvInventory.ColumnWidthChanged -= new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.dgvInventory_ColumnWidthChanged);
            this.dgvInventory.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.dgvInventory_ColumnWidthChanged);

            #endregion Events

        }

        public override CommonData.Mode ViewMode
        {
            get
            {
                return base.ViewMode;
            }
            set
            {
                base.ViewMode = value;
                this.resItem.IsActive = this.ViewMode != CommonData.Mode.View;
                this.resItem.Code = CommonData.FunctionGr.MS_Items;
            }
        }
        public override void LoadControlData()
        {
            base.LoadControlData();

            this.resDocumentNo.Code = ShowDocument ? CommonData.FunctionGr.ST_StockTransactionMaster : string.Empty;

            this.resItemType.Code = ShowItemType ? CommonData.Code.ItemType : string.Empty;

            this.resTransferType.Code = ShowTransferType ? CommonData.Code.TransferStatusType : string.Empty;


            this.resItem.IsActive = ViewMode != CommonData.Mode.View;
            this.resItem.Code = ShowItemCode ? CommonData.FunctionGr.MS_Items : string.Empty;

            this.resUnit.Code = ShowUnit ? CommonData.FunctionGr.MS_Units : string.Empty;

            this.resProductionLine.ShowBlank = true;
            this.resProductionLine.Code = ShowProductionLine ? CommonData.FunctionGr.MS_ProductionLines : string.Empty;

            this.resQualityStatus.Code = ShowQuanlityStatus ? CommonData.Code.QualityStatus : string.Empty;

            this.resErrorReason.Code = ShowErrorReason ? CommonData.FunctionGr.MS_ErrorReasons : string.Empty;

            this.resProcessType.Code = CommonData.FunctionGr.ProcessType;
        }

        public void ShowGridColumn()
        {
            this.colSelect.Visible = this.ShowSelect;
            this.colLineNumber.Visible = this.ShowNo;
            this.colOrderNo.Visible = this.ShowOrderNo;
            this.colTransferType.Visible = this.ShowTransferType;
            this.colDocumentDate.Visible = false;
            this.colDocumentNo.Visible = this.ShowDocument;
            this.colItemType.Visible = this.ShowItemType;
            this.colItemCode.Visible = this.ShowItemCode;
            this.colItemName.Visible = this.ShowItemCode;
            this.colUnit.Visible = this.ShowUnit;
            this.colStockQty.Visible = this.ShowStockQuantity;
            this.colQuantity.Visible = this.ShowQuantity;
            this.colUnitPrice.Visible = this.ShowUnitPrice;
            this.colAmount.Visible = this.ShowAmount;
            this.colPruductionLine.Visible = this.ShowProductionLine;
            this.colQualityStatus.Visible = this.ShowQuanlityStatus;
            this.colErrorReason.Visible = this.ShowErrorReason;
            this.colRemark.Visible = this.ShowRemark;
            this.colLotNo.Visible = this.ShowLotNo;
            this.colProcessType.Visible = this.ShowProcessType;
        }


        private void resProcessType_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit LookupEdit = sender as LookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();
            if (SelectedDataRow != null)
            {
                if (CommonMethod.ParseString(SelectedDataRow[CommonKey.Code]) == CommonData.ProcessType.FG)
                {
                    dgcInventory.SetRowCellValue(CommonKey.ProductionLine, "FG");
                }
                //else if (CommonMethod.ParseString(SelectedDataRow[CommonKey.Code]) == CommonData.ProcessType.WIP)
                //{
                //    dgcInventory.SetRowCellValue(CommonKey.ProductionLine, CommonData.ProductionLineBlank.Code);
                //}
                else
                {
                    dgcInventory.SetRowCellValue(CommonKey.ProductionLine, CommonData.StringEmpty);
                }
            }
            dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonData.StringEmpty);
            dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonData.StringEmpty);
            dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonData.StringEmpty);
            dgcInventory.SetRowCellValue(CommonKey.QualityStatus, CommonData.StringEmpty);
            
            dgvInventory.PostEditor();

        }

        private void resErrorReason_EditValueChanged(object sender, EventArgs e)
        {
            dgvInventory.PostEditor();
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

            this.dgcInventory.ChangeLanguage();
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
                this.dgvInventory.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
            else
            {
                this.dgvInventory.OptionsBehavior.Editable = true;
                this.dgvInventory.OptionsSelection.EnableAppearanceFocusedCell = true;
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

        /// <summary>
        /// Set error for controls
        /// </summary>
        public override void SetError(int rowIndex, string fieldName, string errorText)
        {
            dgcInventory.SetColumnError(rowIndex, fieldName, errorText);
        }
        public

        #endregion Methods

        #region Events

            //void dgvInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
            //{
            //    //If exist error on grid
            //    //if (!this.isValid)
            //    //{
            //    //    //Disable Focused to other row
            //    //    this.dgvInventory.FocusedRowHandle = this.selectedRowIndex;
            //    //    return;
            //    //}
            //}

        void dgvInventory_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            //Set selected row index on grid
            this.selectedRowIndex = e.RowHandle;

            dgcInventory.SetRowCellValue(CommonKey.LineNumber, CommonMethod.ParseString(e.RowHandle + 1));

            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();

            #region Set validate

            dgcInventory.ClearErrors();

            this.isValid = true;

            if (!this.ShowSelect || detailDto.Select)
            {
                /// <summary>
                /// TransferType must be fill in
                ///</summary>
                if (this.ShowTransferType && CommonMethod.IsNullOrEmpty(detailDto.TransferType))
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colTransferType.Caption);
                    dgcInventory.SetColumnError(colTransferType.FieldName, msg.MessageText);
                    isValid = false;
                }

                /// <summary>
                /// Item Code must be fill in
                ///</summary>
                if (string.IsNullOrEmpty(detailDto.ItemCode))
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colItemCode.Caption);
                    dgcInventory.SetColumnError(colItemCode.FieldName, msg.MessageText);
                    isValid = false;
                }

                /// <summary>
                /// Quantity must be fill in.
                ///</summary>
                if (detailDto.InputQuantity == null)
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colQuantity.Caption);
                    dgcInventory.SetColumnError(colQuantity.FieldName, msg.MessageText);
                    isValid = false;
                }
                else
                {
                    /// <summary>
                    /// Quantity must be greater than 0
                    ///</summary>
                    if (detailDto.InputQuantity <= 0)
                    {
                        IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_GREATER_THAN, colQuantity.Caption, 0);
                        dgcInventory.SetColumnError(colQuantity.FieldName, msg.MessageText);
                        isValid = false;
                    }
                }

                /// <summary>
                /// QualityStatus must be fill in
                ///</summary>
                if (this.ShowQuanlityStatus && CommonMethod.IsNullOrEmpty(detailDto.QualityStatus))
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colQualityStatus.Caption);
                    dgcInventory.SetColumnError(colQualityStatus.FieldName, msg.MessageText);
                    isValid = false;
                }

                /// <summary>
                /// ProductLine must be fill in when Type is WIP
                ///</summary>
                if (this.ShowProcessType && CommonMethod.ParseString(detailDto.ProcessType).Equals(CommonData.ProcessType.WIP) && ShowProductionLine && CommonMethod.IsNullOrEmpty(detailDto.ProductionLine))
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colPruductionLine.Caption);
                    dgcInventory.SetColumnError(colPruductionLine.FieldName, msg.MessageText);
                    isValid = false;
                }

                /// <summary>
                /// Error reason must be fill in
                ///</summary>
                if (this.ShowErrorReason && CommonMethod.IsNullOrEmpty(detailDto.ErrorReason))
                {
                    IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, colErrorReason.Caption);
                    dgcInventory.SetColumnError(colErrorReason.FieldName, msg.MessageText);
                    isValid = false;
                }
            }

            #endregion Set validate

            #region Add new row if focus to last row

            if (this.AllowAddNewRow && isValid && dgcInventory.IsFocusedLastRow())
            {
                dgcInventory.AddNewRow();
            }

            #endregion Add new row if focus to last row
        }

        private void resUnitPrice_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();
            decimal quantity = CommonMethod.ParseDecimal(detailDto.InputQuantity);
            decimal amount = quantity * CommonMethod.ParseDecimal(e.NewValue);
            dgcInventory.SetRowCellValue(CommonKey.InputQuantity, CommonMethod.ParseString(quantity));
            dgcInventory.SetRowCellValue(CommonKey.InputAmount, CommonMethod.ParseString(amount));
            dgvInventory.RefreshData();

        }

        private void resQuantity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            ST_StockTransactionDetailDto detailDto = dgcInventory.GetFocusedRow<ST_StockTransactionDetailDto>();
            decimal unitPrice = CommonMethod.ParseDecimal(detailDto.InputUnitPrice);
            decimal amount = unitPrice * CommonMethod.ParseDecimal(e.NewValue);
            dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, CommonMethod.ParseString(unitPrice));
            dgcInventory.SetRowCellValue(CommonKey.InputAmount, CommonMethod.ParseString(amount));
            dgvInventory.RefreshData();
        }

        protected virtual void resParentItem_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit LookupEdit = sender as LookUpEdit;
            if (!CommonMethod.IsNullOrEmpty(LookupEdit.EditValue))
            {
                dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.QualityStatus, CommonData.StringEmpty);
            }
            dgvInventory.PostEditor();
        }

        private void TransferType_EditValueChanged(object sender, EventArgs e)
        {
            string qualityStatus = string.Empty; ;
            LookUpEdit LookupEdit = sender as LookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();
            if (SelectedDataRow != null)
            {
                switch (CommonMethod.ParseString(SelectedDataRow["Key"]))
                {
                    case CommonData.TransferStatusType.OK2NC:
                    case CommonData.TransferStatusType.OK2NG:
                    case CommonData.TransferStatusType.OK2QI:
                        qualityStatus = CommonData.QualityStatus.OK;
                        break;
                    case CommonData.TransferStatusType.NC2NG:
                        qualityStatus = CommonData.QualityStatus.NC;
                        break;
                    case CommonData.TransferStatusType.QI2NC:
                    case CommonData.TransferStatusType.QI2NG:
                    case CommonData.TransferStatusType.QI2OK:
                        qualityStatus = CommonData.QualityStatus.QI;
                        break;

                }
            }
            dgcInventory.SetRowCellValue(CommonKey.QualityStatus, qualityStatus);
            dgvInventory.PostEditor();
        }

        protected void PostEditor_EditValueChanged(object sender, EventArgs e)
        {
            dgvInventory.PostEditor();
        }

        private DataTable InitProcessType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            DataRow dr = null;

            if (!CommonMethod.IsNullOrEmpty(ProcessType))
            {
                string[] process = ProcessType.Split(",".ToCharArray());
                if (process.Contains(CommonData.ProcessType.RM))
                {
                    dr = dt.NewRow();
                    dr[0] = CommonData.ProcessType.RM;
                    dr[1] = "RM";
                    dt.Rows.Add(dr);
                }
                if (process.Contains(CommonData.ProcessType.WIP))
                {
                    dr = dt.NewRow();
                    dr[0] = CommonData.ProcessType.WIP;
                    dr[1] = "WIP";
                    dt.Rows.Add(dr);
                }

                if (process.Contains(CommonData.ProcessType.FG))
                {
                    dr = dt.NewRow();
                    dr[0] = CommonData.ProcessType.FG;
                    dr[1] = "FG";
                    dt.Rows.Add(dr);
                }


            }
            return dt;

        }

        private void ShowingEditor(object sender, CancelEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;


            if (view.FocusedColumn.FieldName != CommonKey.OrderNo && view.FocusedColumn.FieldName != CommonKey.RelatedDocumentNo)
            {
                if (view.FocusedColumn.FieldName == CommonKey.ProductionLine)
                {
                    string processType = CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]);
                    string itemType = CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)[CommonKey.ItemType]);
                    if ((ShowProcessType && (processType.Equals(CommonData.ProcessType.FG) || processType.Equals(CommonData.ProcessType.RM))) || itemType == CommonData.ItemType.RawMaterials)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (ShowProcessType)
                {
                    string processType = CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]);
                    if (CommonMethod.IsNullOrEmpty(processType) && view.FocusedColumn.FieldName != "ProcessType")
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

           

        }

        public virtual void ShowEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {
                DevExpress.XtraEditors.LookUpEdit edit;
                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) return;
                if ((DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
                {
                    if (view.FocusedColumn.FieldName == CommonKey.ItemType)
                    {
                        //DataTable table = new DataTable();
                        System.Data.DataTable dtResult = new System.Data.DataTable();
                        System.Collections.Hashtable htCond = new System.Collections.Hashtable();
                        htCond.Add(CommonData.CommonCode, CommonData.Code.ItemType);

                        _commonBl.SelectItemTypeInRepositoryControl(htCond, out dtResult, this.ItemType);

                        if (resItemType.HasNull)
                        {
                            dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        }

                        edit.Properties.DataSource = dtResult;
                    }
                    else if (view.FocusedColumn.FieldName == CommonKey.QualityStatus)
                    {
                        //DataTable table = new DataTable();
                        System.Data.DataTable dtResult = new System.Data.DataTable();
                        System.Collections.Hashtable htCond = new System.Collections.Hashtable();
                        htCond.Add(CommonData.CommonCode, CommonData.Code.QualityStatus);

                        _commonBl.SelectItemTypeInRepositoryControl(htCond, out dtResult, this.QuanlityStatus);

                        if (resQualityStatus.HasNull)
                        {
                            dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        }

                        edit.Properties.DataSource = dtResult;
                    }
                    else if (view.FocusedColumn.FieldName == "RelatedDocumentNo")
                    {

                        System.Data.DataTable dtResult = new System.Data.DataTable();

                        if (!IsSAReturnCustomer)
                            _commonBl.SelectDocumentByWarehouse(out  dtResult, 4, CommonData.TransactionSubCode.SA_StockArrivingForPurchaseOrder, Warehouse, Supplier, Customer);
                        else
                            _commonBl.SelectDocumentByWarehouse(out  dtResult, 5, CommonData.TransactionSubCode.SH_StockShippingForDelivery, Warehouse, Supplier, Customer);


                        if (resDocumentNo.HasNull)
                        {
                            dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        }

                        edit.Properties.DataSource = dtResult;

                    }
                    else if (view.FocusedColumn.FieldName == CommonKey.InputUnit)
                    {

                        System.Data.DataTable dtResult = new System.Data.DataTable();

                        _commonBl.SelectUnitInRepositoryControl(out  dtResult, CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ItemCode"]));

                        if (resUnit.HasNull)
                        {
                            dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        }

                        edit.Properties.DataSource = dtResult;

                    }
                    else if (view.FocusedColumn.FieldName == "ProcessType")
                    {
                        DataTable dtResult = InitProcessType();
                        if (resProcessType.HasNull)
                            dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        edit.Properties.DataSource = dtResult;

                    }
                    else if (view.FocusedColumn.FieldName == CommonKey.ProductionLine)
                    {
                        System.Data.DataTable dtResult = new System.Data.DataTable();
                        _commonBl.SelectProductionLineInRepositoryControl(out  dtResult, CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]));

                        //if (resProductionLine.HasNull)
                        //{
                        //    dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                        //}

                        edit.Properties.DataSource = dtResult;

                    }

                  
                }
            }

        }

        private void dgvInventory_LostFocus(object sender, EventArgs e)
        {
            // 
            dgvInventory.CloseEditor();
            dgvInventory.UpdateCurrentRow();
            dgvInventory.PostEditor();
        }

        private void dgvInventory_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            this.dgvInventory.OptionsView.ColumnAutoWidth = false;
        }

        #endregion Events
    }


}
