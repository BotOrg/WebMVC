using AutoMapper;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.COMMON;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.ViewModel;
using WebMVC.ENTITIES.CrudModel;

namespace WebMVC.Areas.Admin.Controllers
{
    public class DMChuDeController : Controller
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMChuDe
        [HttpGet]
        public ActionResult Index(ViewModelDMChuDe SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMChuDe>(o => (SearchString.TenChuDe == null || o.TenChuDe.StartsWith(SearchString.TenChuDe)));
            var model = new List<DMChuDe>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMChuDe>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMChuDe());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMChuDe model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMChuDe _model = new DMChuDe();
                    COMMON.Helpers.CopyObject<DMChuDe>(model, ref _model);
                    _db.Insert<DMChuDe>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMChuDe");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm chủ đề  thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaChuDe)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMChuDe model = _db.GetOne<DMChuDe>(o => o.MaChuDe == MaChuDe);
            CrudModelDMChuDe _model = new CrudModelDMChuDe();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMChuDe>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMChuDe model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMChuDe _model = _db.GetOne<DMChuDe>(o => o.MaChuDe == model.MaChuDe);
                    COMMON.Helpers.CopyObject<DMChuDe>(model, ref _model);
                    _db.Update<DMChuDe>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật chủ đề  thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaChuDe)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMChuDe model = _db.GetOne<DMChuDe>(o => o.MaChuDe == MaChuDe);
            _db.DeleteItem<DMChuDe>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}