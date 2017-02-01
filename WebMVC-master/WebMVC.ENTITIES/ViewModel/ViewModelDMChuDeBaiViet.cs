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
    public  class ViewModelDMChuDeBaiViet
    {
         public ViewModelDMChuDeBaiViet()
        {
            this.BaiViets = new HashSet<BaiViet>();
        }
    
        public long MaChuDeBaiViet { get; set; }
        public string TenChuDeBaiViet { get; set; }
        public string MoTa { get; set; }
    
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        public int? Page { get; set; }
        public IPagedList<DMChuDeBaiViet> SearchResults { get; set; }
    }
}
