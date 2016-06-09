using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivs.Core.Web.Controllers;
using Ivs.Models.Master;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.BLL.Master;
using Ivs.BLL.Common;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;
using Ivs.Core.Web.Attributes;
using Ivs.Controls.CustomControls.Web.Components;
using Ivs.Core.Attributes;
//using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace WebApp.Controllers.Master
{
    [CustomAuthorize]
    [CustomHandleError]
    public class ItemController : BaseController, Ivs.Core.Interface.IController
    {
        #region Override properties

        protected override string FunctionGrp
        {
            get
            {
                return CommonData.FunctionGr.MS_Items;
            }
        }
        protected override Ivs.Core.Interface.IService Bl
        {
            get
            {
                return new MS_ItemBl();
            }
        }

        private MS_ItemModel _model = new MS_ItemModel();
        protected override IModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = (MS_ItemModel)value;
            }
        }

        protected override string PartialViewName
        {
            get
            {
                return "ItemPartial";
            }
        }

        #endregion

        #region Action

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(int? page)
        {
            return base.BaseIndex(page);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int? page, string sortColumn, string sortOrder, Ivs.Core.Interface.IModel model)
        {
            return base.BaseIndex(page, sortColumn, sortOrder, model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            return base.BaseAdd();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Ivs.Core.Interface.IModel model)
        {
            return base.BaseAdd(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Copy(int id)
        {
            return base.BaseCopy(id);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Copy(Ivs.Core.Interface.IModel model)
        {
            return base.BaseCopy(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            return base.BaseEdit(id);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ivs.Core.Interface.IModel model)
        {
            return base.BaseEdit(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(int id)
        {
            return base.BaseDetail(id);
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(List<int> lstId)
        {
            return base.BaseDelete(lstId);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Print()
        {
            return base.BasePrint();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ExportXls()
        {
            return base.BaseExportXls();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ExportXlsx()
        {
            return base.BaseExportXlsx();
        }

        #endregion

        protected override void SetEditControlData()
        {
            base.SetEditControlData();

            //Load data for dropdownlist controls
            DataSelectList<MS_ItemGroupModel> lstItemGrp = new DataSelectList<MS_ItemGroupModel>(CommonData.FunctionGr.MS_ItemGroups);
            //lstItemGrp.SelectedValue = ((MS_ItemModel)this.Model).GroupCode;
            lstItemGrp.HasNull = false;
            ViewBag.GroupCodeList = lstItemGrp.FillData();

            DataSelectList<MS_UnitModel> lstInvUnitCode = new DataSelectList<MS_UnitModel>(CommonData.FunctionGr.MS_Units);
            //lstInvUnitCode.SelectedValue = ((MS_ItemModel)this.Model).InvUnitCode;
            lstInvUnitCode.HasNull = false;
            ViewBag.InvUnitCodeList = lstInvUnitCode.FillData();

            DataSelectList<MS_UnitModel> lstUnit = new DataSelectList<MS_UnitModel>(CommonData.FunctionGr.MS_Units);
            lstUnit.HasNull = true;
            ViewBag.Units = lstUnit.FillData();
        }

        protected override void SetSearchControlData()
        {
            base.SetSearchControlData();

            DataSelectList<MS_ItemGroupModel> lstItemGrp = new DataSelectList<MS_ItemGroupModel>(CommonData.FunctionGr.MS_ItemGroups);
            lstItemGrp.HasNull = true;
            //lstItemGrp.DisplayMode = DropDownDisplayMode.CodeName;
            MS_ItemModel model = (MS_ItemModel)this.Model;

            //Solution 1
            ViewBag.Model = model;

            //Solution 2
            if (model != null)
            {
                //Reset value to search condition controls
                ViewBag.Code = model.Code;
                ViewBag.Name1 = model.Name1;
                ViewBag.Name2 = model.Name2;
                //Load data for dropdownlist controls    
                lstItemGrp.SelectedValue = model.GroupCode;
            }
            ViewBag.GroupCodeList = lstItemGrp.FillData();
        }
    }
}
