using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsGridControl : DevExpress.XtraGrid.GridControl
    {
        public bool MoveNextRowWhenLastCellFocused { get; set; }
        public int RowCount
        {
            get
            {
                //this.Refresh();
                this.RefreshDataSource();
                return ((DataTable)this.DataSource) ==null ? 0 : ((DataTable)this.DataSource).Rows.Count;
            }
        }


        public struct ColumnProperty
        {
            public int RowIndex;
            public string ColumnName;
            public string ColumnValue;

            public ColumnProperty(int rowIndex, string columnName, string columnValue)
            {
                this.RowIndex = rowIndex;
                this.ColumnName = columnName;
                this.ColumnValue = columnValue;
            }
        }

        private const string StateColumnName = "State";
        private const string RowNumColumnName = "RowNum";

        private DataTable dtCheck = new DataTable();
        private bool isBindDataForEdit = false;

        public override object DataSource
        {
            get
            {

                return base.DataSource;
            }
            set
            {
                try
                {
                    if (value != null && !isBindDataForEdit)
                    {
                        if (dtCheck.Rows.Count == 0)
                        {
                            //((DataTable)value).AcceptChanges();
                            dtCheck = (DataTable)value;
                            dtCheck.AcceptChanges();
                        }
                    }
                    else
                    {
                        dtCheck = new DataTable();
                    }
                }
                catch
                {
                }

                base.DataSource = value;
            }
        }

        public void Reset()
        {
            DataTable dataSource = new DataTable();

            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            foreach (IvsGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }
            this.DataSource = dataSource;
        }

        public bool HasChanged()
        {
            bool hasChanged = false;

            dtCheck = (DataTable)this.DataSource;
            DataTable dtSource = new DataTable();
            dtSource = (DataTable)this.DataSource;
            DataTable dtChange = dtSource.GetChanges();
            if (dtChange != null)
            {
                foreach (DataRow dr in dtChange.Rows)
                {
                    bool hasData = false;
                    for (int i = 0; i < dtChange.Columns.Count; i++)
                    {
                        if (dr[i] != null && !string.IsNullOrEmpty(dr[i].ToString()))
                        {
                            hasData = true;
                            break;
                        }
                    }
                    if (hasData)
                    {
                        hasChanged = true;
                    }
                }
            }

            return hasChanged;
        }

        public DT GetFocusedRow<DT>() where DT : IDto
        {
            DT dto = (DT)Activator.CreateInstance(typeof(DT));
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return dto;
            }
            DataRow dr = gridView.GetFocusedDataRow();
            dto = SetDto<DT>(dr);
            return dto;
        }

        public DT GetFocusedRowForBandedGridView<DT>() where DT : IDto
        {
            DT dto = (DT)Activator.CreateInstance(typeof(DT));
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return dto;
            }
            DataRow dr = gridView.GetFocusedDataRow();
            dto = SetDto<DT>(dr);
            return dto;
        }

        public void SetColumnError(int rowIndex, string colName, string messText)
        {
            IvsMessage msg = new IvsMessage("CMN026");
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.SetColumnError(colName, messText);
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.RowError = msg.MessageText;
        }

        public void SetColumnError(string colName, string messText)
        {
            IvsMessage msg = new IvsMessage("CMN026");
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int rowIndex = gridView.FocusedRowHandle;
            if (rowIndex > -1)
            {
                ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.SetColumnError(colName, messText);
                ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.RowError = msg.MessageText;
            }
        }

        public void SetColumnErrorBandedGridView(int rowIndex, string colName, string messText)
        {
            IvsMessage msg = new IvsMessage("CMN026");
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.SetColumnError(colName, messText);
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.RowError = msg.MessageText;
        }

        public void SetColumnErrorBandedGridView(string colName, string messText)
        {
            IvsMessage msg = new IvsMessage("CMN026");
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int rowIndex = gridView.FocusedRowHandle;
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.SetColumnError(colName, messText);
            ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.RowError = msg.MessageText;
        }

        public void ClearErrors()
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int rowIndex = gridView.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                if (((System.Data.DataRowView)gridView.GetRow(rowIndex)) != null)
                {
                    ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.ClearErrors();
                }
            }
        }

        public void ClearAllErrors()
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (((System.Data.DataRowView)gridView.GetRow(i)) != null)
                {
                    ((System.Data.DataRowView)gridView.GetRow(i)).Row.ClearErrors();
                }
            }
        }

        public void ClearErrorsForBandedGridView()
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int rowIndex = gridView.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                if (((System.Data.DataRowView)gridView.GetRow(rowIndex)) != null)
                {
                    ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.ClearErrors();
                }
            }
        }

        public void ClearErrorsForBandedGridView(int rowIndex)
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            if (rowIndex >= 0)
            {
                if (((System.Data.DataRowView)gridView.GetRow(rowIndex)) != null)
                {
                    ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.ClearErrors();
                }
            }
        }

        public void ClearErrors(int rowIndex)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            if (rowIndex >= 0)
            {
                if (((System.Data.DataRowView)gridView.GetRow(rowIndex)) != null)
                {
                    ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row.ClearErrors();
                }
            }
        }

        public void SetRowCellValue(List<ColumnProperty> listColumn)
        {
            DataTable dataSource = new DataTable();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
            }
            else
            {
                return;
            }

            foreach (ColumnProperty cp in listColumn)
            {
                dataSource.Rows[cp.RowIndex][cp.ColumnName] = cp.ColumnValue;
            }
            this.DataSource = dataSource;
        }

        public void SetRowCellValue(int indexRow, string columnName, string columnValue)
        {
            DataTable dataSource = new DataTable();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            dataSource.Rows.IndexOf(gridView.GetFocusedDataRow());
            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
            }
            else
            {
                return;
            }

            dataSource.Rows[indexRow][columnName] = columnValue;

            this.DataSource = dataSource;
        }

        public void SetRowCellValueForBandedGridView(int indexRow, string columnName, string columnValue)
        {
            DataTable dataSource = new DataTable();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            dataSource.Rows.IndexOf(gridView.GetFocusedDataRow());
            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
            }
            else
            {
                return;
            }
            dataSource.Rows[indexRow][columnName] = columnValue;

            this.DataSource = dataSource;
        }

        public void SetRowCellValue(string columnName, string columnValue)
        {
            DataTable dataSource = new DataTable();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int indexRow;
            //    int indexRow = gridView.FocusedRowHandle;

            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
                indexRow = dataSource.Rows.IndexOf(gridView.GetFocusedDataRow());
            }
            else
            {
                return;
            }

            if (indexRow > -1 && dataSource.Rows[indexRow] != null)
                dataSource.Rows[indexRow][columnName] = columnValue;

            this.DataSource = dataSource;
        }

        public void SetRowCellValueForBandedGridView(string columnName, string columnValue)
        {
            DataTable dataSource = new DataTable();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            int indexRow;
            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
                indexRow = dataSource.Rows.IndexOf(gridView.GetFocusedDataRow());
            }
            else
            {
                return;
            }

            if (indexRow < 0)
            {
                if (dataSource.Rows.Count > 0)
                {
                    indexRow = 0;
                }
            }
            if (indexRow > -1 && dataSource.Rows[indexRow] != null)
                dataSource.Rows[indexRow][columnName] = columnValue;
            this.DataSource = dataSource;
        }

        public void AddNewRow()
        {
            DataTable dataSource = new DataTable();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
            }
            else
            {
                return;
            }

            DataRow dr = dataSource.NewRow();
            dataSource.Rows.Add(dr);
            this.DataSource = dataSource;
        }

        public void AddNewRowForBandedGridView()
        {
            DataTable dataSource = new DataTable();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            if (gridView.DataSource != null)
            {
                dataSource = (DataTable)this.DataSource;
            }
            else
            {
                //return;
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    dataSource.Columns.Add(gridView.Columns[i].FieldName);
                }
            }

            DataRow dr = dataSource.NewRow();
            //for (int i = 0; i < gridView.Columns.Count; i++)
            //{
            //    dr[i] = null;
            //}
            dataSource.Rows.Add(dr);
            this.DataSource = dataSource;
        }

        public bool IsFocusedLastRow()
        {
            return ((IvsGridView)this.MainView).FocusedRowHandle == ((IvsGridView)this.MainView).RowCount - 1 ? true : false;
        }

        public bool IsFocusedLastRowForBandedGridView()
        {
            return ((IvsBandedGridView)this.MainView).FocusedRowHandle == ((IvsBandedGridView)this.MainView).RowCount - 1 ? true : false;
        }

        public List<DT> GetAllRowWithState<DT>() where DT : IDto
        {
            List<DT> returnList = new List<DT>();
            List<DT> updateListDto = this.GetUpdatedRows<DT>();
            foreach (DT dto in updateListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Update);
                returnList.Add(dto);
            }

            List<DT> insertListDto = this.GetNewRows<DT>();
            foreach (DT dto in insertListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Add);
                returnList.Add(dto);
            }

            List<DT> deleteListDto = this.GetDeleteRows<DT>();
            foreach (DT dto in deleteListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Delete);
                returnList.Add(dto);
            }

            List<DT> unChangeListDto = this.GetUnchangeRows<DT>();
            foreach (DT dto in unChangeListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Unchanged);
                returnList.Add(dto);
            }

            return returnList;
        }

        /// <summary>
        /// Get All Band Row With State
        /// </summary>
        /// <typeparam name="DT"></typeparam>
        /// <returns></returns>
        public List<DT> GetAllBandRowWithState<DT>() where DT : IDto
        {
            List<DT> returnList = new List<DT>();
            List<DT> updateListDto = this.GetUpdatedBandRows<DT>();
            foreach (DT dto in updateListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Update);
                returnList.Add(dto);
            }

            List<DT> insertListDto = this.GetNewBandRows<DT>();
            foreach (DT dto in insertListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Add);
                returnList.Add(dto);
            }

            List<DT> deleteListDto = this.GetDeleteBandRows<DT>();
            foreach (DT dto in deleteListDto)
            {
                SetProperty<DT>(dto, StateColumnName, CommonData.State.Delete);
                returnList.Add(dto);
            }

            List<DT> unChangeListDto = this.GetUnchangeBandRows<DT>();
            foreach (DT dto in unChangeListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Unchanged);
                returnList.Add(dto);
            }

            return returnList;
        }

        public List<DT> GetOnlyChangedRowsWithState<DT>() where DT : IDto
        {
            List<DT> returnList = new List<DT>();

            List<DT> deleteListDto = this.GetDeleteRowsWithIndex<DT>();
            foreach (DT dto in deleteListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Delete);
                returnList.Add(dto);
            }

            List<DT> updateListDto = this.GetUpdatedRowsWithIndex<DT>();
            foreach (DT dto in updateListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Update);
                returnList.Add(dto);
            }

            List<DT> insertListDto = this.GetNewRowsWithIndex<DT>();
            foreach (DT dto in insertListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Add);
                returnList.Add(dto);
            }

            return returnList;
        }

        public List<DT> GetUnchangeRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Unchanged);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        /// <summary>
        /// Get Unchange
        /// </summary>
        /// <typeparam name="DT"></typeparam>
        /// <returns></returns>
        public List<DT> GetUnchangeBandRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Unchanged);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetUnchangeRowsWithIndex<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Unchanged);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetDeleteRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataView myView = new DataView(dtCheck, null, null, DataViewRowState.Deleted);
                DataTable dtChange = myView.ToTable();

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetDeleteBandRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataView myView = new DataView(dtCheck, null, null, DataViewRowState.Deleted);
                DataTable dtChange = myView.ToTable();

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetDeleteRowsWithIndex<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataView myView = new DataView(dtCheck, null, null, DataViewRowState.Deleted);
                DataTable dtChange = myView.ToTable();

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        DT dto = SetDto<DT>(dr);
                        int index = GetRowIndex(dr);
                        SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                        listDto.Add(dto);
                    }
                }
            }

            return listDto;
        }

        #region truc code

        public List<DT> GetOnlyChangedRowsWithStateForIvsBandedGridview<DT>() where DT : IDto
        {
            List<DT> returnList = new List<DT>();

            List<DT> deleteListDto = this.GetDeleteRowsWithIndexForIvsBandedGridview<DT>();
            foreach (DT dto in deleteListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Delete);
                returnList.Add(dto);
            }

            List<DT> updateListDto = this.GetUpdatedRowsWithIndexForIvsBandedGridview<DT>();
            foreach (DT dto in updateListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Update);
                returnList.Add(dto);
            }

            List<DT> insertListDto = this.GetNewRowsWithIndexForIvsBandedGridview<DT>();
            foreach (DT dto in insertListDto)
            {
                SetProperty<DT>(dto, "State", CommonData.State.Add);
                returnList.Add(dto);
            }

            return returnList;
        }

        public List<DT> GetDeleteRowsWithIndexForIvsBandedGridview<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataView myView = new DataView(dtCheck, null, null, DataViewRowState.Deleted);
                DataTable dtChange = myView.ToTable();

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        DT dto = SetDto<DT>(dr);
                        int index = GetRowIndexForIvsBandedGridview(dr);
                        SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                        listDto.Add(dto);
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetUpdatedRowsWithIndexForIvsBandedGridview<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Modified);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        DT dto = SetDto<DT>(dr);
                        int index = GetRowIndexForIvsBandedGridview(dr);
                        SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                        listDto.Add(dto);
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetNewRowsWithIndexForIvsBandedGridview<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            DataTable dtSource = new DataTable();
            if (gridView.DataSource != null)
            {
                dtSource = (DataTable)this.DataSource;
                DataTable dtChange = dtSource.GetChanges(DataRowState.Added);

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        // check if row is blank or not
                        bool hasData = false;
                        for (int i = 0; i < dtChange.Columns.Count; i++)
                        {
                            if (dr[i] != null && !string.IsNullOrEmpty(dr[i].ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            DT dto = SetDto<DT>(dr);
                            int index = GetRowIndexForIvsBandedGridview(dr);
                            SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                            listDto.Add(dto);
                        }
                    }
                }
            }

            return listDto;
        }

        #endregion truc code

        public List<DT> GetNewRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            DataTable dtSource = new DataTable();
            if (gridView.DataSource != null)
            {
                //dtCheck = (DataTable)this.DataSource;
                //DataTable dtChange = dtCheck.GetChanges(DataRowState.Added);
                dtSource = (DataTable)this.DataSource;
                DataTable dtChange = dtSource.GetChanges(DataRowState.Added);

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        bool hasData = false;
                        for (int i = 0; i < dtChange.Columns.Count; i++)
                        {
                            if (dr[i] != null && !string.IsNullOrEmpty(dr[i].ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            listDto.Add(SetDto<DT>(dr));
                        }
                    }
                }
            }

            return listDto;
        }

        /// <summary>
        /// Get New Band Rows
        /// </summary>
        /// <typeparam name="DT"></typeparam>
        /// <returns></returns>
        public List<DT> GetNewBandRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            DataTable dtSource = new DataTable();
            if (gridView.DataSource != null)
            {
                //dtCheck = (DataTable)this.DataSource;
                //DataTable dtChange = dtCheck.GetChanges(DataRowState.Added);
                dtSource = (DataTable)this.DataSource;
                DataTable dtChange = dtSource.GetChanges(DataRowState.Added);

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        bool hasData = false;
                        for (int i = 0; i < dtChange.Columns.Count; i++)
                        {
                            if (dr[i] != null && !string.IsNullOrEmpty(dr[i].ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            listDto.Add(SetDto<DT>(dr));
                        }
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetNewRowsWithIndex<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            DataTable dtSource = new DataTable();
            if (gridView.DataSource != null)
            {
                dtSource = (DataTable)this.DataSource;
                DataTable dtChange = dtSource.GetChanges(DataRowState.Added);

                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        // check if row is blank or not
                        bool hasData = false;
                        for (int i = 0; i < dtChange.Columns.Count; i++)
                        {
                            if (dr[i] != null && !string.IsNullOrEmpty(dr[i].ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            DT dto = SetDto<DT>(dr);
                            int index = GetRowIndex(dr);
                            SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                            listDto.Add(dto);
                        }
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetUpdatedRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Modified);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        /// <summary>
        /// Get Updated Band Rows
        /// </summary>
        /// <typeparam name="DT"></typeparam>
        /// <returns></returns>
        public List<DT> GetUpdatedBandRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Modified);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        listDto.Add(SetDto<DT>(dr));
                    }
                }
            }

            return listDto;
        }

        public List<DT> GetUpdatedRowsWithIndex<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtCheck = (DataTable)this.DataSource;
                DataTable dtChange = dtCheck.GetChanges(DataRowState.Modified);
                if (dtChange != null)
                {
                    foreach (DataRow dr in dtChange.Rows)
                    {
                        DT dto = SetDto<DT>(dr);
                        int index = GetRowIndex(dr);
                        SetProperty<DT>(dto, RowNumColumnName, index.ToString());
                        listDto.Add(dto);
                    }
                }
            }

            return listDto;
        }

        public void BindDataForEdit()
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            DataTable dtSource = new DataTable();
            if (gridView == null)
            {
                return;
            }
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                dtSource.Columns.Add(gridView.Columns[i].FieldName);
            }
            isBindDataForEdit = true;
            this.DataSource = dtSource;
            isBindDataForEdit = false;
            gridView.AddNewRow();
        }

        // Trong added in 2013/04/21
        public void BindDataForEdit(bool isInitial)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            DataTable dtSource = new DataTable();
            if (gridView == null)
            {
                return;
            }
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                dtSource.Columns.Add(gridView.Columns[i].FieldName);
            }
            isBindDataForEdit = true;
            this.DataSource = dtSource;
            isBindDataForEdit = false;

            if (isInitial)
                gridView.AddNewRow();
        }

        public void BindDataForBandedGridView()
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            DataTable dtSource = new DataTable();
            if (gridView == null)
            {
                return;
            }
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                dtSource.Columns.Add(gridView.Columns[i].FieldName);
            }
            //dtSource.Rows.Add(dtSource.NewRow());
            isBindDataForEdit = true;
            this.DataSource = dtSource;
            isBindDataForEdit = false;
            gridView.AddNewRow();
        }

        public DT GetRow<DT>(int rowIndex) where DT : IDto
        {
            DT dto = default(DT);
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return dto;
            }

            System.Data.DataRow row = ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row;
            if (row != null)
            {
                dto = SetDto<DT>(row);
            }
            
            return dto;
        }

        public List<DT> GetGetSelectedRows<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }

            int numSelectedRows = gridView.GetSelectedRows().Length;

            for (int i = 0; i < numSelectedRows; i++)
            {
                int rowIndex = gridView.GetSelectedRows()[i];
                if (rowIndex < 0)
                {
                    break;
                }
                System.Data.DataRow row = ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row;
                listDto.Add(SetDto<DT>(row));
            }

            return listDto;
        }

        public List<DT> GetGetSelectedRowsForBandedGridView<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }

            int numSelectedRows = gridView.GetSelectedRows().Length;

            for (int i = 0; i < numSelectedRows; i++)
            {
                int rowIndex = gridView.GetSelectedRows()[i];
                if (rowIndex < 0)
                {
                    break;
                }
                System.Data.DataRow row = ((System.Data.DataRowView)gridView.GetRow(rowIndex)).Row;
                listDto.Add(SetDto<DT>(row));
            }

            return listDto;
        }

        public List<DT> GetAllRows<DT>(bool getNullRow = true) where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            if (getNullRow)
            {
                IvsGridView gridView = (IvsGridView)this.MainView;
                if (gridView == null)
                {
                    return listDto;
                }
                DataTable dtSource = new DataTable();

                if (gridView.DataSource != null)
                {
                    dtSource = ((DataView)gridView.DataSource).ToTable();
                }

                if (dtSource != null && dtSource.Rows.Count != 0)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        System.Data.DataRow row = dtSource.Rows[i];
                        listDto.Add(SetDto<DT>(row));
                    }
                }
            }
            else
            {
                List<DT> updateListDto = this.GetUpdatedRows<DT>();
                foreach (DT dto in updateListDto)
                {
                    SetProperty<DT>(dto, StateColumnName, CommonData.State.Update);
                    listDto.Add(dto);
                }

                List<DT> insertListDto = this.GetNewRows<DT>();
                foreach (DT dto in insertListDto)
                {
                    SetProperty<DT>(dto, StateColumnName, CommonData.State.Add);
                    listDto.Add(dto);
                }

                List<DT> unChangeListDto = this.GetUnchangeRows<DT>();
                foreach (DT dto in unChangeListDto)
                {
                    SetProperty<DT>(dto, "State", CommonData.State.Unchanged);
                    listDto.Add(dto);
                }
            }

            return listDto;
        }

        public List<DT> GetAllRowsForBandedGridView<DT>() where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            DataTable dtSource = new DataTable();

            if (gridView.DataSource != null)
            {
                dtSource = ((DataView)gridView.DataSource).ToTable();
            }

            if (dtSource != null && dtSource.Rows.Count != 0)
            {
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    System.Data.DataRow row = dtSource.Rows[i];
                    listDto.Add(SetDto<DT>(row));
                }
            }
            return listDto;
        }

        private DT SetDto<DT>(System.Data.DataRow row)
        {
            DT dto = (DT)Activator.CreateInstance(typeof(DT));

            if (row == null)
            {
                return dto;
            }

            var type = typeof(DT);
            var properties = type.GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    Type propertyType = Type.GetType(property.PropertyType.FullName);
                    object newValue;
                    if (propertyType == null)
                    {
                        continue;
                    }
                    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        if (row[property.Name] == null || row[property.Name] == DBNull.Value || CommonMethod.IsNullOrEmpty(row[property.Name]))
                        //if (row[property.Name] == null || row[property.Name] == DBNull.Value)
                        {
                            newValue = null;
                        }
                        else
                        {
                            newValue = Convert.ChangeType(row[property.Name], propertyType.GetGenericArguments()[0]);
                        }
                    }
                    else
                    {
                        if (row[property.Name] == null || row[property.Name] == DBNull.Value)
                        {
                            newValue = null;
                        }
                        else
                        {
                            newValue = Convert.ChangeType(row[property.Name], property.PropertyType);
                        }
                    }
                    property.SetValue(dto, newValue, null);
                    //if (row[property.Name] != DBNull.Value)
                    //{
                    //    property.SetValue(dto, Convert.ChangeType(row[property.Name], property.PropertyType), null);
                    //}
                }
            }
            return dto;
        }

        public void SetAllRows<DT>(List<DT> setDtos) where DT : IDto
        {
            DataTable dataSource = new DataTable();

            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            //IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;

            foreach (IvsGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddRow<DT>(dto, ref dataSource);
                }
            }

            this.DataSource = dataSource;
        }

        public void SetAllRowsWithAutoNumber<DT>(List<DT> setDtos, string autoColumnName) where DT : IDto
        {
            DataTable dataSource = new DataTable();

            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            //IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;

            foreach (IvsGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddRowWithAutoNumber<DT>(dto, autoColumnName, ref dataSource);
                }
            }

            this.DataSource = dataSource;
        }

        /// <summary>
        /// Set All Rows Auto number for BandGridView
        /// </summary>
        /// <typeparam name="DT"></typeparam>
        /// <param name="setDtos"></param>
        /// <param name="autoColumnName"></param>
        public void SetAllBandRowsWithAutoNumber<DT>(List<DT> setDtos, string autoColumnName) where DT : IDto
        {
            DataTable dataSource = new DataTable();

            //IvsGridView gridView = (IvsGridView)this.MainView;

            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            foreach (IvsBandedGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddBandRowWithAutoNumber<DT>(dto, autoColumnName, ref dataSource);
                }
            }

            this.DataSource = dataSource;
        }

        public void SetAllRows<DT>(List<DT> setDtos, bool addNullRow) where DT : IDto
        {
            DataTable dataSource = new DataTable();

            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            //IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;

            foreach (IvsGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddRow<DT>(dto, ref dataSource);
                }
            }

            if (addNullRow)
            {
                DataRow dr = dataSource.NewRow();
                dataSource.Rows.Add(dr);
            }

            this.DataSource = dataSource;
        }

        public void SetAllRows2<DT>(List<DT> setDtos) where DT : IDto
        {
            this.DataSource = null;
            DataTable dataSource = new DataTable();

            //IvsGridView gridView = (IvsGridView)this.MainView;

            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            foreach (IvsBandedGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddRow<DT>(dto, ref dataSource);
                }
            }

            this.DataSource = dataSource;
        }

        public void SetAllRows2<DT>(List<DT> setDtos, bool addNullRow) where DT : IDto
        {
            DataTable dataSource = new DataTable();

            //IvsGridView gridView = (IvsGridView)this.MainView;

            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            foreach (IvsBandedGridColumn col in gridView.Columns)
            {
                dataSource.Columns.Add(col.FieldName);
            }

            if (setDtos != null)
            {
                foreach (DT dto in setDtos)
                {
                    AddRow<DT>(dto, ref dataSource);
                }
            }

            if (addNullRow)
            {
                DataRow dr = dataSource.NewRow();
                dataSource.Rows.Add(dr);
            }

            this.DataSource = dataSource;
        }

        public void AddRow<DT>(DT dto)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            DataTable dt = new DataTable();
            if ((DataView)gridView.DataSource == null)
            {
                foreach (IvsGridColumn col in gridView.Columns)
                {
                    dt.Columns.Add(col.FieldName);
                }
            }
            else
            {
                dt = ((DataView)gridView.DataSource).ToTable();
            }

            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }
            }
            dt.Rows.Add(dr);

            this.DataSource = dt;
        }

        public void AddBandRow<DT>(DT dto)
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            DataTable dt = new DataTable();
            if ((DataView)gridView.DataSource == null)
            {
                foreach (IvsBandedGridColumn col in gridView.Columns)
                {
                    dt.Columns.Add(col.FieldName);
                }
            }
            else
            {
                dt = ((DataView)gridView.DataSource).ToTable();
            }

            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }
            }
            dt.Rows.Add(dr);

            this.DataSource = dt;
        }

        public void AddRowWithAutoNumber<DT>(DT dto, string autoColumnName)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            DataTable dt = new DataTable();
            if ((DataView)gridView.DataSource == null)
            {
                foreach (IvsGridColumn col in gridView.Columns)
                {
                    dt.Columns.Add(col.FieldName);
                }
            }
            else
            {
                dt = ((DataView)gridView.DataSource).ToTable();
            }

            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }

                dr[autoColumnName] = (dt.Rows.Count + 1);
            }
            dt.Rows.Add(dr);

            this.DataSource = dt;
        }

        public void AddBandRowWithAutoNumber<DT>(DT dto, string autoColumnName)
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }

            DataTable dt = new DataTable();
            if ((DataView)gridView.DataSource == null)
            {
                foreach (IvsBandedGridColumn col in gridView.Columns)
                {
                    dt.Columns.Add(col.FieldName);
                }
            }
            else
            {
                dt = ((DataView)gridView.DataSource).ToTable();
            }

            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }

                dr[autoColumnName] = (dt.Rows.Count + 1);
            }
            dt.Rows.Add(dr);

            this.DataSource = dt;
        }

        private void AddRow<DT>(DT dto, ref DataTable dt)
        {
            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }
            }
            dt.Rows.Add(dr);
        }

        private void AddRowWithAutoNumber<DT>(DT dto, string autoColumnName, ref DataTable dt)
        {
            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string columnValue = CommonData.StringEmpty;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }

                dr[autoColumnName] = (dt.Rows.Count + 1);
            }
            dt.Rows.Add(dr);
        }

        private void AddBandRowWithAutoNumber<DT>(DT dto, string autoColumnName, ref DataTable dt)
        {
            var type = typeof(DT);
            var properties = type.GetProperties();
            DataRow dr;
            dr = dt.NewRow();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                string columnName = property.Name;
                object columnValue = null;
                var value = property.GetValue(dto, null);
                if (value != null)
                {
                    columnValue = property.GetValue(dto, null).ToString();
                }
                if (dt.Columns.Contains(columnName))
                {
                    dr[columnName] = columnValue;
                }

                dr[autoColumnName] = (dt.Rows.Count + 1);
            }
            dt.Rows.Add(dr);
        }

        
        /// <summary>
        /// Open directory to save file
        /// </summary>
        /// <param name="fileType">
        /// File Type that needs to create
        /// </param>
        /// <returns>
        /// The full path of file
        /// </returns>
        public string GetPathDialog(string fileType)
        {
            string pathFile = CommonData.StringEmpty;
            SaveFileDialog saveFileDdialog = new SaveFileDialog();
            saveFileDdialog.Title = "Save file...";

            switch (fileType)
            {
                case CommonData.FileType.Xls:
                    saveFileDdialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    break;

                case CommonData.FileType.Xlsx:
                    saveFileDdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    break;

                case CommonData.FileType.Pdf:
                    saveFileDdialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    break;

                case CommonData.FileType.Csv:
                    saveFileDdialog.Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    break;

                case CommonData.FileType.Txt:
                    saveFileDdialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;

                case CommonData.FileType.Html:
                    saveFileDdialog.Filter = "Html files (*.html)|*.html|All files (*.*)|*.*";
                    break;
            }

            saveFileDdialog.FileName = "ExportingData_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            if (saveFileDdialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = System.IO.Path.GetFullPath(saveFileDdialog.FileName);
            }

            return pathFile;
        }

        /// <summary>
        /// Export to excel file .xls
        /// </summary>
        public virtual int ExportToXls()
        {
            int returnCode = CommonData.IOReturnCode.Succeed;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xls);
                if (!string.IsNullOrEmpty(filePath))
                {
                    //IvsGridView gridView = (IvsGridView)this.MainView;
                    //gridView.OptionsPrint.AutoWidth = false;
                    GridView gridViewv = (GridView)this.MainView;
                    if (gridViewv == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridViewv.OptionsPrint.AutoWidth = false;
                    base.ExportToXls(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
                //try
                //{
                //    if (!string.IsNullOrEmpty(filePath))
                //    {
                //        IvsGridView gridView = (IvsGridView)this.MainView;
                //        gridView.OptionsPrint.AutoWidth = false;
                //        base.ExportToXls(filePath);
                //    }

                //    returnCode = CommonData.IOReturnCode.Succeed;
                //}
                //catch
                //{
                //    if (!string.IsNullOrEmpty(filePath))
                //    {
                //        IvsAdvBandedGridView gridView = (IvsAdvBandedGridView)this.MainView;
                //        gridView.OptionsPrint.AutoWidth = false;
                //        base.ExportToXls(filePath);
                //    }
                //}
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to excel file .xlsx
        /// </summary>
        public int ExportToXlsx()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xlsx);
                if (!string.IsNullOrEmpty(filePath))
                {
                    GridView gridViewv = (GridView)this.MainView;
                    if (gridViewv == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridViewv.OptionsPrint.AutoWidth = false;
                    base.ExportToXlsx(filePath);
                }
                //try
                //{
                //    if (!string.IsNullOrEmpty(filePath))
                //    {
                //        IvsGridView gridView = (IvsGridView)this.MainView;
                //        gridView.OptionsPrint.AutoWidth = false;
                //        base.ExportToXlsx(filePath);
                //    }

                //    returnCode = CommonData.IOReturnCode.Succeed;
                //}
                //catch
                //{
                //    if (!string.IsNullOrEmpty(filePath))
                //    {
                //        IvsAdvBandedGridView gridView = (IvsAdvBandedGridView)this.MainView;
                //        gridView.OptionsPrint.AutoWidth = false;
                //        base.ExportToXlsx(filePath);
                //    }
                //}
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to excel file .xls
        /// </summary>
        public virtual int ExportToXlsForBandView()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xls);

                if (!string.IsNullOrEmpty(filePath))
                {
                    IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
                    if (gridView == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridView.OptionsPrint.AutoWidth = false;
                    base.ExportToXls(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        public int ExportToXlsxForBandView()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xlsx);

                if (!string.IsNullOrEmpty(filePath))
                {
                    IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
                    if (gridView == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridView.OptionsPrint.AutoWidth = false;
                    base.ExportToXlsx(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        public virtual int ExportToXlsForIvsAdvBandedGridView()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xls);

                if (!string.IsNullOrEmpty(filePath))
                {
                    IvsAdvBandedGridView gridView = (IvsAdvBandedGridView)this.MainView;
                    if (gridView == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridView.OptionsPrint.AutoWidth = false;
                    base.ExportToXls(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        public int ExportToXlsxForIvsAdvBandedGridView()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Xlsx);
                if (!string.IsNullOrEmpty(filePath))
                {
                    IvsAdvBandedGridView gridView = (IvsAdvBandedGridView)this.MainView;
                    if (gridView == null)
                    {
                        return CommonData.IOReturnCode.AccessDenied;
                    }
                    gridView.OptionsPrint.AutoWidth = false;
                    base.ExportToXlsx(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to Pdf file
        /// </summary>
        public int ExportToPdf()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Pdf);

                if (!string.IsNullOrEmpty(filePath))
                {
                    base.ExportToPdf(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to Text file
        /// </summary>
        public int ExportToText()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Txt);

                if (!string.IsNullOrEmpty(filePath))
                {
                    base.ExportToText(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to Csv file
        /// </summary>
        public int ExportToCsv()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Csv);

                if (!string.IsNullOrEmpty(filePath))
                {
                    base.ExportToCsv(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        /// <summary>
        /// Export to Html file
        /// </summary>
        public int ExportToHtml()
        {
            int returnCode = 0;

            try
            {
                string filePath = this.GetPathDialog(CommonData.FileType.Html);

                if (!string.IsNullOrEmpty(filePath))
                {
                    base.ExportToHtml(filePath);
                }

                returnCode = CommonData.IOReturnCode.Succeed;
            }
            catch
            {
                returnCode = CommonData.IOReturnCode.AccessDenied;
            }

            return returnCode;
        }

        private void SetProperty<DT>(DT dto, string name, string value)
        {
            var type = typeof(DT);
            var properties = type.GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                if (property.Name == name)
                {
                    property.SetValue(dto, Convert.ChangeType(value, property.PropertyType), null);
                }
            }
        }

        private int GetRowIndex(DataRow dr)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return -1;
            }
            DataTable dt = (DataTable)this.DataSource;
            DataRow[] foundRows;
            string queryStr = "";
            bool theFirstColumn = true;
            foreach (DataColumn dc in dt.Columns)
            {
                if (dr[dc.ColumnName].ToString() != CommonData.StringEmpty)
                {
                    if (!theFirstColumn)
                    {
                        queryStr = queryStr + " and ";
                    }

                    queryStr += dc.ColumnName + "= '" + CommonMethod.ParseString(dr[dc.ColumnName]).Replace("'", "''") + "'";
                    theFirstColumn = false;
                }
            }

            foundRows = dt.Select(queryStr);

            if (foundRows.Length != 0)
            {
                return dt.Rows.IndexOf(foundRows[0]) + 1;
            }

            return -1;
        }

        private int GetRowIndexForIvsBandedGridview(DataRow dr)
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return -1;
            }
            DataTable dt = (DataTable)this.DataSource;
            DataRow[] foundRows;
            string queryStr = "";
            bool theFirstColumn = true;
            foreach (DataColumn dc in dt.Columns)
            {
                if (dr[dc.ColumnName].ToString() != CommonData.StringEmpty)
                {
                    if (!theFirstColumn)
                    {
                        queryStr = queryStr + " and ";
                    }

                    queryStr += dc.ColumnName + "= '" + CommonMethod.ParseString(dr[dc.ColumnName]).Replace("'", "''") + "'";
                    theFirstColumn = false;
                }
            }

            foundRows = dt.Select(queryStr);

            if (foundRows.Length != 0)
            {
                return dt.Rows.IndexOf(foundRows[0]) + 1;
            }

            return -1;
        }

        public DataTable CutSelectedRows()
        {
            DataTable dt = new DataTable();
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return dt;
            }
            DataTable dataSource = (DataTable)this.DataSource;
            
            if (dataSource != null)
            {
                dt = dataSource.Clone();
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    dt.Rows.Add(row.ItemArray);
                }
                gridView.DeleteSelectedRows();
                dataSource.AcceptChanges();
            }
            
            return dt;
        }

        public DataTable CutAllRows()
        {
            //IvsGridView gridView = (IvsGridView)this.MainView;
            //DataTable dataSource = (DataTable)this.DataSource;
            //DataTable dt = dataSource.Clone();
            //foreach (DataRow dr in dataSource.Rows)
            //{
            //    dt.Rows.Add(dr.ItemArray);
            //}
            //dataSource.Clear();
            //this.DataSource = dataSource;

            DataTable dt = (DataTable)this.DataSource;
            if (this.DataSource != null)
            {
                DataTable dataSource = dt.Clone();
                this.DataSource = dataSource;
            }

            return dt;
        }

        public void PasteRows(int rowIndex, DataTable dtSource)
        {
            DataTable dt = (DataTable)this.DataSource;
            if (this.DataSource == null)
            {
                dt = new DataTable();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == rowIndex)
                {
                    foreach (DataRow rowSource in dtSource.Rows)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow.ItemArray = rowSource.ItemArray;
                        dt.Rows.InsertAt(newRow, i);
                    }
                }
            }

            dt.AcceptChanges();
        }

        //public void AddAllRows(DataTable dt)
        //{
        //    DataTable dataSource = new DataTable();
        //    if (this.DataSource == null)
        //    {
        //        dataSource = dt.Clone();
        //    }
        //    else
        //    {
        //        dataSource = (DataTable)this.DataSource;
        //    }
        //    if (dt.Rows.Count > dataSource.Rows.Count)
        //    {
        //        foreach (DataRow dr in dataSource.Rows)
        //        {
        //            dt.Rows.Add(dr.ItemArray);
        //        }
        //        this.DataSource = dt;
        //    }
        //    else
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            dataSource.Rows.Add(dr.ItemArray);
        //        }
        //        this.DataSource = dataSource;
        //    }
        //}

        public void AddNewRows(DataTable dt)
        {
            if (dt != null)
            {
                DataTable dataSource = dt.Clone();
                if (this.DataSource != null)
                {
                    dataSource = (DataTable)this.DataSource;
                    if (dt.Rows.Count > dataSource.Rows.Count)
                    {
                        foreach (DataRow dr in dataSource.Rows)
                        {
                            if (dr.RowState != DataRowState.Deleted)
                            {
                                dt.Rows.Add(dr.ItemArray);
                            }
                        }
                        this.DataSource = dt;
                    }
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr.RowState != DataRowState.Deleted)
                            {
                                dataSource.Rows.Add(dr.ItemArray);
                            }
                        }
                        this.DataSource = dataSource;
                    }
                }
                else
                {
                    this.DataSource = dt;
                }
            }
        }

        public void SetReadOnly(int columnHandle, bool isReadOnly, bool isFocus)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            gridView.Columns[columnHandle].OptionsColumn.AllowEdit = !isReadOnly;
            gridView.Columns[columnHandle].OptionsColumn.AllowFocus = isFocus;
            gridView.Columns[columnHandle].OptionsColumn.ReadOnly = isReadOnly;
        }

        public void SetReadOnly(string fieldName, bool isReadOnly, bool isFocus)
        {
            IvsGridView gridView = (IvsGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            gridView.Columns[fieldName].OptionsColumn.AllowEdit = !isReadOnly;
            gridView.Columns[fieldName].OptionsColumn.AllowFocus = isFocus;
            gridView.Columns[fieldName].OptionsColumn.ReadOnly = isReadOnly;
        }

        public void SetReadOnlyForBandedGrid(string fieldName, bool isReadOnly, bool isFocus)
        {
            IvsBandedGridView gridView = (IvsBandedGridView)this.MainView;
            if (gridView == null)
            {
                return;
            }
            gridView.Columns[fieldName].OptionsColumn.AllowEdit = !isReadOnly;
            gridView.Columns[fieldName].OptionsColumn.AllowFocus = isFocus;
            gridView.Columns[fieldName].OptionsColumn.ReadOnly = isReadOnly;
        }

        public List<DT> GetCheckedRows<DT>(string checkedColumnName) where DT : IDto
        {
            List<DT> listDto = new List<DT>();
            DataTable dtSource = new DataTable();
            GridView gridView = (GridView)this.MainView;
            if (gridView == null)
            {
                return listDto;
            }
            if (gridView.DataSource != null)
            {
                dtSource = ((DataView)gridView.DataSource).ToTable();
            }

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                if (CommonMethod.ParseBool(dtSource.Rows[i][checkedColumnName]))
                {
                    System.Data.DataRow row = dtSource.Rows[i];
                    listDto.Add(SetDto<DT>(row));
                }
            }

            return listDto;
        }

        public void ChangeLanguage()
        {
            if (this != null)
            {
                this.EmbeddedNavigator.TextStringFormat = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_GRID_RECORD_OF_TOTAL, "Mẫu tin {0} của {1}");
                if (this.MainView != null)
                {
                    ((GridView)this.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
                    //if (this.MainView.GetType().Equals(typeof(IvsGridView)))
                    //{
                    //    ((IvsGridView)this.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
                    //}
                    //else if (this.MainView.GetType().Equals(typeof(IvsBandedGridView)))
                    //{
                    //    ((IvsBandedGridView)this.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
                    //}
                }
            }
        }
    }
}