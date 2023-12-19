namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachKhamBenh")]
    public partial class DanhSachKhamBenh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaDS { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayKham { get; set; }

        public int? SoLuong { get; set; }
    }
}
