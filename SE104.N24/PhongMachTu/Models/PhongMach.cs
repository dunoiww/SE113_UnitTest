using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PhongMachTu.Database
{
    public partial class PhongMach : DbContext
    {
        public PhongMach()
            : base("name=PhongMach")
        {
        }

        public virtual DbSet<BenhNhan> BenhNhan { get; set; }
        public virtual DbSet<CachDungThuoc> CachDungThuoc { get; set; }
        public virtual DbSet<ChiDinhDungThuoc> ChiDinhDungThuoc { get; set; }
        public virtual DbSet<ChiTietDS> ChiTietDS { get; set; }
        public virtual DbSet<ChiTietThongKeThuoc> ChiTietThongKeThuoc { get; set; }
        public virtual DbSet<DanhSachKhamBenh> DanhSachKhamBenh { get; set; }
        public virtual DbSet<DonViThuoc> DonViThuoc { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhieuKhamBenh> PhieuKhamBenh { get; set; }
        public virtual DbSet<QuyDinh> QuyDinh { get; set; }
        public virtual DbSet<ThongKeThuoc> ThongKeThuoc { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaBN)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.ChiTietDS)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.PhieuKhamBenh)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CachDungThuoc>()
                .Property(e => e.MaCachDung)
                .IsUnicode(false);

            modelBuilder.Entity<ChiDinhDungThuoc>()
                .Property(e => e.MaPK)
                .IsUnicode(false);

            modelBuilder.Entity<ChiDinhDungThuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ChiDinhDungThuoc>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<ChiDinhDungThuoc>()
                .Property(e => e.MaCachDung)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDS>()
                .Property(e => e.MaDS)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDS>()
                .Property(e => e.MaBN)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThongKeThuoc>()
                .Property(e => e.MaTKThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietThongKeThuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachKhamBenh>()
                .Property(e => e.MaDS)
                .IsUnicode(false);

            modelBuilder.Entity<DonViThuoc>()
                .Property(e => e.MaDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaPK)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhamBenh>()
                .Property(e => e.MaPK)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhamBenh>()
                .Property(e => e.MaBN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhamBenh>()
                .HasMany(e => e.HoaDon)
                .WithRequired(e => e.PhieuKhamBenh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyDinh>()
                .Property(e => e.MaQD)
                .IsFixedLength();

            modelBuilder.Entity<ThongKeThuoc>()
                .Property(e => e.MaTKThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.ChiDinhDungThuoc)
                .WithRequired(e => e.Thuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.ChiTietThongKeThuoc)
                .WithRequired(e => e.Thuoc)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ChiDinhDungThuoc>()
            .HasKey(c => new { c.MaPK, c.MaThuoc });

            modelBuilder.Entity<ChiTietDS>()
            .HasKey(c => new { c.MaDS, c.MaBN });

            modelBuilder.Entity<ChiTietThongKeThuoc>()
           .HasKey(c => new { c.MaTKThuoc, c.MaThuoc });
        }

    }
}
