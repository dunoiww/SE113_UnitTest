namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


  

    [Table("ChiDinhDungThuoc")]
  
    public partial class ChiDinhDungThuoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(5)]
        public string MaPK { get; set; }

        [Key]
        [StringLength(5)]
        public string MaThuoc { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(5)]
        public string MaDonVi { get; set; }

        [StringLength(5)]
        public string MaCachDung { get; set; }

        [StringLength(40)]
        public string GhiChu { get; set; }

        public virtual CachDungThuoc CachDungThuoc { get; set; }

        public virtual DonViThuoc DonViThuoc { get; set; }

        public virtual Thuoc Thuoc { get; set; }

        [ForeignKey("MaPK")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
    }
}
