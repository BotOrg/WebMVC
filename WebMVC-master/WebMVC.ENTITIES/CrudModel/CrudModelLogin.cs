using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelLogin
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string TenDangNhap { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { set; get; }
        public bool RememberMe { get; set; }
    }
}
