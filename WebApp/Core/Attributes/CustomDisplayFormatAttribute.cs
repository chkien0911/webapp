using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Ivs.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomDisplayFormatAttribute : DisplayFormatAttribute
    {
        public CustomDisplayFormatAttribute(string formatString)
            : base()
        {
            base.ApplyFormatInEditMode = true;
            base.HtmlEncode = true;
            base.DataFormatString = formatString;
        }
    }
}
