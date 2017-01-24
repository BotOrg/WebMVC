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
    public class DMCapHocVienController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMCapHocVien
        [HttpGet]
        public ActionResult Index(ViewModelDMCapHocVien SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMCapHocVien>(o => (SearchString.TenCapHocVien == null || o.TenCapHocVien.StartsWith(SearchString.TenCapHocVien)));
            var model = new List<DMCapHocVien>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMCapHocVien>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMCapHocVien());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMCapHocVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMCapHocVien _model = new DMCapHocVien();
                    COMMON.Helpers.CopyObject<DMCapHocVien>(model, ref _model);
                    _db.Insert<DMCapHocVien>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMCapHocVien");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm cấp học viên thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaCapHocVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMCapHocVien model = _db.GetOne<DMCapHocVien>(o => o.MaCapHocVien == MaCapHocVien);
            CrudModelDMCapHocVien _model = new CrudModelDMCapHocVien();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMCapHocVien>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMCapHocVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMCapHocVien _model = _db.GetOne<DMCapHocVien>(o => o.MaCapHocVien == model.MaCapHocVien);
                    COMMON.Helpers.CopyObject<DMCapHocVien>(model, ref _model);
                    _db.Update<DMCapHocVien>(_model);
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
        public ActionResult Delete(long MaCapHocVien)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMCapHocVien model = _db.GetOne<DMCapHocVien>(o => o.MaCapHocVien == MaCapHocVien);
            _db.DeleteItem<DMCapHocVien>(model);

            return RedirectToAction("Index");
        }

        #endregion

       
    }
}