namespace ShopPizzaHut.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [Key]
        public int MaNhaCC { get; set; }

        public string TenNhaCC { get; set; }

        public string DiaChiNhaCC { get; set; }

        public long? DienThoaiNhaCC { get; set; }
    }
}
