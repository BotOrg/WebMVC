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
    public class KhoaHocController : Controller
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/KhoaHoc
        [HttpGet]
        public ActionResult Index(ViewModelKhoaHoc SearchString, int? currentPage)

        {
            var entities = _db.Filter<KhoaHoc>(o => (SearchString.TenKhoaHoc == null || o.TenKhoaHoc.StartsWith(SearchString.TenKhoaHoc)));
            var model = new List<KhoaHoc>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<KhoaHoc>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            //SearchString.lstDMGioiTinh = _db.GetAll<DMGioiTinh>();
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            initialCategoryEditAction();
            return View(new CrudModelKhoaHoc());
        }

        [HttpPost]
        public ActionResult Create(CrudModelKhoaHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    KhoaHoc _model = new KhoaHoc();
                    COMMON.Helpers.CopyObject<KhoaHoc>(model, ref _model);
                    _db.Insert<KhoaHoc>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "KhoaHoc");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm khóa học thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaKhoaHoc)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            KhoaHoc model = _db.GetOne<KhoaHoc>(o => o.MaKhoaHoc == MaKhoaHoc);
            CrudModelKhoaHoc _model = new CrudModelKhoaHoc();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelKhoaHoc>(model, ref _model);
            initialCategoryEditAction(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelKhoaHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    KhoaHoc _model = _db.GetOne<KhoaHoc>(o => o.MaKhoaHoc == model.MaKhoaHoc);
                    COMMON.Helpers.CopyObject<KhoaHoc>(model, ref _model);
                    _db.Update<KhoaHoc>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaKhoaHoc)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            KhoaHoc model = _db.GetOne<KhoaHoc>(o => o.MaKhoaHoc == MaKhoaHoc);
            _db.DeleteItem<KhoaHoc>(model);

            return RedirectToAction("Index");
        }

        #endregion

        public void initialCategoryEditAction(CrudModelKhoaHoc view)
        {
            //ViewBag.lstQuyenQuanTri = new SelectList(_db.Filter<DMQuyenQuanTri>(x => x.MaQuyenQuanTri == view.MaQuyenQuanTri), "MaQuyenQuanTri", "TenQuyenQuanTri");
            //ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh", view.ma);
        }
        public void initialCategoryEditAction()
        {
            //ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh");
        }
    }
}