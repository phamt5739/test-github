namespace ShopPizzaHut.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(5)]
        public string MaSP { get; set; }

        public string TenSP { get; set; }

        public int? MaLoaiSP { get; set; }

        public string ChiTietSP { get; set; }

        [StringLength(50)]
        public string Donvitinh { get; set; }

        public double? Dongia { get; set; }

        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }
    }
}
