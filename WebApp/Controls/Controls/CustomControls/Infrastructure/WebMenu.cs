using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ivs.Core.Interface;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;
using System.Data;
using System.Web.Mvc;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public class WebMenu<TModel> : WebBaseEdit, IWebControl, IHtmlString
    {
        private Dictionary<string, string> _dicModules = new Dictionary<string, string>();
        public List<TModel> Functions { get; protected set; }
        public DataTable DtFunctions { get; protected set; }

        public WebMenu(HtmlHelper helper)
            : base(helper)
        {
        }

        //public WebMenu(HtmlHelper helper, string name)
        //    : base(helper, name)
        //{
        //}

        public WebMenu<TModel> SetFunctions(DataTable dtFunctions)
        {
            this.DtFunctions = dtFunctions;
            return this;
        }

        public WebMenu<TModel> SetFunctions(List<TModel> lstFunctions)
        {
            this.Functions = lstFunctions;
            return this;
        }

        public string ToHtmlString()
        {
            return RenderControl();
        }

        public string RenderControl()
        {
            //<ul class="nav navbar-nav navbar-left">
            //    <li class="dropdown">
            //      <a href="">System <span class="caret"></span></a>
            //      <ul class="dropdown-menu" role="menu">
            //        <li><a href="#">User Management</a></li>
            //        <li><a href="#">User Group Management</a></li>
            //        <li class="divider"></li>
            //        <li><a href="#">System Jounals</a></li>
            //      </ul>
            //    </li>
            //    <li class="dropdown">
            //      <a href="">Master <span class="caret"></span></a>
            //      <ul class="dropdown-menu" role="menu">
            //        <li>
            //            @Html.ActionLink("Item Management", "Index", "Item")
            //        </li>
            //        <li class="divider"></li>
            //        <li>
            //            @Html.ActionLink("Department Management", "Index", "Department")
            //        </li>
                    
            //      </ul>
            //    </li>
            //</ul>

            TagBuilder ulbuilder = new TagBuilder("ul");
            ulbuilder.AddCssClass("nav navbar-nav navbar-left");

            if (this.Functions != null)
            {
                StringBuilder ilStrBuilder = new StringBuilder();

                List<TModel> lstModules = GetModules(this.Functions);

                foreach (var rModule in lstModules)
                {
                    var nModuleCodeValue = GetPropertyValue(rModule, "ModuleCode");
                    var nModuleNameValue = GetPropertyValue(rModule, "ModuleName");


                    List<TModel> lstGroups = GetModuleGroups(this.Functions, nModuleCodeValue);


                    //Begin add module menu
                    ilStrBuilder.AppendLine("<li class='dropdown'>");
                    ilStrBuilder.AppendLine("<a href='#'>" + nModuleNameValue + " <span class='caret'></span></a>");
                    ilStrBuilder.AppendLine("<ul class='dropdown-menu' role='menu'>");

                    foreach (var gItem in lstGroups)
                    {
                        //var gModuleCodeValue = GetPropertyValue(gItem, "ModuleCode");
                        var gGroupName = GetPropertyValue(gItem, "GroupName");
                        //if (nModuleCodeValue.Equals(gModuleCodeValue))
                        //{
                        //Begin add group menu (sub menu)
                        ilStrBuilder.AppendLine("<li class='dropdown-submenu'>");
                        ilStrBuilder.AppendLine("<a href='#' class='dropdown-toggle' data-toggle='dropdown'>" + gGroupName + "</a>");
                        ilStrBuilder.AppendLine("<ul class='dropdown-menu'>");

                        //Begin add page
                        foreach (var citem in this.Functions)
                        {
                            var cModuleCodeValue = GetPropertyValue(citem, "ModuleCode");
                            var cGroupName = GetPropertyValue(citem, "GroupName");
                            var cControllerValue = GetPropertyValue(citem, "Controller");
                            var cActionValue = GetPropertyValue(citem, "Action");
                            var cDisplayValue = GetPropertyValue(citem, "DisplayName");
                            if (nModuleCodeValue.Equals(cModuleCodeValue) && gGroupName.Equals(cGroupName))
                            {
                                string url = string.Format("/{0}/{1}", cControllerValue, cActionValue);
                                ilStrBuilder.AppendLine("<li><a href='" + url + "'>" + cDisplayValue + "</a></li>");
                            }
                        }

                        //End add page
                        ilStrBuilder.AppendLine("</ul>");
                        ilStrBuilder.AppendLine("</li>");
                        //}
                    }

                    //End add module menu
                    ilStrBuilder.AppendLine("</ul>");
                    ilStrBuilder.AppendLine("</li>");
                }

                ulbuilder.InnerHtml = ilStrBuilder.ToString();
            }
            //if (this.DtFunctions != null)
            //{
            //    StringBuilder ilStrBuilder = new StringBuilder();
            //    DataTable dtModules = GetModules(this.DtFunctions);
            //    foreach (DataRow rModule in dtModules.Rows)
            //    {
            //        ilStrBuilder.AppendLine("<li class='dropdown'>");
            //        ilStrBuilder.AppendLine("<a href=''>" + rModule["ModuleName"].ToString() + "<span class='caret'></span></a>");
            //        ilStrBuilder.AppendLine("<ul class='dropdown-menu' role='menu'>");
            //        foreach (DataRow rFunction in this.DtFunctions.Rows)
            //        {
            //            if (rModule["ModuleCode"].Equals(rFunction["ModuleCode"]))
            //            {
            //                string url = string.Format("/{0}/{1}", rFunction["Controller"].ToString(), rFunction["Action"].ToString());
            //                ilStrBuilder.AppendLine("<li><a href='" + url + "'>" + rFunction["DisplayName"].ToString() + "</a></li>");
            //            }
            //        }
            //        ilStrBuilder.AppendLine("</ul>");
            //        ilStrBuilder.AppendLine("</li>");
            //    }

            //    ulbuilder.InnerHtml = ilStrBuilder.ToString();
            //}

            return ulbuilder.ToString(TagRenderMode.Normal);
        }

        private List<TModel> GetModuleGroups(List<TModel> lstFunctions, object nModuleCodeValue)
        {
            List<TModel> lstGroups = new List<TModel>();
            foreach (var item in lstFunctions)
            {
                var gModuleCodeValue = GetPropertyValue(item, "ModuleCode");
                var gGroupName = GetPropertyValue(item, "GroupName");

                if (gModuleCodeValue.Equals(nModuleCodeValue))
                {
                    bool isExisted = false;
                    foreach (var group in lstGroups)
                    {
                        var eGroupName = GetPropertyValue(group, "GroupName");
                        if (eGroupName == gGroupName)
                        {
                            isExisted = true;
                            break;
                        }
                    }
                    if (!isExisted)
                    {
                        lstGroups.Add(item);
                    }
                }
            }

            return lstGroups;
        }

        private List<TModel> GetModules(List<TModel> lstFunction)
        {
            List<TModel> lstModules = new List<TModel>();
            foreach (var item in lstFunction)
            {
                var nModuleCodeValue = GetPropertyValue(item, "ModuleCode");
                var nModuleNameValue = GetPropertyValue(item, "ModuleName");

                bool isExisted = false;
                foreach (var module in lstModules)
                {
                    var eModuleCodeValue = GetPropertyValue(module, "ModuleCode");
                    var eModuleNameValue = GetPropertyValue(module, "ModuleName");
                    if (eModuleCodeValue == nModuleCodeValue)
                    {
                        isExisted = true;
                        break;
                    }
                }
                if (!isExisted)
                {
                    lstModules.Add(item);
                }
            }

            return lstModules;
        }

        private object GetPropertyValue(TModel item, string propertyName)
        {
            var property = item.GetType().GetProperty(propertyName);
            return property.GetValue(item, null) ?? CommonData.StringEmpty;
        }

    }
}
