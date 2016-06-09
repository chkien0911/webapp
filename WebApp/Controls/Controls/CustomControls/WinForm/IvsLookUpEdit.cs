using Ivs.BLL.Common;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsLookUpEdit : DevExpress.XtraEditors.LookUpEdit
    {
        #region Private Variables

        private string _CaptionText = "";
        private bool _HasNullData = false;
        private string _Code = null;
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        #endregion Private Variables

        #region Properties

        public string CaptionText
        {
            get
            {
                return _CaptionText;
            }
            set
            {
                _CaptionText = value;
            }
        }

        public bool HasNullData
        {
            get
            {
                return _HasNullData;
            }
            set
            {
                _HasNullData = value;
            }
        }

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
                if (!string.IsNullOrEmpty(_Code))
                {
                    if (!IsDesignMode)
                    {
                        System.Data.DataTable dtStatus = new System.Data.DataTable();
                        System.Collections.Hashtable htCond = new System.Collections.Hashtable();
                        htCond.Add(CommonData.CommonCode, Code);
                        CommonBl commonBl = new CommonBl();
                        commonBl.SelectCommonData(htCond, out dtStatus);
                        if (HasNullData)
                        {
                            dtStatus.Rows.InsertAt(dtStatus.NewRow(), 0);
                        }
                        this.Properties.DataSource = dtStatus;
                        this.Properties.Columns.Clear();
                        DevExpress.XtraEditors.Controls.LookUpColumnInfo lookupColumn = new DevExpress.XtraEditors.Controls.LookUpColumnInfo(CommonData.CommonValue);
                        this.Properties.Columns.Add(lookupColumn);
                        this.Properties.Columns[CommonData.CommonValue].Caption = CaptionText;
                        this.Properties.DisplayMember = CommonData.CommonValue;
                        this.Properties.ValueMember = CommonData.CommonKey;
                        this.Properties.PopupFormMinSize = new System.Drawing.Size(50, 50);
                        this.Properties.PopupSizeable = false;
                    }
                }
            }
        }

        public override object EditValue
        {
            get
            {
                if (base.EditValue == null || string.IsNullOrEmpty(base.EditValue.ToString()))
                {
                    return string.Empty;
                }
                return base.EditValue;
            }
            set
            {
                base.EditValue = value;
            }
        }

        #endregion Properties

        #region public Method

        public void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        public void SetWarning(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        public void SetInfo(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        public override void Reset()
        {
        }

        #endregion public Method

        #region Methods About Clearing Message

        /// <summary>
        ///Clear error IvsMessage and icon for textbox control
        /// </summary>
        public void ClearErrors()
        {
            if (_errorProvider.HasErrors)
            {
                _errorProvider.ClearErrors();
            }
        }

        #endregion Methods About Clearing Message

        #region

        /// <summary>
        /// Set DataTable source into datasouce of lookupedit control
        /// </summary>
        /// <param name="dtResult">Datasource</param>
        /// <param name="valueMemeber">ValueMember</param>
        /// <param name="displayMember">DisplayMember</param>
        public void DataTableToDataSource(System.Data.DataTable dtResult, string valueMember, string DisplayMember)
        {
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    System.Data.DataRow dr = dtResult.NewRow();
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        dr.ItemArray.SetValue("", i);
                    }
                    dtResult.Rows.InsertAt(dr, 0);
                    if (this.Properties.Columns.Count >= 2)
                    {
                        this.Properties.Columns[0].FieldName = valueMember;
                        this.Properties.Columns[1].FieldName = DisplayMember;
                    }
                    this.Properties.ValueMember = valueMember;
                    this.Properties.DisplayMember = DisplayMember;
                    this.Properties.DataSource = dtResult;
                }
            }
        }

        /// <summary>
        /// Set DataTable source into datasouce of lookupedit control
        /// </summary>
        /// <param name="dtResult">Datasource</param>
        /// <param name="valueMemeber">ValueMember</param>
        /// <param name="displayMember">DisplayMember</param>
        public void DataTableToDataSourceNoEmptyRow(System.Data.DataTable dtResult, string valueMember, string DisplayMember)
        {
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    System.Data.DataRow dr = dtResult.NewRow();

                    if (this.Properties.Columns.Count >= 2)
                    {
                        this.Properties.Columns[0].FieldName = valueMember;
                        this.Properties.Columns[1].FieldName = DisplayMember;
                    }
                    this.Properties.ValueMember = valueMember;
                    this.Properties.DisplayMember = DisplayMember;
                    this.Properties.DataSource = dtResult;
                }
            }
        }

        /// <summary>
        /// Set DataTable source into datasouce of lookupedit control
        /// </summary>
        /// <param name="dtResult">Datasource</param>
        /// <param name="valueMemeber">ValueMember</param>
        /// <param name="displayMember">DisplayMember</param>
        //public void DataTableToDataSource(System.Data.DataTable dtResult, string valueMember1,string valueMember2, string DisplayMember)
        //{
        //    if (dtResult != null)
        //    {
        //        if (dtResult.Rows.Count > 0)
        //        {
        //            System.Data.DataRow dr = dtResult.NewRow();
        //            for (int i = 0; i < dr.ItemArray.Length; i++)
        //            {
        //                dr.ItemArray.SetValue("", i);
        //            }
        //            dtResult.Rows.InsertAt(dr, 0);
        //            if (this.Properties.Columns.Count >= 2)
        //            {
        //                this.Properties.Columns[0].FieldName = valueMember1;
        //                this.Properties.Columns[1].FieldName = valueMember2;
        //                this.Properties.Columns[2].FieldName = DisplayMember;
        //            }
        //            this.Properties.ValueMember = valueMember1;
        //            this.Properties.DisplayMember = DisplayMember;
        //            this.Properties.DataSource = dtResult;
        //        }
        //    }
        //}
        //public void DataTableToDataSource(System.Data.DataTable dtResult, string valueMember1, string valueMember2, string valueMember3, string DisplayMember)
        //{
        //    if (dtResult != null)
        //    {
        //        if (dtResult.Rows.Count > 0)
        //        {
        //            System.Data.DataRow dr = dtResult.NewRow();
        //            for (int i = 0; i < dr.ItemArray.Length; i++)
        //            {
        //                dr.ItemArray.SetValue("", i);
        //            }
        //            dtResult.Rows.InsertAt(dr, 0);
        //            if (this.Properties.Columns.Count >= 2)
        //            {
        //                this.Properties.Columns[0].FieldName = valueMember1;
        //                this.Properties.Columns[1].FieldName = valueMember2;
        //                this.Properties.Columns[2].FieldName = valueMember3;
        //                this.Properties.Columns[3].FieldName = DisplayMember;
        //            }
        //            this.Properties.ValueMember = valueMember1;
        //            this.Properties.DisplayMember = DisplayMember;
        //            this.Properties.DataSource = dtResult;
        //        }
        //    }
        //}

        #endregion
    }
}