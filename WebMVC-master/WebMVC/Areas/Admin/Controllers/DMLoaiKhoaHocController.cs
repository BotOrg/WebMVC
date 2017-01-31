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
    public class DMLoaiKhoaHocController : Controller
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMLoaiKhoaHoc
        [HttpGet]
        public ActionResult Index(ViewModelDMLoaiKhoaHoc SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMLoaiKhoaHoc>(o => (SearchString.TenLoaiKhoaHoc == null || o.TenLoaiKhoaHoc.StartsWith(SearchString.TenLoaiKhoaHoc)));
            var model = new List<DMLoaiKhoaHoc>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMLoaiKhoaHoc>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMLoaiKhoaHoc());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMLoaiKhoaHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMLoaiKhoaHoc _model = new DMLoaiKhoaHoc();
                    COMMON.Helpers.CopyObject<DMLoaiKhoaHoc>(model, ref _model);
                    _db.Insert<DMLoaiKhoaHoc>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMLoaiKhoaHoc");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm loại khóa học thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaLoaiKhoaHoc)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMLoaiKhoaHoc model = _db.GetOne<DMLoaiKhoaHoc>(o => o.MaLoaiKhoaHoc == MaLoaiKhoaHoc);
            CrudModelDMLoaiKhoaHoc _model = new CrudModelDMLoaiKhoaHoc();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMLoaiKhoaHoc>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMLoaiKhoaHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMLoaiKhoaHoc _model = _db.GetOne<DMLoaiKhoaHoc>(o => o.MaLoaiKhoaHoc == model.MaLoaiKhoaHoc);
                    COMMON.Helpers.CopyObject<DMLoaiKhoaHoc>(model, ref _model);
                    _db.Update<DMLoaiKhoaHoc>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật loại khóa học thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaLoaiKhoaHoc)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMLoaiKhoaHoc model = _db.GetOne<DMLoaiKhoaHoc>(o => o.MaLoaiKhoaHoc == MaLoaiKhoaHoc);
            _db.DeleteItem<DMLoaiKhoaHoc>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}