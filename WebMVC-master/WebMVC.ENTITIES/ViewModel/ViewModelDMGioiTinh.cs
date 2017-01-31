using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;
using PagedList;

namespace WebMVC.ENTITIES.ViewModel
{
    public class ViewModelDMGioiTinh
    {
        public int MaGioiTinh { get; set; }
        public string TenGioiTinh { get; set; }

        public int? Page { get; set; }
        public IPagedList<DMGioiTinh> SearchResults { get; set; }
    }
}
