using KubeCustomer.API.Data;
using KubeCustomer.Core.Data;
using KubeCustomer.Core.GraphQL;
using KubeCustomer.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("--> Using Connection String: " + builder.Configuration.GetConnectionString("DefaultConnection"));
Console.WriteLine("--> Environment: " + builder.Environment.EnvironmentName);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<KubeCustomerDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddDbContext<KubeCustomerDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// GQL Setup
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<CustomerType>()
    .AddFiltering()
    .AddSorting()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());

// Add services to the container.
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

DbInitializer.Populate(app, app.Environment);

app.UseGraphQLVoyager(new GraphQL.Server.Ui.Voyager.VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

app.Run();
