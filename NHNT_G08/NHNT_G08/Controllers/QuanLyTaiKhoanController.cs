using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NHNT_G08.Models;

namespace NHNT_G08.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        private readonly NHNTContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuanLyTaiKhoanController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: bài đăng
        public async Task<IActionResult> Index()
        {
            var maTaiKhoan = _httpContextAccessor.HttpContext.Session.GetString("maTaiKhoan");
            if (maTaiKhoan != null && Convert.ToInt32(maTaiKhoan) == 1)
            {
                var listTK = await _context.tblTaiKhoan.ToListAsync();
                foreach (var taikhoan in listTK)
                {
                    var dmtaiKhoan = _context.tblDmTaiKhoan.First(p => p.maDmTaiKhoan == taikhoan.maDmTaiKhoan);
                    taikhoan.tenLoaiTK = dmtaiKhoan.tenLoaiTK;
                }

                return View(listTK);
            }
            return View("~/Views/Account/Login.cshtml");
            
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
