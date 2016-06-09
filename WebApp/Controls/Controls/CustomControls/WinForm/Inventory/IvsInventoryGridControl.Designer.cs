namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class IvsInventoryGridControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IvsInventoryGridControl));
            this.dgcInventory = new Ivs.Controls.CustomControls.WinForm.IvsGridControl();
            this.dgvInventory = new Ivs.Controls.CustomControls.WinForm.IvsGridView();
            this.colSelect = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.chkSelect = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCheckEdit();
            this.colLineNumber = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colOrderNo = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resOrderNo = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colDocumentDate = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colItemType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resItemType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colTransferType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resTransferType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colItemCode = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resItem = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemProductLookUp();
            this.colItemName = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colUnit = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resUnit = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colStockQty = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resQuantity = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colQuantity = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colAmount = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resAmount = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colPruductionLine = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resProductionLine = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemProductionLineDataLookUp();
            this.colQualityStatus = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resQualityStatus = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colErrorReason = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resErrorReason = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colRemark = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resRemark = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colLotNo = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resLotNo = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colProcessType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resProcessType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.resItemGrid = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new Ivs.Controls.CustomControls.WinForm.IvsGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resDocumentNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTransferType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resLotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProcessType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcInventory
            // 
            resources.ApplyResources(this.dgcInventory, "dgcInventory");
            this.dgcInventory.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgcInventory.MainView = this.dgvInventory;
            this.dgcInventory.MoveNextRowWhenLastCellFocused = false;
            this.dgcInventory.Name = "dgcInventory";
            this.dgcInventory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.resQuantity,
            this.resUnitPrice,
            this.resAmount,
            this.resItem,
            this.resUnit,
            this.resDocumentNo,
            this.resItemType,
            this.resTransferType,
            this.resProductionLine,
            this.resQualityStatus,
            this.resErrorReason,
            this.resItemGrid,
            this.resRemark,
            this.resOrderNo,
            this.resLotNo,
            this.resProcessType,
            this.chkSelect});
            this.dgcInventory.UseEmbeddedNavigator = true;
            this.dgcInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvInventory});
            // 
            // dgvInventory
            // 
            this.dgvInventory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelect,
            this.colLineNumber,
            this.colOrderNo,
            this.colDocumentNo,
            this.colDocumentDate,
            this.colItemType,
            this.colTransferType,
            this.colItemCode,
            this.colItemName,
            this.colUnit,
            this.colStockQty,
            this.colQuantity,
            this.colUnitPrice,
            this.colAmount,
            this.colPruductionLine,
            this.colQualityStatus,
            this.colErrorReason,
            this.colRemark,
            this.colLotNo,
            this.colProcessType});
            this.dgvInventory.GridControl = this.dgcInventory;
            this.dgvInventory.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.OptionsView.ColumnAutoWidth = false;
            this.dgvInventory.OptionsView.ShowAutoFilterRow = true;
            this.dgvInventory.OptionsView.ShowGroupPanel = false;
            this.dgvInventory.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colSelect
            // 
            resources.ApplyResources(this.colSelect, "colSelect");
            this.colSelect.ColumnEdit = this.chkSelect;
            this.colSelect.FieldName = "Select";
            this.colSelect.Name = "colSelect";
            // 
            // chkSelect
            // 
            resources.ApplyResources(this.chkSelect, "chkSelect");
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.ValueChecked = "True";
            this.chkSelect.ValueGrayed = "False";
            this.chkSelect.ValueUnchecked = "False";
            // 
            // colLineNumber
            // 
            this.colLineNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colLineNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colLineNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLineNumber, "colLineNumber");
            this.colLineNumber.FieldName = "LineNumber";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.OptionsColumn.AllowEdit = false;
            this.colLineNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLineNumber.OptionsColumn.AllowMove = false;
            // 
            // colOrderNo
            // 
            this.colOrderNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colOrderNo, "colOrderNo");
            this.colOrderNo.ColumnEdit = this.resOrderNo;
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNo.OptionsColumn.AllowMove = false;
            // 
            // resOrderNo
            // 
            resources.ApplyResources(this.resOrderNo, "resOrderNo");
            this.resOrderNo.IsCurrency = false;
            this.resOrderNo.IsNumberic = false;
            this.resOrderNo.IsPositiveNumber = false;
            this.resOrderNo.IsPositivePercentage = false;
            this.resOrderNo.MaxLength = 20;
            this.resOrderNo.Name = "resOrderNo";
            this.resOrderNo.NumOfDecimalPlaces = 0;
            // 
            // colDocumentNo
            // 
            this.colDocumentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDocumentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colDocumentNo, "colDocumentNo");
            this.colDocumentNo.ColumnEdit = this.resDocumentNo;
            this.colDocumentNo.FieldName = "RelatedDocumentNo";
            this.colDocumentNo.Name = "colDocumentNo";
            this.colDocumentNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDocumentNo.OptionsColumn.AllowMove = false;
            // 
            // resDocumentNo
            // 
            resources.ApplyResources(this.resDocumentNo, "resDocumentNo");
            this.resDocumentNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resDocumentNo.Buttons"))))});
            this.resDocumentNo.Code = "";
            this.resDocumentNo.EmpWrkType = "";
            this.resDocumentNo.HasNull = false;
            this.resDocumentNo.IsActive = false;
            this.resDocumentNo.IsFemale = false;
            this.resDocumentNo.IsLeavePlanning = false;
            this.resDocumentNo.IsLeaveReason = false;
            this.resDocumentNo.MaxLength = 15;
            this.resDocumentNo.Name = "resDocumentNo";
            this.resDocumentNo.Table = null;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDocumentDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDocumentDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDocumentDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colDocumentDate, "colDocumentDate");
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.OptionsColumn.AllowEdit = false;
            this.colDocumentDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDocumentDate.OptionsColumn.AllowMove = false;
            // 
            // colItemType
            // 
            this.colItemType.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colItemType, "colItemType");
            this.colItemType.ColumnEdit = this.resItemType;
            this.colItemType.FieldName = "ItemType";
            this.colItemType.Name = "colItemType";
            this.colItemType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colItemType.OptionsColumn.AllowMove = false;
            // 
            // resItemType
            // 
            resources.ApplyResources(this.resItemType, "resItemType");
            this.resItemType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resItemType.Buttons"))))});
            this.resItemType.Code = "";
            this.resItemType.HasNull = false;
            this.resItemType.Name = "resItemType";
            // 
            // colTransferType
            // 
            this.colTransferType.AppearanceHeader.Options.UseTextOptions = true;
            this.colTransferType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colTransferType, "colTransferType");
            this.colTransferType.ColumnEdit = this.resTransferType;
            this.colTransferType.FieldName = "TransferType";
            this.colTransferType.Name = "colTransferType";
            this.colTransferType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferType.OptionsColumn.AllowMove = false;
            // 
            // resTransferType
            // 
            resources.ApplyResources(this.resTransferType, "resTransferType");
            this.resTransferType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resTransferType.Buttons"))))});
            this.resTransferType.Code = "";
            this.resTransferType.HasNull = false;
            this.resTransferType.Name = "resTransferType";
            // 
            // colItemCode
            // 
            this.colItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.ColumnEdit = this.resItem;
            this.colItemCode.FieldName = "ItemCode";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colItemCode.OptionsColumn.AllowMove = false;
            // 
            // resItem
            // 
            resources.ApplyResources(this.resItem, "resItem");
            this.resItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resItem.Buttons"))))});
            this.resItem.Code = "";
            this.resItem.DocumentNo = null;
            this.resItem.EmpWrkType = "";
            this.resItem.HasNull = false;
            this.resItem.IsActive = false;
            this.resItem.IsFemale = false;
            this.resItem.IsLeavePlanning = false;
            this.resItem.IsLeaveReason = false;
            this.resItem.ItemType = null;
            this.resItem.Name = "resItem";
            this.resItem.Table = null;
            this.resItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // colItemName
            // 
            this.colItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
            this.colItemName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsColumn.AllowMove = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colUnit, "colUnit");
            this.colUnit.ColumnEdit = this.resUnit;
            this.colUnit.FieldName = "InputUnit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsColumn.AllowMove = false;
            // 
            // resUnit
            // 
            resources.ApplyResources(this.resUnit, "resUnit");
            this.resUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resUnit.Buttons"))))});
            this.resUnit.Code = "";
            this.resUnit.EmpWrkType = "";
            this.resUnit.HasNull = false;
            this.resUnit.IsActive = false;
            this.resUnit.IsFemale = false;
            this.resUnit.IsLeavePlanning = false;
            this.resUnit.IsLeaveReason = false;
            this.resUnit.Name = "resUnit";
            this.resUnit.Table = null;
            // 
            // colStockQty
            // 
            this.colStockQty.AppearanceCell.Options.UseTextOptions = true;
            this.colStockQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colStockQty, "colStockQty");
            this.colStockQty.ColumnEdit = this.resQuantity;
            this.colStockQty.FieldName = "CurrentQty";
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.OptionsColumn.AllowEdit = false;
            // 
            // resQuantity
            // 
            this.resQuantity.AllowMouseWheel = false;
            resources.ApplyResources(this.resQuantity, "resQuantity");
            this.resQuantity.IsCurrency = false;
            this.resQuantity.IsNumberic = false;
            this.resQuantity.IsPositiveNumber = false;
            this.resQuantity.IsPositivePercentage = false;
            this.resQuantity.MaxLength = 9;
            this.resQuantity.Name = "resQuantity";
            this.resQuantity.NumOfDecimalPlaces = 0;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colQuantity, "colQuantity");
            this.colQuantity.ColumnEdit = this.resQuantity;
            this.colQuantity.FieldName = "InputQuantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity.OptionsColumn.AllowMove = false;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colUnitPrice, "colUnitPrice");
            this.colUnitPrice.ColumnEdit = this.resUnitPrice;
            this.colUnitPrice.FieldName = "InputUnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsColumn.AllowMove = false;
            // 
            // resUnitPrice
            // 
            resources.ApplyResources(this.resUnitPrice, "resUnitPrice");
            this.resUnitPrice.IsCurrency = false;
            this.resUnitPrice.IsNumberic = false;
            this.resUnitPrice.IsPositiveNumber = false;
            this.resUnitPrice.IsPositivePercentage = false;
            this.resUnitPrice.Name = "resUnitPrice";
            this.resUnitPrice.NumOfDecimalPlaces = 0;
            // 
            // colAmount
            // 
            this.colAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colAmount, "colAmount");
            this.colAmount.ColumnEdit = this.resAmount;
            this.colAmount.FieldName = "InputAmount";
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowEdit = false;
            this.colAmount.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colAmount.OptionsColumn.AllowMove = false;
            // 
            // resAmount
            // 
            resources.ApplyResources(this.resAmount, "resAmount");
            this.resAmount.IsCurrency = false;
            this.resAmount.IsNumberic = false;
            this.resAmount.IsPositiveNumber = false;
            this.resAmount.IsPositivePercentage = false;
            this.resAmount.Name = "resAmount";
            this.resAmount.NumOfDecimalPlaces = 0;
            // 
            // colPruductionLine
            // 
            this.colPruductionLine.AppearanceHeader.Options.UseTextOptions = true;
            this.colPruductionLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colPruductionLine, "colPruductionLine");
            this.colPruductionLine.ColumnEdit = this.resProductionLine;
            this.colPruductionLine.FieldName = "ProductionLine";
            this.colPruductionLine.Name = "colPruductionLine";
            this.colPruductionLine.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPruductionLine.OptionsColumn.AllowMove = false;
            // 
            // resProductionLine
            // 
            resources.ApplyResources(this.resProductionLine, "resProductionLine");
            this.resProductionLine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resProductionLine.Buttons"))))});
            this.resProductionLine.Code = "";
            this.resProductionLine.EmpWrkType = "";
            this.resProductionLine.HasNull = false;
            this.resProductionLine.IsActive = false;
            this.resProductionLine.IsFemale = false;
            this.resProductionLine.IsLeavePlanning = false;
            this.resProductionLine.IsLeaveReason = false;
            this.resProductionLine.Name = "resProductionLine";
            this.resProductionLine.Table = null;
            // 
            // colQualityStatus
            // 
            this.colQualityStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colQualityStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQualityStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colQualityStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colQualityStatus, "colQualityStatus");
            this.colQualityStatus.ColumnEdit = this.resQualityStatus;
            this.colQualityStatus.FieldName = "QualityStatus";
            this.colQualityStatus.Name = "colQualityStatus";
            this.colQualityStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colQualityStatus.OptionsColumn.AllowMove = false;
            // 
            // resQualityStatus
            // 
            resources.ApplyResources(this.resQualityStatus, "resQualityStatus");
            this.resQualityStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resQualityStatus.Buttons"))))});
            this.resQualityStatus.Code = "";
            this.resQualityStatus.HasNull = false;
            this.resQualityStatus.Name = "resQualityStatus";
            // 
            // colErrorReason
            // 
            this.colErrorReason.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorReason.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colErrorReason, "colErrorReason");
            this.colErrorReason.ColumnEdit = this.resErrorReason;
            this.colErrorReason.FieldName = "ErrorReason";
            this.colErrorReason.Name = "colErrorReason";
            this.colErrorReason.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colErrorReason.OptionsColumn.AllowMove = false;
            // 
            // resErrorReason
            // 
            resources.ApplyResources(this.resErrorReason, "resErrorReason");
            this.resErrorReason.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resErrorReason.Buttons"))))});
            this.resErrorReason.Code = "";
            this.resErrorReason.EmpWrkType = "";
            this.resErrorReason.HasNull = false;
            this.resErrorReason.IsActive = false;
            this.resErrorReason.IsFemale = false;
            this.resErrorReason.IsLeavePlanning = false;
            this.resErrorReason.IsLeaveReason = false;
            this.resErrorReason.Name = "resErrorReason";
            this.resErrorReason.Table = null;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colRemark, "colRemark");
            this.colRemark.ColumnEdit = this.resRemark;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colRemark.OptionsColumn.AllowMove = false;
            // 
            // resRemark
            // 
            this.resRemark.IsCurrency = false;
            this.resRemark.IsNumberic = false;
            this.resRemark.IsPositiveNumber = false;
            this.resRemark.IsPositivePercentage = false;
            this.resRemark.MaxLength = 150;
            this.resRemark.Name = "resRemark";
            this.resRemark.NumOfDecimalPlaces = 0;
            // 
            // colLotNo
            // 
            this.colLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLotNo, "colLotNo");
            this.colLotNo.ColumnEdit = this.resLotNo;
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLotNo.OptionsColumn.AllowMove = false;
            // 
            // resLotNo
            // 
            resources.ApplyResources(this.resLotNo, "resLotNo");
            this.resLotNo.IsCurrency = false;
            this.resLotNo.IsNumberic = false;
            this.resLotNo.IsPositiveNumber = false;
            this.resLotNo.IsPositivePercentage = false;
            this.resLotNo.MaxLength = 15;
            this.resLotNo.Name = "resLotNo";
            this.resLotNo.NumOfDecimalPlaces = 0;
            // 
            // colProcessType
            // 
            this.colProcessType.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcessType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colProcessType, "colProcessType");
            this.colProcessType.ColumnEdit = this.resProcessType;
            this.colProcessType.FieldName = "ProcessType";
            this.colProcessType.Name = "colProcessType";
            // 
            // resProcessType
            // 
            resources.ApplyResources(this.resProcessType, "resProcessType");
            this.resProcessType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resProcessType.Buttons"))))});
            this.resProcessType.Code = "";
            this.resProcessType.EmpWrkType = "";
            this.resProcessType.HasNull = false;
            this.resProcessType.IsActive = false;
            this.resProcessType.IsFemale = false;
            this.resProcessType.IsLeavePlanning = false;
            this.resProcessType.IsLeaveReason = false;
            this.resProcessType.Name = "resProcessType";
            this.resProcessType.Table = null;
            // 
            // resItemGrid
            // 
            resources.ApplyResources(this.resItemGrid, "resItemGrid");
            this.resItemGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("resItemGrid.Buttons"))))});
            this.resItemGrid.Columns = null;
            this.resItemGrid.DisplayMember = "ItemCode";
            this.resItemGrid.HasNull = false;
            this.resItemGrid.Name = "resItemGrid";
            this.resItemGrid.TableData = null;
            this.resItemGrid.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // IvsInventoryGridControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcInventory);
            this.Name = "IvsInventoryGridControl";
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resDocumentNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTransferType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resLotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProcessType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IvsRepositoryItemTextEdit resQuantity;
        private IvsRepositoryItemTextEdit resUnitPrice;
        private IvsRepositoryItemTextEdit resAmount;
        private IvsRepositoryItemDataLookUp resDocumentNo;
        private IvsRepositoryItemCodeLookUp resItemType;
        private IvsRepositoryItemCodeLookUp resTransferType;
        private IvsRepositoryItemCodeLookUp resQualityStatus;
        private IvsRepositoryItemDataLookUp resErrorReason;
        public IvsGridControl dgcInventory;
        public IvsGridView dgvInventory;
        protected IvsRepositoryItemProductLookUp resItem;
        public IvsGridColumn colLineNumber;
        public IvsGridColumn colOrderNo;
        public IvsGridColumn colItemCode;
        public IvsGridColumn colItemName;
        public IvsGridColumn colUnit;
        public IvsGridColumn colQuantity;
        public IvsGridColumn colUnitPrice;
        public IvsGridColumn colAmount;
        public IvsGridColumn colRemark;
        public IvsGridColumn colDocumentNo;
        public IvsGridColumn colDocumentDate;
        public IvsGridColumn colErrorReason;
        public IvsGridColumn colTransferType;
        public IvsGridColumn colItemType;
        public IvsGridColumn colPruductionLine;
        public IvsGridColumn colQualityStatus;
        private IvsRepositoryItemGridLookUpEdit resItemGrid;
        private IvsGridView repositoryItemGridLookUpEdit1View;
        private IvsGridColumn colLotNo;
        private IvsRepositoryItemTextEdit resRemark;
        protected IvsRepositoryItemProductionLineDataLookUp resProductionLine;
        private IvsRepositoryItemTextEdit resOrderNo;
        private IvsRepositoryItemTextEdit resLotNo;
        private IvsGridColumn colProcessType;
        protected IvsRepositoryItemDataLookUp resProcessType;
        protected IvsRepositoryItemDataLookUp resUnit;
        private IvsGridColumn colSelect;
        private IvsRepositoryItemCheckEdit chkSelect;
        private IvsGridColumn colStockQty;


    }
}
