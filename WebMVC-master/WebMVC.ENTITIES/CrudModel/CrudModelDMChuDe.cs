using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMChuDe
    {
        public CrudModelDMChuDe()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaChuDe { get; set; }
        public string TenChuDe { get; set; }
        public Nullable<int> CapChuDe { get; set; }
        public Nullable<int> ChuDeCha { get; set; }
        public Nullable<int> MoTa { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
