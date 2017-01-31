using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMHienThi
    {
        public CrudModelDMHienThi()
        {
            this.BaiViets = new HashSet<BaiViet>();
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaHienThi { get; set; }
        public string TenHienThi { get; set; }

        public virtual ICollection<BaiViet> BaiViets { get; set; }
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
