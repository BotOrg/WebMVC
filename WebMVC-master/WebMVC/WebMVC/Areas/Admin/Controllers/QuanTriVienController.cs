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
    public class QuanTriVienController : Controller
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/QuanTriVien
        [HttpGet]
        public ActionResult Index(ViewModelQTV SearchModel, int? currentPage)
        {
            var entities = _db.GetAll<QuanTriVien>();
            var model = new List<QuanTriVien>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<QuanTriVien>(currentEntity));
            }
            var pageIndex = SearchModel.Page ?? 1;
            SearchModel.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchModel);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            initialCategoryCreateAction();
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
            QuanTriVien model = new QuanTriVien();
            model = _db.GetOne<QuanTriVien>(o=>o.MaQuanTriVien == MaQuanTriVien);
            CrudModelQuanTriVien _model = new CrudModelQuanTriVien();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelQuanTriVien>(model, ref _model);
            initialCategoryEditAction(_model);

            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelQuanTriVien model)
        {
            QuanTriVien _model = new QuanTriVien();
            _model = _db.GetOne<QuanTriVien>(o => o.MaQuanTriVien == model.MaQuanTriVien);
            COMMON.Helpers.CopyObject<QuanTriVien>(model, ref _model);
            _db.Update<QuanTriVien>(_model);
            return RedirectToAction("Index","QuanTriVien");
        }
        #endregion


        #region Load DataSource for DropDownList
        public void initialCategoryEditAction(CrudModelQuanTriVien view)
        {
            ViewBag.lstQuyenQuanTri = new SelectList(_db.Filter<DMQuyenQuanTri>(o=>o.MaQuyenQuanTri == view.MaQuyenQuanTri), "MaQuyenQuanTri", "TenQuyenQuanTri");
            //ViewBag.lstQuyenQuanTri = new SelectList(_db.Filter<DMQuyenQuanTri>(x=>x.MaQuyenQuanTri == view.MaQuyenQuanTri), "MaQuyenQuanTri", "TenQuyenQuanTri");
        }

        public void initialCategoryCreateAction()
        {
            ViewBag.lstQuyenQuanTri = new SelectList(_db.GetAll<DMQuyenQuanTri>(), "MaQuyenQuanTri", "TenQuyenQuanTri");
        }
        #endregion

    }
}