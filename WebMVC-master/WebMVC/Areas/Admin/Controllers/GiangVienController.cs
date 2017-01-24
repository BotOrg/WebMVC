using AutoMapper;
using PagedList;
using System;
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
    public class GiangVienController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/GiangVien
        [HttpGet]
        public ActionResult Index(ViewModelGiangVien SearchString, int? currentPage)

        {
            var entities = _db.Filter<GiangVien>(o => (SearchString.TenGiangVien == null || o.TenGiangVien.StartsWith(SearchString.TenGiangVien)));
            var model = new List<GiangVien>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<GiangVien>(currentEntity));
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
            return View(new CrudModelGiangVien());
        }

        [HttpPost]
        public ActionResult Create(CrudModelGiangVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GiangVien _model = new GiangVien();
                    COMMON.Helpers.CopyObject<GiangVien>(model, ref _model);
                    _db.Insert<GiangVien>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "GiangVien");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm quản trị viên thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaGiangVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            GiangVien model = _db.GetOne<GiangVien>(o => o.MaGiangVien == MaGiangVien);
            CrudModelGiangVien _model = new CrudModelGiangVien();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelGiangVien>(model, ref _model);
            initialCategoryEditAction(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelGiangVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GiangVien _model = _db.GetOne<GiangVien>(o => o.MaGiangVien == model.MaGiangVien);
                    COMMON.Helpers.CopyObject<GiangVien>(model, ref _model);
                    _db.Update<GiangVien>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật quản trị viên thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaGiangVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            GiangVien model = _db.GetOne<GiangVien>(o => o.MaGiangVien == MaGiangVien);
            _db.DeleteItem<GiangVien>(model);

            return RedirectToAction("Index");
        }

        #endregion

        public void initialCategoryEditAction(CrudModelGiangVien view)
        {
            //ViewBag.lstQuyenQuanTri = new SelectList(_db.Filter<DMQuyenQuanTri>(x => x.MaQuyenQuanTri == view.MaQuyenQuanTri), "MaQuyenQuanTri", "TenQuyenQuanTri");
            ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh", view.MaGioiTinh);
        }
        public void initialCategoryEditAction()
        {
            ViewBag.lstGioiTinh = new SelectList(_db.GetAll<DMGioiTinh>(), "MaGioiTinh", "TenGioiTinh");
        }
    }
}