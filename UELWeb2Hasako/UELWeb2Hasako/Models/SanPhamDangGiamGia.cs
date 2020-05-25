using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UELWeb2Hasako.Models
{
    public class SanPhamDangGiamGia
    {
        public int MaHS { get; set;  }
        public string TenHS { get; set; }
        public int DonGia { get; set; }
        public string AnhBia { get; set; }
        public int PhanTramGiam { get; set; }
        public double ? GiaKM { get; set;  }
        public static List<SanPhamDangGiamGia> LaySanPham()
        {
            dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
            List<SanPhamDangGiamGia> dsHS = new List<SanPhamDangGiamGia>();
            List<HAISANKHO> ds = data.HAISANKHOs.ToList();
            List<KHUYENMAI> dsKM = data.KHUYENMAIs.ToList();
            //Random rnd = new Random();
            foreach (var spkm in dsKM)
            {
                HAISANKHO hs = data.HAISANKHOs.Where(x=>x.MaHS== spkm.MaHS).FirstOrDefault();
                if (spkm.TinhTrangKM == true)
                {
                    double giakm = Convert.ToDouble(hs.Dongia) * (1 - spkm.PhanTramGiam / 100);
                    dsHS.Add(new SanPhamDangGiamGia() 
                    { MaHS = hs.MaHS, TenHS = hs.TenHS, DonGia = hs.Dongia, AnhBia = hs.Anhbia, PhanTramGiam = spkm.PhanTramGiam, GiaKM = giakm });
                }
                //int pt = rnd.Next(10, 30);
            //    double ptd = Convert.ToDouble(pt);
            //    double dgd = Convert.ToDouble(hs.Dongia);
            //    double km = hs.Dongia * (1 - ptd / 100);
            //    dsHS.Add(new SanPhamDangGiamGia() { MaHS = hs.MaHS, TenHS = hs.TenHS, DonGia = hs.Dongia, AnhBia = hs.Anhbia, PhanTramGiam = pt, GiaKM=km});
            }
            return dsHS;
        }
    }
}