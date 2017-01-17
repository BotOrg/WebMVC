using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelKhoaHoc
    {
        public CrudModelKhoaHoc()
        {
            this.KhoaHoc_GiangVien = new HashSet<CrudModelKhoaHoc_GiangVien>();
            this.SlideShows = new HashSet<CrudModelSlideShow>();
        }

        public long MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public Nullable<System.DateTime> NgayKhoiTao { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<int> SoLuongHocVien { get; set; }
        public Nullable<int> SoLuongBuoiHoc { get; set; }
        public Nullable<int> SoLuongHocTrinh { get; set; }
        public Nullable<int> MaChuDe { get; set; }
        public Nullable<int> MaLoaiKhoaHoc { get; set; }
        public Nullable<int> MaCapHocVien { get; set; }
        public Nullable<int> MaNgonNguLapTrinh { get; set; }
        public string MoTa { get; set; }
        public string AnhKhoaHoc { get; set; }
        public Nullable<int> MaHienThi { get; set; }
        public Nullable<decimal> HocPhi { get; set; }

        public virtual CrudModelDMCapHocVien DMCapHocVien { get; set; }
        public virtual CrudModelDMChuDe DMChuDe { get; set; }
        public virtual CrudModelDMHienThi DMHienThi { get; set; }
        public virtual CrudModelDMLoaiKhoaHoc DMLoaiKhoaHoc { get; set; }
        public virtual CrudModelDMNgonNguLapTrinh DMNgonNguLapTrinh { get; set; }
        public virtual ICollection<CrudModelKhoaHoc_GiangVien> KhoaHoc_GiangVien { get; set; }
        public virtual ICollection<CrudModelSlideShow> SlideShows { get; set; }
    }
}
