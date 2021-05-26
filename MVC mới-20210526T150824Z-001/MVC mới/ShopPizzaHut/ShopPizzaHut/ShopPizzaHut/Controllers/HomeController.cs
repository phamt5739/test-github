using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShopPizzaHut.Models;
using ShopPizzaHut.Models.EF;

namespace ShopPizzaHut.Controllers
{
    public class HomeController : Controller
    {
        PizzaHutShopDbContext db = new PizzaHutShopDbContext();
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSP);
            return View(sanPhams.ToList());
        }
    }
}