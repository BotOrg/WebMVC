using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    public class CrudModelDMQuyenQuanTri
    {
        public CrudModelDMQuyenQuanTri()
        {
            this.CrudModelQuanTriVien = new HashSet<CrudModelQuanTriVien>();
        }

        [Display(Name = "Mã quản trị viên")]
        public int MaQuyenQuanTri { get; set; }

        [Display(Name = "Tên quyền quản trị")]
        public string TenQuyenQuanTri { get; set; }

        [Display(Name = "Tên quyền quản trị")]
        public virtual ICollection<CrudModelQuanTriVien> CrudModelQuanTriVien
        {
            get; set;
        }
    }
}
