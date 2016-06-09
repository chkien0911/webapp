using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.Models.Master;
using System.Data;
using Ivs.Core.Interface;
using Ivs.Core.Data;

namespace Ivs.DAL.Dao.Master
{
    public class MS_ItemDao : BaseDao
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
        public int SelectData(MS_ItemModel selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            try
            {
                IQueryable<ms_items> query = this.ms_items.AsQueryable();

                #region Search Condition

                //Filter by Department Code
                if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                {
                    query = query.Where(d => d.Code.Contains(selectDto.Code));
                }

                //Filter by Department Name
                if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                {
                    query = query.Where(d => d.Name1.Contains(selectDto.Name1));
                }

                if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                {
                    query = query.Where(d => d.Name2.Contains(selectDto.Name2));
                }

                #endregion

                #region Search data

                var queryResult = from d in query
                                  select new MS_ItemModel
                                  {
                                      ID = d.ID,
                                      Code = d.Code,
                                      Name1 = d.Name1,
                                      Name2 = d.Name2,
                                  };

                dtResult = base.ToDataTable(queryResult);

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

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
        public int SelectData(MS_ItemModel selectDto, out List<IModel> lstResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            lstResult = new List<IModel>();
            try
            {
                var query = this.ms_items
                    .Join(this.ms_units, it => it.InvUnitCode, un => un.Code, (it, un) => new { Item = it, InvUnit = un })
                    .Join(this.ms_itemgrp, it => it.Item.GroupCode, un => un.Code, (it, un) => new { ItemUnit = it, Group = un })
                    .Select(x => new
                    {
                        ID = x.ItemUnit.Item.ID,
                        Code = x.ItemUnit.Item.Code,
                        Name1 = x.ItemUnit.Item.Name1,
                        Name2 = x.ItemUnit.Item.Name2,
                        Name3 = x.ItemUnit.Item.Name3,
                        GroupCode = x.Group.Code,
                        GroupName1 = x.Group.Name1,
                        GroupName2 = x.Group.Name2,
                        GroupName3 = x.Group.Name3,
                        InvUnitCode = x.ItemUnit.InvUnit.Code,
                        InvUnitName1 = x.ItemUnit.InvUnit.Name1,
                        InvUnitName2 = x.ItemUnit.InvUnit.Name2,
                    })
                    .AsQueryable();

                #region Search Condition

                //Filter by Department Code
                if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                {
                    query = query.Where(d => d.Code.Contains(selectDto.Code));
                }

                //Filter by Department Name
                if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                {
                    query = query.Where(d => d.Name1.Contains(selectDto.Name1));
                }

                if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                {
                    query = query.Where(d => d.Name2.Contains(selectDto.Name2));
                }

                if (!CommonMethod.IsNullOrEmpty(selectDto.GroupCode))
                {
                    query = query.Where(d => d.GroupCode.Contains(selectDto.GroupCode));
                }

                #endregion

                #region Search data

                lstResult = query.Select(ss => new MS_ItemModel
                {
                    ID = ss.ID,
                    Code = ss.Code,
                    Name1 = ss.Name1,
                    Name2 = ss.Name2,
                    GroupCode = ss.GroupCode,
                    GroupName = UserSession.LangId == CommonData.LanguageDB.VietNamese
                                ? ss.GroupName1
                                : UserSession.LangId == CommonData.LanguageDB.Japanese
                                    ? ss.GroupName3
                                    : ss.GroupName2,
                    InvUnitCode = ss.InvUnitCode,
                })
                    .ToList()
                    .Cast<IModel>()
                    .ToList();

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }


        public int SelectData(int id, out IModel modelResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            modelResult = null;
            try
            {
                modelResult = this.ms_items
                    .Select(ss => new MS_ItemModel
                    {
                        ID = ss.ID,
                        Code = ss.Code,
                        Name1 = ss.Name1,
                        Name2 = ss.Name2,
                        GroupCode = ss.GroupCode,
                        InvUnitCode = ss.InvUnitCode,
                        UnitConverts = this.ms_unitconvert.Where(un => un.ItemCode == ss.Code)
                                    .Select(x => new MS_UnitConvertModel
                                    {
                                        ID = x.ID,
                                        Factor = x.Factor,
                                        FromUnit = x.FromUnit,
                                        ToUnit = x.ToUnit,
                                        Remark = x.Remark,
                                    }),
                    })
                    .FirstOrDefault(ss => ss.ID == id);

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Insert new Department
        /// </summary>
        /// <param name="insertDto">
        /// Dto that contains all Department data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(MS_ItemModel insertDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                ms_items _departments = new ms_items();
                _departments.Code = insertDto.Code;
                _departments.Name1 = insertDto.Name1;
                _departments.Name2 = insertDto.Name2;
                _departments.GroupCode = insertDto.GroupCode;
                _departments.InvUnitCode = insertDto.InvUnitCode;
                //_departments.Insert_PIC = !CommonMethod.IsNullOrEmpty(insertDto.Insert_PIC) ? insertDto.Insert_PIC : string.Empty;

                //Create insert information
                //this.CreateInsertHistory(_departments, CommonData.FunctionGr.ms_items);

                //Add Factory
                this.ms_items.AddObject(_departments);

                //Save to database
                returnCode = this.Saves(CommonData.FunctionGr.MS_Items, CommonData.Action.Insert,
                         new
                         {
                             _departments.Code,
                             _departments.Name1,
                             _departments.Name2,
                             _departments.Name3,
                             _departments.Remark,

                         },
                         typeof(ms_items).Name);

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="updateDto">
        /// Dto that contains all Department data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(MS_ItemModel updateDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_items _departments = context.ms_items.FirstOrDefault(d => d.ID.Equals(updateDto.ID));
                    if (_departments != null)
                    {
                        _departments.Code = updateDto.Code;
                        _departments.Name1 = updateDto.Name1;
                        _departments.Name2 = updateDto.Name2;
                        _departments.GroupCode = updateDto.GroupCode;
                        _departments.InvUnitCode = updateDto.InvUnitCode;
                        //_departments.Insert_PIC = !CommonMethod.IsNullOrEmpty(updateDto.Insert_PIC) ? updateDto.Insert_PIC : string.Empty;
                        //_departments.Update_PIC = !CommonMethod.IsNullOrEmpty(updateDto.Update_PIC) ? updateDto.Update_PIC : string.Empty;

                        //Create insert information
                        this.CreateUpdateHistory(_departments, CommonData.FunctionGr.MS_Items);

                        //Save to database
                        returnCode = context.Saves(CommonData.FunctionGr.MS_Items, CommonData.Action.Update,
                        new
                        {
                            _departments.Code,
                            _departments.Name1,
                            _departments.Name2,
                            _departments.Name3,
                            _departments.Remark,

                        },
                        typeof(ms_items).Name);
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

        /// <summary>
        /// Delete Department list
        /// </summary>
        /// <param name="listDeleteData">
        /// List that contains Department ID
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<int> listDeleteData)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            List<object> lstHis = new List<object>();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    foreach (int id in listDeleteData)
                    {
                        ms_items _departments = context.ms_items.FirstOrDefault(d => d.ID.Equals(id));
                        if (_departments != null)
                        {
                            //Delete object
                            context.ms_items.DeleteObject(_departments);
                            lstHis.Add(new
                            {
                                _departments.Code,
                                _departments.Name1,
                                _departments.Name2,
                                _departments.Name3,
                                _departments.Remark,
                            });
                        }
                        else
                        {
                            return CommonData.DbReturnCode.DataNotFound;
                        }
                    }

                    //returnCode = context.Saves();
                    returnCode = context.Saves(CommonData.FunctionGr.MS_Items, CommonData.Action.Delete, lstHis, typeof(ms_items).Name);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int SelectItemGrpData(out List<MS_ItemGroupModel> lstResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            lstResult = new List<MS_ItemGroupModel>();
            try
            {
                IQueryable<ms_itemgrp> query = this.ms_itemgrp.AsQueryable();

                #region Search data

                lstResult = query.Select(ss => new MS_ItemGroupModel
                {
                    ID = ss.ID,
                    Code = ss.Code,
                    Name1 = ss.Name1,
                    Name2 = ss.Name2,
                    Name3 = ss.Name3,
                })
                    .ToList();

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int SelectInvUnitData(out List<MS_ItemGroupModel> lstResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            lstResult = new List<MS_ItemGroupModel>();
            try
            {
                IQueryable<ms_units> query = this.ms_units.AsQueryable();

                #region Search data

                lstResult = query.Select(ss => new MS_ItemGroupModel
                {
                    ID = ss.ID,
                    Code = ss.Code,
                    Name1 = ss.Name1,
                    Name2 = ss.Name2,
                    Name3 = ss.Name3,
                })
                    .ToList();

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }
    }
}
