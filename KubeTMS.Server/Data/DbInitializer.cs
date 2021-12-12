using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeTMS.Server.Data
{
    public static class DbInitializer
    {
        public static void Populate(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KubeTMSDbContext>(), env);
            }
        }

        private static void SeedData(KubeTMSDbContext context, IWebHostEnvironment env)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--> Could not run migrations: " + ex.Message);
            }

            if (context.Shipments.Any())
            {
                Console.WriteLine("--> We already have data");
                return;
            }

            Console.WriteLine("--> Seeding data...");

            context.Customers.AddRange(
                new Customer { Name = "ABC Glassware"},
                new Customer { Name = "Maxwell Cabinets" }
            );

            context.Carriers.AddRange(
                new Carrier { Name = "A Duie Pyle", Scac = "PYLE" },
                new Carrier { Name = "Fedex", Scac = "FXFE" },
                new Carrier { Name = "R&L Carriers", Scac = "RLCA" }
            );

            context.Shipments.Add(new Shipment
            {
                Origin = "Little Rock, AR 72211", 
                Destination = "Chicago, IL 60606", 
                WeightInPounds = 1500, 
                PickupDate = DateTime.Now.AddDays(1),
                DeliveryDate = DateTime.Now.AddDays(5),
                Customer = new Customer
                {
                    Name = "Brodkin State University"
                },
                Carrier = new Carrier
                {
                    Name = "Averitt Express", Scac = "AVRT"
                }
            });

            context.SaveChanges();
        }
    }
}
