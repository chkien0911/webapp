using System.ComponentModel;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsProductionLineDataLookUp : IvsDataLookUp
    {
        private bool _showFG = false;
        private bool _showBlank = false;

        [DefaultValue(false)]
        public bool ShowFG
        {
            get
            {
                return _showFG;
            }
            set
            {
                _showFG = value;
            }
        }

        [DefaultValue(false)]
        public bool ShowBlank
        {
            get
            {
                return _showBlank;
            }
            set
            {
                _showBlank = value;
            }
        }

        protected override void FillData()
        {
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDataForControl(CommonData.FunctionGr.MS_ProductionLines, out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (this.ShowFG)
                {
                    DataRow newRow = dtResult.NewRow();
                    newRow[CommonKey.Code] = CommonData.FG_RMCode;
                    newRow[CommonKey.Name1] = "Thành Phẩm/Nguyên Liệu";
                    newRow[CommonKey.Name2] = "FG/RM";
                    newRow[CommonKey.Name3] = "FG/RM";
                    //newRow[0] = CommonData.StringEmpty;
                    dtResult.Rows.InsertAt(newRow, 0);
                }

                if (this.ShowBlank)
                {
                    DataRow newRow = dtResult.NewRow();

                    newRow[CommonKey.Code] = Ivs.Core.Common.CommonData.ProductionLineBlank.Code;
                    newRow[CommonKey.Name1] = Ivs.Core.Common.CommonData.ProductionLineBlank.Name1;
                    newRow[CommonKey.Name2] = Ivs.Core.Common.CommonData.ProductionLineBlank.Name2;
                    newRow[CommonKey.Name3] = Ivs.Core.Common.CommonData.ProductionLineBlank.Name3;
                    //newRow[0] = CommonData.StringEmpty;
                    dtResult.Rows.InsertAt(newRow, 0);
                }


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