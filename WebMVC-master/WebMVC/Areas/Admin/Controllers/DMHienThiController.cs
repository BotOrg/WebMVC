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
    public class DMHienThiController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMHienThi
        [HttpGet]
        public ActionResult Index(ViewModelDMHienThi SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMHienThi>(o => (SearchString.TenHienThi == null || o.TenHienThi.StartsWith(SearchString.TenHienThi)));
            var model = new List<DMHienThi>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMHienThi>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMHienThi());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMHienThi model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMHienThi _model = new DMHienThi();
                    COMMON.Helpers.CopyObject<DMHienThi>(model, ref _model);
                    _db.Insert<DMHienThi>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMHienThi");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm danh mục thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaHienThi)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMHienThi model = _db.GetOne<DMHienThi>(o => o.MaHienThi == MaHienThi);
            CrudModelDMHienThi _model = new CrudModelDMHienThi();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMHienThi>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMHienThi model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMHienThi _model = _db.GetOne<DMHienThi>(o => o.MaHienThi == model.MaHienThi);
                    COMMON.Helpers.CopyObject<DMHienThi>(model, ref _model);
                    _db.Update<DMHienThi>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật hiển thị thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaHienThi)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMHienThi model = _db.GetOne<DMHienThi>(o => o.MaHienThi == MaHienThi);
            _db.DeleteItem<DMHienThi>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}
