using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using Ivs.Core.Attributes;
using System.ComponentModel.DataAnnotations;
using Ivs.Core.Common;

namespace Ivs.Models.Master
{
    public class MS_UnitConvertModel : IModel
    {
        public int ID { get; set; }

        [CustomDisplayName("COM_LBL_MS_UNIT_CONVERT_FROM_UNIT")]
        [CustomRequired]
        [CustomStringLength(10)]
        public string FromUnit { get; set; }

        [CustomDisplayName("COM_LBL_MS_UNIT_CONVERT_TO_UNIT")]
        [CustomRequired]
        [CustomStringLength(10)]
        public string ToUnit { get; set; }

        [CustomDisplayName("COM_LBL_MS_UNIT_CONVERT_FACTOR")]
        [CustomRequired]
        [CustomStringLength(10)]
        [CustomDisplayFormat(CommonData.NumberFormat.N2_CustomDigit)]
        public decimal? Factor { get; set; }

        public string ItemCode { get; set; }

        public string Remark { get; set; }
    }
}
