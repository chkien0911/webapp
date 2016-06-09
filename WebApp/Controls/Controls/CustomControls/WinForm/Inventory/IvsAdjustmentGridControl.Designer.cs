namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class IvsAdjustmentGridControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IvsAdjustmentGridControl));
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.dgcAdjustment = new Ivs.Controls.CustomControls.WinForm.IvsGridControl();
            this.dgvAdjustment = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridView();
            this.colNo = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.colProcessType = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resProcessType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colItemCode = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resItem = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemProductLookUp();
            this.colItemName = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.colProductionLine = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resProductionLine = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemProductionLineDataLookUp();
            this.colUnit = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resUnit = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colQuality = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resQualityStatus = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colPlusOrMinus = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.colQuatity = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resQuantity = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colInputUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colInputAmount = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resAmount = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colLotNo = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.colReason = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.colItemType = new Ivs.Controls.CustomControls.WinForm.IvsBandedGridColumn();
            this.resErrorReason = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.bandNo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandProcessType = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandItemCode = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandItemName = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BandProductionLine = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandUnit = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandQualityStatus = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BandQuality = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandAdjustment = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandMinusPlus = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandQty = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandUnitPrice = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandAmount = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandLotNo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandReason = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ivsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProcessType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).BeginInit();
            this.SuspendLayout();
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.dgcAdjustment);
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
            this.ivsPanel1.Name = "ivsPanel1";
            // 
            // dgcAdjustment
            // 
            resources.ApplyResources(this.dgcAdjustment, "dgcAdjustment");
            this.dgcAdjustment.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgcAdjustment.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgcAdjustment.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgcAdjustment.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgcAdjustment.MainView = this.dgvAdjustment;
            this.dgcAdjustment.MoveNextRowWhenLastCellFocused = false;
            this.dgcAdjustment.Name = "dgcAdjustment";
            this.dgcAdjustment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.resItem,
            this.resUnit,
            this.resProductionLine,
            this.resQualityStatus,
            this.resQuantity,
            this.resErrorReason,
            this.resProcessType,
            this.resUnitPrice,
            this.resAmount});
            this.dgcAdjustment.UseEmbeddedNavigator = true;
            this.dgcAdjustment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvAdjustment});
            // 
            // dgvAdjustment
            // 
            this.dgvAdjustment.Appearance.BandPanel.Options.UseTextOptions = true;
            this.dgvAdjustment.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvAdjustment.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.dgvAdjustment.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvAdjustment.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandNo,
            this.bandProcessType,
            this.bandItemCode,
            this.bandItemName,
            this.BandProductionLine,
            this.bandUnit,
            this.bandQualityStatus,
            this.BandQuality,
            this.bandAdjustment,
            this.bandLotNo,
            this.bandReason});
            this.dgvAdjustment.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colNo,
            this.colProcessType,
            this.colItemType,
            this.colItemCode,
            this.colItemName,
            this.colProductionLine,
            this.colUnit,
            this.colPlusOrMinus,
            this.colQuatity,
            this.colQuality,
            this.colLotNo,
            this.colReason,
            this.colInputUnitPrice,
            this.colInputAmount});
            this.dgvAdjustment.GridControl = this.dgcAdjustment;
            this.dgvAdjustment.Name = "dgvAdjustment";
            this.dgvAdjustment.OptionsPrint.PrintHeader = false;
            this.dgvAdjustment.OptionsView.ShowAutoFilterRow = true;
            this.dgvAdjustment.OptionsView.ShowColumnHeaders = false;
            this.dgvAdjustment.OptionsView.ShowGroupPanel = false;
            // 
            // colNo
            // 
            resources.ApplyResources(this.colNo, "colNo");
            this.colNo.FieldName = "LineNumber";
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            // 
            // colProcessType
            // 
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
            // colItemCode
            // 
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.ColumnEdit = this.resItem;
            this.colItemCode.FieldName = "ItemCode";
            this.colItemCode.Name = "colItemCode";
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
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            // 
            // colProductionLine
            // 
            resources.ApplyResources(this.colProductionLine, "colProductionLine");
            this.colProductionLine.ColumnEdit = this.resProductionLine;
            this.colProductionLine.FieldName = "ProductionLine";
            this.colProductionLine.Name = "colProductionLine";
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
            // colUnit
            // 
            this.colUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colUnit, "colUnit");
            this.colUnit.ColumnEdit = this.resUnit;
            this.colUnit.FieldName = "InputUnit";
            this.colUnit.Name = "colUnit";
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
            // colQuality
            // 
            this.colQuality.AppearanceCell.Options.UseTextOptions = true;
            this.colQuality.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colQuality, "colQuality");
            this.colQuality.ColumnEdit = this.resQualityStatus;
            this.colQuality.FieldName = "QualityStatus";
            this.colQuality.Name = "colQuality";
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
            // colPlusOrMinus
            // 
            this.colPlusOrMinus.AppearanceCell.Options.UseTextOptions = true;
            this.colPlusOrMinus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colPlusOrMinus, "colPlusOrMinus");
            this.colPlusOrMinus.FieldName = "BalanceFlag";
            this.colPlusOrMinus.Name = "colPlusOrMinus";
            this.colPlusOrMinus.OptionsColumn.AllowEdit = false;
            // 
            // colQuatity
            // 
            this.colQuatity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuatity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colQuatity, "colQuatity");
            this.colQuatity.ColumnEdit = this.resQuantity;
            this.colQuatity.FieldName = "InputQuantity";
            this.colQuatity.Name = "colQuatity";
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
            // colInputUnitPrice
            // 
            this.colInputUnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colInputUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colInputUnitPrice, "colInputUnitPrice");
            this.colInputUnitPrice.ColumnEdit = this.resUnitPrice;
            this.colInputUnitPrice.FieldName = "InputUnitPrice";
            this.colInputUnitPrice.Name = "colInputUnitPrice";
            this.colInputUnitPrice.OptionsColumn.AllowEdit = false;
            // 
            // resUnitPrice
            // 
            resources.ApplyResources(this.resUnitPrice, "resUnitPrice");
            this.resUnitPrice.IsCurrency = false;
            this.resUnitPrice.IsNumberic = false;
            this.resUnitPrice.IsPositiveNumber = false;
            this.resUnitPrice.IsPositivePercentage = false;
            this.resUnitPrice.MaxLength = 10;
            this.resUnitPrice.Name = "resUnitPrice";
            this.resUnitPrice.NumOfDecimalPlaces = 0;
            // 
            // colInputAmount
            // 
            this.colInputAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colInputAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colInputAmount, "colInputAmount");
            this.colInputAmount.ColumnEdit = this.resAmount;
            this.colInputAmount.FieldName = "InputAmount";
            this.colInputAmount.Name = "colInputAmount";
            this.colInputAmount.OptionsColumn.AllowEdit = false;
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
            // colLotNo
            // 
            resources.ApplyResources(this.colLotNo, "colLotNo");
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            // 
            // colReason
            // 
            resources.ApplyResources(this.colReason, "colReason");
            this.colReason.FieldName = "Remark";
            this.colReason.Name = "colReason";
            // 
            // colItemType
            // 
            resources.ApplyResources(this.colItemType, "colItemType");
            this.colItemType.FieldName = "ItemType";
            this.colItemType.Name = "colItemType";
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
            // bandNo
            // 
            resources.ApplyResources(this.bandNo, "bandNo");
            this.bandNo.Columns.Add(this.colNo);
            // 
            // bandProcessType
            // 
            resources.ApplyResources(this.bandProcessType, "bandProcessType");
            this.bandProcessType.Columns.Add(this.colProcessType);
            // 
            // bandItemCode
            // 
            resources.ApplyResources(this.bandItemCode, "bandItemCode");
            this.bandItemCode.Columns.Add(this.colItemCode);
            // 
            // bandItemName
            // 
            resources.ApplyResources(this.bandItemName, "bandItemName");
            this.bandItemName.Columns.Add(this.colItemName);
            // 
            // BandProductionLine
            // 
            resources.ApplyResources(this.BandProductionLine, "BandProductionLine");
            this.BandProductionLine.Columns.Add(this.colProductionLine);
            // 
            // bandUnit
            // 
            resources.ApplyResources(this.bandUnit, "bandUnit");
            this.bandUnit.Columns.Add(this.colUnit);
            // 
            // bandQualityStatus
            // 
            resources.ApplyResources(this.bandQualityStatus, "bandQualityStatus");
            // 
            // BandQuality
            // 
            resources.ApplyResources(this.BandQuality, "BandQuality");
            this.BandQuality.Columns.Add(this.colQuality);
            // 
            // bandAdjustment
            // 
            resources.ApplyResources(this.bandAdjustment, "bandAdjustment");
            this.bandAdjustment.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandMinusPlus,
            this.bandQty,
            this.bandUnitPrice,
            this.bandAmount});
            // 
            // bandMinusPlus
            // 
            resources.ApplyResources(this.bandMinusPlus, "bandMinusPlus");
            this.bandMinusPlus.Columns.Add(this.colPlusOrMinus);
            // 
            // bandQty
            // 
            resources.ApplyResources(this.bandQty, "bandQty");
            this.bandQty.Columns.Add(this.colQuatity);
            // 
            // bandUnitPrice
            // 
            resources.ApplyResources(this.bandUnitPrice, "bandUnitPrice");
            this.bandUnitPrice.Columns.Add(this.colInputUnitPrice);
            // 
            // bandAmount
            // 
            resources.ApplyResources(this.bandAmount, "bandAmount");
            this.bandAmount.Columns.Add(this.colInputAmount);
            // 
            // bandLotNo
            // 
            resources.ApplyResources(this.bandLotNo, "bandLotNo");
            this.bandLotNo.Columns.Add(this.colLotNo);
            // 
            // bandReason
            // 
            resources.ApplyResources(this.bandReason, "bandReason");
            this.bandReason.Columns.Add(this.colReason);
            // 
            // IvsAdjustmentGridControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ivsPanel1);
            this.Name = "IvsAdjustmentGridControl";
            this.ivsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcAdjustment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProcessType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IvsPanel ivsPanel1;

        public IvsGridControl dgcAdjustment;
        private IvsRepositoryItemDataLookUp resUnit;
        private IvsBandedGridColumn colItemCode;
        private IvsBandedGridColumn colItemName;
        private IvsBandedGridColumn colUnit;
        private IvsBandedGridColumn colPlusOrMinus;
        private IvsBandedGridColumn colQuatity;
        private IvsBandedGridColumn colReason;
        private IvsBandedGridColumn colNo;
        private IvsBandedGridColumn colProductionLine;
        private IvsBandedGridColumn colQuality;
        private IvsBandedGridColumn colLotNo;
        private IvsRepositoryItemProductionLineDataLookUp resProductionLine;
        protected IvsRepositoryItemProductLookUp resItem;
        private IvsRepositoryItemCodeLookUp resQualityStatus;
        private IvsRepositoryItemTextEdit resQuantity;
        public IvsBandedGridView dgvAdjustment;
        private IvsRepositoryItemDataLookUp resErrorReason;
        private IvsBandedGridColumn colProcessType;
        private IvsRepositoryItemDataLookUp resProcessType;
        private IvsBandedGridColumn colItemType;
        private IvsBandedGridColumn colInputUnitPrice;
        private IvsRepositoryItemTextEdit resUnitPrice;
        private IvsBandedGridColumn colInputAmount;
        private IvsRepositoryItemTextEdit resAmount;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandNo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandProcessType;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandItemCode;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandItemName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand BandProductionLine;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandQualityStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand BandQuality;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandAdjustment;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandMinusPlus;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandQty;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandUnitPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandAmount;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandLotNo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandReason;
    }
}
