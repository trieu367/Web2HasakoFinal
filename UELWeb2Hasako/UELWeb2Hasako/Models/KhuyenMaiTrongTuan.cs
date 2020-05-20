using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UELWeb2Hasako.Models
{
    public class KhuyenMaiTrongTuan
    {
        public int MaHS { get; set; }
        public string TenDM { get; set; }
        public string TenHS { get; set; }
        public int DonGia { get; set; }
        public string AnhBia { get; set; }
        public int PhanTramGiam { get; set; }
        public double GiaKM { get; set; }
        public int  ? HangTon { get; set; }
        public int ? DaBan { get; set; }
        public static List<KhuyenMaiTrongTuan> LaySanPham()
        {
            dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
            List<KhuyenMaiTrongTuan> dsHS = new List<KhuyenMaiTrongTuan>();
            List<HAISANKHO> ds = data.HAISANKHOs.OrderBy(s => s.Ngaycapnhat).Take(3).ToList();
            Random rnd = new Random();
            foreach (var hs in ds)
            {
                int pt = rnd.Next(30, 50);
                double ptd = Convert.ToDouble(pt);
                double dgd = Convert.ToDouble(hs.Dongia);
                double km = hs.Dongia * (1 - ptd / 100);
                int? db = 0;
                DANHMUCHAISANKHO dm = data.DANHMUCHAISANKHOs.FirstOrDefault(x => x.MaDM == hs.MaDM);
                if (data.CHITIETDONHANGs.Where(x => x.MaHS == hs.MaHS).FirstOrDefault() != null)
                {
                     db = data.CHITIETDONHANGs.Where(x => x.MaHS == hs.MaHS).Sum(x => x.Soluong);
                }
                else {  db = 0; }
                dsHS.Add(new KhuyenMaiTrongTuan() { MaHS = hs.MaHS, TenDM=dm.TenDM, TenHS = hs.TenHS, DonGia = hs.Dongia, AnhBia = hs.Anhbia, PhanTramGiam = pt, GiaKM = km, HangTon = hs.Soluongton, DaBan=db });
            }
            return dsHS;
        }
    }
}