using KubeCustomer.API.Data;
using KubeCustomer.Core.Data;
using KubeCustomer.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("--> Using Connection String: " + builder.Configuration.GetConnectionString("DefaultConnection"));
Console.WriteLine("--> Environment: " + builder.Environment.EnvironmentName);

// Add services to the container.
builder.Services.AddDbContext<KubeCustomerDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Add services to the container.
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

DbInitializer.Populate(app, app.Environment);

app.Run();
