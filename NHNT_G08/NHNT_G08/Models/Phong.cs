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
        public string tenPhong { get; set; }
        public string diaChi { get; set; }
        public int giaPhong { get; set; }
        public int giaDien { get; set; }
        public int giaNuoc { get; set; }
        public string chiTietPhong { get; set; }
        public string anhPhong { get; set; }
        public string trangThaiPhong { get; set; }
        public string trangThaiBaiDang { get; set; }
        [NotMapped]
        public int soSaoTrungBinh { get; set; }
    }
}
