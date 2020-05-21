using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UELWeb2Hasako.Models;
namespace UELWeb2Hasako.Models
{
    public class Giohang
    {
        dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
        public int iMahaisan { get; set; }
        public string sTenhaisan { get; set; }
        public string sAnhbia { get; set; }
        public Double dDongia { get; set; }
        public int iSoluong { get; set; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        //Khoi tao theo ma hang duoc truyen vao voi so luong mac dinh la 1
        public Giohang(int Mahaisan)
        {
            iMahaisan = Mahaisan;
            HAISANKHO haisan = data.HAISANKHOs.Single(n => n.MaHS == iMahaisan);
            sTenhaisan = haisan.TenHS;
            sAnhbia = haisan.Anhbia;
            dDongia = double.Parse(haisan.Dongia.ToString());
            iSoluong = 1;

        }
    }
}
