using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ivs.BLL.Common;
using System.Data;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsItemCategoryLookup : IvsDataLookUp
    {

        protected override void FillData()
        {
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();

            commonBl.SelectItemCategoryData(out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                {
                    DataRow newRow = dtResult.NewRow();
                    //newRow[0] = CommonData.StringEmpty;

                    dtResult.Rows.InsertAt(newRow, 0);
                }
            }

            this.Properties.DataSource = dtResult;
            this.Properties.NullText = CommonData.StringEmpty;

        }
    }
}
