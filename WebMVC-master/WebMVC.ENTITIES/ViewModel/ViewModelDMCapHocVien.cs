using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;
using PagedList;

namespace WebMVC.ENTITIES.ViewModel
{
    [Serializable]
    public class ViewModelDMCapHocVien
    {
        public ViewModelDMCapHocVien()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaCapHocVien { get; set; }
        public string TenCapHocVien { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
        public int? Page { get; set; }
        public IPagedList<DMCapHocVien> SearchResults { get; set; }
    }
}
