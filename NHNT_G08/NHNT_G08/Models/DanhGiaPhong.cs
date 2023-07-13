using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class DanhGiaPhong
    {
        [Key]
        public int maPhong { get; set; }
        public int maDanhGia { get; set; }
        public int maNguoiDung { get; set; }
        public int soSao { get; set; }
    }
}
