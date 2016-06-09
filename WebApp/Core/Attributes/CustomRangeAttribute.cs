using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ivs.Resources.Common;
using Ivs.Core.Common;
using System.Web.Mvc;

namespace Ivs.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomRangeAttribute : RangeAttribute
    {
        private string _resourceKey = "COM_MSG_BETWEEN";

        public CustomRangeAttribute(object minValue, object maxValue)
            : base(minValue.GetType(), minValue == null ? CommonData.StringEmpty : minValue.ToString(), maxValue == null ? CommonData.StringEmpty : maxValue.ToString())
        {
        }

        public override string FormatErrorMessage(string name)
        {
            string messageText = I18n.GetMessage(_resourceKey);
            return string.Format(messageText, name, base.Minimum, base.Maximum);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!CommonMethod.IsNullOrEmpty(value))
            {
                if (Compare(value, base.Minimum) == -1
                    ||
                    Compare(value, base.Maximum) == 1)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
                            ModelMetadata metadata,
                            ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "range"
            };

            return new[] { clientValidationRule };
        }

        private static int Compare<T>(T value1, T value2)
        {
            return Comparer<T>.Default.Compare(value1, value2);
        }

        public static int Compare(object value1, object value2)
        {
            return Compare(value1, value2);
        }
    }
}
