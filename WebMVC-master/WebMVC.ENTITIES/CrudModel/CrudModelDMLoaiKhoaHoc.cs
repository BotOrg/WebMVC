using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMLoaiKhoaHoc
    {
        public CrudModelDMLoaiKhoaHoc()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaLoaiKhoaHoc { get; set; }
        public string TenLoaiKhoaHoc { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
