using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class Phong
    {
        [Key]
        public int maPhong { get; set; }
        public int maTaiKhoan { get; set; }
        public string tenPhong { get; set; }
        public string diaChi { get; set; }
        public int giaPhong { get; set; }
        public int giaDien { get; set; }
        public int giaNuoc { get; set; }
        public string chiTietPhong { get; set; }
        public string trangThaiPhong { get; set; }
        public string trangThaiBaiDang { get; set; }
        public string soDienThoai { get; set; }

        public double dienTich { get; set;  }
        [NotMapped]
        public string tenNguoiDang { get; set; }
    }
}
