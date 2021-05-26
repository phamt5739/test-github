namespace ShopPizzaHut.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGiaBan { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
