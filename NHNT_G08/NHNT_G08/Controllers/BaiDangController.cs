﻿using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaiDangController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult ThemBaiDang()
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                ViewData["Title"] = "Thêm Bài Đăng";
                ViewData["Action"] = "ThemBaiDang";
                ViewData["Btn_Value"] = "Tạo Mới";
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult ThemBaiDang([Bind("tenPhong, diaChi, giaPhong, giaDien, giaNuoc, soDienThoai, chiTietPhong, trangThaiBaiDang, trangThaiPhong, maTaiKhoan,files, dienTich")] Phong phong)
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(phong);
                    _context.SaveChanges();
                    var maPhong = phong.maPhong;
                    if (phong.files.Count > 0)
                    {
                        foreach (var file in phong.files)
                        {

                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhphong_" + maPhong);

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

                    return RedirectToAction("BaiDaDang");
                }
                return View(phong);
            }
            return RedirectToAction("Index", "Login");     
        }

        [HttpGet]
        public IActionResult SuaBaiDang(Phong phong)
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                ViewData["Title"] = "Sửa Bài Đăng";
                ViewData["Btn_Value"] = "Sửa";
                ViewData["Action"] = "SuaBaiDang";
                return View("ThemBaiDang");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult SuaBaiDang(Phong phong, string unusedValue = "")
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(phong);
                    var listAnh = _context.tblHinhAnh.Where(p => p.maPhong == phong.maPhong).ToList();
                    _context.tblHinhAnh.RemoveRange(listAnh);
                    _context.SaveChanges();
                    var maPhong = phong.maPhong;
                    if (phong.files.Count > 0)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhphong_" + maPhong);

                        //create folder if not exist
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        else
                        {
                            Directory.Delete(path, true);
                            Directory.CreateDirectory(path);
                        }

                        foreach (var file in phong.files)
                        {
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

                    return RedirectToAction("BaiDaDang");
                }
                return View(phong);
            }
            return RedirectToAction("Index", "Login");  
        }

        [HttpPost]
        public bool XoaBaiDang([FromForm] int maPhong)
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                try
                {
                    var phong = _context.tblPhong.Find(maPhong);
                    var hinhAnhPhong = _context.tblHinhAnh.Where(p => p.maPhong == maPhong).ToList();
                    _context.tblPhong.Remove(phong);
                    _context.tblHinhAnh.RemoveRange(hinhAnhPhong);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }


        [HttpGet]
        public IActionResult BaiDangDaDanhGia(int? pageIndex)
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                int pageSize = 12;
                int maTaiKhoan = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("maTaiKhoan"));
                var listMaPhong = _context.tblDanhGiaPhong.Where(p => p.maTaiKhoan == maTaiKhoan).Select(p => p.maPhong).ToList();
                var listPhong = _context.tblPhong.Where(p => listMaPhong.Contains(p.maPhong)).ToList();
                foreach (var phong in listPhong)
                {
                    var soSao = _context.tblDanhGiaPhong.Where(p => p.maPhong == phong.maPhong && p.maTaiKhoan == maTaiKhoan).Select(p => p.soSao).First();
                    phong.soSaoTrungBinh = soSao;
                }
                return View(Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
            }
            return RedirectToAction("Index", "Login");
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
        public IActionResult BaiDaDang()
        {
            var quyen = checkQuyen();
            if (quyen)
            {
                var listPhong = _context.tblPhong.Where(p => p.maTaiKhoan == Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("maTaiKhoan"))).ToList();
                LayThongTinNguoiDang(listPhong);
                return View(listPhong);
            }
            return RedirectToAction("Index", "Login");
            
        }

        public bool checkQuyen()
        {
            var maTaiKhoan = _httpContextAccessor.HttpContext.Session.GetString("maTaiKhoan");
            if (maTaiKhoan != null)
            {
                return true;
            }
            return false;
        }
    }
}
