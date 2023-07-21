using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT_G08.Models;
using Microsoft.AspNetCore.Http;


namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private NHNTContext db;
        public RegisterController( NHNTContext context)
        {
            db = context;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                // Thêm dữ liệu mới vào cơ sở dữ liệu
                model.maDmTaiKhoan = 2;
                db.tblTaiKhoan.Add(model);
                db.SaveChanges();

                // Redirect đến trang đăng nhập hoặc trang chủ
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}