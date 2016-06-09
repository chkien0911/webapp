using System;
using System.Data;
using System.Linq;
using Ivs.Core.Data;
using Ivs.DAL.EFModels;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_GroupListDAO : BaseDao
    {
        #region Search Function InGroup belond UserName

        public int SelectFunction(out DataTable dtResult)
        {
            int returnCode = 0;

            try
            {
                using (DBContext = new WmsContext())
                {
                    var query = from f in DBContext.sy_functions
                                join fm in DBContext.sy_functionmapping on f.FunctionID equals fm.FunctionID
                                join p in DBContext.ms_permissionsassign on fm.ID equals p.MappingID
                                join ug in DBContext.ms_usergroups on p.GroupCode equals ug.Code
                                join ga in DBContext.ms_groupsassign on ug.Code equals ga.GroupCode
                                join u in DBContext.ms_users on ga.UserCode equals u.Code
                                where u.Code == UserSession.UserName
                                select new
                                {
                                    FunctionID = f.ID
                                };
                    dtResult = ToDataTable(query);
                    dtResult = null;
                }
            }
            catch (Exception ex)
            {
                dtResult = new DataTable();
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        #endregion Search Function InGroup belond UserName

        public int SelectData(out DataTable dtResult)
        {
            int returnCode = 0;
            try
            {
                //Do Something
                dtResult = null;
            }
            catch (Exception ex)
            {
                dtResult = new DataTable();
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }
    }
}