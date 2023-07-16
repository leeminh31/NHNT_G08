using Microsoft.AspNetCore.Mvc;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Controllers
{
    public class BaiDangController : Controller
    {
        private readonly NHNTContext _context;

        public BaiDangController(NHNTContext context)
        {
            _context = context;
        }
        public IActionResult ThemBaiDang()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ThemBaiDang([Bind("tenPhong, diaChi, giaPhong, giaDien, giaNuoc, soDienThoai, chiTietPhong, trangThaiBaiDang, trangThaiPhong, maTaiKhoan")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(phong);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                return View(phong);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BaiDangDaDanhGia(int? pageIndex)
        {
            int pageSize = 12;
            var listMaPhong = _context.tblDanhGiaPhong.Where(p => p.maTaiKhoan == 3).Select(p => p.maPhong).ToList();
            var listPhong = _context.tblPhong.Where(p => listMaPhong.Contains(p.maPhong)).ToList();
            foreach (var phong in listPhong)
            {
                var soSao = _context.tblDanhGiaPhong.Where(p => p.maPhong == phong.maPhong).Select(p => p.soSao).First();
                phong.soSaoTrungBinh = soSao;
            }
            return View(Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        }
    }
}
