using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;
using WebMVC.ENTITIES.CrudModel;

namespace WebMVC.ENTITIES.ViewModel
{
    [Serializable]
    public class ViewModelGiangVien
    {
        public int? Page { get; set; }
        public long MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string TieuSu { get; set; }
        public string HocVi { get; set; }
        public string AnhDaiDien { get; set; }
        public Nullable<int> MaGioiTinh { get; set; }

        public virtual CrudModelDMGioiTinh DMGioiTinh { get; set; }
        public virtual ICollection<CrudModelKhoaHoc_GiangVien> KhoaHoc_GiangVien { get; set; }
        public List<DMGioiTinh> lstDMGioiTinh { get; set; }
        public IPagedList<GiangVien> SearchResults { get; set; }

        public List<DMQuyenQuanTri> lstDMQuanTriVien { get; set; }
    }
}
