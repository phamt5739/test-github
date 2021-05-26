using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopPizzaHut.Models;
using ShopPizzaHut.Models.EF;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ShopPizzaHut.Controllers
{
    public class GiohangController : Controller
    {
        private PizzaHutShopDbContext db = new PizzaHutShopDbContext();
        // GET: Giohang
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }
        //khai bao phuong thuc them san pham vao gio hang
        public RedirectToRouteResult AddToCart(string MaSP)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CartItem>();
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            //kiem tra san pham khach dang chon co trong gio hang chua
            if (giohang.FirstOrDefault(m => m.MaSP == MaSP) == null)//chua co trong gio hang
            {
                SanPham sp = db.SanPhams.Find(MaSP);
                CartItem newItem = new CartItem();
                newItem.MaSP = MaSP;
                newItem.TenSP = sp.TenSP;
                newItem.SoLuong = 1;
                newItem.DonGia = Convert.ToDouble(sp.Dongia);
                giohang.Add(newItem);
            }
            else//san pham da co trong gio thi se +1 so luong
            {
                CartItem cardItem = giohang.FirstOrDefault(m => m.MaSP == MaSP);
                cardItem.SoLuong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Update(string MaSP, int txtSoluong)
        {
            //tim cartItem muon xoa
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem item = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if (item != null)
            {
                item.SoLuong = txtSoluong;
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult DelCartItem(string MaSP)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem item = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if (item != null)
            {
                giohang.Remove(item);
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }
        public JsonResult SendMailToUser(string Email)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            string sMsg = "<html><body><table border='1'><caption>Thông tin đặt hàng</caption><tr><th>STT</th><th>Tên hàng</th><th>Số lượng</th><th>Đơn giá</th><th>Thành tiền</th></tr>";
            int i = 0;
            double tongtien = 0;
            foreach (CartItem item in giohang)
            {
                i++;
                sMsg += "<tr>";
                sMsg += "<td>" + i.ToString() + "</td>";
                sMsg += "<td>" + item.TenSP + "</td>";
                sMsg += "<td>" + item.SoLuong.ToString() + "</td>";
                sMsg += "<td>" + String.Format("{0:#,###}", item.DonGia) + "</td>";
                sMsg += "<td>" + String.Format("{0:#,###}", item.SoLuong * item.DonGia) + "</td>";
                sMsg += "</tr>";
                tongtien += item.SoLuong * item.DonGia;
            }
            sMsg += "<tr><th colspan='5'>Tổng cộng: " + String.Format("{0:#,### vnđ}", tongtien) + "</th></tr></table></body></html>";
            bool result = false;
            result = SendEmail(Email, "Thông tin đặt hàng", sMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}