using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.Core.Data;
using Ivs.Models.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_FunctionMappingDao : BaseDao
    {
        /// <summary>
        /// Select Mapping Information by FunctionId ang OperationID
        /// </summary>
        /// <param name="htCondition">
        /// Hashtable contain condition to select data from table sy_functionmapping
        /// </param>
        /// <param name="dtResult">
        /// DataTable to contain data selected from table sy_functionmapping
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public void SelectMappingInfo(string functionId, string operId, out System.Data.DataTable dtResult)
        {
            int returnCode = 0;
            dtResult = new System.Data.DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<sy_functionmapping> lstItem = context.sy_functionmapping.AsQueryable();

                    if (!CommonMethod.IsNullOrEmpty(functionId))
                    {
                        lstItem = lstItem.Where(ig => ig.FunctionID.Equals(functionId));
                    }

                    if (!CommonMethod.IsNullOrEmpty(operId))
                    {
                        lstItem = lstItem.Where(ig => ig.OperID.Equals(operId));
                    }

                    #region Search data

                    IEnumerable<SYS_FunctionMappingModel> lstResult = lstItem.Select(ig => new SYS_FunctionMappingModel
                    {
                        Id = ig.ID,
                        FunctionId = ig.FunctionID,
                        OperId = ig.OperID,
                        OperName = UserSession.LangId.Equals(CommonData.Language.VietNamese) 
                                    ? ig.sy_operas.Name1 
                                    : (UserSession.LangId.Equals(CommonData.Language.English) 
                                        ? ig.sy_operas.Name2 
                                        : ig.sy_operas.Name3),
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
