using System.Collections.Generic;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Systems;
using Ivs.DTO.Systems;
using Ivs.DAL.Dao.Common;

namespace Ivs.BLL.Systems
{
    public class SYS_UserListBLL : Ivs.Core.Interface.IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region IBl Members

        public int SearchData(Ivs.Core.Interface.IDto selectDto, out System.Data.DataTable dtResult)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            SYS_UserDetailDTO dto = (SYS_UserDetailDTO)selectDto;
            return _UserDAO.SelectData(dto, out dtResult);
        }

        public int InsertData(Ivs.Core.Interface.IDto insertDto)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            SYS_UserDetailDTO dto = (SYS_UserDetailDTO)insertDto;

            return _UserDAO.InsertData(dto);
        }

        public int UpdateData(Ivs.Core.Interface.IDto updateDto)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            SYS_UserDetailDTO dto = (SYS_UserDetailDTO)updateDto;

            return _UserDAO.UpdateData(dto);
        }

        public int DeleteData(List<IDto> listDto)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            List<SYS_UserDetailDTO> listDeleteData = new List<SYS_UserDetailDTO>();

            return _UserDAO.DeleteData(listDto);
        }

        public int SelectGroupbyUser(string userCode, out IList<SYS_UserGroupDTO> GroupDto)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            return _UserDAO.SelectGroupbyUser(userCode, out GroupDto);
        }

        public bool IsExistProfile(string code, string profile)
        {
            SYS_UserDAO _UserDAO = new SYS_UserDAO();
            return _UserDAO.IsExistProfile(code, profile);
        }

        public SYS_UserDetailDTO GetUserInfo(string userCode)
        {
            return new SYS_UserDAO().GetUserInfo(userCode);
        }
        #endregion IBl Members
    }
}