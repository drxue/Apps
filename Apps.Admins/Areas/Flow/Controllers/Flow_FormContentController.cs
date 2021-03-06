﻿using Apps.Admins.Core;
using Apps.Common;
using Apps.Flow.IBLL;
using Apps.Models.Flow;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apps.Admins.Areas.Flow.Controllers
{
    public class Flow_FormContentController : BaseController
    {
        [Dependency]
        public IFlow_FormContentBLL m_BLL { get; set; }
        ValidationErrors errors = new ValidationErrors();
        // GET: Flow/Flow_FormContent
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<Flow_FormContentModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new Flow_FormContentModel()
                        {

                            Id = r.Id,
                            Title = r.Title,
                            UserId = r.UserId,
                            FormId = r.FormId,
                            FormLevel = r.FormLevel,
                            CreateTime = r.CreateTime,
                            AttrA = r.AttrA,
                            AttrB = r.AttrB,
                            AttrC = r.AttrC,
                            AttrD = r.AttrD,
                            AttrE = r.AttrE,
                            AttrF = r.AttrF,
                            AttrG = r.AttrG,
                            AttrH = r.AttrH,
                            AttrI = r.AttrI,
                            AttrJ = r.AttrJ,
                            AttrK = r.AttrK,
                            AttrL = r.AttrL,
                            AttrM = r.AttrM,
                            AttrN = r.AttrN,
                            AttrO = r.AttrO,
                            AttrP = r.AttrP,
                            AttrQ = r.AttrQ,
                            AttrR = r.AttrR,
                            AttrS = r.AttrS,
                            AttrT = r.AttrT,
                            AttrU = r.AttrU,
                            AttrV = r.AttrV,
                            AttrW = r.AttrW,
                            AttrX = r.AttrX,
                            AttrY = r.AttrY,
                            AttrZ = r.AttrZ,
                            CustomMember = r.CustomMember,
                            TimeOut = r.TimeOut

                        }).ToArray()

            };

            return Json(json);
        }
        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(Flow_FormContentModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Title" + model.Title, "成功", "创建", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Title" + model.Title + "," + ErrorCol, "失败", "创建", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            Flow_FormContentModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(Flow_FormContentModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Title" + model.Title, "成功", "修改", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Title" + model.Title + "," + ErrorCol, "失败", "修改", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion
        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            Flow_FormContentModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion
        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "Flow_FormContent");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion
    }
}