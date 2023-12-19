namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTietDS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public string MaDS { get; set; }

        [Key]
        [StringLength(5)]
        public string MaBN { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [ForeignKey("MaDS")]
        public virtual DanhSachKhamBenh DanhSachKhamBenh { get; set; }
        public virtual BenhNhan BenhNhan { get; set; }
    }
}
