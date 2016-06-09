using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.DTO.Systems;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_FunctionDao : BaseDao
    {
        /// <summary>
        /// Search Data in sy_Functions table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), Type
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in sy_Functions table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(SYS_FunctionsDto selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<sy_functions> lstGroup = context.sy_functions.AsQueryable();

                    #region Search Condition

                    //Filter by FunctionID
                    if (!CommonMethod.IsNullOrEmpty(selectDto.FunctionID))
                    {
                        lstGroup = lstGroup.Where(ig => ig.FunctionID.Contains(selectDto.FunctionID));
                    }

                    //Filter by Name(VN)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name1.Contains(selectDto.Name1));
                    }

                    //Filter by Name(EN)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name2.Contains(selectDto.Name2));
                    }

                    //Filter by Name(JP)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name3))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name3.Contains(selectDto.Name3));
                    }

                    lstGroup = lstGroup.OrderBy(ig => ig.ID);

                    #endregion Search Condition

                    #region Search data

                    IEnumerable<SYS_FunctionsDto> lstResult = lstGroup.Select(ig => new SYS_FunctionsDto
                    {
                        FunctionID = ig.FunctionID,
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
    }
}
