using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelBaiViet
    {
        public CrudModelBaiViet()
        {
            this.CrudModelSlideShows = new HashSet<CrudModelSlideShow>();
        }

        public long MaBaiViet { get; set; }
        public string TenBaiViet { get; set; }
        public string NoiDung { get; set; }
        public Nullable<long> MaChuDeBaiViet { get; set; }
        public Nullable<int> MaHienThi { get; set; }

        public virtual CrudModelDMChuDeBaiViet DMChuDeBaiViet { get; set; }
        public virtual CrudModelDMHienThi DMHienThi { get; set; }
        public virtual ICollection<CrudModelSlideShow> CrudModelSlideShows { get; set; }
    }
}
