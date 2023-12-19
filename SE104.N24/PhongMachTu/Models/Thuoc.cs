namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            ChiDinhDungThuoc = new HashSet<ChiDinhDungThuoc>();
            ChiTietThongKeThuoc = new HashSet<ChiTietThongKeThuoc>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(40)]
        public string TenThuoc { get; set; }

        [Required]
        [StringLength(40)]
        public string LoaiThuoc { get; set; }

        public int GiaThuoc { get; set; }

        public int TonKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiDinhDungThuoc> ChiDinhDungThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThongKeThuoc> ChiTietThongKeThuoc { get; set; }
    }
}
