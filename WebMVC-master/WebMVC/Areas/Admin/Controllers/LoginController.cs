using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.COMMON;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        DbContextHelper<WebMVC_ModelDbContext> _db = Singleton<DbContextHelper<WebMVC_ModelDbContext>>.Inst;

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(CrudModelLogin model)
        {
            if (ModelState.IsValid)
            {
                //model.MatKhau = COMMON.CommonEncryptor.MD5Hash(model.MatKhau);
                var result = _db.EntityExists<QuanTriVien>(x => x.TenDangNhap == model.TenDangNhap && x.MatKhau == model.MatKhau);

                if (result)
                {
                    var userSession = new CrudModelLogin();
                    userSession.TenDangNhap = model.TenDangNhap;
                    userSession.MatKhau = model.MatKhau;
                    Session.Add(COMMON.CommonConstans.USER_SESSION,userSession);
                    return RedirectToAction("Index","Home");
                }   
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
                return View("Index");
        }
    }

}