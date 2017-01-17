using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMLoaiKhoaHoc
    {
        public CrudModelDMLoaiKhoaHoc()
        {
            this.KhoaHocs = new HashSet<CrudModelKhoaHoc>();
        }

        public int MaLoaiKhoaHoc { get; set; }
        public string TenLoaiKhoaHoc { get; set; }

        public virtual ICollection<CrudModelKhoaHoc> KhoaHocs { get; set; }
    }
}
