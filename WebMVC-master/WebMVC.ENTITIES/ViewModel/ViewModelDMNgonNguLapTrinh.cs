using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.ViewModel
{
    [Serializable]
    public class ViewModelDMNgonNguLapTrinh
    {
        public ViewModelDMNgonNguLapTrinh()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaNgonNguLapTrinh { get; set; }
        public string TenNgonNguLapTrinh { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }

        public int? Page { get; set; }
        public IPagedList<DMNgonNguLapTrinh> SearchResults { get; set; }
    }
}
