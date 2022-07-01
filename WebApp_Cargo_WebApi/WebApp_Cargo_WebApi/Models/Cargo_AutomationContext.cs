using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Cargo_AutomationContext : DbContext
    {
        public Cargo_AutomationContext()
        {
        }

        public Cargo_AutomationContext(DbContextOptions<Cargo_AutomationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargoes> Cargoes { get; set; }
        public virtual DbSet<Couriers> Couriers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<SupplierCargoDetails> SupplierCargoDetails { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargoes>(entity =>
            {
                entity.HasKey(e => e.CargoId);

                entity.Property(e => e.CargoDescription).HasMaxLength(200);

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.Freight).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.ShippedDate).HasColumnType("date");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Cargoes)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("FK_Cargoes_Couriers");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cargoes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Cargoes_Customers");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.Cargoes)
                    .HasForeignKey(d => d.TransportId)
                    .HasConstraintName("FK_Cargoes_Transports");
            });

            modelBuilder.Entity<Couriers>(entity =>
            {
                entity.HasKey(e => e.CourierId);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            modelBuilder.Entity<SupplierCargoDetails>(entity =>
            {
                entity.HasKey(e => new { e.SupplierId, e.CargoId });

                entity.Property(e => e.SupplyDate).HasColumnType("date");

                entity.Property(e => e.SupplyDescription).HasMaxLength(200);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.SupplierCargoDetails)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierCargoDetails_Cargoes");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierCargoDetails)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierCargoDetails_Suppliers");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Transports>(entity =>
            {
                entity.HasKey(e => e.TransportId);

                entity.Property(e => e.TransportType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
