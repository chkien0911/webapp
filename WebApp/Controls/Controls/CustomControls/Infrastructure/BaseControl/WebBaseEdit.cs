using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Interface;
using Ivs.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Ivs.Controls.CustomControls.Infrastructure.BaseControl
{
    public class WebBaseEdit : WebBaseControl
    {
        #region Properties

        protected override void HelperOnchaged()
        {
            base.HelperOnchaged();

            this.SetValueFromModelMetadata();
        }

        protected override void NameOnchanged()
        {
            base.NameOnchanged();

            this.SetValueFromModelMetadata();
        }

        public virtual object Value { get; protected set; }
        //public virtual int MaxLength { get; protected set; }
        public virtual bool Readonly { get; protected set; }
        //public virtual bool IsRequire { get; protected set; }
        public virtual bool IsUnique { get; protected set; }
        public virtual bool IsPrimary { get; protected set; }
        public virtual bool IsFocus { get; protected set; }
        public virtual bool IsNoWrap { get; protected set; }
        //public virtual string FormatString { get; protected set; }
        public virtual CommonData.Width Width { get; protected set; }
        //public virtual bool IsPasswordType { get; private set; }
        public virtual CommonData.InputWebType InputType { get; protected set; }
        protected string WidthClass
        {
            get
            {
                string result = CommonData.StringEmpty;
                switch (this.Width)
                {
                    case CommonData.Width.Small:
                        result = "col-sm-2 col-md-2";
                        break;
                    case CommonData.Width.Medium:
                        result = "col-sm-3 col-md-3";
                        break;
                    case CommonData.Width.Large:
                        result = "col-sm-8 col-md-8";
                        break;
                    default:
                        break;
                }

                return result;
            }
        }

        #endregion

        #region Private methods

        private void SetValueFromModelMetadata()
        {
            if (this.Helper != null && !CommonMethod.IsNullOrEmpty(this.Name))
            {
                var modelMetadata = ModelMetadata.FromStringExpression(this.Name, this.Helper.ViewData);
                if (modelMetadata != null)
                {
                    this.Value = CommonMethod.ParseString(modelMetadata.Model);
                }
            }
        }

        //private void SetValidationAttributes()
        //{
        //    if (this.Helper != null && !CommonMethod.IsNullOrEmpty(this.Name))
        //    {
        //        if (this.ValidationAttributes.Count == 0)
        //        {
        //            ModelMetadata modelMetadata = ModelMetadata.FromStringExpression(this.Name, this.Helper.ViewData);
        //            this.ValidationAttributes = this.Helper.GetUnobtrusiveValidationAttributes(this.Name, modelMetadata);
        //        }
        //    }
        //}

        //private void SetCustomAttributes()
        //{
        //    if (this.Helper != null && !CommonMethod.IsNullOrEmpty(this.Name))
        //    {
        //        ModelMetadata modelMetadata = ModelMetadata.FromStringExpression(this.Name, this.Helper.ViewData);

        //        if (!CommonMethod.IsNullOrEmpty(modelMetadata.PropertyName))
        //        {
        //            var requireAttr = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
        //                               .GetCustomAttributes(typeof(RequiredAttribute), false)
        //                               .FirstOrDefault() as RequiredAttribute;
        //            if (requireAttr != null)
        //            {
        //                this.IsRequire = !requireAttr.AllowEmptyStrings;
        //            }

        //            var lengthAttr = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
        //                               .GetCustomAttributes(typeof(StringLengthAttribute), false)
        //                               .FirstOrDefault() as StringLengthAttribute;
        //            if (lengthAttr != null)
        //            {
        //                this.MaxLength = lengthAttr.MaximumLength;
        //            }

        //            var displayFormatAttr = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
        //                               .GetCustomAttributes(typeof(DisplayFormatAttribute), false)
        //                               .FirstOrDefault() as DisplayFormatAttribute;
        //            if (displayFormatAttr != null)
        //            {
        //                this.FormatString = displayFormatAttr.DataFormatString;
        //            }
        //        }
        //    }
        //}

        #endregion

        public WebBaseEdit SetPasswordType(bool isPasswordType = true)
        {
            if (isPasswordType)
            {
                this.InputType = CommonData.InputWebType.password;
            }
            return this;
        }

        public WebBaseEdit SetNoWrap(bool isNoWrap = true)
        {
            this.IsNoWrap = isNoWrap;
            return this;
        }

        public WebBaseEdit SetMaxLength(int maxlength)
        {
            this.MaxLength = maxlength;
            return this;
        }

        public WebBaseEdit SetValue(object value)
        {
            this.Value = value;
            return this;
        }

        public WebBaseEdit SetHtmlAttributes(object htmlAttributes)
        {
            this.HtmlAttributes = htmlAttributes;
            return this;
        }

        public WebBaseEdit SetReadonly(bool isReadonly = true)
        {
            this.Readonly = isReadonly;
            return this;
        }

        public WebBaseEdit SetPrimary(bool isPrimary = true)
        {
            this.IsPrimary = isPrimary;
            return this;
        }

        public WebBaseEdit SetFocus(bool isFocus = true)
        {
            this.IsFocus = isFocus;
            return this;
        }

        public WebBaseEdit SetUnique(bool isUnique = true)
        {
            this.IsUnique = isUnique;
            return this;
        }

        public WebBaseEdit SetMode(CommonData.Mode mode)
        {
            this.Mode = mode;
            return this;
        }

        public WebBaseEdit SetInputType(CommonData.InputWebType inputType)
        {
            this.InputType = inputType;
            return this;
        }

        public WebBaseEdit SetWidth(CommonData.Width width = CommonData.Width.Medium)
        {
            this.Width = width;
            return this;
        }

        public WebBaseEdit(HtmlHelper helper)
            : this(helper, CommonData.StringEmpty)
        {
        }

        public WebBaseEdit(HtmlHelper helper, string name)
            : this(helper, name, CommonData.Mode.Search)
        {
        }

        public WebBaseEdit(HtmlHelper helper, string name, object value)
            : this(helper, name, value, null)
        {
        }

        public WebBaseEdit(HtmlHelper helper, string name, object value, object htmlAttributes)
            : this(helper, name, value, htmlAttributes, CommonData.InputWebType.text)
        {
        }

        public WebBaseEdit(HtmlHelper helper, string name, object value, object htmlAttributes, CommonData.InputWebType inputType)
        {
            base.HtmlAttributes = htmlAttributes;
            this.Helper = helper;
            this.Name = name;
            this.Value = value;
            this.InputType = inputType;
            this.Width = CommonData.Width.Medium;
        }
    }
}
