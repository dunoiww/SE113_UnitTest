namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(40)]
        public string TenNV { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(3)]
        public string Sex { get; set; }

        [StringLength(40)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Required]
        [StringLength(20)]
        public string ChucVu { get; set; }

        [Required]
        [StringLength(15)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
