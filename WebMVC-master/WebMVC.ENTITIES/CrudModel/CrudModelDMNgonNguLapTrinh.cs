using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMNgonNguLapTrinh
    {
        public CrudModelDMNgonNguLapTrinh()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int MaNgonNguLapTrinh { get; set; }
        public string TenNgonNguLapTrinh { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
