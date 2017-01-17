using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.ENTITIES.CrudModel
{
    [Serializable]
    public class CrudModelSlideShow
    {

        public int MaSlide { get; set; }
        public string TenSlide { get; set; }
        public Nullable<long> MaKhoaHoc { get; set; }
        public Nullable<long> MaBaiViet { get; set; }
        public string AnhSlide { get; set; }
        public Nullable<int> MaHienThi { get; set; }

        public virtual CrudModelBaiViet BaiViet { get; set; }
        public virtual CrudModelKhoaHoc KhoaHoc { get; set; }
    }
}
