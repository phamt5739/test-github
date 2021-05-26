using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopPizzaHut.Models;
using ShopPizzaHut.Models.EF;

namespace ShopPizzaHut.Areas.Admin.Controllers
{
    public class CTHDController : BaseController
    {
        private PizzaHutShopDbContext db = new PizzaHutShopDbContext();

        // GET: Admin/CTHD
        public ActionResult Index(string MaHD)
        {
            using (PizzaHutShopDbContext db = new PizzaHutShopDbContext())
            {
                List<KhachHang> khachhang = db.KhachHangs.ToList();
                List<HoaDon> hoadon = db.HoaDons.ToList();
                List<NhanVien> nhanvien = db.NhanViens.ToList();
                List<SanPham> sanpham = db.SanPhams.ToList();
                List<CTHD> cthd = db.CTHDs.ToList();
                var main = from h in hoadon
                           join k in khachhang on h.MaKH equals k.MaKH
                           where (h.MaHD == MaHD)
                           select new ViewModel
                           {
                               hoadon = h,
                               khachhang = k
                           };
                var sub = from c in cthd
                          join s in sanpham on c.MaSP equals s.MaSP
                          where (c.MaHD == MaHD)
                          select new ViewModel
                          {
                              cthd = c,
                              sanpham = s,
                              Thanhtien = Convert.ToDouble(c.DonGiaBan * c.SoLuong)
                          };
                ViewBag.Main = main;
                ViewBag.Sub = sub;
                return View();
            }
        }

        // GET: Admin/CTHD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHDs.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            return View(cTHD);
        }

        // GET: Admin/CTHD/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: Admin/CTHD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSP,SoLuong,DonGiaBan")] CTHD cTHD)
        {
            if (ModelState.IsValid)
            {
                db.CTHDs.Add(cTHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHD.MaSP);
            return View(cTHD);
        }

        // GET: Admin/CTHD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHDs.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHD.MaSP);
            return View(cTHD);
        }

        // POST: Admin/CTHD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSP,SoLuong,DonGiaBan")] CTHD cTHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaHD", cTHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", cTHD.MaSP);
            return View(cTHD);
        }

        // GET: Admin/CTHD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHDs.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            return View(cTHD);
        }

        // POST: Admin/CTHD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHD cTHD = db.CTHDs.Find(id);
            db.CTHDs.Remove(cTHD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
