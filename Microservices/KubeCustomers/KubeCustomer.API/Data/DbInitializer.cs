using KubeCustomer.Core.Data;
using KubeCustomer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCustomer.API.Data
{
    public static class DbInitializer
    {
        public static void Populate(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KubeCustomerDbContext>(), env);
            }
        }

        private static void SeedData(KubeCustomerDbContext context, IWebHostEnvironment env)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--> Could not run migrations: " + ex.Message);
            }

            if (context.Customers.Any())
            {
                Console.WriteLine("--> We already have data");
                return;
            }

            Console.WriteLine("--> Seeding data...");

            context.Customers.AddRange(
                new Customer { Name = "ABC Glassware", CustomerNumber = "ABC123", SpendingLimit = 50000m },
                new Customer { Name = "Maxwell Cabinets", CustomerNumber = "MAX444", SpendingLimit = 100000m },
                new Customer { Name = "Brodkin State University", CustomerNumber = "BSU111" }
            );

            context.SaveChanges();
        }
    }
}
