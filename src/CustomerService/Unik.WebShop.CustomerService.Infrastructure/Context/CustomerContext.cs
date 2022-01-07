using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.CustomerService.Infrastructure.Models;

namespace Unik.WebShop.CustomerService.Infrastructure.Context
{
	public class CustomerContext : DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
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
		public DbSet<CustomerEf> Customers { get; set; }
	}
}
