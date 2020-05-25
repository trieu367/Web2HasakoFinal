using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UELWeb2Hasako.Models
{
    public class BanChayNhat
    {
        public int MaHS { get; set; }
        public int MaDM { get; set; }
        public string MoTa { get; set; }
        public string TenDM { get; set; }
        public string TenHS { get; set; }
        public int DonGia { get; set; }
        public string AnhBia { get; set; }
        public int? HangTon { get; set; }
        public int ? DaBan { get; set; }
        public static List<BanChayNhat> LaySanPham(int count)
        {
            dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
            List<BanChayNhat> dsHS = new List<BanChayNhat>();
            List<HAISANKHO> ds = data.HAISANKHOs.ToList();
            List<CHITIETDONHANG> ct = data.CHITIETDONHANGs.ToList();

            foreach (var hs in ds)
            {
                DANHMUCHAISANKHO dm = data.DANHMUCHAISANKHOs.FirstOrDefault(x => x.MaDM == hs.MaDM);
                int ? sum = 0; 
                foreach (var c in ct)
                {
                    if (c.MaHS==hs.MaHS)
                    {
                        sum += c.Soluong;
                    }
                }
               dsHS.Add(new BanChayNhat() { MaHS = hs.MaHS,MaDM=dm.MaDM, TenDM = dm.TenDM, TenHS = hs.TenHS, DonGia = hs.Dongia, AnhBia = hs.Anhbia, HangTon = hs.Soluongton, DaBan = sum , MoTa=hs.Mota});
            }
            return dsHS.OrderByDescending(x=>x.DaBan).Take(count).ToList();
        }
    }
}