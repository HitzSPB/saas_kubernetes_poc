using Unik.WebShop.OrderService.Domain.Mappers;
using Unik.WebShop.OrderService.Domain.Services;
using Unik.WebShop.OrderService.Domain.Repository;
using Unik.WebShop.OrderService.Infrastructure.Repository;
using Unik.WebShop.OrderService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Unik.WebShop.OrderService.Infrastructure.Mappers;
using Unik.WebShop.OrderService.Domain.External;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEfMapper, EfMapper>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerServiceCall, CustomerServiceCall>();
builder.Services.AddScoped<ICustomerDtoMapper, CustomerDtoMapper>();
builder.Services.AddHttpClient<ICustomerDtoMapper, CustomerDtoMapper>();
var server = configuration.GetValue("Server", "localhost");
var port = configuration.GetValue("Port", "1434");
var database = configuration.GetValue("db","orderservice");
var user = configuration.GetValue("User", "sa");
var password = configuration.GetValue("Password", "SuperSecretPasswordNoOneWilKnow");
var customerServiceBasePath = configuration.GetValue("customerServiceBasepath", "https://localhost:7153/");
builder.Services.AddDbContext<OrderContext>( options => options.UseSqlServer($"Server={server};Initial Catalog={database};User ID ={user};password={password}", x => x.MigrationsAssembly("Unik.WebShop.OrderService.Infrastructure")));

// Logging
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
.WriteTo.Seq(configuration.GetValue("SeqLogging", "http://localhost:5341/")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();
//}



//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
