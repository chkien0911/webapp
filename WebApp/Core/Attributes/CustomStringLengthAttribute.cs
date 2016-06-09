using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ivs.Resources.Common;
using Ivs.Core.Common;

namespace Ivs.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomStringLengthAttribute : StringLengthAttribute, IClientValidatable
    {
        private string _resourceKey = "COM_MSG_LENGTH_MAXIMUM";

        public CustomStringLengthAttribute(int maximumLength)
            : base(maximumLength)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            string messageText = I18n.GetMessage(_resourceKey);
            return string.Format(messageText, name, base.MaximumLength);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!CommonMethod.IsNullOrEmpty(value))
            {
                if (CommonMethod.ParseString(value).Length > base.MaximumLength)
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
                ValidationType = "length"
            };

            return new[] { clientValidationRule };
        }
    }
}
