using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelHocVien
    {
        public long MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string CMTND { get; set; }
        public string NoiSinh { get; set; }
        public Nullable<int> MaCapHocVien { get; set; }
        public Nullable<int> MaGioiTinh { get; set; }

        public virtual CrudModelDMGioiTinh DMGioiTinh { get; set; }
    }
}
