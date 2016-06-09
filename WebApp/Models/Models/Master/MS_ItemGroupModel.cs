using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;

namespace Ivs.Models.Master
{
    public class MS_ItemGroupModel : IModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public DateTime Date { get; set; }
    }
}
