using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopPizzaHut.Models.EF;

namespace ShopPizzaHut.Areas.Admin.Controllers
{
    public class ChucVuNhanVienController : BaseController
    {
        private PizzaHutShopDbContext db = new PizzaHutShopDbContext();

        // GET: Admin/ChucVuNhanVien
        public ActionResult Index()
        {
            return View(db.ChucVuNhanViens.ToList());
        }

        // GET: Admin/ChucVuNhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVuNhanVien chucVuNhanVien = db.ChucVuNhanViens.Find(id);
            if (chucVuNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(chucVuNhanVien);
        }

        // GET: Admin/ChucVuNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChucVuNhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChucVu,TenChucVu")] ChucVuNhanVien chucVuNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.ChucVuNhanViens.Add(chucVuNhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucVuNhanVien);
        }

        // GET: Admin/ChucVuNhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVuNhanVien chucVuNhanVien = db.ChucVuNhanViens.Find(id);
            if (chucVuNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(chucVuNhanVien);
        }

        // POST: Admin/ChucVuNhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChucVu,TenChucVu")] ChucVuNhanVien chucVuNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucVuNhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucVuNhanVien);
        }

        // GET: Admin/ChucVuNhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVuNhanVien chucVuNhanVien = db.ChucVuNhanViens.Find(id);
            if (chucVuNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(chucVuNhanVien);
        }

        // POST: Admin/ChucVuNhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChucVuNhanVien chucVuNhanVien = db.ChucVuNhanViens.Find(id);
            db.ChucVuNhanViens.Remove(chucVuNhanVien);
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
