using KubeCarrier.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCarrier.Core.Data
{
    public class KubeCarrierDbContext : DbContext
    {
        public KubeCarrierDbContext(DbContextOptions<KubeCarrierDbContext> opt) : base(opt)
        {
        }

        public DbSet<Carrier> Carriers { get; set; }
    }
}
