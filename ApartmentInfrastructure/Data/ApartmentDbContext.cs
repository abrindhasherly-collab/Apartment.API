using ApartmentDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Data
{
    public class ApartmentDbContext : DbContext
    {
        public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flat> Flats { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        public DbSet<Parking> Parkings { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Flat configuration
            modelBuilder.Entity<Flat>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FlatNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.FlatType)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.Status)
                      .IsRequired();
            });

            // Maintenance configuration
            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Amount)
                      .HasPrecision(18, 2);

                entity.Property(x => x.Status)
                      .IsRequired();

                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Parking configuration
            modelBuilder.Entity<Parking>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.SlotNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.VehicleNumber)
                      .HasMaxLength(20);

                entity.Property(x => x.Status)
                      .IsRequired();

                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Staff configuration
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.Phone)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(x => x.JobRole)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(x => x.Status)
                      .IsRequired();
            });
        }
    }
}
