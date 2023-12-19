namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPK { get; set; }

        public DateTime NgayLap { get; set; }

        public int TienKham { get; set; }

        public int TienThuoc { get; set; }

        public int TongTienThanhToan { get; set; }

        public int TrangThai { get; set; }
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
    }
}
