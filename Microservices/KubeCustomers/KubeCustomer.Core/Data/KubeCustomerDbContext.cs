using KubeCustomer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCustomer.Core.Data
{
    public class KubeCustomerDbContext : DbContext
    {
        public KubeCustomerDbContext(DbContextOptions<KubeCustomerDbContext> opt) : base(opt)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
