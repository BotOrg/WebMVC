using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMCapHocVien
    {
        public CrudModelDMCapHocVien()
        {
            this.KhoaHocs = new HashSet<CrudModelKhoaHoc>();
        }

        public int MaCapHocVien { get; set; }
        public string TenCapHocVien { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<CrudModelKhoaHoc> KhoaHocs { get; set; }
    }
}
