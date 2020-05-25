using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UELWeb2Hasako.Models;

namespace UELWeb2Hasako.Controllers
{
    public class HasakoController : Controller
    {
        // GET: Hasako
        //Võ Nguyễn Tâm An section
        dbHasakoProjectDataContext data = new dbHasakoProjectDataContext();
        
        //Sản phẩm mới 
        private List<HAISANKHO> SanPhamMoiTatCa(int count)
        {
            return data.HAISANKHOs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        private List<HAISANKHO> SanPhamMoiHSK(int count)
        {
            return data.HAISANKHOs.Where(s => s.MaDM != 7).OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        private List<HAISANKHO> SanPhamMoiHSCB(int count)
        {
            return data.HAISANKHOs.Where(s => s.MaDM == 7).OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult IndexHasako()
        {
            ViewBag.Title = "Hasako";
            return View();
        }
        public ActionResult SanPhamMoiTatCa()
        {
            var spmoi = SanPhamMoiTatCa(16);
            return PartialView(spmoi);
        }
        //Sản phẩm mới thuộc danh mục Hải sản khô
        public ActionResult SanPhamMoiHSK()
        {
            var spmoi = SanPhamMoiHSK(16);
            return PartialView(spmoi);
        }
        //Sản phẩm mới thuộc danh mục Hải sản chế biến       
        public ActionResult SanPhamMoiHSCB()
        {
            var spmoi = SanPhamMoiHSCB(16);
            return PartialView(spmoi);
        }
        //chưa code
        public ActionResult SanPhamMoiNhat()
        {
            var sp = SanPhamMoiTatCa(1);
            var spmoi = sp.FirstOrDefault();
            DANHMUCHAISANKHO dm = data.DANHMUCHAISANKHOs.FirstOrDefault(x => x.MaDM == spmoi.MaDM);
            string tendm = dm.TenDM;
            ViewBag.tendm = tendm;
            return PartialView(spmoi);
        }
        //Section danh mục phổ biến
        public ActionResult DanhMucPhoBien()
        {
            List<DANHMUCHAISANKHO> dm = data.DANHMUCHAISANKHOs.Take(6).ToList();
            return PartialView(dm);
        }
        
        //Sản phẩm nổi bật đang khuyến mãi
        public ActionResult KhuyenMaiTrongTuan()
        {
            List <HAISANKHO> hs = data.HAISANKHOs.ToList();
            return PartialView(Models.KhuyenMaiTrongTuan.LaySanPham());
        }
        //Sản phẩm đặc trưng của Hasako
        public ActionResult TopDacTrung()
        {
            var sp = data.HAISANKHOs.OrderByDescending(x => x.Dongia).Take(16);
            return PartialView(sp);
        }
        //Sản phẩm đang giảm giá
        public ActionResult TopDangGiamGia()
        {
            return PartialView(SanPhamDangGiamGia.LaySanPham());
        }
        //Sản phẩm được review tốt, chưa code
        public ActionResult TopDanhGiaTot()
        {
            return PartialView();
        }
        public ActionResult BanChayNhatTop20()
        {
            return PartialView(Models.BanChayNhat.LaySanPham(20));
        }
        public ActionResult BanChayNhatHSK()
        {
            return PartialView(Models.BanChayNhat.LaySanPham(20).Where(x => x.MaDM != 7));
        }
        public ActionResult BanChayNhatHSCB()
        {
            return PartialView(Models.BanChayNhat.LaySanPham(20).Where(x => x.MaDM == 7));
        }
        public ActionResult Banner()
        {
            return PartialView(Models.BanChayNhat.LaySanPham(3));
        }
        //Các bạn sections
        public ActionResult SanPham()
        {
            var sanphammoi = Laysanphammoi(16);
            return View(sanphammoi);
        }
        private List<HAISANKHO> Laysanphammoi(int count)
        {
            return data.HAISANKHOs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult ChiTietSanPham()
        {
            return View();
        }
        public ActionResult GioHang()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult Gioithieu()
        {
            return View();
        }
        public ActionResult Danhmuc()
        {
            var Danhmuc = from dm in data.DANHMUCHAISANKHOs select dm;
            return PartialView(Danhmuc);
        }
        public ActionResult SPTheodanhmuc(int id)
        {
            var sanpham = from s in data.HAISANKHOs where s.MaDM == id select s;
            return View(sanpham);
        }
    }
}