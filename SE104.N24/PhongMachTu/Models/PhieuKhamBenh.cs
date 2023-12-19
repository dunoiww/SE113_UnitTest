namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKhamBenh")]
    public partial class PhieuKhamBenh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKhamBenh()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaPK { get; set; }

        [Required]
        [StringLength(5)]
        public string MaBN { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [Required]
        [StringLength(50)]
        public string TrieuChung { get; set; }

        [Required]
        [StringLength(50)]
        public string DuDoan { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
