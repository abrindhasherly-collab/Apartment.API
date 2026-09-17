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

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<ParcelDelivery> ParcelDeliveries { get; set; }

        public DbSet<FlatTransfer> FlatTransfers { get; set; }
    }
}
