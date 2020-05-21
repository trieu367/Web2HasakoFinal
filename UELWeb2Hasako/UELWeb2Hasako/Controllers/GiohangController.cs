using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UELWeb2Hasako.Models;
namespace UELWeb2Hasako.Controllers
{
    public class GiohangController : Controller
    {
        // GET: Giohang
        //Tao doi tuong data chua du lieu tu Models
        dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                //Neu gio hang chua ton tai thi khoi tao lstGiohang
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        //Them hang vao gio
        public ActionResult ThemGiohang(int iMahaisan, string strURL)
        {
            //Lay session gio hang
            List<Giohang> lstGiohang = Laygiohang();
            //Kiem tra session da ton tai trong Session["Giohang"] chua?
            Giohang sanpham = lstGiohang.Find(n => n.iMahaisan == iMahaisan);
            if (sanpham == null)
            {
                sanpham = new Giohang(iMahaisan);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        //Tong so luong
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongsoluong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongsoluong;
        }

        //Tomg tien
        private double TongTien()
        {
            double iTongtien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongtien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }
        //Xay dung trang gio hang
    
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
            {
                //return RedirectToAction("IndexHasako", "Hasako");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.TongTien = TongTien();
            return View(lstGiohang);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
