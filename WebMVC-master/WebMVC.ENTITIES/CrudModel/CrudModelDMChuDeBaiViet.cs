using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{   [Serializable]
    public class CrudModelDMChuDeBaiViet
    {
        public CrudModelDMChuDeBaiViet()
        {
            this.BaiViets = new HashSet<CrudModelBaiViet>();
        }

        public long MaChuDeBaiViet { get; set; }
        public string TenChuDeBaiViet { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<CrudModelBaiViet> BaiViets { get; set; }
    }
}
