using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLTV_test.Models
{
    public partial class QLTVModel : DbContext
    {
        public QLTVModel()
            : base("name=QLTVEntities")
        {
        }

        public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public virtual DbSet<LoaiDocGia> LoaiDocGias { get; set; }
        public virtual DbSet<LoaiNguoiDung> LoaiNguoiDungs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhieuMuonSach> PhieuMuonSaches { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheDocGia> TheDocGias { get; set; }
        public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }
        public virtual DbSet<TinhTrangSach> TinhTrangSaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiDocGia>()
                .Property(e => e.TenLoaiDG)
                .IsFixedLength();

            modelBuilder.Entity<LoaiDocGia>()
                .HasMany(e => e.TheDocGias)
                .WithOptional(e => e.LoaiDocGia1)
                .HasForeignKey(e => e.LoaiDocGia);

            modelBuilder.Entity<LoaiNguoiDung>()
                .Property(e => e.TenLoaiND)
                .IsFixedLength();

            modelBuilder.Entity<LoaiNguoiDung>()
                .HasMany(e => e.NguoiDungs)
                .WithOptional(e => e.LoaiNguoiDung1)
                .HasForeignKey(e => e.LoaiNguoiDung);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<TheDocGia>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<TheDocGia>()
                .HasMany(e => e.PhieuMuonSaches)
                .WithOptional(e => e.TheDocGia)
                .HasForeignKey(e => e.MaTheDocGia);

            modelBuilder.Entity<TheLoaiSach>()
                .HasMany(e => e.ChiTietPhieuMuons)
                .WithOptional(e => e.TheLoaiSach)
                .HasForeignKey(e => e.MaTheLoai);

            modelBuilder.Entity<TheLoaiSach>()
                .HasMany(e => e.Saches)
                .WithOptional(e => e.TheLoaiSach)
                .HasForeignKey(e => e.TheLoai);

            modelBuilder.Entity<TinhTrangSach>()
                .HasMany(e => e.Saches)
                .WithOptional(e => e.TinhTrangSach)
                .HasForeignKey(e => e.TinhTrang);
        }
    }
}
