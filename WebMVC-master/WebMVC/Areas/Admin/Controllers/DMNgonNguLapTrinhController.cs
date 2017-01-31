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
    public class DMNgonNguLapTrinhController : BaseController
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/DMNgonNguLapTrinh
        [HttpGet]
        public ActionResult Index(ViewModelDMNgonNguLapTrinh SearchString, int? currentPage)

        {
            var entities = _db.Filter<DMNgonNguLapTrinh>(o => (SearchString.TenNgonNguLapTrinh == null || o.TenNgonNguLapTrinh.StartsWith(SearchString.TenNgonNguLapTrinh)));
            var model = new List<DMNgonNguLapTrinh>();
            foreach (var currentEntity in entities)
            {
                model.Add(Mapper.Map<DMNgonNguLapTrinh>(currentEntity));
            }
            var pageIndex = SearchString.Page ?? 1;
            SearchString.SearchResults = model.ToPagedList(pageIndex, CommonConstans.PageSize);
            return View(SearchString);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CrudModelDMNgonNguLapTrinh());
        }

        [HttpPost]
        public ActionResult Create(CrudModelDMNgonNguLapTrinh model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMNgonNguLapTrinh _model = new DMNgonNguLapTrinh();
                    COMMON.Helpers.CopyObject<DMNgonNguLapTrinh>(model, ref _model);
                    _db.Insert<DMNgonNguLapTrinh>(_model);
                    _db.SaveChange();
                    return RedirectToAction("Index", "DMNgonNguLapTrinh");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Thêm ngôn ngữ lập trình thất bại.");
                }
            }
            return View("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(long MaNgonNguLapTrinh)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMNgonNguLapTrinh model = _db.GetOne<DMNgonNguLapTrinh>(o => o.MaNgonNguLapTrinh == MaNgonNguLapTrinh);
            CrudModelDMNgonNguLapTrinh _model = new CrudModelDMNgonNguLapTrinh();
            WebMVC.COMMON.Helpers.CopyObject<CrudModelDMNgonNguLapTrinh>(model, ref _model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(CrudModelDMNgonNguLapTrinh model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DMNgonNguLapTrinh _model = _db.GetOne<DMNgonNguLapTrinh>(o => o.MaNgonNguLapTrinh == model.MaNgonNguLapTrinh);
                    COMMON.Helpers.CopyObject<DMNgonNguLapTrinh>(model, ref _model);
                    _db.Update<DMNgonNguLapTrinh>(_model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật ngôn ngữ lập trình thất bại.");
                }
            }
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public ActionResult Delete(long MaNgonNguLapTrinh)
        {
            _db.DbContext.Configuration.ProxyCreationEnabled = false;
            DMNgonNguLapTrinh model = _db.GetOne<DMNgonNguLapTrinh>(o => o.MaNgonNguLapTrinh == MaNgonNguLapTrinh);
            _db.DeleteItem<DMNgonNguLapTrinh>(model);

            return RedirectToAction("Index");
        }

        #endregion
    }
}