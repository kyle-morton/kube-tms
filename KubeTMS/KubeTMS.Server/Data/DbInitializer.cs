using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KubeTMS.Server.Data
{
    public static class DbInitializer
    {
        public static async Task Populate(IApplicationBuilder app, IConfiguration config, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                await SeedData(serviceScope.ServiceProvider.GetService<KubeTMSDbContext>(), config, env);
            }
        }

        private static async Task SeedData(KubeTMSDbContext context, IConfiguration config, IWebHostEnvironment env)
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
                return;
            }

            context.Shipments.Add(new Shipment
            {
                Origin = "Little Rock, AR 72211",
                Destination = "Chicago, IL 60606",
                WeightInPounds = 1500,
                PickupDate = DateTime.Now.AddDays(1),
                DeliveryDate = DateTime.Now.AddDays(5),
                CustomerId = 1,
                CarrierId = 1,
            });

            context.SaveChanges();
        }
    }
}
