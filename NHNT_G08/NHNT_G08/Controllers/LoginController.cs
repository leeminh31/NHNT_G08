using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly NHNTContext _context;
        public LoginController( NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            // ViewBag.TenDangNhap = HttpContext.Session.GetString("tenDangNhap");
            return View("~/Views/Account/Login.cshtml");
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(TaiKhoan model)
        {    
            if (ModelState.IsValid)
            {
                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.tenDangNhap == model.tenDangNhap && u.matKhau == model.matKhau);
                if (user != null)
                {
                    //GaleL_Elliott@example.com | kbcwqbdadmor
                    _httpContextAccessor.HttpContext.Session.SetString("tenDangNhap", user.tenDangNhap);
                    _httpContextAccessor.HttpContext.Session.SetString("hoTenNguoiDung", user.hoTenNguoiDung);
                    _httpContextAccessor.HttpContext.Session.SetString("maDmTaiKhoan", user.maDmTaiKhoan.ToString());

//++ mã tk ++ maDmTaiKhoan
                    ViewBag.hoTenNguoiDung = user.hoTenNguoiDung;
                    return RedirectToAction("Index", "Home");
                    // return View("~/Views/Account/Login.cshtml");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác.");
                    ViewBag.loi = "Tên đăng nhập hoặc mật khẩu không chính xác";
                    // return View("~/Views/Account/Login.cshtml");
                }
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _httpContextAccessor.HttpContext.Session.Remove("tenDangNhap");
            _httpContextAccessor.HttpContext.Session.Remove("hoTenNguoiDung");
            _httpContextAccessor.HttpContext.Session.Remove("maDmTaiKhoan");
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}