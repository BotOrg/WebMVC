using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMHienThi
    {
        public CrudModelDMHienThi()
        {
            this.BaiViets = new HashSet<CrudModelBaiViet>();
            this.KhoaHocs = new HashSet<CrudModelKhoaHoc>();
        }

        public int MaHienThi { get; set; }
        public string TenHienThi { get; set; }

        public virtual ICollection<CrudModelBaiViet> BaiViets { get; set; }
        public virtual ICollection<CrudModelKhoaHoc> KhoaHocs { get; set; }
    }
}
