using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMNgonNguLapTrinh
    {
        public CrudModelDMNgonNguLapTrinh()
        {
            this.KhoaHocs = new HashSet<CrudModelKhoaHoc>();
        }

        public int MaNgonNguLapTrinh { get; set; }
        public string TenNgonNguLapTrinh { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<CrudModelKhoaHoc> KhoaHocs { get; set; }
    }
}
