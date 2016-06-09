using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;

namespace Ivs.Models.Systems
{
    public class SYS_FunctionMappingModel : IModel
    {
        public int Id { get; set; }
        public string FunctionId { get; set; }
        public string OperId { get; set; }
        public string OperName { get; set; }
        public string OperCode 
        {
            get
            {
                return this.OperId;
            }
        }
        
    }
}
