using System;
using System.Collections.Generic;
using System.Data;
using Ivs.DAL.Dao.Systems;
using Ivs.DTO.Systems;
using Ivs.Core.Interface;

namespace Ivs.BLL.Systems
{
    public class SYS_GroupsAssignBl : Ivs.Core.Interface.IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region IBl Members

        public int SearchData(Core.Interface.IDto searchDto, out DataTable dtResult)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(Core.Interface.IDto updateDto)
        {
            throw new NotImplementedException();
        }

        public int InsertData(Core.Interface.IDto insertDto)
        {
            throw new NotImplementedException();
        }

        public int DeleteData(List<Core.Interface.IDto> listDto)
        {
            throw new NotImplementedException();
        }

        #endregion IBl Members

        #region Group Assign Business functions

        public IEnumerable<SYS_GroupsAssignDto> GetGroupAssignByGroupCode(string groupCode)
        {
            return new SYS_GroupsAssignDao().GetGroupAssignByGroupCode(groupCode);
        }

        #endregion Group Assign Business functions
    }
}