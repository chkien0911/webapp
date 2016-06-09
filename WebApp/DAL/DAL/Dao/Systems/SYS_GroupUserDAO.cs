using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.DTO.Systems;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using System;

namespace Ivs.DAL.Dao.Sys
{
    public class SYS_GroupUserDAO : Ivs.DAL.Dao.BaseDao
    {
       
        public int SelectData(SYS_UserGroupDTO selectDto, out DataTable dtResult)
        {
            dtResult = new DataTable();
            return 0;
        }

        public IEnumerable<SYS_UserGroupDTO> GetAllUserGroups()
        {
            return new BaseDao().ms_usergroups.Select(c => new SYS_UserGroupDTO
            {
                ID = c.ID,
                Code = c.Code,
                Name1 = c.Name1,
                Name2 = c.Name2,
                Name3 = c.Name3,
                Description = c.Description
            });
        }

        public int InsertData(SYS_UserGroupDTO insertDto)
        {
            return 0;
        }

        public int UpdateData(SYS_UserGroupDTO updateDto)
        {
            return 0;
        }

        public int DeleteData(List<int> listDeleteData)
        {
            return 0;
        }
    }
}