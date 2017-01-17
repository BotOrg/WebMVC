using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelQuanTriVien
    {
        [Required(ErrorMessage = "Mã quản trị bắt buộc nhập")]
        [Display(Name = "Mã quản trị viên")]
        public long MaQuanTriVien { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập bắt buộc nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Tên hiển thị")]
        public string TenHienThi { get; set; }
        [Required(ErrorMessage = "Mật khẩu bắt buộc nhập")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }


        public Nullable<int> MaQuyenQuanTri { get; set; }

        [Display(Name = "Tên quyền quản trị")]
        public virtual CrudModelDMQuyenQuanTri DMQuyenQuanTri { get; set; }
    }
}
