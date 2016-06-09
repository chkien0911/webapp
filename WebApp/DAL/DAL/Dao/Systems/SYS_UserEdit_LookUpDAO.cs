using System;
using System.Data;
using System.Linq;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_UserEdit_LookUpDAO : BaseDao
    {
        public int SelectCbb(out System.Data.DataTable dtResult)
        {
            int returnCode = 0;
            try
            {
                var result = from ug in this.ms_usergroups
                             select new
                             {
                                 //get Group Code
                                 Code = ug.Code,
                                 //get Name1
                                 Name1 = ug.Name1,
                                 //get Name2
                                 Name2 = ug.Name2,
                                 //get Name3
                                 Name3 = ug.Name3
                             };
                dtResult = ToDataTable(result);
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