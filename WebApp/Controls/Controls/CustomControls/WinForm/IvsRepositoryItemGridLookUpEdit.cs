using System.Data;
using DevExpress.XtraEditors.Repository;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsRepositoryItemGridLookUpEdit : RepositoryItemGridLookUpEdit
    {
        private bool _hasNull;
        private string _code;
        private string _currentLanguage = CommonData.StringEmpty;

        private string _columns;

        public string Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                this._columns = value;
            }
        }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool HasNull
        {
            get
            {
                return _hasNull;
            }
            set
            {
                this._hasNull = value;
            }
        }

        ///// <summary>
        ///// Presenting for FunctionId
        ///// </summary>
        //public string Code
        //{
        //    get
        //    {
        //        return _code;
        //    }
        //    set
        //    {
        //        this._code = value;

        //        if (!IsDesignMode)
        //        {
        //            if (!string.IsNullOrEmpty(this._code))
        //            {
        //                this.FillData();
        //                this._currentLanguage = UserSession.LangId;
        //            }
        //        }
        //    }
        //}

        public DataTable TableData { get; set; }

        //protected void FillData()
        //{
        //    DataTable dtResult = new System.Data.DataTable();
        //    CommonBl commonBl = new CommonBl();
        //    commonBl.SelectDataForControl(this._code, out dtResult);

        //    if (this.HasNull)
        //    {
        //        dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
        //    }

        //    this.BindDataSourceFromTable(dtResult);
        //    // this.EditValue = CommonData.StringEmpty;
        //    this.NullText = CommonData.StringEmpty;

        //    CreateColumns();
        //}

        //protected void CreateColumns()
        //{
        //    if (TableData != null)
        //    {
        //        foreach (var col in TableData.Columns)
        //        {
        //        }
        //    }
        //}

        ///// <summary>
        ///// Bind datatable to gridview
        ///// </summary>
        ///// <param name="dt"></param>
        //protected void BindDataSourceFromTable(DataTable dt)
        //{
        //    this.TableData = dt;
        //    this.DataSource = dt;
        //}

        ///// <summary>
        ///// Bind data has filtered to gridview
        ///// </summary>
        ///// <param name="filter"></param>
        //protected void BindDataSourceAfterFilter(string filter)
        //{
        //    if (TableData != null)
        //    {
        //        DataView dv = TableData.AsDataView();
        //        dv.RowFilter = filter;
        //        this.DataSource = dv;
        //    }
        //}
    }
}