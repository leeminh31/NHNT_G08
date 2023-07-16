using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NHNT_G08.Models;

namespace NHNT_G08.Controllers
{
    public class QuanLyBaiDangController : Controller
    {
        
        private readonly NHNTContext _context;

        public QuanLyBaiDangController(NHNTContext context)
        {
            _context = context;
        }

        // GET: bài đăng
        public async Task<IActionResult> Index()
        {
            var listBD = await _context.tblPhong.ToListAsync();
            foreach (var phong in listBD)
            {
                var taiKhoan = _context.tblTaiKhoan.First(p => p.maTaiKhoan == phong.maTaiKhoan);
                phong.tenNguoiDang = taiKhoan.hoTenNguoiDung;
            }

            return View(listBD);
        }
    }
}
