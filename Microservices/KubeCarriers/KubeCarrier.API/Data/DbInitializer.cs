using KubeCarrier.Core.Data;
using KubeCarrier.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCarrier.API.Data
{
    public static class DbInitializer
    {
        public static void Populate(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KubeCarrierDbContext>(), env);
            }
        }

        private static void SeedData(KubeCarrierDbContext context, IWebHostEnvironment env)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--> Could not run migrations: " + ex.Message);
            }

            if (context.Carriers.Any())
            {
                Console.WriteLine("--> We already have data");
                return;
            }

            Console.WriteLine("--> Seeding data...");

            context.Carriers.AddRange(
                new Carrier { Name = "A Duie Pyle", Scac = "PYLE", SafetyRating = "Safe", IsApproved = true },
                new Carrier { Name = "Fedex", Scac = "FXFE", SafetyRating = "Safe", IsApproved = true },
                new Carrier { Name = "R&L Carriers", Scac = "RLCA", SafetyRating = "Safe", IsApproved = true },
                new Carrier { Name = "Averitt Express", Scac = "AVRT", SafetyRating = "Conditional", IsApproved = false }
            );

            context.SaveChanges();
        }
    }
}
