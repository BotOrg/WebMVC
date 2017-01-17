using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoaiKhoaHocController : Controller
    {
        // GET: Admin/LoaiKhoaHoc
        public ActionResult Index()
        {
            return View();
        }
    }
}