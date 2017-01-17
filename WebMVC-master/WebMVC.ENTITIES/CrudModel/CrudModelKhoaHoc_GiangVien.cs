using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelKhoaHoc_GiangVien
    {
        public long MaGiangVien { get; set; }
        public long MaKhoaHoc { get; set; }
        public string MoTa { get; set; }

        public virtual CrudModelGiangVien GiangVien { get; set; }
        public virtual CrudModelKhoaHoc KhoaHoc { get; set; }
    }
}
