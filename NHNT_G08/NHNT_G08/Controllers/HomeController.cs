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
        public HomeController( NHNTContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageIndex)
        {
            int pageSize = 12;
            return View(Pagination<Phong>.Create(await LaySoSaoTrungBinh(5), pageIndex ?? 1,pageSize));
        }

        public async Task<IActionResult> DanhGia (int? pageIndex)
        {
            int pageSize = 12;
            return View(Pagination<Phong>.Create(await LaySoSaoTrungBinh(5), pageIndex ?? 1, pageSize));
        }

        async Task<List<Phong>> LaySoSaoTrungBinh(int? soSao)
        {
            //var query = from danhgia in _context.tblDanhGiaPhong
            //            group danhgia by danhgia.maPhong into groupings
            //            let total = groupings.Sum(p => p.soSao)
            //            let number = groupings.Count()
            //            let average = Math.Round((decimal)total / number)
            //            select new
            //            {
            //                maPhong = groupings.Key,
            //                Summary = new
            //                {
            //                    Total = total,
            //                    Number = number,
            //                    Average = average
            //                }
            //            };

            

            var listMaPhong = _context.tblDanhGiaPhong.Where(p => p.soSao == soSao).Select(p => p.maPhong).ToList();
            return await _context.tblPhong.Where(x => listMaPhong.Contains(x.maPhong)).ToListAsync();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
