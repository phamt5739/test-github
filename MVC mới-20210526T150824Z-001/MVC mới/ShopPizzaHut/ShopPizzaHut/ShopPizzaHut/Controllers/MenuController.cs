using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopPizzaHut.Models.EF;
using System.Collections;

namespace ShopPizzaHut.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using(PizzaHutShopDbContext db = new PizzaHutShopDbContext())
            {
                var loaisp = db.LoaiSPs.ToList();
                Hashtable tenloaisp = new Hashtable();
                foreach(var item in loaisp.OrderByDescending(m=>m.MaLoaiSP))
                {
                    tenloaisp.Add(item.MaLoaiSP, item.TenLoaiSP);
                }
                ViewBag.TenLoaiSP = tenloaisp;
                return PartialView("Index");
            }
        }
    }
}