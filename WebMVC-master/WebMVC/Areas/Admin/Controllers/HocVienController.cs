using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.COMMON;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;
using WebMVC.ENTITIES.ViewModel;
using PagedList;

namespace WebMVC.Areas.Admin.Controllers
{
    public class HocVienController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/HocVien
        [HttpGet]
        public ActionResult Index(ViewModelHocVien SearchString, int? currentPage)

        {
            var entities = _db.Filter<HocVien>(o => (SearchString.TenHocVien == null || o.TenHocVien.StartsWith(SearchString.TenHocVien)));
            var model = new List<HocVien>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<HocVien>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            SearchString.lstDMGioiTinh = _db.GetAll<DMGioiTinh>();
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            initialCategoryEditAction();
            return View(new CrudModelHocVien());
        }

        [HttpPost]
        public ActionResult Create(CrudModelHocVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HocVien _model = new HocVien();
                    COMMON.Helpers.CopyObject<HocVien>(model, ref _model);
                    _db.Insert<HocVien>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "HocVien");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm học viên thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaHocVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            HocVien model = _db.GetOne<HocVien>(o => o.MaHocVien == MaHocVien);
            CrudModelHocVien _model = new CrudModelHocVien();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelHocVien>(model, ref _model);
            initialCategoryEditAction(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelHocVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HocVien _model = _db.GetOne<HocVien>(o => o.MaHocVien == model.MaHocVien);
                    COMMON.Helpers.CopyObject<HocVien>(model, ref _model);
                    _db.Update<HocVien>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật học viên thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaHocVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            HocVien model = _db.GetOne<HocVien>(o => o.MaHocVien == MaHocVien);
            _db.DeleteItem<HocVien>(model);

            return RedirectToAction("Index");
        }

        #endregion
        public void initialCategoryEditAction(CrudModelHocVien view)
        {
            ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh", view.MaGioiTinh);
        }
        public void initialCategoryEditAction()
        {
            ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh");
        }
    }
}