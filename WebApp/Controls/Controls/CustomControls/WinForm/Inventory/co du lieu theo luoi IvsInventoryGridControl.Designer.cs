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
            this.dgcInventory = new Ivs.Controls.CustomControls.WinForm.IvsGridControl();
            this.dgvInventory = new Ivs.Controls.CustomControls.WinForm.IvsGridView();
            this.colLineNumber = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colOrderNo = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colDocumentDate = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colItemType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resItemType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colTransferType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resTransferType = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colItemCode = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resItemGrid = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new Ivs.Controls.CustomControls.WinForm.IvsGridView();
            this.colItemName = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colUnit = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resUnit = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colQuantity = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resQuantity = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resUnitPrice = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colAmount = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resAmount = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemTextEdit();
            this.colPruductionLine = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resProductionLine = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colQuanlityStatus = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resQualityStatus = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemCodeLookUp();
            this.colErrorReason = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resErrorReason = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemDataLookUp();
            this.colRemark = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.resItem = new Ivs.Controls.CustomControls.WinForm.IvsRepositoryItemProductLookUp();
            this.colLotNo = new IvsGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resDocumentNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTransferType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcInventory
            // 
            this.dgcInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcInventory.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.dgcInventory.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.dgcInventory.Location = new System.Drawing.Point(0, 0);
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
            this.resItemGrid});
            this.dgcInventory.Size = new System.Drawing.Size(1348, 371);
            this.dgcInventory.TabIndex = 1;
            this.dgcInventory.UseEmbeddedNavigator = true;
            this.dgcInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvInventory});
            // 
            // dgvInventory
            // 
            this.dgvInventory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineNumber,
            this.colOrderNo,
            this.colDocumentNo,
            this.colDocumentDate,
            this.colItemType,
            this.colTransferType,
            this.colItemCode,
            this.colItemName,
            this.colUnit,
            this.colQuantity,
            this.colUnitPrice,
            this.colAmount,
            this.colPruductionLine,
            this.colQuanlityStatus,
            this.colErrorReason,
            this.colRemark,
            this.colLotNo});
            this.dgvInventory.GridControl = this.dgcInventory;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.OptionsView.ShowAutoFilterRow = true;
            this.dgvInventory.OptionsView.ShowGroupPanel = false;
            // 
            // colLineNumber
            // 
            this.colLineNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colLineNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colLineNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineNumber.Caption = "No.";
            this.colLineNumber.FieldName = "LineNumber";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.OptionsColumn.AllowEdit = false;
            this.colLineNumber.Visible = true;
            this.colLineNumber.VisibleIndex = 0;
            this.colLineNumber.Width = 50;
            // 
            // colOrderNo
            // 
            this.colOrderNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderNo.Caption = "Order No.";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 1;
            this.colOrderNo.Width = 100;
            // 
            // colDocumentNo
            // 
            this.colDocumentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDocumentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDocumentNo.Caption = "Document No.";
            this.colDocumentNo.ColumnEdit = this.resDocumentNo;
            this.colDocumentNo.FieldName = "DocumentNo";
            this.colDocumentNo.Name = "colDocumentNo";
            this.colDocumentNo.Visible = true;
            this.colDocumentNo.VisibleIndex = 2;
            // 
            // resDocumentNo
            // 
            this.resDocumentNo.AutoHeight = false;
            this.resDocumentNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resDocumentNo.Code = "";
            this.resDocumentNo.EmpWrkType = "";
            this.resDocumentNo.HasNull = false;
            this.resDocumentNo.IsActive = false;
            this.resDocumentNo.IsFemale = false;
            this.resDocumentNo.IsLeavePlanning = false;
            this.resDocumentNo.IsLeaveReason = false;
            this.resDocumentNo.Name = "resDocumentNo";
            this.resDocumentNo.Table = null;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDocumentDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDocumentDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDocumentDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDocumentDate.Caption = "Document Date";
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.OptionsColumn.AllowEdit = false;
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 3;
            // 
            // colItemType
            // 
            this.colItemType.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemType.Caption = "Item Type";
            this.colItemType.ColumnEdit = this.resItemType;
            this.colItemType.FieldName = "ItemType";
            this.colItemType.Name = "colItemType";
            this.colItemType.Visible = true;
            this.colItemType.VisibleIndex = 4;
            // 
            // resItemType
            // 
            this.resItemType.AutoHeight = false;
            this.resItemType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resItemType.Code = "";
            this.resItemType.HasNull = false;
            this.resItemType.Name = "resItemType";
            // 
            // colTransferType
            // 
            this.colTransferType.AppearanceHeader.Options.UseTextOptions = true;
            this.colTransferType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTransferType.Caption = "TransferType";
            this.colTransferType.ColumnEdit = this.resTransferType;
            this.colTransferType.FieldName = "TransferType";
            this.colTransferType.Name = "colTransferType";
            this.colTransferType.Visible = true;
            this.colTransferType.VisibleIndex = 5;
            // 
            // resTransferType
            // 
            this.resTransferType.AutoHeight = false;
            this.resTransferType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resTransferType.Code = "";
            this.resTransferType.HasNull = false;
            this.resTransferType.Name = "resTransferType";
            // 
            // colItemCode
            // 
            this.colItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemCode.Caption = "Item Code";
            this.colItemCode.ColumnEdit = this.resItemGrid;
            this.colItemCode.FieldName = "ItemCode";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 6;
            this.colItemCode.Width = 150;
            // 
            // resItemGrid
            // 
            this.resItemGrid.AutoHeight = false;
            this.resItemGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resItemGrid.Columns = null;
            this.resItemGrid.DisplayMember = "ItemCode";
            this.resItemGrid.HasNull = false;
            this.resItemGrid.Name = "resItemGrid";
            this.resItemGrid.NullText = "";
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
            // colItemName
            // 
            this.colItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 7;
            this.colItemName.Width = 200;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.Caption = "Unit";
            this.colUnit.ColumnEdit = this.resUnit;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 8;
            this.colUnit.Width = 100;
            // 
            // resUnit
            // 
            this.resUnit.AutoHeight = false;
            this.resUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.ColumnEdit = this.resQuantity;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 9;
            // 
            // resQuantity
            // 
            this.resQuantity.AutoHeight = false;
            this.resQuantity.IsCurrency = false;
            this.resQuantity.IsNumberic = false;
            this.resQuantity.IsPositiveNumber = false;
            this.resQuantity.IsPositivePercentage = false;
            this.resQuantity.Name = "resQuantity";
            this.resQuantity.NumOfDecimalPlaces = 0;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitPrice.Caption = "Unit Price";
            this.colUnitPrice.ColumnEdit = this.resUnitPrice;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 10;
            this.colUnitPrice.Width = 169;
            // 
            // resUnitPrice
            // 
            this.resUnitPrice.AutoHeight = false;
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
            this.colAmount.Caption = "Amount";
            this.colAmount.ColumnEdit = this.resAmount;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowEdit = false;
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 11;
            this.colAmount.Width = 169;
            // 
            // resAmount
            // 
            this.resAmount.AutoHeight = false;
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
            this.colPruductionLine.Caption = "Production Line";
            this.colPruductionLine.ColumnEdit = this.resProductionLine;
            this.colPruductionLine.FieldName = "ProductionLine";
            this.colPruductionLine.Name = "colPruductionLine";
            this.colPruductionLine.OptionsColumn.AllowEdit = false;
            this.colPruductionLine.Visible = true;
            this.colPruductionLine.VisibleIndex = 12;
            // 
            // resProductionLine
            // 
            this.resProductionLine.AutoHeight = false;
            this.resProductionLine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            // colQuanlityStatus
            // 
            this.colQuanlityStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuanlityStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuanlityStatus.Caption = "Quanlity Status";
            this.colQuanlityStatus.ColumnEdit = this.resQualityStatus;
            this.colQuanlityStatus.FieldName = "QualityStatus";
            this.colQuanlityStatus.Name = "colQuanlityStatus";
            this.colQuanlityStatus.Visible = true;
            this.colQuanlityStatus.VisibleIndex = 13;
            // 
            // resQualityStatus
            // 
            this.resQualityStatus.AutoHeight = false;
            this.resQualityStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resQualityStatus.Code = "";
            this.resQualityStatus.HasNull = false;
            this.resQualityStatus.Name = "resQualityStatus";
            // 
            // colErrorReason
            // 
            this.colErrorReason.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorReason.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorReason.Caption = "Error Reason";
            this.colErrorReason.ColumnEdit = this.resErrorReason;
            this.colErrorReason.FieldName = "ErrorReason";
            this.colErrorReason.Name = "colErrorReason";
            this.colErrorReason.Visible = true;
            this.colErrorReason.VisibleIndex = 14;
            // 
            // resErrorReason
            // 
            this.resErrorReason.AutoHeight = false;
            this.resErrorReason.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 16;
            this.colRemark.Width = 106;
            // 
            // resItem
            // 
            this.resItem.AutoHeight = false;
            this.resItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Lot.No";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.Visible = true;
            this.colLotNo.VisibleIndex = 15;
            // 
            // IvsInventoryGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcInventory);
            this.Name = "IvsInventoryGridControl";
            this.Size = new System.Drawing.Size(1348, 371);
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resDocumentNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTransferType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resProductionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resQualityStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resErrorReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IvsRepositoryItemDataLookUp resUnit;
        private IvsRepositoryItemTextEdit resQuantity;
        private IvsRepositoryItemTextEdit resUnitPrice;
        private IvsRepositoryItemTextEdit resAmount;
        private IvsRepositoryItemDataLookUp resDocumentNo;
        private IvsRepositoryItemCodeLookUp resItemType;
        private IvsRepositoryItemCodeLookUp resTransferType;
        private IvsRepositoryItemDataLookUp resProductionLine;
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
        public IvsGridColumn colQuanlityStatus;
        private IvsRepositoryItemGridLookUpEdit resItemGrid;
        private IvsGridView repositoryItemGridLookUpEdit1View;
        private IvsGridColumn colLotNo;

    }
}
