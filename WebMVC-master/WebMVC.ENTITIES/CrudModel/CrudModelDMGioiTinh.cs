using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelDMGioiTinh
    {
        public CrudModelDMGioiTinh()
        {
            this.GiangViens = new HashSet<CrudModelGiangVien>();
            this.HocViens = new HashSet<CrudModelHocVien>();
        }

        public int MaGioiTinh { get; set; }
        public string TenGioiTinh { get; set; }
        public virtual ICollection<CrudModelGiangVien> GiangViens { get; set; }
        public virtual ICollection<CrudModelHocVien> HocViens { get; set; }
    }
}
