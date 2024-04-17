using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspdotNetCoreMVCExam.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoUuTien> DoUuTiens { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<YeuCau> YeuCaus { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoUuTien>(entity =>
        {
            entity.HasKey(e => e.Madouutien).HasName("PK__DoUuTien__F830DB59152307AF");

            entity.ToTable("DoUuTien");

            entity.Property(e => e.Madouutien).HasColumnName("madouutien");
            entity.Property(e => e.TendouuTien)
                .HasMaxLength(100)
                .HasColumnName("tendouuTien");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__NhanVien__F3DBC57366B54494");

            entity.ToTable("NhanVien");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hinhanh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Kichhoat).HasColumnName("kichhoat");
            entity.Property(e => e.Ngaysinh).HasColumnName("ngaysinh");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Quyen).HasColumnName("quyen");
        });

        modelBuilder.Entity<YeuCau>(entity =>
        {
            entity.HasKey(e => e.Mayeucau).HasName("PK__YeuCau__F3815ED32BFED99B");

            entity.ToTable("YeuCau");

            entity.Property(e => e.Mayeucau).HasColumnName("mayeucau");
            entity.Property(e => e.Madouutien).HasColumnName("madouutien");
            entity.Property(e => e.ManvGui)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("manv_gui");
            entity.Property(e => e.ManvXuly)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("manv_xuly");
            entity.Property(e => e.Ngaygui).HasColumnName("ngaygui");
            entity.Property(e => e.Noidung)
                .HasMaxLength(1000)
                .HasColumnName("noidung");
            entity.Property(e => e.Tieude)
                .HasMaxLength(150)
                .HasColumnName("tieude");

            entity.HasOne(d => d.MadouutienNavigation).WithMany(p => p.YeuCaus)
                .HasForeignKey(d => d.Madouutien)
                .HasConstraintName("FK__YeuCau__madouuti__4D94879B");

            entity.HasOne(d => d.ManvGuiNavigation).WithMany(p => p.YeuCauManvGuiNavigations)
                .HasForeignKey(d => d.ManvGui)
                .HasConstraintName("FK__YeuCau__manv_gui__4E88ABD4");

            entity.HasOne(d => d.ManvXulyNavigation).WithMany(p => p.YeuCauManvXulyNavigations)
                .HasForeignKey(d => d.ManvXuly)
                .HasConstraintName("FK__YeuCau__manv_xul__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
