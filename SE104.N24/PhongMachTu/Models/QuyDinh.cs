namespace PhongMachTu.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyDinh")]
    public partial class QuyDinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(20)]
        public string MaQD { get; set; }

        [Required]
        [StringLength(100)]
        public string TenQD { get; set; }

        [Required]
        [StringLength(50)]
        public string GiaTri { get; set; }
    }
}
