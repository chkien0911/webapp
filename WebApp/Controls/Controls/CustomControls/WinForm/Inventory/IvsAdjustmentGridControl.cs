using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ivs.Core.Interface;
using Ivs.DTO.Common;
using Ivs.Core.Common;
using Ivs.DTO.Master;
using Ivs.BLL.Common;
using Ivs.Core.Data;
using System.Linq;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsAdjustmentGridControl : IvsUserControl
    {
        protected CommonBl _commonBl = new CommonBl();

        public string Warehouse { get; set; }

        public string QuanlityStatus { get; set; }

        public string DefaultQualityStatus { get; set; }

        public bool ShowUnitPrice { get; set; }

        public bool ShowAmount { get; set; }

        //public string ProcessType { get; set; } //use to view combobox ItemType in gridview
        //private bool _showProductionLine;
        private bool _isValid = true;
        //public bool ShowProductionLine
        //{
        //    get { return _showProductionLine; }
        //    set
        //    {
        //        _showProductionLine = value;
        //        this.BandProductionLine.Visible = value;
        //    }
        //}
        public bool IsMinus { get; set; }

        public IvsAdjustmentGridControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// override Dto in IvsAdjustmentGridControl
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

                    dgvAdjustment.FocusedRowHandle = -1;
                    ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();

                    List<ST_StockTransactionDetailDto> list = dgcAdjustment.GetOnlyChangedRowsWithStateForIvsBandedGridview<ST_StockTransactionDetailDto>();
                    //foreach (var item in list)
                    //{
                    //    if (item.ProcessType == CommonData.ProcessType.RM)
                    //        item.ItemType = CommonData.ItemType.RawMaterials;
                    //}


                    //2014/03/14 Convert ProductionLine No-Processing to null
                    //dto.Details = detail;
                    dto.Details = list.ConvertLineBlankToNull();


                    //Get caption column to validate
                    if (dto.Details.Count > 0)
                    {
                        foreach (ST_StockTransactionDetailDto detailDto in dto.Details)
                        {
                            detailDto.ItemCodeCtrl = bandItemCode.Caption;
                            detailDto.QuantityCtrl = bandQty.Caption;
                            detailDto.UnitCtrl = bandUnit.Caption;
                            detailDto.QualityStatusCtrl = BandQuality.Caption;
                            detailDto.ProductionLineCtrl = BandProductionLine.Caption;
                            detailDto.RemarkCtrl = bandReason.Caption;
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
                    //dgvAdjustment.FocusedRowHandle = -1;
                    dgcAdjustment.BindDataForBandedGridView();
                    ST_StockTransactionMasterDto dto = (ST_StockTransactionMasterDto)value;

                    if (dto != null)
                    {
                        if (dto.Details != null && dto.Details.Count > 0)
                            //2014/03/14 Convert ProductionLine  null to No-Processing 
                            // dgcAdjustment.SetAllRows2<ST_StockTransactionDetailDto>(dto.Details);
                            dgcAdjustment.SetAllRows2<ST_StockTransactionDetailDto>(dto.Details.ConvertLineNullToBlank());

                    }
                    dgvAdjustment.FocusedRowHandle = -1;
                }
            }
        }

        public void SetEdit(bool isEdit)
        {
            colNo.OptionsColumn.AllowFocus = false;
            colNo.OptionsColumn.AllowEdit = false;

            colProcessType.OptionsColumn.AllowEdit = isEdit;
            colItemType.OptionsColumn.AllowEdit = isEdit;
            colItemCode.OptionsColumn.AllowEdit = isEdit;
            colItemName.OptionsColumn.AllowEdit = isEdit;
            colLotNo.OptionsColumn.AllowEdit = isEdit;
            //colPlusOrMinus.OptionsColumn.AllowEdit = isEdit;
            colProductionLine.OptionsColumn.AllowEdit = isEdit;
            colQuality.OptionsColumn.AllowEdit = isEdit;
            colQuatity.OptionsColumn.AllowEdit = isEdit;
            colReason.OptionsColumn.AllowEdit = isEdit;
            colUnit.OptionsColumn.AllowEdit = isEdit;

            colItemCode.OptionsColumn.AllowFocus = isEdit;
            colItemName.OptionsColumn.AllowFocus = isEdit;
            colLotNo.OptionsColumn.AllowFocus = isEdit;

            //colPlusOrMinus.OptionsColumn.AllowFocus = isEdit;
            colProductionLine.OptionsColumn.AllowFocus = isEdit;
            colQuality.OptionsColumn.AllowFocus = isEdit;
            colQuatity.OptionsColumn.AllowFocus = isEdit;
            colReason.OptionsColumn.AllowFocus = isEdit;
            colUnit.OptionsColumn.AllowFocus = isEdit;
        }

        /// <summary>
        /// Set error for controls
        /// </summary>
        public override void SetError(int rowIndex, string fieldName, string errorText)
        {
            dgcAdjustment.SetColumnErrorBandedGridView(rowIndex, fieldName, errorText);
        }

        public void InitControl(string warehouse, string quanlityStatus = "")
        {
            this.InitControl();
            this.Warehouse = warehouse;
            this.QuanlityStatus = quanlityStatus;
            //this.ProcessType = processType;
        }
        private void InitLookupEdit()
        {

            resItem.Columns.Clear();


            var col1 = new IvsLookUpColumnInfo("Code");

            col1.Caption = "";
            col1.Width = 100;
            resItem.Columns.Add(col1);

            col1 = new IvsLookUpColumnInfo("Name");
            col1.Caption = "";
            col1.Width = 300;
            resItem.Columns.Add(col1);



            resItem.PopupWidth = 400;


        }

        public void ShowGridColumn()
        {
            this.bandUnitPrice.Visible = this.ShowUnitPrice;
            this.bandAmount.Visible = this.ShowAmount;
        }

        public override void SetControl()
        {
            base.SetControl();

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.dgvAdjustment.OptionsBehavior.Editable = false;
                this.dgvAdjustment.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
            else
            {
                this.dgvAdjustment.OptionsBehavior.Editable = true;
                this.dgvAdjustment.OptionsSelection.EnableAppearanceFocusedCell = true;
            }
        }

        public void ClearGrid()
        {

            this.Dto = null;
            dgvAdjustment.FocusedRowHandle = -1;
            this.InitLookupEdit();
        }

        /// <summary>
        /// Intalize controls
        /// </summary>
        public override void InitControl()
        {
            base.InitControl();
            // this.BandProductionLine.Visible = this.ShowProductionLine ? true : false;

            if (this.ViewMode == CommonData.Mode.View)
            {
                this.resItem.HasNull = true;
                
                this.resUnit.HasNull = true;
                this.resErrorReason.HasNull = true;
                this.resQualityStatus.HasNull = true;
            }
            else
            {
                this.resItem.HasNull = false;
                this.resUnit.HasNull = false;
                this.resErrorReason.HasNull = false;
                this.resQualityStatus.HasNull = false;
            }


            //this.resItem.Code = CommonData.FunctionGr.MS_Items;
            //this.resUnit.Code = CommonData.FunctionGr.MS_Units;
            //this.resQualityStatus.Code = CommonData.Code.QualityStatus;

            this.resProductionLine.HasNull = true;

            this.resQuantity.NumOfDecimalPlaces = 2;
            this.resQuantity.IsNumberic = true;

            this.resUnitPrice.NumOfDecimalPlaces = 2;
            this.resUnitPrice.IsNumberic = true;

            this.resAmount.NumOfDecimalPlaces = 2;
            this.resAmount.IsNumberic = true;
            //this.resProductionLine.ShowBlank = true;
            //this.resProductionLine.Code = CommonData.FunctionGr.MS_ProductionLines;

            //this.resErrorReason.Code = CommonData.FunctionGr.MS_ErrorReasons;
            //this.resProcessType.Code = CommonData.FunctionGr.ProcessType;

            ShowGridColumn();

            InitLookupEdit();

            this.dgvAdjustment.ShownEditor -= new EventHandler(ShowEditor);
            this.dgvAdjustment.ShownEditor += new EventHandler(ShowEditor);

            this.dgvAdjustment.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(dgvAdjustment_CellValueChanged);
            this.dgvAdjustment.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(dgvAdjustment_CellValueChanged);

            this.resItem.EditValueChanged -= new EventHandler(resItem_EditValueChanged);
            this.resItem.EditValueChanged += new EventHandler(resItem_EditValueChanged);

            this.resProductionLine.EditValueChanged -= new EventHandler(resProductionLine_EditValueChanged);
            this.resProductionLine.EditValueChanged += new EventHandler(resProductionLine_EditValueChanged);

            this.resQualityStatus.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resQualityStatus.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resQuantity.EditValueChanging -= new DevExpress.XtraEditors.Controls.ChangingEventHandler(resQuantity_EditValueChanging);
            this.resQuantity.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(resQuantity_EditValueChanging);

            this.resQuantity.EditValueChanged -= new EventHandler(PostEditor_EditValueChanged);
            this.resQuantity.EditValueChanged += new EventHandler(PostEditor_EditValueChanged);

            this.resUnit.EditValueChanged -= new EventHandler(resUnit_EditValueChanged);
            this.resUnit.EditValueChanged += new EventHandler(resUnit_EditValueChanged);

            this.dgvAdjustment.ColumnWidthChanged -= new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.dgvAdjustment_ColumnWidthChanged);
            this.dgvAdjustment.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.dgvAdjustment_ColumnWidthChanged);

            this.resProcessType.EditValueChanged -= new EventHandler(resProcessType_EditValueChanged);
            this.resProcessType.EditValueChanged += new EventHandler(resProcessType_EditValueChanged);

            this.dgvAdjustment.ShowingEditor -= new CancelEventHandler(ShowingEditor);
            this.dgvAdjustment.ShowingEditor += new CancelEventHandler(ShowingEditor);

            this.dgvAdjustment.LostFocus -= new System.EventHandler(this.dgvAdjustment_LostFocus);
            this.dgvAdjustment.LostFocus += new EventHandler(dgvAdjustment_LostFocus);
            
            this.dgvAdjustment.ActiveFilterString = CommonData.StringEmpty;
            
            // dgcAdjustment.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);
        }

        void resQuantity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            ST_StockTransactionDetailDto detailDto = dgcAdjustment.GetFocusedRowForBandedGridView<ST_StockTransactionDetailDto>();
            decimal unitPrice = CommonMethod.ParseDecimal(detailDto.InputUnitPrice);
            decimal amount = unitPrice * CommonMethod.ParseDecimal(e.NewValue);
            dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnitPrice, CommonMethod.ParseString(unitPrice));
            dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputAmount, CommonMethod.ParseString(amount));
        }

        void resUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (ViewMode == CommonData.Mode.View)
                return;
            LookUpEdit LookupEdit = sender as LookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();

            if (SelectedDataRow != null)
            {
                decimal unitPrice = IsMinus ? CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.SalesPrice]) : CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.PurchasePrice]);
                decimal quantity = CommonMethod.ParseDecimal(dgvAdjustment.GetDataRow(dgvAdjustment.FocusedRowHandle)[CommonKey.InputQuantity]);
                decimal amount = unitPrice * quantity;
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnitPrice, CommonMethod.ParseString(unitPrice));
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputAmount, CommonMethod.ParseString(amount));
            }

            dgvAdjustment.PostEditor();
        }

        void dgvAdjustment_LostFocus(object sender, EventArgs e)
        {
            dgvAdjustment.CloseEditor();
            dgvAdjustment.UpdateCurrentRow();
            dgvAdjustment.PostEditor();
        }

        public override void LoadControlData()
        {
            base.LoadControlData();
            this.resItem.IsActive = ViewMode != CommonData.Mode.View;
            this.resItem.Code = CommonData.FunctionGr.MS_Items;
            this.resUnit.Code = CommonData.FunctionGr.MS_Units;
            this.resQualityStatus.Code = CommonData.Code.QualityStatus;

            this.resProductionLine.ShowBlank = true;
            this.resProductionLine.Code = CommonData.FunctionGr.MS_ProductionLines;

            this.resErrorReason.Code = CommonData.FunctionGr.MS_ErrorReasons;
            this.resProcessType.Code = CommonData.FunctionGr.ProcessType;
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
        private void resProcessType_EditValueChanged(object sender, EventArgs e)
        {
            if (ViewMode != CommonData.Mode.View)
            {
                LookUpEdit LookupEdit = sender as LookUpEdit;
                DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();
                if (SelectedDataRow != null)
                {
                    if (CommonMethod.ParseString(SelectedDataRow[CommonKey.Code]) == CommonData.ProcessType.FG)
                    {
                        dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ProductionLine, "FG");
                    }
                    //else if (CommonMethod.ParseString(SelectedDataRow[CommonKey.Code]) == CommonData.ProcessType.WIP)
                    //{
                    //    dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ProductionLine, CommonData.ProductionLineBlank.Code);
                    //}
                    else
                    {
                        dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ProductionLine, CommonData.StringEmpty);
                    }
                }
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemCode, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemName, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnit, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.QualityStatus, CommonData.StringEmpty);

                dgvAdjustment.PostEditor();
            }
        }


        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //this._isValid = true;
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (dgvAdjustment.RowCount == 1)
                {
                    e.Handled = true;
                }

            }

        }

        private void resProductionLine_EditValueChanged(object sender, EventArgs e)
        {
            //dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemCode, CommonData.StringEmpty);
            //dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemName, CommonData.StringEmpty);
            //dgcAdjustment.SetRowCellValueForBandedGridView("InputUnit", CommonData.StringEmpty);
            dgvAdjustment.PostEditor();
        }

        private void PostEditor_EditValueChanged(object sender, EventArgs e)
        {
            dgvAdjustment.PostEditor();
        }


        private void resItem_EditValueChanged(object sender, EventArgs e)
        {
            RefreshItemDataByParent(sender);

        }

        private void RefreshItemDataByParent(object sender)
        {
            if (ViewMode == CommonData.Mode.View)
                return;

            LookUpEdit LookupEdit = sender as LookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();

            if (SelectedDataRow != null)
            {
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemType, CommonMethod.ParseString(SelectedDataRow[CommonKey.ItemType]));
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemCode, CommonMethod.ParseString(SelectedDataRow["Code"]));
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemName, CommonMethod.ParseString(SelectedDataRow["Name"]));
                dgcAdjustment.SetRowCellValueForBandedGridView("InputUnit", CommonMethod.ParseString(SelectedDataRow["InvUnitCode"]));
                //if (ProcessType == CommonData.ProcessType.FG)
                //    dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ProductionLine, CommonData.FG);
                if (!string.IsNullOrEmpty(QuanlityStatus))
                {
                    if (QuanlityStatus.IndexOf(",") == -1)
                        dgcAdjustment.SetRowCellValueForBandedGridView("QualityStatus", QuanlityStatus);
                    else
                        dgcAdjustment.SetRowCellValueForBandedGridView("QualityStatus", QuanlityStatus.Split(",".ToCharArray())[0]);
                }
                else if (!string.IsNullOrEmpty(DefaultQualityStatus))
                    dgcAdjustment.SetRowCellValueForBandedGridView("QualityStatus", DefaultQualityStatus);


                //--StartUpdate 2014/06/05 (Kien)
                if (IsMinus)
                {
                    dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnitPrice, CommonMethod.ParseString(SelectedDataRow[CommonKey.SalesPrice]));
                }
                else
                {
                    dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnitPrice, CommonMethod.ParseString(SelectedDataRow[CommonKey.PurchasePrice]));
                }
                decimal quantity = CommonMethod.ParseDecimal(dgvAdjustment.GetRowCellValue(dgvAdjustment.FocusedRowHandle, CommonKey.InputQuantity));
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputAmount, (quantity * CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.PurchasePrice])).ToString());
                //--EndUpdate

                //if (ShowProductionLine)
                //    dgcInventory.SetRowCellValue("ProductionLine", CommonMethod.ParseString(SelectedDataRow["Line"]));

            }
            else
            {
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemType, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemCode, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.ItemName, CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView("InputUnit", CommonData.StringEmpty);
                dgcAdjustment.SetRowCellValueForBandedGridView("QualityStatus", CommonData.StringEmpty);
                //--StartUpdate 2014/06/05 (Kien)
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputUnitPrice, "0");
                dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.InputAmount, "0");
                //--EndUpdate
                // dgcInventory.SetRowCellValue("ProductionLine", CommonData.StringEmpty);

            }



        }
        public override void Reset()
        {
            base.Reset();

        }

        public override void SetLanguage()
        {
            base.SetLanguage();

            this.Reset();
        }

        private void dgvAdjustment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            ST_StockTransactionDetailDto detailDto = dgcAdjustment.GetFocusedRowForBandedGridView<ST_StockTransactionDetailDto>();
            dgcAdjustment.ClearErrorsForBandedGridView();
            this._isValid = true;

            //Set auto value for column No
            dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.LineNumber, CommonMethod.ParseString(e.RowHandle + 1));
            dgcAdjustment.SetRowCellValueForBandedGridView(CommonKey.BalanceFlag, IsMinus ? CommonData.BalanceFlag.Minus : CommonData.BalanceFlag.Plus);


            IsValidFocusedRow(detailDto);

            #region Add new row if focus to last row

            if (_isValid && dgcAdjustment.IsFocusedLastRowForBandedGridView())
            {
                dgcAdjustment.AddNewRowForBandedGridView();
            }

            #endregion Add new row if focus to last row
        }

        private void IsValidFocusedRow(ST_StockTransactionDetailDto detailDto)
        {


            #region Set validate


            /// <summary>
            /// Item Code must be fill in
            ///</summary>
            if (string.IsNullOrEmpty(detailDto.ItemCode))
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, bandItemCode.Caption);
                dgcAdjustment.SetColumnErrorBandedGridView(colItemCode.FieldName, msg.MessageText);
                _isValid = false;
            }

            /// <summary>
            /// Item Code must be fill in
            ///</summary>
            if (string.IsNullOrEmpty(detailDto.QualityStatus))
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, BandQuality.Caption);
                dgcAdjustment.SetColumnErrorBandedGridView(colQuality.FieldName, msg.MessageText);
                _isValid = false;
            }

            /// <summary>
            /// Quantity must be greater than 0
            ///</summary>
            if (detailDto.InputQuantity == null || detailDto.InputQuantity <= 0)
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, bandQty.Caption);
                dgcAdjustment.SetColumnErrorBandedGridView(colQuatity.FieldName, msg.MessageText);
                _isValid = false;
            }



            /// <summary>
            /// Item Code must be fill in
            ///</summary>
            if (string.IsNullOrEmpty(detailDto.Remark))
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, bandReason.Caption);
                dgcAdjustment.SetColumnErrorBandedGridView(colReason.FieldName, msg.MessageText);
                _isValid = false;
            }

            /// <summary>
            /// ProductLine must be fill in when Type is WIP
            ///</summary>
            if (CommonMethod.ParseString(detailDto.ProcessType).Equals(CommonData.ProcessType.WIP) &&  CommonMethod.IsNullOrEmpty(detailDto.ProductionLine))
            {
                IvsMessage msg = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, BandProductionLine.Caption);
                dgcAdjustment.SetColumnErrorBandedGridView(colProductionLine.FieldName, msg.MessageText);
                _isValid = false;
            }


            #endregion Set validate
        }




        private void ShowingEditor(object sender, CancelEventArgs e)
        {
            IvsBandedGridView view;
            view = sender as IvsBandedGridView;
            if (view.FocusedRowHandle >= 0)
            {
                string processType = CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]);
                if (view.FocusedColumn.FieldName == CommonKey.ProductionLine)
                {

                    //string itemType = CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)[CommonKey.ItemType]);
                    if (processType.Equals(CommonData.ProcessType.FG) || processType.Equals(CommonData.ProcessType.RM))
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                if (CommonMethod.IsNullOrEmpty(processType) && view.FocusedColumn.FieldName != "ProcessType")
                {
                    e.Cancel = true;
                    return;
                }
            }



        }


        public void ShowEditor(object sender, EventArgs e)
        {

            IvsBandedGridView view;
            view = sender as IvsBandedGridView;

            if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {

                DevExpress.XtraEditors.LookUpEdit edit;
                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;


                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) return;
                if (view.FocusedColumn.FieldName == CommonKey.ItemCode)
                {

                    DataTable table = new DataTable();
                    //if(ViewMode==CommonData.Mode.New)
                    _commonBl.SelectDataForStockRepositoryItemControl(out table, true, false,
                   "", Warehouse,
                    QuanlityStatus, "",
                    CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProductionLine"]), "", CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]));
                    //else
                    //_commonBl.SelectDataForStockRepositoryItemControl(out table, ItemType);


                    if (resItem.HasNull)
                    {
                        table.Rows.InsertAt(table.NewRow(), 0);
                    }

                    edit.Properties.DataSource = table;

                }
                else if (view.FocusedColumn.FieldName == "InputUnit")
                {

                    System.Data.DataTable dtResult = new System.Data.DataTable();

                    _commonBl.SelectUnitInRepositoryControl(out  dtResult, CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ItemCode"]));

                    if (resUnit.HasNull)
                    {
                        dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                    }

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



        private void dgvAdjustment_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            this.dgvAdjustment.OptionsView.ColumnAutoWidth = false;
        }

    }
}
