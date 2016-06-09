using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;

namespace Ivs.Models.Systems
{
    public class SYS_FunctionModel : IModel
    {
        public string FunctionID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string GroupName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string DisplayName { get; set; }
    }
}
