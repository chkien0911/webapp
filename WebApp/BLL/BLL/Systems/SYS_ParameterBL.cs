using System;
using System.Collections.Generic;
using System.Data;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Master;
using Ivs.DTO.Master;
using Ivs.DTO.Systems;

namespace Ivs.BLL.Systems
{
    public class SYS_ParameterBL : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        public int SearchData(IDto selectDto, out System.Data.DataTable dtResult)
        {
            //Do Something
            dtResult = null;
            return 0;
        }

        public int InsertData(IDto insertDto)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(IDto updateDto)
        {
            SYS_ParameterDao dao = new SYS_ParameterDao();
            SYS_ParameterDto dto = (SYS_ParameterDto)updateDto;
            ConvertDataDto(ref dto);
            return dao.UpdateData(dto);
        }

        private void ConvertDataDto(ref SYS_ParameterDto dto)
        {
            List<SYS_AdditionalDto> additionals = dto.Additional;

            foreach (var item in dto.Additional)
            {
                string ItemAdditionalIsRequired = item.Required == true ? CommonData.Status.Enable : CommonData.Status.Disable;
                string ItemAdditionalIsActive = item.Active == true ? CommonData.Status.Enable : CommonData.Status.Disable;
                if (item == null)
                {
                    continue;
                }
                switch (item.ItemAdditionalRowIndex)
                {
                    case 1:
                        {
                            dto.ItemAdditional1 = item.ItemAdditionalVN;
                            dto.ItemAdditional1EN = item.ItemAdditionalEN;
                            dto.ItemAdditional1JP = item.ItemAdditionalJP;

                            dto.ItemAdditionalIsRequired1 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive1 = ItemAdditionalIsActive;
                            break;
                        }
                    case 2:
                        {
                            dto.ItemAdditional2 = item.ItemAdditionalVN;
                            dto.ItemAdditional2EN = item.ItemAdditionalEN;
                            dto.ItemAdditional2JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired2 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive2 = ItemAdditionalIsActive;
                            break;
                        }
                    case 3:
                        {
                            dto.ItemAdditional3 = item.ItemAdditionalVN;
                            dto.ItemAdditional3EN = item.ItemAdditionalEN;
                            dto.ItemAdditional3JP = item.ItemAdditionalJP;

                            dto.ItemAdditionalIsRequired3 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive3 = ItemAdditionalIsActive;
                            break;
                        }
                    case 4:
                        {
                            dto.ItemAdditional4 = item.ItemAdditionalVN;
                            dto.ItemAdditional4EN = item.ItemAdditionalEN;
                            dto.ItemAdditional4JP = item.ItemAdditionalJP;

                            dto.ItemAdditionalIsRequired4 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive4 = ItemAdditionalIsActive;
                            break;
                        }
                    case 5:
                        {
                            dto.ItemAdditional5 = item.ItemAdditionalVN;
                            dto.ItemAdditional5EN = item.ItemAdditionalEN;
                            dto.ItemAdditional5JP = item.ItemAdditionalJP;

                            dto.ItemAdditionalIsRequired5 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive5 = ItemAdditionalIsActive;
                            break;
                        }
                    case 6:
                        {
                            dto.ItemAdditional6 = item.ItemAdditionalVN;
                            dto.ItemAdditional6EN = item.ItemAdditionalEN;
                            dto.ItemAdditional6JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired6 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive6 = ItemAdditionalIsActive;
                            break;
                        }
                    case 7:
                        {
                            dto.ItemAdditional7 = item.ItemAdditionalVN;
                            dto.ItemAdditional7EN = item.ItemAdditionalEN;
                            dto.ItemAdditional7JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired7 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive7 = ItemAdditionalIsActive;
                            break;
                        }
                    case 8:
                        {
                            dto.ItemAdditional8 = item.ItemAdditionalVN;
                            dto.ItemAdditional8EN = item.ItemAdditionalEN;
                            dto.ItemAdditional8JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired8 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive8 = ItemAdditionalIsActive;
                            break;
                        }
                    case 9:
                        {
                            dto.ItemAdditional9 = item.ItemAdditionalVN;
                            dto.ItemAdditional9EN = item.ItemAdditionalEN;
                            dto.ItemAdditional9JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired9 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive9 = ItemAdditionalIsActive;
                            break;
                        }
                    case 10:
                        {
                            dto.ItemAdditional10 = item.ItemAdditionalVN;
                            dto.ItemAdditional10EN = item.ItemAdditionalEN;
                            dto.ItemAdditional10JP = item.ItemAdditionalJP;
                            dto.ItemAdditionalIsRequired10 = ItemAdditionalIsRequired;
                            dto.ItemAdditionalIsActive10 = ItemAdditionalIsActive;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public int DeleteData(List<IDto> listDeleteData)
        {
            //Do Something
            return 0;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int GetParemeterData(out SYS_ParameterDto dto)
        {
            SYS_ParameterDao dao = new SYS_ParameterDao();
            return dao.GetParameterData(out dto);
        }

        public int GetParameterInfo(out DataTable dtParameter)
        {
            SYS_ParameterDao dao = new SYS_ParameterDao();
            return dao.GetParameterData(out dtParameter);
        }
    }
}