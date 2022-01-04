using TeamTwo.WebShop.OrderService.Domain.Mappers;
using TeamTwo.WebShop.OrderService.Domain.Services;
using TeamTwo.WebShop.OrderService.Domain.Repository;
using TeamTwo.WebShop.OrderService.Infrastructure.Repository;
using TeamTwo.WebShop.OrderService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TeamTwo.WebShop.OrderService.Infrastructure.Mappers;
using TeamTwo.WebShop.OrderService.Domain.External;

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
var customerServiceBasePath = configuration.GetValue("customerServiceBasepath", "SuperSecretPasswordNoOneWilKnow");
builder.Services.AddDbContext<OrderContext>( options => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};password={password}", x => x.MigrationsAssembly("TeamTwo.WebShop.OrderService.Infrastructure")));


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
