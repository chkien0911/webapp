using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.BLL.Common;

namespace Ivs.Controls.CustomControls.Web.Components
{
    public enum DropDownDisplayMode
    {
        Code,
        Name,
        CodeName,
        NameCode,
    }

    public class DataSelectList<T> where T : class
    {
        private IEnumerable<T> DataSource { get; set; }
        public bool HasNull { get; set; }
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public string Code { get; set; }
        public object SelectedValue { get; set; }
        public DropDownDisplayMode DisplayMode { get; set; }
        public string DisplaySplitString { get; set; }

        #region Constructor

        public DataSelectList(string code, object selectedValue)
        {
            this.Code = code;
            this.SelectedValue = selectedValue;
            this.DisplayMode = DropDownDisplayMode.Name;
        }

        public DataSelectList(string code)
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
            List<T> lstResult = new List<T>();
            if (!CommonMethod.IsNullOrEmpty(this.Code))
            {
                CommonBl commonBl = new CommonBl();
                commonBl.SelectDataForControl<T>(this.Code, out lstResult);
            }

            if (this.HasNull && lstResult != null)
            {
                lstResult.Insert(0, default(T));
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
            string splitStr = CommonMethod.IsNullOrEmpty(this.DisplaySplitString) ? " - " : this.DisplaySplitString;
            if (UserSession.LangId == null)
            {
                this.ValueMember = CommonKey.Code;
                switch (this.DisplayMode)
                {
                    case DropDownDisplayMode.Code:
                        this.DisplayMember = CommonKey.Code;
                        break;
                    case DropDownDisplayMode.Name:
                        this.DisplayMember = CommonKey.Name2;
                        break;
                    case DropDownDisplayMode.CodeName:
                        this.DisplayMember = CommonKey.Code + splitStr + CommonKey.Name2;
                        break;
                    case DropDownDisplayMode.NameCode:
                        this.DisplayMember = CommonKey.Name2 + splitStr + CommonKey.Code;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                {
                    this.ValueMember = CommonKey.Code;
                    switch (this.DisplayMode)
                    {
                        case DropDownDisplayMode.Code:
                            this.DisplayMember = CommonKey.Code;
                            break;
                        case DropDownDisplayMode.Name:
                            this.DisplayMember = CommonKey.Name1;
                            break;
                        case DropDownDisplayMode.CodeName:
                            this.DisplayMember = CommonKey.Code + splitStr + CommonKey.Name1;
                            break;
                        case DropDownDisplayMode.NameCode:
                            this.DisplayMember = CommonKey.Name1 + splitStr + CommonKey.Code;
                            break;
                        default:
                            break;
                    }
                }
                else if (UserSession.LangId.Equals((CommonData.Language.English)))
                {
                    this.ValueMember = CommonKey.Code;
                    switch (this.DisplayMode)
                    {
                        case DropDownDisplayMode.Code:
                            this.DisplayMember = CommonKey.Code;
                            break;
                        case DropDownDisplayMode.Name:
                            this.DisplayMember = CommonKey.Name2;
                            break;
                        case DropDownDisplayMode.CodeName:
                            this.DisplayMember = CommonKey.Code + splitStr + CommonKey.Name2;
                            break;
                        case DropDownDisplayMode.NameCode:
                            this.DisplayMember = CommonKey.Name2 + splitStr + CommonKey.Code;
                            break;
                        default:
                            break;
                    }
                }
                else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                {
                    this.ValueMember = CommonKey.Code;
                    switch (this.DisplayMode)
                    {
                        case DropDownDisplayMode.Code:
                            this.DisplayMember = CommonKey.Code;
                            break;
                        case DropDownDisplayMode.Name:
                            this.DisplayMember = CommonKey.Name3;
                            break;
                        case DropDownDisplayMode.CodeName:
                            this.DisplayMember = CommonKey.Code + splitStr + CommonKey.Name3;
                            break;
                        case DropDownDisplayMode.NameCode:
                            this.DisplayMember = CommonKey.Name3 + splitStr + CommonKey.Code;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public SelectList Reset(bool reloadDataSource = false)
        {
            if (reloadDataSource)
            {
                return this.FillData();
            }

            this.SetLanguage();
            return new SelectList(this.DataSource, this.ValueMember, this.DisplayMember, this.SelectedValue);
        }

        #endregion Private Method
    }
}
