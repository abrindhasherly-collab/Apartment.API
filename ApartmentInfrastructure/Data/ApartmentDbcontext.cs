using ApartmentDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Data
{
    public class ApartmentDbcontext : DbContext
    {
        public ApartmentDbcontext(DbContextOptions<ApartmentDbcontext> options)
            : base(options)
        {
        }

        public DbSet<ResidentEntity> Residents { get; set; }

        public DbSet<PaymentEntity> Payments { get; set; }

        public DbSet<ComplaintEntity> Complaints { get; set; }

        public DbSet<EmergencyEntity> Emergencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Payment amount precision
            modelBuilder.Entity<PaymentEntity>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}