using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.DataAccessLayer;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMGioiTinh
    {
        public CrudModelDMGioiTinh()
        {
            this.GiangViens = new HashSet<GiangVien>();
            this.HocViens = new HashSet<HocVien>();
        }

        public int MaGioiTinh { get; set; }
        public string TenGioiTinh { get; set; }
        public virtual ICollection<GiangVien> GiangViens { get; set; }
        public virtual ICollection<HocVien> HocViens { get; set; }
    }
}
