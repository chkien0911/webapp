using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.DTO.Common;
using Ivs.Core.Common;
using Ivs.DTO.Inventory;

namespace Ivs.BLL.Common
{
    public static class ConvertExtendBl
    {
        /// <summary>
        /// Convert ProductionLine No-Processing to null
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ST_StockTransactionDetailDto> ConvertLineBlankToNull(this   List<ST_StockTransactionDetailDto> list)
        {
            foreach (var item in list)
            {
                if (!CommonMethod.IsNullOrEmpty(item.ProductionLine))
                    item.IsChooiseLine = true;

                if ((item.ItemType != CommonData.ItemType.RawMaterials && item.ProductionLine == CommonData.ProductionLineBlank.Code) || CommonMethod.IsNullOrEmpty(item.ProductionLine))
                {
                    item.ProductionLine = null;

                }

            }
            return list;
        }

        /// <summary>
        /// Convert ProductionLine Null to No-Processing 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ST_StockTransactionDetailDto> ConvertLineNullToBlank(this   List<ST_StockTransactionDetailDto> list)
        {
            foreach (var item in list)
            {
                if (item.ItemType != CommonData.ItemType.RawMaterials && CommonMethod.IsNullOrEmpty(item.ProductionLine))
                {
                    item.ProductionLine = CommonData.ProductionLineBlank.Code;
                }

            }
            return list;
        }



    }
}
