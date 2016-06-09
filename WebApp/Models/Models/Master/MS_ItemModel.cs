using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using System.ComponentModel.DataAnnotations;
using Ivs.Resources.Common;
using System.ComponentModel;
using Ivs.Core.Attributes;

namespace Ivs.Models.Master
{
    public class MS_ItemModel : IModel
    {
        public int ID { get; set; }

        [CustomDisplayName("COM_LBL_MS_ITEM_CODE")]
        [CustomRequired]
        [CustomStringLength(10)]
        public string Code { get; set; }

        //[Required(ErrorMessage = I18n.GetMessage("COM_MSG_REQUIRED_MS_ITEM_NAME1"))]
        
        [CustomStringLength(50)]
        [CustomRequired]
        [CustomDisplayName("COM_LBL_MS_ITEM_NAME1")]
        public string Name1 { get; set; }

        //[Required(ErrorMessage = I18n.GetMessage("COM_MSG_REQUIRED_MS_ITEM_NAME2"))]
        [CustomStringLength(50)]
        [CustomRequired]
        [CustomDisplayName("COM_LBL_MS_ITEM_NAME2")]
        public string Name2 { get; set; }

        //[Required(ErrorMessage = I18n.GetMessage("COM_MSG_REQUIRED_MS_ITEM_GROUPCODE"))]
        [CustomStringLength(10)]
        [CustomRequired]
        [CustomDisplayName("COM_LBL_MS_ITEM_GROUPCODE")]
        public string GroupCode { get; set; }

        //[Required(ErrorMessage = I18n.GetMessage("COM_MSG_REQUIRED_MS_ITEM_INVUNITCODE"))]
        [CustomStringLength(10)]
        [CustomRequired]
        [CustomDisplayName("COM_LBL_MS_ITEM_INVUNITCODE")]
        public string InvUnitCode { get; set; }

        [CustomDisplayName("COM_LBL_MS_ITEM_GROUPNAME")]
        public string GroupName { get; set; }

        
        public string InvUnitName { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<MS_UnitConvertModel> UnitConverts { get; set; }
    }
}
