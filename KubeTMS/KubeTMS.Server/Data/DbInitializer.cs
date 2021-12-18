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

            //Console.WriteLine("--> Pulling customers/carriers...");

            var url = config["ApiUrls:Customers"] + "customers";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    var customerFromMicroservice = JsonSerializer.Deserialize<List<Customer>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var existingIds = await context.Customers.Select(c => c.ExternalId).ToListAsync();
                    foreach (var customer in customerFromMicroservice.Where(c => !existingIds.Contains(c.Id)))
                    {
                        customer.ExternalId = customer.Id;
                        customer.Id = 0;
                        context.Customers.Add(customer);
                    }
                }
            }

            url = config["ApiUrls:Carriers"] + "carriers";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    var carriersFromMicroservice = JsonSerializer.Deserialize<List<Carrier>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var existingIds = await context.Customers.Select(c => c.ExternalId).ToListAsync();
                    foreach (var carrier in carriersFromMicroservice.Where(c => !existingIds.Contains(c.Id)))
                    {
                        carrier.ExternalId = carrier.Id;
                        carrier.Id = 0;
                        context.Carriers.Add(carrier);
                    }
                }
            }

            if (!context.Shipments.Any())
            {
                context.Shipments.Add(new Shipment
                {
                    Origin = "Little Rock, AR 72211",
                    Destination = "Chicago, IL 60606",
                    WeightInPounds = 1500,
                    PickupDate = DateTime.Now.AddDays(1),
                    DeliveryDate = DateTime.Now.AddDays(5),
                    CustomerId = 1,
                    CarrierId = 1
                });
            }

            context.SaveChanges();
        }
    }
}
