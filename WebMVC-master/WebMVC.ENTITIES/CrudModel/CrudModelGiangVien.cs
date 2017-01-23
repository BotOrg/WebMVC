using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày sinh:")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string TieuSu { get; set; }
        public string HocVi { get; set; }
        public string AnhDaiDien { get; set; }
        public Nullable<int> MaGioiTinh { get; set; }

        //public virtual CrudModelDMGioiTinh DMGioiTinh { get; set; }
        //public virtual ICollection<CrudModelKhoaHoc_GiangVien> KhoaHoc_GiangVien { get; set; }
    }
}
