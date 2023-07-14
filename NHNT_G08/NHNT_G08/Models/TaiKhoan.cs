using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class TaiKhoan
    {
        [Key]
        public int maTaiKhoan { get; set; }
        public string tenDangNhap { get; set; }
        public string soDienThoai { get; set; }
        public string hoTenNguoiDung { get; set; }
        public string matKhau { get; set; }
        public int maDmTaiKhoan { get; set; }
    }
}
