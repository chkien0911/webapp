using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using System.Web.Mvc;
using Ivs.Core.Interface;
using System.Web;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;
using Ivs.Resources.Common;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public class WebButton : WebBaseButton, IWebControl, IHtmlString
    {
        private readonly string _frefixButton = "btn";
        
        #region Constructors

        public WebButton(HtmlHelper helper)
            : this(helper, CommonData.StringEmpty)
        {
        }

        public WebButton(HtmlHelper helper, string name)
            : this(helper, name, CommonData.StringEmpty)
        {
        }

        public WebButton(HtmlHelper helper, string name, string caption)
            : this(helper, name, caption, CommonData.ButtonCategory.Default)
        {
        }

        public WebButton(HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category)
            : this(helper, name, caption, category, CommonData.ButtonWebType.button)
        {
        }

        public WebButton(HtmlHelper helper, string name, CommonData.ButtonCategory category)
            : this(helper, name, category, CommonData.ButtonWebType.button)
        {
        }

        public WebButton(HtmlHelper helper, string name, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
            : this(helper, name, CommonData.StringEmpty, category, type)
        {
        }

        public WebButton(HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
        {
            base.Helper = helper;
            base.Name = name.Contains("btn") ? name : this._frefixButton + name;
            base.ButtonCategory = category;
            base.Caption = caption;
            base.ButtonType = type;
            base.IconName = this.GetDefaultIcon(category);
        }

        public WebButton(HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category, CommonData.ButtonWebType type, object htmlAttributes)
        {
            base.Helper = helper;
            base.Name = this._frefixButton + name;
            base.ButtonCategory = category;
            base.Caption = caption;
            base.ButtonType = type;
            base.IconName = this.GetDefaultIcon(category);
            base.HtmlAttributes = htmlAttributes;
        }

        public WebButton(string name)
            : this(name, CommonData.StringEmpty)
        {
        }

        public WebButton(string name, string caption)
            : this(name, caption, CommonData.ButtonCategory.Default)
        {
        }

        public WebButton(string name, string caption, CommonData.ButtonCategory category)
            : this(name, caption, category, CommonData.ButtonWebType.button)
        {
        }

        public WebButton(string name, CommonData.ButtonCategory category)
            : this(name, CommonData.StringEmpty, category, CommonData.ButtonWebType.button)
        {
        }

        public WebButton(string name, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
            : this(name, CommonData.StringEmpty, category, type)
        {
        }

        public WebButton(CommonData.ButtonCategory category)
            : this(category, CommonData.ButtonWebType.button)
        {
        }

        public WebButton(CommonData.ButtonCategory category, CommonData.ButtonWebType type)
            : this(category.ToString(), CommonData.StringEmpty, category, type)
        {
        }

        public WebButton(string name, string caption, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
        {
            base.Name = name.Contains("btn") ? name : this._frefixButton + name;
            base.ButtonCategory = category;
            base.Caption = caption;
            base.ButtonType = type;
            base.IconName = this.GetDefaultIcon(category);
        }

        #endregion

        public string ToHtmlString()
        {
            return RenderControl();
        }

        private string RenderExport()
        {
            TagBuilder divTagbuilder = new TagBuilder("div");
            divTagbuilder.AddCssClass("btn-group btn-group-sm btn-group-md");

            string defaultClassName = "btn btn-default dropdown-toggle";
            string defaultIconClass = "glyphicon";

            #region button Export

            TagBuilder buttonBuilder = new TagBuilder("button");
            buttonBuilder.Attributes.Add("type", base.ButtonType.ToString());
            buttonBuilder.Attributes.Add("name", base.Name);
            buttonBuilder.Attributes.Add("id", base.Name);
            buttonBuilder.Attributes.Add("data-toggle", "dropdown");
            //string defaultEvent = this.GetDefaultEvent(base.ButtonCategory);
            //if (!CommonMethod.IsNullOrEmpty(defaultEvent))
            //{
            //    buttonBuilder.Attributes.Add("onclick", defaultEvent);
            //}

            buttonBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(base.HtmlAttributes), true);
            buttonBuilder.AddCssClass(defaultClassName);

            TagBuilder spanIconBuilder = new TagBuilder("span");
            if (!CommonMethod.IsNullOrEmpty(base.IconName))
            {
                spanIconBuilder.AddCssClass((CommonMethod.IsNullOrEmpty(base.IconName)) ? defaultIconClass : defaultIconClass + " " + base.IconName);
            }

            string caption = CommonMethod.IsNullOrEmpty(base.Caption) ? GetDefaultCation(base.ButtonCategory) : base.Caption;
            buttonBuilder.InnerHtml = spanIconBuilder.ToString(TagRenderMode.Normal) + " " + caption;
            buttonBuilder.InnerHtml += " <span class='caret'></span>";

            divTagbuilder.InnerHtml += buttonBuilder.ToString(TagRenderMode.Normal);

            #endregion

            #region popup export types

            TagBuilder ulBuilder = new TagBuilder("ul");
            ulBuilder.Attributes.Add("role", "menu");
            ulBuilder.AddCssClass("dropdown-menu");

            TagBuilder ilXls = new TagBuilder("li");
            ilXls.InnerHtml += "<a href='#' onclick='exportXls();'><span class='glyphicon glyphicon-save'></span> Xls</a>";
            ulBuilder.InnerHtml += ilXls.ToString(TagRenderMode.Normal);

            TagBuilder ilXlsx = new TagBuilder("li");
            ilXlsx.InnerHtml += "<a href='#' onclick='exportXlsx();'><span class='glyphicon glyphicon-save'></span> Xlsx</a>";
            ulBuilder.InnerHtml += ilXlsx.ToString(TagRenderMode.Normal);

            //TagBuilder ilPdf = new TagBuilder("li");
            //ilPdf.InnerHtml += "<a href='#' onclick='exportPdf();'><span class='glyphicon glyphicon-save'></span> Pdf</a>";
            //ulBuilder.InnerHtml += ilPdf.ToString(TagRenderMode.Normal);

            divTagbuilder.InnerHtml += ulBuilder.ToString(TagRenderMode.Normal);

            #endregion

            //divTagbuilder.InnerHtml = RenderControl();
            return divTagbuilder.ToString(TagRenderMode.Normal);
        }

        public string RenderControl()
        {
            //<button type="submit" id="btnSearch" name="btnSearch" class="btn btn-default">
            //    <span class="glyphicon glyphicon-search"></span> Search
            //</button>

            if (base.IsAuthority == CommonData.IsAuthority.Deny)
            {
                return CommonData.StringEmpty;
            }

            if (base.ButtonCategory == CommonData.ButtonCategory.Export)
            {
                return RenderExport();
            }

            string defaultClassName = "btn btn-default";
            string defaultIconClass = "glyphicon";

            TagBuilder buttonBuilder = new TagBuilder("button");
            buttonBuilder.Attributes.Add("type", base.ButtonType.ToString());
            buttonBuilder.Attributes.Add("name", base.Name);
            buttonBuilder.Attributes.Add("id", base.Name);

            if (base.IsDismissModal)
            {
                buttonBuilder.Attributes.Add("data-dismiss", "modal");
            }

            string defaultEvent = this.GetDefaultEvent(base.ButtonCategory);
            if (!CommonMethod.IsNullOrEmpty(defaultEvent))
            {
                buttonBuilder.Attributes.Add("onclick", defaultEvent);
            }

            buttonBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(base.HtmlAttributes), true);
            buttonBuilder.AddCssClass(defaultClassName);

            TagBuilder spanIconBuilder = new TagBuilder("span");
            if (!CommonMethod.IsNullOrEmpty(base.IconName))
            {
                spanIconBuilder.AddCssClass((CommonMethod.IsNullOrEmpty(base.IconName)) ? defaultIconClass : defaultIconClass + " " + base.IconName);
            }

            string caption = CommonMethod.IsNullOrEmpty(base.Caption) ? GetDefaultCation(base.ButtonCategory) : base.Caption;
            buttonBuilder.InnerHtml = spanIconBuilder.ToString(TagRenderMode.Normal) + " " + caption;
            if (base.ButtonCategory == CommonData.ButtonCategory.Export)
            {
                buttonBuilder.InnerHtml += " <span class='caret'></span>";
            }

            return buttonBuilder.ToString(TagRenderMode.Normal);
        }

        

        private string GetDefaultCation(CommonData.ButtonCategory category)
        {
            string caption = CommonData.StringEmpty;
            switch (category)
            {
                case CommonData.ButtonCategory.Add:
                    caption = I18n.GetMessage("COM_LBL_ADD");
                    break;
                case CommonData.ButtonCategory.Edit:
                    caption = I18n.GetMessage("COM_LBL_EDIT");
                    break;
                case CommonData.ButtonCategory.Copy:
                    caption = I18n.GetMessage("COM_LBL_COPY");
                    break;
                case CommonData.ButtonCategory.Detail:
                    caption = I18n.GetMessage("COM_LBL_DETAIL");
                    break;
                case CommonData.ButtonCategory.Delete:
                    caption = I18n.GetMessage("COM_LBL_DELETE");
                    break;
                case CommonData.ButtonCategory.Search:
                    caption = I18n.GetMessage("COM_LBL_SEARCH");
                    break;
                case CommonData.ButtonCategory.Export:
                    caption = I18n.GetMessage("COM_LBL_EXPORT");
                    break;
                case CommonData.ButtonCategory.Print:
                    caption = I18n.GetMessage("COM_LBL_PRINT");
                    break;
                case CommonData.ButtonCategory.Close:
                    caption = I18n.GetMessage("COM_LBL_CLOSE");
                    break;
                case CommonData.ButtonCategory.Save:
                    caption = I18n.GetMessage("COM_LBL_SAVE");
                    break;
                case CommonData.ButtonCategory.SaveAndNext:
                    caption = I18n.GetMessage("COM_LBL_SAVEANDNEXT");
                    break;
                case CommonData.ButtonCategory.Back:
                    caption = I18n.GetMessage("COM_LBL_BACK");
                    break;
                case CommonData.ButtonCategory.Import:
                    caption = I18n.GetMessage("COM_LBL_IMPORT");
                    break;
                case CommonData.ButtonCategory.Refresh:
                    caption = I18n.GetMessage("COM_LBL_REFRESH");
                    break;
                case CommonData.ButtonCategory.Yes:
                    caption = I18n.GetMessage("COM_LBL_YES");
                    break;
                case CommonData.ButtonCategory.No:
                    caption = I18n.GetMessage("COM_LBL_NO");
                    break;
                case CommonData.ButtonCategory.Ok:
                    caption = I18n.GetMessage("COM_LBL_OK");
                    break;
                case CommonData.ButtonCategory.Cancel:
                    caption = I18n.GetMessage("COM_LBL_CANCEL");
                    break;
                case CommonData.ButtonCategory.Default:
                    break;
                default:
                    break;
            }

            return caption;
        }

        private string GetDefaultIcon(CommonData.ButtonCategory category)
        {
            string iconName = CommonData.StringEmpty;
            switch (category)
            {
                case CommonData.ButtonCategory.Add:
                    iconName = "glyphicon-plus";
                    break;
                case CommonData.ButtonCategory.Edit:
                    iconName = "glyphicon-edit";
                    break;
                case CommonData.ButtonCategory.Copy:
                    iconName = "glyphicon-repeat";
                    break;
                case CommonData.ButtonCategory.Detail:
                    iconName = "glyphicon-pencil";
                    break;
                case CommonData.ButtonCategory.Delete:
                    iconName = "glyphicon-remove";
                    break;
                case CommonData.ButtonCategory.Search:
                    iconName = "glyphicon-search";
                    break;
                case CommonData.ButtonCategory.Export:
                    iconName = "glyphicon-export";
                    break;
                case CommonData.ButtonCategory.Print:
                    iconName = "glyphicon-print";
                    break;
                case CommonData.ButtonCategory.Close:
                    iconName = "glyphicon-off";
                    break;
                case CommonData.ButtonCategory.Save:
                    iconName = "glyphicon-saved";
                    break;
                case CommonData.ButtonCategory.SaveAndNext:
                    iconName = "glyphicon-log-in";
                    break;
                case CommonData.ButtonCategory.Back:
                    iconName = "glyphicon-circle-arrow-left";
                    break;
                case CommonData.ButtonCategory.Import:
                    iconName = "glyphicon-import";
                    break;
                case CommonData.ButtonCategory.Refresh:
                    iconName = "glyphicon-refresh";
                    break;
                case CommonData.ButtonCategory.Yes:
                    iconName = "glyphicon-ok";
                    break;
                case CommonData.ButtonCategory.No:
                    iconName = "glyphicon-remove";
                    break;
                case CommonData.ButtonCategory.Ok:
                    iconName = "glyphicon-ok";
                    break;
                case CommonData.ButtonCategory.Cancel:
                    iconName = "glyphicon-off";
                    break;
                case CommonData.ButtonCategory.Default:
                    break;
                default:
                    break;
            }

            return iconName;
        }

        private string GetDefaultEvent(CommonData.ButtonCategory category)
        {
            string result = CommonData.StringEmpty;
            switch (category)
            {
                case CommonData.ButtonCategory.Add:
                    result = "addData();";
                    break;
                case CommonData.ButtonCategory.Edit:
                    result = "editData();";
                    break;
                case CommonData.ButtonCategory.Copy:
                    result = "copyData();";
                    break;
                case CommonData.ButtonCategory.Detail:
                    result = "detailData();";
                    break;
                case CommonData.ButtonCategory.Delete:
                    result = "deleteData();";
                    break;
                case CommonData.ButtonCategory.Search:
                    //result = "onclick = 'deleteData()';";
                    break;
                case CommonData.ButtonCategory.Export:
                    //result = "onclick = 'deleteData()';";
                    break;
                case CommonData.ButtonCategory.Print:
                    result = "printData();";
                    break;
                case CommonData.ButtonCategory.Close:
                    //result = "onclick = 'deleteData()';";
                    break;
                case CommonData.ButtonCategory.Save:
                    result = "saveData();";
                    break;
                case CommonData.ButtonCategory.SaveAndNext:
                    result = "saveAndNextData();";
                    break;
                case CommonData.ButtonCategory.Back:
                    result = "backData();";
                    break;
                case CommonData.ButtonCategory.Import:
                    result = "importData();";
                    break;
                case CommonData.ButtonCategory.Refresh:
                    result = "refreshData();";
                    break;
                case CommonData.ButtonCategory.Yes:
                    //result = "onclick = 'deleteData()';";
                    break;
                case CommonData.ButtonCategory.No:
                    //result = "glyphicon-remove";
                    break;
                case CommonData.ButtonCategory.Ok:
                    //result = "glyphicon-ok";
                    break;
                case CommonData.ButtonCategory.Cancel:
                    //result = "glyphicon-off";
                    break;
                case CommonData.ButtonCategory.Default:
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
