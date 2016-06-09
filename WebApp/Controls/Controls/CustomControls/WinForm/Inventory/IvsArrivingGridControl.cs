using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Common;
using DevExpress.XtraEditors;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsArrivingGridControl : IvsInventoryGridControl
    {

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
                decimal unitPrice=CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.PurchasePrice]);
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

                    //if (ShowUnitPrice)
                    //{
                        dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, CommonMethod.ParseString(SelectedDataRow[CommonKey.PurchasePrice]));
                        decimal quantity = CommonMethod.ParseDecimal(dgvInventory.GetRowCellValue(dgvInventory.FocusedRowHandle, CommonKey.InputQuantity));
                        dgcInventory.SetRowCellValue(CommonKey.InputAmount, (quantity * CommonMethod.ParseDecimal(SelectedDataRow[CommonKey.PurchasePrice])).ToString());
                    //}

                    if (!string.IsNullOrEmpty(QuanlityStatus))
                    {
                        if (QuanlityStatus.IndexOf(",") == -1)
                            dgcInventory.SetRowCellValue(CommonKey.QualityStatus, QuanlityStatus);
                        else
                            dgcInventory.SetRowCellValue(CommonKey.QualityStatus, QuanlityStatus.Split(",".ToCharArray())[0]);
                    }
                }
                else
                {
                    dgcInventory.SetRowCellValue(CommonKey.ItemCode, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.ItemName, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.InputUnit, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.QualityStatus, CommonData.StringEmpty);
                    dgcInventory.SetRowCellValue(CommonKey.InputUnitPrice, "0");
                    dgcInventory.SetRowCellValue(CommonKey.InputAmount, "0");
                    //dgcInventory.SetRowCellValue("ProductionLine", CommonData.StringEmpty);
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
                    _commonBl.SelectDataForStockRepositoryItemControl(out table, ShowItemType ? CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ItemType"]) : ItemType,
                        ShowProcessType ? CommonMethod.ParseString(view.GetDataRow(view.FocusedRowHandle)["ProcessType"]) : ProcessType);

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
