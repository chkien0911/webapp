using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;

namespace Ivs.Models.Common
{
    public class SYS_CommonModel : IModel
    {
        public string Key { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string LangId { get; set; }
    }
}
