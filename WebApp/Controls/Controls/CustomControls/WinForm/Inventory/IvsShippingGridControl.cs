using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsShippingGridControl : IvsInventoryGridControl
    {

        DataTable _tableItem = new DataTable();
        public IvsShippingGridControl()
        {
            InitializeComponent();

        }

        public override void InitControl()
        {
            base.InitControl();

            this.resItem.EditValueChanged -= new EventHandler(resItem_EditValueChanged);
            this.resItem.EditValueChanged += new EventHandler(resItem_EditValueChanged);

            this.resUnit.EditValueChanged -= new EventHandler(resUnit_EditValueChanged);
            this.resUnit.EditValueChanged += new EventHandler(resUnit_EditValueChanged);

        }


        private void resUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (ViewMode == CommonData.Mode.View)
                return;
            LookUpEdit LookupEdit = sender as LookUpEdit;
            DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();

            if (SelectedDataRow != null)
            {
                decimal unitPrice = CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.SalesPrice]);
                decimal quantity = CommonMethod.ParseDecimal(dgvInventory.GetDataRow(dgvInventory.FocusedRowHandle)[CommonKey.InputQuantity]);
                decimal amount = unitPrice * quantity;
                dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, CommonMethod.ParseString(unitPrice));
                dgcInventory.SetRowCellValue(CommonKey.InputAmount, CommonMethod.ParseString(amount));
            }
            dgvInventory.PostEditor();
        }

        private void resItem_EditValueChanged(object sender, EventArgs e)
        {
            RefreshItemDataByParent(sender);

        }

        private void RefreshItemDataByParent(object sender)
        {
            if (ViewMode == CommonData.Mode.View)
                return;

            try
            {
                LookUpEdit LookupEdit = sender as LookUpEdit;
                DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();

                if (SelectedDataRow != null)
                {
                    dgcInventory.SetRowCellValue(CommonKey.ItemType, CommonMethod.ParseString(SelectedDataRow[CommonKey.ItemType]));
                    dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonMethod.ParseString(SelectedDataRow["Code"]));
                    dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonMethod.ParseString(SelectedDataRow["Name"]));
                    dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonMethod.ParseString(SelectedDataRow["InvUnitCode"]));
                    dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, CommonMethod.ParseString(SelectedDataRow["SalesPrice"]));
                    decimal quantity = CommonMethod.ParseDecimal(dgvInventory.GetRowCellValue(dgvInventory.FocusedRowHandle, CommonKey.InputQuantity));
                    dgcInventory.SetRowCellValue(CommonKey.InputAmount, (quantity * CommonMethod.ParseDecimal(SelectedDataRow["SalesPrice"])).ToString());
                    if (!string.IsNullOrEmpty(QuanlityStatus))
                    {
                        if (QuanlityStatus.IndexOf(",") == -1)
                            dgcInventory.SetRowCellValue(CommonKey.QualityStatus, QuanlityStatus);
                        //else
                        //    dgcInventory.SetRowCellValue(CommonKey.QualityStatus, QuanlityStatus.Split(",".ToCharArray())[0]);
                    }
                    else if (!string.IsNullOrEmpty(DefaultQualityStatus))
                        dgcInventory.SetRowCellValue(CommonKey.QualityStatus, DefaultQualityStatus);


                    //if (ShowProductionLine)
                    //    dgcInventory.SetRowCellValue(CommonKey.ProductionLine, CommonMethod.ParseString(SelectedDataRow["Line"]));

                }
                else
                {
                    dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.QualityStatus, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, "0");
                    dgcInventory.SetRowCellValue(CommonKey.InputAmount, "0");
                    // dgcInventory.SetRowCellValue(CommonKey.ProductionLine, CommonData.StringEmpty);
                    //dgcInventory.FocusedView.PostEditor();
                }
            }
            catch
            {
                dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.QualityStatus, CommonData.StringEmpty);
                dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, "0");
                dgcInventory.SetRowCellValue(CommonKey.InputAmount, "0");
            }
            //dgcInventory.FocusedView.PostEditor();

        }


        public override void ShowEditor(object sender, EventArgs e)
        {
            base.ShowEditor(sender, e);
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {

                DevExpress.XtraEditors.LookUpEdit edit;
                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;


                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) return;
                if (view.FocusedColumn.FieldName == CommonKey.ItemCode && (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
                {

                    DataTable table = new DataTable();
                    _commonBl.SelectDataForStockRepositoryItemControl(out table, ShowProductionLine, ShowDocument,
                        ShowItemType ? CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ItemType"]) : ItemType, Warehouse,
                        QuanlityStatus, CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["RelatedDocumentNo"]),
                        CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)[CommonKey.ProductionLine]), Supplier, ShowProcessType ? CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]) : ProcessType,IsFull);

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
