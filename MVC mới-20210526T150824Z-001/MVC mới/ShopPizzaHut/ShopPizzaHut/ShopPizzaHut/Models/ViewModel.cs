using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ShopPizzaHut.Models.EF;

namespace ShopPizzaHut.Models
{
    public class ViewModel
    {
        public KhachHang khachhang { get; set; }
        public CTHD cthd { get; set; }
        public HoaDon hoadon { get; set; }
        public LoaiSP loaisp { get; set; }
        public NhanVien nhanvien { get; set; }
        public SanPham sanpham { get; set; }
        [DisplayFormat(DataFormatString ="{0:0.##0}")]
        public double Thanhtien { get; set; }
    }
}