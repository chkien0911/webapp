using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.BLL.Common;
using Ivs.Core.Interface;
namespace Ivs.Controls.CustomControls.Web.Components
{
    public class CodeSelectList
    {
        private IEnumerable<IModel> DataSource { get; set; }
        public bool HasNull { get; set; }
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public string Code { get; set; }
        public object SelectedValue { get; set; }

        #region Constructor

        public CodeSelectList(string code, object selectedValue)
        {
            this.Code = code;
            this.SelectedValue = selectedValue;
        }

        public CodeSelectList(string code)
            : this(code, null)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        public SelectList FillData()
        {
            List<IModel> lstResult = new List<IModel>();
            if (!CommonMethod.IsNullOrEmpty(this.Code))
            {
                CommonBl commonBl = new CommonBl();
                commonBl.SelectCommonData(this.Code, out lstResult);
            }

            if (this.HasNull && lstResult != null)
            {
                lstResult.Insert(0, default(IModel));
            }

            this.DataSource = lstResult;
            this.SetLanguage();

            return new SelectList(this.DataSource, this.ValueMember, this.DisplayMember, this.SelectedValue);
        }

        /// <summary>
        /// Change content in control follow to current language
        /// </summary>
        protected void SetLanguage()
        {
            this.ValueMember = CommonKey.Key;
            this.DisplayMember = CommonKey.Value;
        }

        public SelectList Reset()
        {
            this.FillData();
            this.SetLanguage();
            return new SelectList(this.DataSource, this.ValueMember, this.DisplayMember, this.SelectedValue);
        }

        #endregion Private Method
    }
}
