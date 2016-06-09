using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DAL.EFModels;
using Ivs.DTO.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_ChangePasswordDao : BaseDao
    {
        public int SearchData(IDto userDto, out DataTable dtResult)
        {
            int returnCode = 0;
            try
            {
                SYS_ChangePasswordDto dto = (SYS_ChangePasswordDto)userDto;
                var mUser = this.ms_users.Where(m => m.Code == dto.UserCode && m.Password == dto.PasswordCurrent);
                dtResult = ToDataTable(mUser);
            }
            catch (System.Exception ex)
            {
                dtResult = new DataTable();
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int UpdatePassword(IDto userDto)
        {
            int returnCode = 0;

            try
            {
                SYS_ChangePasswordDto dto = (SYS_ChangePasswordDto)userDto;
                var mUser = this.ms_users.FirstOrDefault(m => m.Code == dto.UserCode && m.Password == dto.PasswordCurrent);
                if (mUser != null)
                {
                    mUser.Password = dto.PasswordNew;
                    this.Saves(CommonData.FunctionGr.SY_ChangePassword, CommonData.Action.Update,
                        new { mUser.Code, dto.PasswordCurrent, dto.PasswordNew },
                        typeof(ms_users).Name);
                }
                else
                {
                    returnCode = 9;
                }
            }
            catch (System.Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }
    }
}