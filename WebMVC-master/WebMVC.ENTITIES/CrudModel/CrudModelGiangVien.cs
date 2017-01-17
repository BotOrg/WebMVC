using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
     public class CrudModelGiangVien
    {
        public long MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string TieuSu { get; set; }
        public string HocVi { get; set; }
        public string AnhDaiDien { get; set; }
        public Nullable<int> MaGioiTinh { get; set; }

        //public virtual CrudModelDMGioiTinh DMGioiTinh { get; set; }
        //public virtual ICollection<CrudModelKhoaHoc_GiangVien> KhoaHoc_GiangVien { get; set; }
    }
}
