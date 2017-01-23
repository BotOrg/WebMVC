using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;

namespace WebMVC.ENTITIES.ViewModel
{
    public class ViewModelQTV
    {
        public int? Page { get; set; }
        [Display(Name = "Mã quản trị viên")]
        public long MaQuanTriVien { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Tên hiển thị")]
        public string TenHienThi { get; set; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }


        public Nullable<int> MaQuyenQuanTri { get; set; }

        public virtual CrudModelDMQuyenQuanTri DMQuyenQuanTri { get; set; }
        public List<DMQuyenQuanTri> lstDMQuyenQuanTri { get; set; }

        public IPagedList<QuanTriVien> SearchResults { get; set; }
    }
}
