using Microsoft.AspNetCore.Mvc;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public IActionResult ThemBaiDang()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemBaiDang([Bind("tenPhong, diaChi, giaPhong, giaDien, giaNuoc, soDienThoai, chiTietPhong, trangThaiBaiDang, trangThaiPhong, maTaiKhoan,files, dienTich")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                _context.SaveChanges();
                var maPhong = _context.tblPhong.OrderBy(p=> p.maPhong).Select(p=>p.maPhong).Last();
                if (phong.files.Count > 0)
                {
                    foreach (var file in phong.files)
                    {

                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhphong_"+maPhong);

                        //create folder if not exist
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);


                        string fileNameWithPath = Path.Combine(path, file.FileName);

                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        HinhAnh anh = new HinhAnh();
                        anh.maPhong = maPhong;
                        anh.duongDan = file.FileName;
                        _context.tblHinhAnh.Add(anh);                      
                    }
                    _context.SaveChanges();
                }
                
                return RedirectToAction("Index", "Home");
            }
            return View(phong);
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

        List<Phong> LayThongTinNguoiDang(List<Phong> listPhong)
        {
            foreach (var phong in listPhong)
            {
                var taiKhoan = _context.tblTaiKhoan.First(p => p.maTaiKhoan == phong.maTaiKhoan);
                phong.tenNguoiDang = taiKhoan.hoTenNguoiDung;
            }
            return listPhong;
        }

        [HttpGet]
        public IActionResult BaiDaDang ()
        {
            var listPhong = _context.tblPhong.Where(p => p.maTaiKhoan == 7).ToList();
            LayThongTinNguoiDang(listPhong);
            return View(listPhong);
        }
    }
}
