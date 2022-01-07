using Microsoft.EntityFrameworkCore;
using Unik.WebShop.CustomerService.Domain.Mappers;
using Unik.WebShop.CustomerService.Domain.Repositories;
using Unik.WebShop.CustomerService.Domain.Services;
using Unik.WebShop.CustomerService.Infrastructure.Context;
using Unik.WebShop.CustomerService.Infrastructure.Mappers;
using Unik.WebShop.CustomerService.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Logging
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
.WriteTo.Seq(configuration.GetValue("SeqLogging", "http://localhost:5341/")));

// Add services to the container.
builder.Services.AddScoped<ICustomerMapper, CustomerMapper>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEfMapper, EfMapper>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
var server = configuration.GetValue("Server", "localhost");
var port = configuration.GetValue("Port", "1433");
var database = configuration.GetValue("db", "customerservice");
var user = configuration.GetValue("User", "sa");
var password = configuration.GetValue("Password", "SuperSecretPasswordNoOneWilKnow");
//builder.Services.AddDbContext<CustomerContext>(options => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};password={password}", x => x.MigrationsAssembly("Unik.WebShop.CustomerService.Infrastructure")));
builder.Services.AddDbContext<CustomerContext>(options => options.UseSqlServer($"Server={server};Initial Catalog={database};User ID ={user};password={password}", x => x.MigrationsAssembly("Unik.WebShop.CustomerService.Infrastructure")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
