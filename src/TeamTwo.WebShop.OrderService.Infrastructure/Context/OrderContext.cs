
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Context
{
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				// Use the entity name instead of the Context.DbSet<T> name
				// refs https://docs.microsoft.com/en-us/ef/core/modeling/relational/tables#conventions
				modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
			}
		}
		public DbSet<OrderEf> Orders { get; set; }
	}
}
