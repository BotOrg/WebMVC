using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.COMMON;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;
using WebMVC.ENTITIES.ViewModel;

namespace WebMVC.Areas.Admin.Controllers
{
    public class DMChuDeBaiVietController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMChuDeBaiViet
        [HttpGet]
        public ActionResult Index(ViewModelDMChuDeBaiViet SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMChuDeBaiViet>(o => (SearchString.TenChuDeBaiViet == null || o.TenChuDeBaiViet.StartsWith(SearchString.TenChuDeBaiViet)));
            var model = new List<DMChuDeBaiViet>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMChuDeBaiViet>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMChuDeBaiViet());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMChuDeBaiViet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMChuDeBaiViet _model = new DMChuDeBaiViet();
                    COMMON.Helpers.CopyObject<DMChuDeBaiViet>(model, ref _model);
                    _db.Insert<DMChuDeBaiViet>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMChuDeBaiViet");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm chủ đề bài viết thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaDMChuDeBaiViet)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMChuDeBaiViet model = _db.GetOne<DMChuDeBaiViet>(o => o.MaChuDeBaiViet == MaDMChuDeBaiViet);
            CrudModelDMChuDeBaiViet _model = new CrudModelDMChuDeBaiViet();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMChuDeBaiViet>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMChuDeBaiViet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMChuDeBaiViet _model = _db.GetOne<DMChuDeBaiViet>(o => o.MaChuDeBaiViet == model.MaChuDeBaiViet);
                    COMMON.Helpers.CopyObject<DMChuDeBaiViet>(model, ref _model);
                    _db.Update<DMChuDeBaiViet>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật chủ đề bài viết thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaChuDeBaiViet)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMChuDeBaiViet model = _db.GetOne<DMChuDeBaiViet>(o => o.MaChuDeBaiViet == MaChuDeBaiViet);
            _db.DeleteItem<DMChuDeBaiViet>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}