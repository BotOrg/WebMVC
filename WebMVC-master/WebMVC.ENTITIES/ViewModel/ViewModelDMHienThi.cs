using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.ViewModel
{
    public class ViewModelDMHienThi
    {

        public int MaHienThi { get; set; }
        public string TenHienThi { get; set; }

        public int? Page { get; set; }
        public IPagedList<DMHienThi> SearchResults { get; set; }

    }
}
