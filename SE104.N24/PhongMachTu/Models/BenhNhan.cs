namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BenhNhan()
        {
            ChiTietDS = new HashSet<ChiTietDS>();
            PhieuKhamBenh = new HashSet<PhieuKhamBenh>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaBN { get; set; }

        [Required]
        [StringLength(40)]
        public string FullName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(3)]
        public string Sex { get; set; }

        [StringLength(40)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDS> ChiTietDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKhamBenh> PhieuKhamBenh { get; set; }
    }
}
