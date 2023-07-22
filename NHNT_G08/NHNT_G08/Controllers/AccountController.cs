using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NHNT_G08.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly NHNTContext _context;
        public AccountController( NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [Route("Index")]
        public IActionResult Index()
        {

                var taikhoan = HttpContext.Session.GetString("tenDangNhap");
            var user = _context.tblTaiKhoan.SingleOrDefault(u => u.tenDangNhap == taikhoan);
            

                //++ mã tk ++ maDmTaiKhoan
                ViewBag.tenDangNhap = user.tenDangNhap;
                ViewBag.hoTenNguoiDung = user.hoTenNguoiDung;
                ViewBag.soDienThoai= user.soDienThoai;
                
                ViewBag.anhDaiDien = Url.Content("~/img/anhdaidien/" + user.anhDaiDien);;
      
            return View("~/Views/Account/Account.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}