using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Common;
using Ivs.DTO.Common;

namespace Ivs.BLL.Common
{
    public class LoginBl
    {
        public int CheckLogin(IDto loginDto, out int iResult, out string employeeCode, out string displayName, out string skin)
        {
            LoginDao loginDao = new LoginDao();
            LoginDto dto = (LoginDto)loginDto;
            dto.Password = UserSession.Md5(dto.Password);
            return loginDao.CheckExistData(dto, out iResult, out employeeCode, out displayName, out skin);
        }
        //public int CheckLogin(IDto loginDto, out int iResult, out string employeeCode, out string displayName)
        //{
        //    LoginDao loginDao = new LoginDao();
        //    LoginDto dto = (LoginDto)loginDto;
        //    dto.Password = UserSession.Md5(dto.Password);
        //    return loginDao.CheckExistData(dto, out iResult, out employeeCode, out displayName);
        //}
        public int CheckExistDataHaveIPAdd(IDto loginDto, out int iResult, out string employeeCode, out string displayName,out string ipAddress, out string computerName)
        {
            LoginDao loginDao = new LoginDao();
            LoginDto dto = (LoginDto)loginDto;
            dto.Password = UserSession.Md5(dto.Password);
            return loginDao.CheckExistDataHaveIPAdd(dto, out iResult, out employeeCode, out displayName, out ipAddress, out computerName);
        }

        public int CheckExistDataHaveIPAdd(IDto loginDto, out int iResult, out string message)
        {
            LoginDao loginDao = new LoginDao();
            LoginDto dto = (LoginDto)loginDto;
            return loginDao.CheckExistDataHaveIPAdd(dto, out iResult, out message);
        }

        public int UpdateDataLogin(IDto updateDto)
        {
            LoginDao loginDao = new LoginDao();
            LoginDto dto = (LoginDto)updateDto;
            //{ 
            //     Code = UserSession.UserCode ,
            //     Password = (UserSession.Pw),
            //     ComputerName = UserSession.ComputerName,
            //     IPAddress = UserSession.IPAddress,
            //     LangId = UserSession.LangId
            //};
            return loginDao.UpdateDataLogin(dto);
        }

        public int CheckMessage(LoginDto loginDto, out string message)
        {
            LoginDao loginDao = new LoginDao();
            LoginDto dto = (LoginDto)loginDto;
            //dto.Password = UserSession.Md5(dto.Password);
            return loginDao.CheckMessage(dto, out message);
        }
    }
}