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
        public async Task<IActionResult> Index(string timP, string timND)
        {


            var listBD = await _context.tblPhong.ToListAsync();
            foreach (var phong in listBD)
            {
                var taiKhoan = _context.tblTaiKhoan.First(p => p.maTaiKhoan == phong.maTaiKhoan);
                phong.tenNguoiDang = taiKhoan.hoTenNguoiDung;
            }
            if (!String.IsNullOrEmpty(timP))
            {
                listBD = listBD.Where(s => s.tenPhong.Contains(timP)).ToList();
                
            }

            if (!String.IsNullOrEmpty(timND))
            {
                
                listBD = listBD.Where(s => s.tenNguoiDang.Contains(timND)).ToList();
            }

            return View(listBD);


            

            
        }

        [HttpPost]
        public async Task<bool> duyetBaiDang(int id)
        {
            try
            {
                var phong = _context.tblPhong.Where(p=>p.maPhong == id).First();
                phong.trangThaiBaiDang = "duyệt";
                _context.tblPhong.Update(phong);
                await _context.SaveChangesAsync();
                return true;
            } catch
            {
                return false;
            }
        }


        [HttpPost]
        public async Task<IActionResult> xoaBaiDang(int id)
        {
            
                //var phong = _context.tblPhong.Where(p => p.maPhong == id).First();
                var phong = await _context.tblPhong.FindAsync(id);
                _context.tblPhong.Remove(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


        }
    }
}
