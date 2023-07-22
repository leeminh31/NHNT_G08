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
    public class QuanLyTaiKhoanController : Controller
    {
        private readonly NHNTContext _context;

        public QuanLyTaiKhoanController(NHNTContext context)
        {
            _context = context;
        }

        // GET: bài đăng
        public async Task<IActionResult> Index()
        {
            var listTK = await _context.tblTaiKhoan.ToListAsync();
            foreach (var taikhoan in listTK)
            {
                var dmtaiKhoan = _context.tblDmTaiKhoan.First(p => p.maDmTaiKhoan == taikhoan.maDmTaiKhoan);
                taikhoan.tenLoaiTK = dmtaiKhoan.tenLoaiTK;
            }

            return View(listTK);
        }

        [HttpPost]
        public async Task<bool> khoaTaiKhoan(int id)
        {
            try
            {
                var taikhoan = _context.tblTaiKhoan.Where(p => p.maTaiKhoan == id).First();
                taikhoan.trangThai = "Khóa tài khoản";
                _context.tblTaiKhoan.Update(taikhoan);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
