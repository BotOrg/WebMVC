using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMQuyenQuanTri
    {
        public CrudModelDMQuyenQuanTri()
        {
            this.CrudModelQuanTriViens = new HashSet<CrudModelQuanTriVien>();
        }

        [Display(Name = "Mã quản trị viên")]
        public int MaQuyenQuanTri { get; set; }

        [Display(Name = "Tên quyền quản trị")]
        public string TenQuyenQuanTri { get; set; }

        public virtual ICollection<CrudModelQuanTriVien> CrudModelQuanTriViens
        {
            get; set;
        }
    }
}
