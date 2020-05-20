using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UELWeb2Hasako.Models
{
    public class BanChayNhat
    {
        public int MaHS { get; set; }
        public string TenDM { get; set; }
        public string TenHS { get; set; }
        public int DonGia { get; set; }
        public string AnhBia { get; set; }
        public int? HangTon { get; set; }
        public int DaBan { get; set; }
        public static List<BanChayNhat> LaySanPham()
        {
            dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
            List<BanChayNhat> dsHS = new List<BanChayNhat>();
            List<HAISANKHO> ds = data.HAISANKHOs.OrderBy(s => s.Ngaycapnhat).Take(3).ToList();
            foreach (var hs in ds)
            {
                CHITIETDONHANG ct = data.CHITIETDONHANGs.FirstOrDefault(x => x.MaHS==hs.MaHS);
               // int db = 
               // dsHS.Add(new KhuyenMaiTrongTuan() { MaHS = hs.MaHS, TenDM = dm.TenDM, TenHS = hs.TenHS, DonGia = hs.Dongia, AnhBia = hs.Anhbia, PhanTramGiam = pt, GiaKM = km, HangTon = hs.Soluongton, DaBan = db });
            }
            return dsHS;
        }
    }
}