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
    public class ChangePassController : Controller
    {
        private readonly ILogger<ChangePassController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly NHNTContext _context;
        public ChangePassController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            int maTaiKhoanInt = int.Parse(maTaiKhoan);
            if (maTaiKhoan != null)
            {
                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                //++ mã tk ++ maDmTaiKhoan
                ViewBag.tenDangNhap = user.tenDangNhap;
            }

            return View("~/Views/Account/ChangePass.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Update(TaiKhoan taiKhoan, IFormFile anhDaiDien)
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            
                if (ModelState.IsValid)
                {
                    int maTaiKhoanInt = int.Parse(maTaiKhoan);

                    var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);

                    user.matKhau = taiKhoan.matKhau;

                    _context.tblTaiKhoan.Update(user);
                    _context.SaveChanges();
                }else
                {
                    ViewBag.loi = "Vui lòng nhập đủ thông tin !";
                    return View("~/Views/Account/ChangePass.cshtml");
                }

            return RedirectToAction("Index", "ChangePass", taiKhoan);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}