using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using System.ComponentModel.DataAnnotations;
using Ivs.Core.Common;
using Ivs.Resources.Common;
using Ivs.Core.Data;

namespace Ivs.Models.Master
{
    public class MS_DepartmentModel : IModel, IValidatableObject
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Code must be fill in")]
        [StringLength(10, ErrorMessage = "Can only be 10 characters long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name1 must be fill in")]
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Remark { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IvsMessage message = null;
            if (CommonMethod.IsNullOrEmpty(Code))
            {
                message = new IvsMessage("COM_MSG_MS_DEPARTMENT_CODE");
                yield return new ValidationResult(message.MessageText, new[] { CommonKey.Code });
            }
            if (CommonMethod.IsNullOrEmpty(Name1))
            {
                message = new IvsMessage("COM_MSG_MS_DEPARTMENT_NAME1");
                yield return new ValidationResult(message.MessageText, new[] { CommonKey.Name1 });
            }
            if (CommonMethod.IsNullOrEmpty(Name2))
            {
                message = new IvsMessage("COM_MSG_MS_DEPARTMENT_NAME2");
                yield return new ValidationResult(message.MessageText, new[] { CommonKey.Name2 });
            }
        }
    }
}
