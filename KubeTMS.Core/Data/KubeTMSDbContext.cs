﻿using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeTMS.Core.Data
{
    public class KubeTMSDbContext : DbContext
    {
        public KubeTMSDbContext(DbContextOptions<KubeTMSDbContext> opt) : base(opt)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
    }
}
