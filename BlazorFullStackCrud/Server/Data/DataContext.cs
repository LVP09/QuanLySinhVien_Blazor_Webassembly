using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext :IdentityDbContext<User,Role,Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => e.MaDiem);

                entity.HasIndex(e => e.MonHocMaMh, "IX_Diems_MonHocMaMh");

                entity.HasIndex(e => e.SinhViensMaSv, "IX_Diems_SinhViensMaSV");

                entity.Property(e => e.SinhViensMaSv).HasColumnName("SinhViensMaSV");

                entity.HasOne(d => d.MonHocMaMhNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MonHocMaMh);

                entity.HasOne(d => d.SinhViensMaSvNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.SinhViensMaSv);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.HasIndex(e => e.MaNghanh, "IX_Lops_MaNghanh");

                entity.HasOne(d => d.MaNghanhNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaNghanh);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh);
            });

            modelBuilder.Entity<Nghanh>(entity =>
            {
                entity.HasKey(e => e.MaNghanh);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.HasIndex(e => e.MaLop, "IX_SinhViens_MaLop");

           

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaLop);
            });

          base.OnModelCreating(modelBuilder);
        }
       
        public virtual DbSet<Diem> Diems { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<Nghanh> Nghanhs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
      
    }
}
