using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.ViewModel
{
    public class ViewModelDMLoaiKhoaHoc
    {
        public ViewModelDMLoaiKhoaHoc()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaLoaiKhoaHoc { get; set; }
        public string TenLoaiKhoaHoc { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }

        public int? Page { get; set; }
        public IPagedList<DMLoaiKhoaHoc> SearchResults { get; set; }
    }
}
