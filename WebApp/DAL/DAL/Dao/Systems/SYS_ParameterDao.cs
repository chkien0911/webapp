using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DAL.EFModels;
using Ivs.DTO.Master;

namespace Ivs.DAL.Dao.Master
{
    public class SYS_ParameterDao : BaseDao
    {

        /// <summary>
        /// Search Data in ms_item table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), GroupCode
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_item table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int GetParameterData(out SYS_ParameterDto dto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dto = new SYS_ParameterDto();
            try
            {
                IQueryable<sy_parameters> query = this.sy_parameters.AsQueryable();

                #region Search Condition

                #endregion Search Condition

                #region Search data

                IEnumerable<SYS_ParameterDto> lstResult = query.Select(i => new SYS_ParameterDto
                                  {
                                      Id = i.ID,
                                      InitailPWChangeRequied = i.InitailPWChangeRequied,
                                      PWChangeDays = i.PWChangeDays,
                                      PWTemplate = i.PWTemplate,

                                      ItemAdditionalIsActive1 = i.ItemAdditionalIsActive1,
                                      ItemAdditionalIsActive2 = i.ItemAdditionalIsActive2,
                                      ItemAdditionalIsActive3 = i.ItemAdditionalIsActive3,
                                      ItemAdditionalIsActive4 = i.ItemAdditionalIsActive4,
                                      ItemAdditionalIsActive5 = i.ItemAdditionalIsActive5,
                                      ItemAdditionalIsActive6 = i.ItemAdditionalIsActive6,
                                      ItemAdditionalIsActive7 = i.ItemAdditionalIsActive7,
                                      ItemAdditionalIsActive8 = i.ItemAdditionalIsActive8,
                                      ItemAdditionalIsActive9 = i.ItemAdditionalIsActive9,
                                      ItemAdditionalIsActive10 = i.ItemAdditionalIsActive10,

                                      ItemAdditionalIsRequired1 = i.ItemAdditionalIsRequired1,
                                      ItemAdditionalIsRequired2 = i.ItemAdditionalIsRequired2,
                                      ItemAdditionalIsRequired3 = i.ItemAdditionalIsRequired3,
                                      ItemAdditionalIsRequired4 = i.ItemAdditionalIsRequired4,
                                      ItemAdditionalIsRequired5 = i.ItemAdditionalIsRequired5,
                                      ItemAdditionalIsRequired6 = i.ItemAdditionalIsRequired6,
                                      ItemAdditionalIsRequired7 = i.ItemAdditionalIsRequired7,
                                      ItemAdditionalIsRequired8 = i.ItemAdditionalIsRequired8,
                                      ItemAdditionalIsRequired9 = i.ItemAdditionalIsRequired9,
                                      ItemAdditionalIsRequired10 = i.ItemAdditionalIsRequired10,

                                      ItemAdditional1 = i.ItemAdditional1,
                                      ItemAdditional2 = i.ItemAdditional2,
                                      ItemAdditional3 = i.ItemAdditional3,
                                      ItemAdditional4 = i.ItemAdditional4,
                                      ItemAdditional5 = i.ItemAdditional5,
                                      ItemAdditional6 = i.ItemAdditional6,
                                      ItemAdditional7 = i.ItemAdditional7,
                                      ItemAdditional8 = i.ItemAdditional8,
                                      ItemAdditional9 = i.ItemAdditional9,
                                      ItemAdditional10 = i.ItemAdditional10,

                                      ItemAdditional1EN = i.ItemAdditional1EN,
                                      ItemAdditional2EN = i.ItemAdditional2EN,
                                      ItemAdditional3EN = i.ItemAdditional3EN,
                                      ItemAdditional4EN = i.ItemAdditional4EN,
                                      ItemAdditional5EN = i.ItemAdditional5EN,
                                      ItemAdditional6EN = i.ItemAdditional6EN,
                                      ItemAdditional7EN = i.ItemAdditional7EN,
                                      ItemAdditional8EN = i.ItemAdditional8EN,
                                      ItemAdditional9EN = i.ItemAdditional9EN,
                                      ItemAdditional10EN = i.ItemAdditional10EN,

                                      ItemAdditional1JP = i.ItemAdditional1JP,
                                      ItemAdditional2JP = i.ItemAdditional2JP,
                                      ItemAdditional3JP = i.ItemAdditional3JP,
                                      ItemAdditional4JP = i.ItemAdditional4JP,
                                      ItemAdditional5JP = i.ItemAdditional5JP,
                                      ItemAdditional6JP = i.ItemAdditional6JP,
                                      ItemAdditional7JP = i.ItemAdditional7JP,
                                      ItemAdditional8JP = i.ItemAdditional8JP,
                                      ItemAdditional9JP = i.ItemAdditional9JP,
                                      ItemAdditional10JP = i.ItemAdditional10JP
                                  });

                if (lstResult.Count() > 0)
                {
                    dto = lstResult.First();
                }
                else
                {
                    dto = null;
                }

                #endregion Search data
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }


        public int GetParameterData(out DataTable dtParameter)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(SYS_ParameterDto updateDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    sy_parameters _parameters = context.sy_parameters.FirstOrDefault(p => p.ID.Equals(updateDto.Id));
                    if (_parameters != null)
                    {
                        //Create insert infomation

                        //ItemAdditional VN
                        _parameters.ItemAdditional1 = updateDto.ItemAdditional1;
                        _parameters.ItemAdditional2 = updateDto.ItemAdditional2;
                        _parameters.ItemAdditional3 = updateDto.ItemAdditional3;
                        _parameters.ItemAdditional4 = updateDto.ItemAdditional4;
                        _parameters.ItemAdditional5 = updateDto.ItemAdditional5;
                        _parameters.ItemAdditional6 = updateDto.ItemAdditional6;
                        _parameters.ItemAdditional7 = updateDto.ItemAdditional7;
                        _parameters.ItemAdditional8 = updateDto.ItemAdditional8;
                        _parameters.ItemAdditional9 = updateDto.ItemAdditional9;
                        _parameters.ItemAdditional10 = updateDto.ItemAdditional10;

                        //ItemAdditional EN
                        _parameters.ItemAdditional1EN = updateDto.ItemAdditional1EN;
                        _parameters.ItemAdditional2EN = updateDto.ItemAdditional2EN;
                        _parameters.ItemAdditional3EN = updateDto.ItemAdditional3EN;
                        _parameters.ItemAdditional4EN = updateDto.ItemAdditional4EN;
                        _parameters.ItemAdditional5EN = updateDto.ItemAdditional5EN;
                        _parameters.ItemAdditional6EN = updateDto.ItemAdditional6EN;
                        _parameters.ItemAdditional7EN = updateDto.ItemAdditional7EN;
                        _parameters.ItemAdditional8EN = updateDto.ItemAdditional8EN;
                        _parameters.ItemAdditional9EN = updateDto.ItemAdditional9EN;
                        _parameters.ItemAdditional10EN = updateDto.ItemAdditional10EN;

                        //ItemAdditional JP
                        _parameters.ItemAdditional1JP = updateDto.ItemAdditional1JP;
                        _parameters.ItemAdditional2JP = updateDto.ItemAdditional2JP;
                        _parameters.ItemAdditional3JP = updateDto.ItemAdditional3JP;
                        _parameters.ItemAdditional4JP = updateDto.ItemAdditional4JP;
                        _parameters.ItemAdditional5JP = updateDto.ItemAdditional5JP;
                        _parameters.ItemAdditional6JP = updateDto.ItemAdditional6JP;
                        _parameters.ItemAdditional7JP = updateDto.ItemAdditional7JP;
                        _parameters.ItemAdditional8JP = updateDto.ItemAdditional8JP;
                        _parameters.ItemAdditional9JP = updateDto.ItemAdditional9JP;
                        _parameters.ItemAdditional10JP = updateDto.ItemAdditional10JP;

                        //ItemAdditionalIsActive1
                        _parameters.ItemAdditionalIsActive1 = updateDto.ItemAdditionalIsActive1;
                        _parameters.ItemAdditionalIsActive2 = updateDto.ItemAdditionalIsActive2;
                        _parameters.ItemAdditionalIsActive3 = updateDto.ItemAdditionalIsActive3;
                        _parameters.ItemAdditionalIsActive4 = updateDto.ItemAdditionalIsActive4;
                        _parameters.ItemAdditionalIsActive5 = updateDto.ItemAdditionalIsActive5;
                        _parameters.ItemAdditionalIsActive6 = updateDto.ItemAdditionalIsActive6;
                        _parameters.ItemAdditionalIsActive7 = updateDto.ItemAdditionalIsActive7;
                        _parameters.ItemAdditionalIsActive8 = updateDto.ItemAdditionalIsActive8;
                        _parameters.ItemAdditionalIsActive9 = updateDto.ItemAdditionalIsActive8;
                        _parameters.ItemAdditionalIsActive10 = updateDto.ItemAdditionalIsActive10;

                        //ItemAdditionalIsRequired
                        _parameters.ItemAdditionalIsRequired1 = updateDto.ItemAdditionalIsRequired1;
                        _parameters.ItemAdditionalIsRequired2 = updateDto.ItemAdditionalIsRequired2;
                        _parameters.ItemAdditionalIsRequired3 = updateDto.ItemAdditionalIsRequired3;
                        _parameters.ItemAdditionalIsRequired4 = updateDto.ItemAdditionalIsRequired4;
                        _parameters.ItemAdditionalIsRequired5 = updateDto.ItemAdditionalIsRequired5;
                        _parameters.ItemAdditionalIsRequired6 = updateDto.ItemAdditionalIsRequired6;
                        _parameters.ItemAdditionalIsRequired7 = updateDto.ItemAdditionalIsRequired7;
                        _parameters.ItemAdditionalIsRequired8 = updateDto.ItemAdditionalIsRequired8;
                        _parameters.ItemAdditionalIsRequired9 = updateDto.ItemAdditionalIsRequired9;
                        _parameters.ItemAdditionalIsRequired10 = updateDto.ItemAdditionalIsRequired10;     
                 

                        //Acount Setting
                        _parameters.PWTemplate = updateDto.PWTemplate;
                        _parameters.PWChangeDays = updateDto.PWChangeDays;
                        _parameters.InitailPWChangeRequied = updateDto.InitailPWChangeRequied;    

                        //this.CreateUpdateHistory(_parameters, CommonData.FunctionGr.SY_Parameters);
                   
                        //Save to database
                        returnCode = context.Saves();
                    }
                    else
                    {
                        returnCode = CommonData.DbReturnCode.DataNotFound;
                    }
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int SelectSysAdditionalItem(out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            List<SYS_ParameterDto> lstResult = new List<SYS_ParameterDto>();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    var par = context.sy_parameters.FirstOrDefault();

                    SYS_ParameterDto addItem1 = new SYS_ParameterDto
                    {
                        ItemAdditional1 = par.ItemAdditional1,
                        ItemAdditional1EN = par.ItemAdditional1EN,
                        ItemAdditional1JP = par.ItemAdditional1JP,
                        ItemAdditionalIsActive1 = par.ItemAdditionalIsActive1,
                    };
                    lstResult.Add(addItem1);

                    SYS_ParameterDto addItem2 = new SYS_ParameterDto
                    {
                        ItemAdditional2 = par.ItemAdditional2,
                        ItemAdditional2EN = par.ItemAdditional2EN,
                        ItemAdditional2JP = par.ItemAdditional2JP,
                        ItemAdditionalIsActive2 = par.ItemAdditionalIsActive2,
                    };
                    lstResult.Add(addItem2);

                    SYS_ParameterDto addItem3 = new SYS_ParameterDto
                    {
                        ItemAdditional3 = par.ItemAdditional3,
                        ItemAdditional3EN = par.ItemAdditional3EN,
                        ItemAdditional3JP = par.ItemAdditional3JP,
                        ItemAdditionalIsActive3 = par.ItemAdditionalIsActive3,
                    };
                    lstResult.Add(addItem3);

                    SYS_ParameterDto addItem4 = new SYS_ParameterDto
                    {
                        ItemAdditional4 = par.ItemAdditional4,
                        ItemAdditional4EN = par.ItemAdditional4EN,
                        ItemAdditional4JP = par.ItemAdditional4JP,
                        ItemAdditionalIsActive4 = par.ItemAdditionalIsActive4,
                    };
                    lstResult.Add(addItem4);

                    SYS_ParameterDto addItem5 = new SYS_ParameterDto
                    {
                        ItemAdditional5 = par.ItemAdditional5,
                        ItemAdditional5EN = par.ItemAdditional5EN,
                        ItemAdditional5JP = par.ItemAdditional5JP,
                        ItemAdditionalIsActive5 = par.ItemAdditionalIsActive5,
                    };
                    lstResult.Add(addItem5);

                    SYS_ParameterDto addItem6 = new SYS_ParameterDto
                    {
                        ItemAdditional6 = par.ItemAdditional6,
                        ItemAdditional6EN = par.ItemAdditional6EN,
                        ItemAdditional6JP = par.ItemAdditional6JP,
                        ItemAdditionalIsActive6 = par.ItemAdditionalIsActive6,
                    };
                    lstResult.Add(addItem6);

                    SYS_ParameterDto addItem7 = new SYS_ParameterDto
                    {
                        ItemAdditional7 = par.ItemAdditional7,
                        ItemAdditional7EN = par.ItemAdditional7EN,
                        ItemAdditional7JP = par.ItemAdditional7JP,
                        ItemAdditionalIsActive7 = par.ItemAdditionalIsActive7,
                    };
                    lstResult.Add(addItem7);

                    SYS_ParameterDto addItem8 = new SYS_ParameterDto
                    {
                        ItemAdditional8 = par.ItemAdditional8,
                        ItemAdditional8EN = par.ItemAdditional8EN,
                        ItemAdditional8JP = par.ItemAdditional8JP,
                        ItemAdditionalIsActive8 = par.ItemAdditionalIsActive8,
                    };
                    lstResult.Add(addItem8);

                    SYS_ParameterDto addItem9 = new SYS_ParameterDto
                    {
                        ItemAdditional9 = par.ItemAdditional9,
                        ItemAdditional9EN = par.ItemAdditional9EN,
                        ItemAdditional9JP = par.ItemAdditional9JP,
                        ItemAdditionalIsActive9 = par.ItemAdditionalIsActive9,
                    };
                    lstResult.Add(addItem9);

                    SYS_ParameterDto addItem10 = new SYS_ParameterDto
                    {
                        ItemAdditional10 = par.ItemAdditional10,
                        ItemAdditional10EN = par.ItemAdditional10EN,
                        ItemAdditional10JP = par.ItemAdditional10JP,
                        ItemAdditionalIsActive10 = par.ItemAdditionalIsActive10,
                    };
                    lstResult.Add(addItem10);

                    dtResult = ToDataTable(lstResult);

                }
                catch (Exception ex)
                {
                    returnCode = ProcessDbException(ex);
                }
            }

            return returnCode;
        }
    }
}