using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.Infrastructure.BaseControl
{
    public class WebBaseDropDown : WebBaseEdit
    {
        public IEnumerable<SelectListItem> DataSource { get; protected set; }

        public WebBaseDropDown(HtmlHelper helper, string name, IEnumerable<SelectListItem> dataSource, object value, object htmlAttributes)
            : base(helper, name, value, htmlAttributes)
        {
            this.DataSource = dataSource;
        }

    }
}
