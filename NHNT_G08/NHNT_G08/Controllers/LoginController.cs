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
                    _httpContextAccessor.HttpContext.Session.SetString("maTaiKhoan", user.maTaiKhoan.ToString());
                    _httpContextAccessor.HttpContext.Session.SetString("tenDangNhap", user.tenDangNhap);
                    _httpContextAccessor.HttpContext.Session.SetString("hoTenNguoiDung", user.hoTenNguoiDung);
                    _httpContextAccessor.HttpContext.Session.SetString("maDmTaiKhoan", user.maDmTaiKhoan.ToString());
                    if(user.anhDaiDien != null)
                        _httpContextAccessor.HttpContext.Session.SetString("anhDaiDien", Url.Content("~/img/anhdaidien/" + user.anhDaiDien));
                    else 
                        _httpContextAccessor.HttpContext.Session.SetString("anhDaiDien", Url.Content("~/img/anhdaidien/macdinh.jpg"));

                    // ViewBag.hoTenNguoiDung = user.hoTenNguoiDung;
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