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
using System.IO;

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly NHNTContext _context;
        public AccountController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            if (maTaiKhoan != null)
            {
                int maTaiKhoanInt = int.Parse(maTaiKhoan);
                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                //++ mã tk ++ maDmTaiKhoan
                ViewBag.tenDangNhap = user.tenDangNhap;
                ViewBag.hoTenNguoiDung = user.hoTenNguoiDung;
                ViewBag.soDienThoai = user.soDienThoai;

                ViewBag.anhDaiDien = Url.Content("~/img/anhdaidien/" + user.anhDaiDien);
            }else{
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/Account.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Update(TaiKhoan taiKhoan, IFormFile anhDaiDien)
        {
            // if (ModelState.IsValid)
            // {
                var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
                if (!string.IsNullOrEmpty(maTaiKhoan))
                {
                    int maTaiKhoanInt = int.Parse(maTaiKhoan);

                    var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                    
                    if (anhDaiDien != null && anhDaiDien.Length > 0)
                    {
                        // Lưu tệp tin vào thư mục trong dự án
                        string oldfile="wwwroot/img/anhdaidien" + user.anhDaiDien;
                        if(System.IO.File.Exists(oldfile)){
                            System.IO.File.Delete(oldfile);
                        }
                        string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
                        string uniqueFileName = maTaiKhoan+".jpg";
                        string filePath = Path.Combine(uploadsPath, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await anhDaiDien.CopyToAsync(fileStream);
                        }
                        // Lưu tên tệp tin vào đối tượng taiKhoan
                        user.anhDaiDien = uniqueFileName;
                    }

                    user.hoTenNguoiDung = taiKhoan.hoTenNguoiDung;
                    user.soDienThoai = taiKhoan.soDienThoai;
                    
                    _context.tblTaiKhoan.Update(user);
                    _context.SaveChanges();
                }
                // Lưu thông tin taiKhoan vào cơ sở dữ liệu
                // _context.tblTaiKhoan.Add(taiKhoan);
                // await _context.SaveChangesAsync();

                // return RedirectToAction("Index", "Account");
            // }
            // return View("~/Views/Account/Account.cshtml");
            return RedirectToAction("Index", "Account", taiKhoan);
        }
        //***********************
        // public async Task<IActionResult> Update(string tenDangNhap, string hoTenNguoiDung, string soDienThoai, IFormFile hinhDaiDien)
        // {
        //     var taikhoan = HttpContext.Session.GetString("tenDangNhap");
        //     var user = _context.tblTaiKhoan.SingleOrDefault(u => u.tenDangNhap == taikhoan);

        //     if (hinhDaiDien != null && hinhDaiDien.Length > 0)
        //     {
        //         var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", hinhDaiDien.FileName);

        //         using (var stream = new FileStream(filePath, FileMode.Create))
        //         {
        //             await hinhDaiDien.CopyToAsync(stream);
        //         }

        //         user.anhDaiDien = hinhDaiDien.FileName;
        //     }
        //     if (user.anhDaiDien == null )
        //     {
        //         ModelState.AddModelError("", "Không thể cập nhật thông tin người dùng.");
        //     }
        //         return RedirectToAction("Index", "Account"); // Trở về trang hồ sơ người dùng 
        // }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}