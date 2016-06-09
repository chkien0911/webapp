using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using System.Data;
using Ivs.Models.Systems;

namespace Ivs.DAL.Dao.Systems 
{
    public class SYS_PermissionAssignDao : BaseDao
    {
        /// <summary>
        /// Select Group Information by MappingID(FunctionID-OperationId)
        /// </summary>
        /// <param name="htCondition">
        /// Hashtable contain condition to select data from table ms_permissionassign
        /// </param>
        /// <param name="dtResult">
        /// DataTable to contain data selected from table ms_permissionassign
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public void SelectGroupByMapping(int mappingId, out System.Data.DataTable dtResult)
        {
            int returnCode = 0;
            dtResult = new System.Data.DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_permissionsassign> lstItem = context.ms_permissionsassign.AsQueryable();

                    if (!CommonMethod.IsNullOrEmpty(mappingId))
                    {
                        lstItem = lstItem.Where(ig => ig.MappingID.Equals(mappingId));
                    }

                    #region Search data

                    IQueryable<SYS_PermissionAssignModel> lstResult = lstItem.Select(ig => new SYS_PermissionAssignModel
                    {
                        Id = ig.ID,
                        MappingId = (ig.MappingID),
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
        }

    }
}
