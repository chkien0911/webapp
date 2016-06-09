using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.Models.Master;
using Ivs.Core.Interface;

namespace Ivs.DAL.Dao.Common
{
    public class MS_UnitLookupDao : BaseDao
    {
        /// <summary>
        /// Search Data for Combobox in ms_Unit table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), Type
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_ItemGroup table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_units> lstUnit = context.ms_units.AsQueryable();

                    #region Search data

                    IEnumerable<MS_UnitModel> lstResult = lstUnit.Select(ig => new MS_UnitModel
                    {
                        Code = ig.Code,
                        Name1 = ig.Name1,
                        Name2 = ig.Name2,
                        Name3 = ig.Name3,
                    });

                    dtResult = base.ToDataTable(lstResult);

                    #endregion Search data
                }
                catch (Exception ex)
                {
                    returnCode = this.ProcessDbException(ex);
                }
            }
            return returnCode;
        }

        public int SelectData<T>(out List<T> lstResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            lstResult = new List<T>();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_units> query = context.ms_units.AsQueryable();

                    #region Search data

                    lstResult = query.Select(ig => new MS_UnitModel
                    {
                        ID = ig.ID,
                        Code = ig.Code,
                        Name1 = ig.Name1,
                        Name2 = ig.Name2,
                        Name3 = ig.Name3,
                    })
                    .ToList()
                    .Cast<T>()
                    .ToList();


                    #endregion Search data
                }
                catch (Exception ex)
                {
                    returnCode = this.ProcessDbException(ex);
                }
            }
            return returnCode;
        }
    }
}