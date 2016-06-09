using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.Models.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_GroupsAssignDao : Ivs.DAL.Dao.BaseDao
    {

        /// <summary>
        /// Select User-Group related informations
        /// </summary>
        /// <param name="htCondition">
        /// Hashtable contain condition to select data from table ms_groupassign
        /// </param>
        /// <param name="dtResult">
        /// DataTable to contain data selected from table ms_groupassign
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectGroupByUserId(string userCode, out DataTable dtResult)
        {
            int returnCode = 0;
            dtResult = new System.Data.DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_groupsassign> lstItem = context.ms_groupsassign.AsQueryable();

                    if (!CommonMethod.IsNullOrEmpty(userCode))
                    {
                        lstItem = lstItem.Where(ig => ig.UserCode.Equals(userCode));
                    }

                    //if (htCondition[CommonKey.GroupCode] != null && !CommonMethod.IsNullOrEmpty(htCondition[CommonKey.GroupCode]))
                    //{
                    //    string groupCode = htCondition[CommonKey.GroupCode].ToString();
                    //    lstItem = lstItem.Where(ig => ig.GroupCode.Equals(groupCode));
                    //}

                    #region Search data

                    IEnumerable<SYS_GroupsAssignModel> lstResult = lstItem.Select(ig => new SYS_GroupsAssignModel
                    {
                        ID = ig.ID,
                        UserCode = ig.UserCode,
                        GroupCode = ig.GroupCode,
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