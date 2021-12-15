using KubeTMS.Core.Data;
using KubeTMS.Core.Services;
using KubeTMS.Server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("--> Using Connection String: " + builder.Configuration.GetConnectionString("DefaultConnection"));
Console.WriteLine("--> Environment: " + builder.Environment.EnvironmentName);

// Add services to the container.
builder.Services.AddDbContext<KubeTMSDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IShipmentService, ShipmentService>();
builder.Services.AddTransient<ICarrierService, CarrierService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

DbInitializer.Populate(app, app.Environment);

app.Run();
