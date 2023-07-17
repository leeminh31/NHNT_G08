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

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private readonly NHNTContext _context;
        public LoginController( NHNTContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(TaiKhoan model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Kiểm tra thông tin đăng nhập với cơ sở dữ liệu hoặc xử lý theo yêuầu

            // Chuyển hướng đến trang thành công
            return View("~/Views/Home/Index.cshtml");
        }
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}