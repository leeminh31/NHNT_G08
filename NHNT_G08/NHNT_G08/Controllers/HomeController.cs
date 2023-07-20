using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Controllers
{
    public class HomeController : Controller
    {
        private readonly NHNTContext _context;
        public HomeController(NHNTContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? pageIndex)
        {
            int pageSize = 12;
            var listPhong = _context.tblPhong.Where(p=> string.Equals(p.trangThaiBaiDang, "Duyệt")).ToList();
            LaySoSaoTrungBinh(listPhong);
            LayThongTinNguoiDang(listPhong);
            LayHinhAnhPhong(listPhong);
            return View(Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        }

        [HttpGet]
        [Route("/ChiTietPhong/{id:int}")]
        public IActionResult ChiTietPhong(int id)
        {
            var phong = _context.tblPhong.First(p => p.maPhong == id);
            phong.soSaoTrungBinh = LayDanhGiaPhongTheoID(id);
            var listAnh = LayHinhAnhPhongTheoID(id);
            if ( listAnh.Count != 0 )
            {
                phong.tenAnh = new List<string>();
                phong.tenAnh.AddRange(listAnh);
            }
                
            return View(phong);
        }

        [HttpPost]
        public bool DanhGiaBaiDang([FromForm] int soSao, [FromForm] int maPhong, [FromForm] int maTaiKhoan)
        {
            try
            {
                var checkDanhGia = _context.tblDanhGiaPhong.FirstOrDefault(p => p.maPhong == maPhong && p.maTaiKhoan == maTaiKhoan);
            checkDanhGia.soSao = soSao;
            if (checkDanhGia != null)
            {
                _context.Update(checkDanhGia);
            }
            else
            {
                _context.tblDanhGiaPhong.Add(checkDanhGia);
            }
            _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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

        List<Phong> LaySoSaoTrungBinh(List<Phong> listPhong)
        {
            var listDanhGia = _context.tblDanhGiaPhong.GroupBy(t => new { ID = t.maPhong })
                                       .Select(g => new
                                       {
                                           Count = g.Count(),
                                           Average = g.Average(p => p.soSao),
                                           ID = g.Key.ID
                                       });

            foreach (var item in listPhong)
            {
                var danhGiaPhong = listDanhGia.FirstOrDefault(p => p.ID == item.maPhong);
                if (danhGiaPhong != null)
                {
                    item.soSaoTrungBinh = (float)danhGiaPhong.Average;
                    item.soLuotDanhGia = danhGiaPhong.Count;
                }
                else continue;
            }
            return listPhong;
        }

        List<Phong> LayHinhAnhPhong(List<Phong> listPhong)
        {
            foreach (var phong in listPhong)
            {
                var listAnh = _context.tblHinhAnh.Where(p=>p.maPhong == phong.maPhong).Select(p => p.duongDan).ToList();
                
                if(listAnh.Count != 0)
                {
                    phong.tenAnh = new List<string>();
                    phong.tenAnh.AddRange(listAnh);
                }                
            }
            return listPhong;
        }

        List<string> LayHinhAnhPhongTheoID(int id)
        { 
            return _context.tblHinhAnh.Where(p => p.maPhong == id).Select(p=> p.duongDan).ToList(); ;
        }

        int LayDanhGiaPhongTheoID(int id)
        {
            return _context.tblDanhGiaPhong.Where(p => p.maPhong == id).Select(p=> p.soSao).FirstOrDefault();
        }
    }
}
