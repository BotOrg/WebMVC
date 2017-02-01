using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.ViewModel
{
    public class ViewModelKhoaHoc
    {
        public ViewModelKhoaHoc()
        {
            this.KhoaHoc_GiangVien = new HashSet<KhoaHoc_GiangVien>();
            this.SlideShows = new HashSet<SlideShow>();
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

        public virtual DMCapHocVien DMCapHocVien { get; set; }
        public virtual DMChuDe DMChuDe { get; set; }
        public virtual DMHienThi DMHienThi { get; set; }
        public virtual DMLoaiKhoaHoc DMLoaiKhoaHoc { get; set; }
        public virtual DMNgonNguLapTrinh DMNgonNguLapTrinh { get; set; }
        public virtual ICollection<KhoaHoc_GiangVien> KhoaHoc_GiangVien { get; set; }
        public virtual ICollection<SlideShow> SlideShows { get; set; }


        public int? Page { get; set; }
        public IPagedList<KhoaHoc> SearchResults { get; set; }
    }
}
