﻿using Apps.BLL;
using Apps.BLL.Core;
using Apps.Common;
using Apps.Flow.IBLL;
using Apps.Flow.IDAL;
using Apps.Models;
using Apps.Models.Flow;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Apps.Flow.BLL
{
    public class Flow_FormContentBLL : BaseBLL, IFlow_FormContentBLL
    {
        [Dependency]
        public IFlow_FormContentRepository m_Rep { get; set; }

        public List<Flow_FormContentModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<Flow_FormContent> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Title.Contains(queryStr) || a.AttrA.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<Flow_FormContentModel> CreateModelList(ref IQueryable<Flow_FormContent> queryData)
        {
            List<Flow_FormContentModel> modelList = (from r in queryData
                                                     select new Flow_FormContentModel
                                                     {
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
                                                         CreateTime = r.CreateTime,
                                                         CustomMember = r.CustomMember,
                                                         FormId = r.FormId,
                                                         FormLevel = r.FormLevel,
                                                         Id = r.Id,
                                                         TimeOut = r.TimeOut,
                                                         Title = r.Title,
                                                         UserId = r.UserId
                                                     }).ToList();
            return modelList;
        }
        public bool Create(ref ValidationErrors errors, Flow_FormContentModel model)
        {
            try
            {
                Flow_FormContent entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new Flow_FormContent();
                entity.AttrA = model.AttrA;
                entity.AttrB = model.AttrB;
                entity.AttrC = model.AttrC;
                entity.AttrD = model.AttrD;
                entity.AttrE = model.AttrE;
                entity.AttrF = model.AttrF;
                entity.AttrG = model.AttrG;
                entity.AttrH = model.AttrH;
                entity.AttrI = model.AttrI;
                entity.AttrJ = model.AttrJ;
                entity.AttrK = model.AttrK;
                entity.AttrL = model.AttrL;
                entity.AttrM = model.AttrM;
                entity.AttrN = model.AttrN;
                entity.AttrO = model.AttrO;
                entity.AttrP = model.AttrP;
                entity.AttrQ = model.AttrQ;
                entity.AttrR = model.AttrR;
                entity.AttrS = model.AttrS;
                entity.AttrT = model.AttrT;
                entity.AttrU = model.AttrU;
                entity.AttrV = model.AttrV;
                entity.AttrW = model.AttrW;
                entity.AttrX = model.AttrX;
                entity.AttrY = model.AttrY;
                entity.AttrZ = model.AttrZ;
                entity.CreateTime = model.CreateTime;
                entity.CustomMember = model.CustomMember;
                entity.FormId = model.FormId;
                entity.FormLevel = model.FormLevel;
                entity.Id = model.Id;
                entity.TimeOut = model.TimeOut;
                entity.Title = model.Title;
                entity.UserId = model.UserId;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Edit(ref ValidationErrors errors, Flow_FormContentModel model)
        {
            try
            {
                Flow_FormContent entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.AttrA = model.AttrA;
                entity.AttrB = model.AttrB;
                entity.AttrC = model.AttrC;
                entity.AttrD = model.AttrD;
                entity.AttrE = model.AttrE;
                entity.AttrF = model.AttrF;
                entity.AttrG = model.AttrG;
                entity.AttrH = model.AttrH;
                entity.AttrI = model.AttrI;
                entity.AttrJ = model.AttrJ;
                entity.AttrK = model.AttrK;
                entity.AttrL = model.AttrL;
                entity.AttrM = model.AttrM;
                entity.AttrN = model.AttrN;
                entity.AttrO = model.AttrO;
                entity.AttrP = model.AttrP;
                entity.AttrQ = model.AttrQ;
                entity.AttrR = model.AttrR;
                entity.AttrS = model.AttrS;
                entity.AttrT = model.AttrT;
                entity.AttrU = model.AttrU;
                entity.AttrV = model.AttrV;
                entity.AttrW = model.AttrW;
                entity.AttrX = model.AttrX;
                entity.AttrY = model.AttrY;
                entity.AttrZ = model.AttrZ;
                entity.CreateTime = model.CreateTime;
                entity.CustomMember = model.CustomMember;
                entity.FormId = model.FormId;
                entity.FormLevel = model.FormLevel;
                entity.Id = model.Id;
                entity.TimeOut = model.TimeOut;
                entity.Title = model.Title;
                entity.UserId = model.UserId;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        public bool IsExists(string id)
        {
            if (db.Flow_FormContent.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        public Flow_FormContentModel GetById(string id)
        {
            if (IsExist(id))
            {
                Flow_FormContent entity = m_Rep.GetById(id);
                Flow_FormContentModel model = new Flow_FormContentModel();
                model.AttrA = entity.AttrA;
                model.AttrB = entity.AttrB;
                model.AttrC = entity.AttrC;
                model.AttrD = entity.AttrD;
                model.AttrE = entity.AttrE;
                model.AttrF = entity.AttrF;
                model.AttrG = entity.AttrG;
                model.AttrH = entity.AttrH;
                model.AttrI = entity.AttrI;
                model.AttrJ = entity.AttrJ;
                model.AttrK = entity.AttrK;
                model.AttrL = entity.AttrL;
                model.AttrM = entity.AttrM;
                model.AttrN = entity.AttrN;
                model.AttrO = entity.AttrO;
                model.AttrP = entity.AttrP;
                model.AttrQ = entity.AttrQ;
                model.AttrR = entity.AttrR;
                model.AttrS = entity.AttrS;
                model.AttrT = entity.AttrT;
                model.AttrU = entity.AttrU;
                model.AttrV = entity.AttrV;
                model.AttrW = entity.AttrW;
                model.AttrX = entity.AttrX;
                model.AttrY = entity.AttrY;
                model.AttrZ = entity.AttrZ;
                model.CreateTime = entity.CreateTime;
                model.CustomMember = entity.CustomMember;
                model.FormId = entity.FormId;
                model.FormLevel = entity.FormLevel;
                model.Id = entity.Id;
                model.TimeOut = entity.TimeOut;
                model.Title = entity.Title;
                model.UserId = entity.UserId;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }

        public List<Flow_FormContentModel> GetListByUserId(ref GridPager pager, string queryStr, string userId)
        {
            IQueryable<Flow_FormContent> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.UserId == userId && a.Title.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db).Where(a => a.UserId == userId);
            }

            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
    }
}
