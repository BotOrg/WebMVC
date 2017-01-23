using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.ViewModel
{
    [Serializable]
    public class ViewModelHocVien
    {
        public int? Page { get; set; }

        public long MaHocVien { get; set; }
        public string TenHocVien { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string CMTND { get; set; }
        public string NoiSinh { get; set; }
        public Nullable<int> MaCapHocVien { get; set; }
        public Nullable<int> MaGioiTinh { get; set; }

        public virtual DMGioiTinh DMGioiTinh { get; set; }

        public List<DMGioiTinh> lstDMGioiTinh { get; set; }

        public IPagedList<HocVien> SearchResults { get; set; }
    }


}
