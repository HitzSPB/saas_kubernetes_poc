using TeamTwo.WebShop.OrderService.Domain.Mappers;
using TeamTwo.WebShop.OrderService.Domain.Services;
using TeamTwo.WebShop.OrderService.Domain.Repository;
using TeamTwo.WebShop.OrderService.Infrastructure.Repository;
using TeamTwo.WebShop.OrderService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TeamTwo.WebShop.OrderService.Infrastructure.Mappers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEfMapper, EfMapper>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDbContext<OrderContext>( options => options.UseSqlServer(configuration.GetConnectionString("Db"), x => x.MigrationsAssembly("TeamTwo.WebShop.OrderService.Infrastructure")));


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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
