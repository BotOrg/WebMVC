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
    public class DMGioiTinhController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMGioiTinh
        [HttpGet]
        public ActionResult Index(ViewModelDMGioiTinh SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMGioiTinh>(o => (SearchString.TenGioiTinh == null || o.TenGioiTinh.StartsWith(SearchString.TenGioiTinh)));
            var model = new List<DMGioiTinh>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMGioiTinh>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMGioiTinh());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMGioiTinh model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMGioiTinh _model = new DMGioiTinh();
                    COMMON.Helpers.CopyObject<DMGioiTinh>(model, ref _model);
                    _db.Insert<DMGioiTinh>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMGioiTinh");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm giới tính thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaGioiTinh)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMGioiTinh model = _db.GetOne<DMGioiTinh>(o => o.MaGioiTinh == MaGioiTinh);
            CrudModelDMGioiTinh _model = new CrudModelDMGioiTinh();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMGioiTinh>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMGioiTinh model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMGioiTinh _model = _db.GetOne<DMGioiTinh>(o => o.MaGioiTinh == model.MaGioiTinh);
                    COMMON.Helpers.CopyObject<DMGioiTinh>(model, ref _model);
                    _db.Update<DMGioiTinh>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật giới tính thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaGioiTinh)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMGioiTinh model = _db.GetOne<DMGioiTinh>(o => o.MaGioiTinh == MaGioiTinh);
            _db.DeleteItem<DMGioiTinh>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}