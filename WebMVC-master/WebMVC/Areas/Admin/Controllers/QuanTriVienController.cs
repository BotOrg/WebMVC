using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.COMMON;
using AutoMapper;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;
using WebMVC.ENTITIES.ViewModel;
using PagedList;

namespace WebMVC.Areas.Admin.Controllers
{
    public class QuanTriVienController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/QuanTriVien
        [HttpGet]
        public ActionResult Index(ViewModelQTV SearchString, int? currentPage)

        { 
            var entities = _db.Filter<QuanTriVien>(o=>(SearchString.TenDangNhap == null || o.TenDangNhap.StartsWith(SearchString.TenDangNhap)));
            var model = new List<QuanTriVien>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<QuanTriVien>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            SearchString.lstDMQuyenQuanTri = _db.GetAll<DMQuyenQuanTri>();
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            initialCategoryEditAction();
            return View(new CrudModelQuanTriVien());
        }

        [HttpPost]
        public ActionResult Create(CrudModelQuanTriVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    QuanTriVien _model = new QuanTriVien();
                    COMMON.Helpers.CopyObject<QuanTriVien>(model, ref _model);
                    _db.Insert<QuanTriVien>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "QuanTriVien");
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
        public ActionResult Edit(long MaQuanTriVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            QuanTriVien model = _db.GetOne<QuanTriVien>(o => o.MaQuanTriVien == MaQuanTriVien);
            CrudModelQuanTriVien _model = new CrudModelQuanTriVien();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelQuanTriVien>(model, ref _model);
            initialCategoryEditAction(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelQuanTriVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    QuanTriVien _model = _db.GetOne<QuanTriVien>(o => o.MaQuanTriVien == model.MaQuanTriVien);
                    COMMON.Helpers.CopyObject<QuanTriVien>(model, ref _model);
                    _db.Update<QuanTriVien>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật quản trị viên thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        public void initialCategoryEditAction(CrudModelQuanTriVien view)
        {
            //ViewBag.lstQuyenQuanTri = new SelectList(_db.Filter<DMQuyenQuanTri>(x => x.MaQuyenQuanTri == view.MaQuyenQuanTri), "MaQuyenQuanTri", "TenQuyenQuanTri");
            ViewBag.lstQuyenQuanTri = new SelectList(_db.GetAll<DMQuyenQuanTri>(), "MaQuyenQuanTri", "TenQuyenQuanTri",view.MaQuyenQuanTri);
        }
        public void initialCategoryEditAction()
        {
            ViewBag.lstQuyenQuanTri = new SelectList(_db.GetAll<DMQuyenQuanTri>(), "MaQuyenQuanTri", "TenQuyenQuanTri");
        }
    }
}