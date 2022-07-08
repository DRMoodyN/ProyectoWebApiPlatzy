using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Entities;

namespace Models.Configuration
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<CtgAccount> CtgAccounts { get; set; } = null!;
        public virtual DbSet<SeatDetail> SeatDetails { get; set; } = null!;
        public virtual DbSet<SeatHeader> SeatHeaders { get; set; } = null!;
        public virtual DbSet<TypeBook> TypeBooks { get; set; } = null!;
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; } = null!;
        public virtual DbSet<TypeFuente> TypeFuentes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BDAccountingSystem;User=AccountingSystem;Password=AccountingSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business", "Business");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessName).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CtgAccount>(entity =>
            {
                entity.ToTable("CtgAccount", "Accounting");

                entity.HasIndex(e => new { e.Code, e.CtgAccountName }, "U_CtgAccount")
                    .IsUnique();

                entity.Property(e => e.CtgAccountId)
                    .HasColumnName("CtgAccountID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CtgAccountName).HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SubCode).HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.CtgAccounts)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__CtgAccoun__Busin__2B3F6F97");
            });

            modelBuilder.Entity<SeatDetail>(entity =>
            {
                entity.ToTable("SeatDetail", "Accounting");

                entity.Property(e => e.SeatDetailId)
                    .HasColumnName("SeatDetailID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.CtgAccountId).HasColumnName("CtgAccountID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModific)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DebitoOcredito).HasColumnName("DebitoOCredito");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SeatDetailDescription)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeatHeaderId).HasColumnName("SeatHeaderID");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.SeatDetails)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__SeatDetai__Busin__4BAC3F29");

                entity.HasOne(d => d.CtgAccount)
                    .WithMany(p => p.SeatDetails)
                    .HasForeignKey(d => d.CtgAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CtgAccountID_CtgAccount_CtgAccountID");

                entity.HasOne(d => d.SeatHeader)
                    .WithMany(p => p.SeatDetails)
                    .HasForeignKey(d => d.SeatHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_SeatHeaderID_SeatHeader_SeatHeaderID");
            });

            modelBuilder.Entity<SeatHeader>(entity =>
            {
                entity.ToTable("SeatHeader", "Accounting");

                entity.Property(e => e.SeatHeaderId)
                    .HasColumnName("SeatHeaderID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModific)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SeatHeaderCode).HasMaxLength(50);

                entity.Property(e => e.SeatHeaderDescription).HasMaxLength(200);

                entity.Property(e => e.TypeBookId).HasColumnName("TypeBookID");

                entity.Property(e => e.TypeDocumentId).HasColumnName("TypeDocumentID");

                entity.Property(e => e.TypeFuenteId).HasColumnName("TypeFuenteID");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.SeatHeaders)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__SeatHeade__Busin__4222D4EF");

                entity.HasOne(d => d.TypeBook)
                    .WithMany(p => p.SeatHeaders)
                    .HasForeignKey(d => d.TypeBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_TypeBook_TypeBook_TypeBookID");

                entity.HasOne(d => d.TypeDocument)
                    .WithMany(p => p.SeatHeaders)
                    .HasForeignKey(d => d.TypeDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_TypeDocumentID_TypeDocument_TypeDocumentID");

                entity.HasOne(d => d.TypeFuente)
                    .WithMany(p => p.SeatHeaders)
                    .HasForeignKey(d => d.TypeFuenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_TypeFuenteID_TypeFuente_TypeFuenteID");
            });

            modelBuilder.Entity<TypeBook>(entity =>
            {
                entity.ToTable("TypeBook", "Accounting");

                entity.HasIndex(e => new { e.TypeBookCode, e.TypeBookName }, "U_TypeBook")
                    .IsUnique();

                entity.Property(e => e.TypeBookId)
                    .HasColumnName("TypeBookID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeBookCode).HasMaxLength(50);

                entity.Property(e => e.TypeBookName).HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.TypeBooks)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__TypeBook__Busine__3C69FB99");
            });

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.ToTable("TypeDocument", "Accounting");

                entity.HasIndex(e => new { e.TypeDocumentCode, e.TypeDocumentName }, "U_TypeDocument")
                    .IsUnique();

                entity.Property(e => e.TypeDocumentId)
                    .HasColumnName("TypeDocumentID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeDocumentCode).HasMaxLength(50);

                entity.Property(e => e.TypeDocumentName).HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.TypeDocuments)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__TypeDocum__Busin__30F848ED");
            });

            modelBuilder.Entity<TypeFuente>(entity =>
            {
                entity.ToTable("TypeFuente", "Accounting");

                entity.HasIndex(e => new { e.TypeFuenteCode, e.TypeFuenteName }, "U_TypeFuente")
                    .IsUnique();

                entity.Property(e => e.TypeFuenteId)
                    .HasColumnName("TypeFuenteID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeFuenteCode).HasMaxLength(50);

                entity.Property(e => e.TypeFuenteName).HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.TypeFuentes)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK__TypeFuent__Busin__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
