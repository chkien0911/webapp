/* =========================================
 * Author: DDKhanh
 * Create Date: 2012/10/12
 ========================================= */

using System;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.DTO.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_JournalDao : BaseDao
    {
        //private static readonly Logger log = new Logger();
        /// <summary>
        /// Search Data in sy_systemjournals table
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in sy_systemjournals table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(SYS_JournalDto dto, out DataTable dtResult)
        {
            int returnCode = 0;
            dtResult = new DataTable();

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    var query = context.sy_systemjournals.AsQueryable();

                    #region Search Condition

                    //Filter by FunctionID
                    if (!CommonMethod.IsNullOrEmpty(dto.FunctionID))
                    {
                        query = query.Where(j => j.FunctionID.Equals(dto.FunctionID));
                    }
                    //Filter by FromDate
                    if (dto.FromDate != null)
                    {
                        dto.FromDate = new DateTime(dto.FromDate.Value.Year, dto.FromDate.Value.Month, dto.FromDate.Value.Day);
                        query = query.Where(j => j.ActionDate >= dto.FromDate);
                    }
                    //Filter by ToDate
                    if (dto.ToDate != null)
                    {
                        dto.ToDate = new DateTime(dto.ToDate.Value.Year, dto.ToDate.Value.Month, dto.ToDate.Value.Day);
                        dto.ToDate = dto.ToDate.Value.Date.AddDays(1).AddSeconds(-1);
                        query = query.Where(j => j.ActionDate <= dto.ToDate);
                    }
                    //Filter by EmployeeID
                    if (!CommonMethod.IsNullOrEmpty(dto.EmployeeID))
                    {
                        query = query.Where(j => j.EmployeeID.ToLower().Contains(dto.EmployeeID.ToLower()));
                    }
                    //Filter by EmployeeName
                    if (!CommonMethod.IsNullOrEmpty(dto.EmployeeName))
                    {
                        //query = query.Where(j => j.EmployeeName.ToLower().Contains(dto.EmployeeName.ToLower()));
                        query = query.Where(j => j.UserName.ToLower().Contains(dto.EmployeeName.ToLower()));
                    }
                    //Filter by Action
                    if (!CommonMethod.IsNullOrEmpty(dto.Action))
                    {
                        query = query.Where(j => j.Action.Equals(dto.Action));
                    }

                    #endregion Search Condition

                    var result = from j in query
                                 orderby j.ID ascending
                                 select new SYS_JournalDto
                                 {
                                     ID = j.ID,
                                     FunctionID = j.FunctionID,

                                     UserCode = j.UserCode,
                                     UserName = j.UserName,
                                     ActionDate = j.ActionDate,
                                     Action = j.Action
                                 };

                    dtResult = ToDataTable(result);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        /// <summary>
        /// Search Data in sy_systemjournalDetail table
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in sy_systemjournalDetail table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectDataDetail(int? minID, int? maxID, out DataTable dtResult)
        {
            int returnCode = 0;
            dtResult = new DataTable();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    var query = context.sy_systemjournaldetail.AsQueryable();

                    #region Search Condition

                    //Filter by minID
                    if (!CommonMethod.IsNullOrEmpty(minID))
                    {
                        query = query.Where(j => j.ParentID >= minID);
                    }
                    //Filter by minID
                    if (!CommonMethod.IsNullOrEmpty(maxID))
                    {
                        query = query.Where(j => j.ParentID <= maxID);
                    }

                    #endregion Search Condition

                    dtResult = ToDataTable(query.ToList());
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }
    }
}