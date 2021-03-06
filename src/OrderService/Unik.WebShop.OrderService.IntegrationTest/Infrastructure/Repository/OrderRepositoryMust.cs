using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Domain.Repository;
using Unik.WebShop.OrderService.Infrastructure.Context;
using Unik.WebShop.OrderService.Infrastructure.Mappers;
using Unik.WebShop.OrderService.Infrastructure.Repository;
using Xunit;
namespace Unik.WebShop.OrderService.IntegrationTest.Infrastructure.Repository
{
	public class OrderRepositoryMust
	{
		private readonly IOrderRepository sut;
		public OrderRepositoryMust()
		{
			var context = new OrderContext(new Microsoft.EntityFrameworkCore.DbContextOptions<OrderContext>());
			var efMapper = new EfMapper();
			sut = new OrderRepository(context, efMapper);
		}

		[Fact]
		public async Task BeAbleTogetAllOrders()
		{
			// Arrange
			await sut.CreateOrderAsync(new Order());
			await sut.CreateOrderAsync(new Order());
			await sut.CreateOrderAsync(new Order());

			// Act
			var actual = await sut.GetAllAsync();

			Assert.Equal(3, actual.Count());
		}
		[Fact]
		public async Task BeAbleTogetOrderById()
		{
			// Arrange
			await sut.CreateOrderAsync(new Order(1, 1, new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(2, 2, new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(3, 3, new List<ProductItem>(), true));

			// Act
			var actual = await sut.GetOrderAsync(2);

			Assert.Equal(2, actual.CustomerId);
		}
		[Fact]
		public async Task BeAbleToCreateOrder()
		{
			// Arrange & Act
			var actual = await sut.CreateOrderAsync(new Order(1, 1, new List<ProductItem>(), true));

			Assert.Equal(1, actual.CustomerId);
		}
		[Fact]
		public async Task BeAbleToUpdateOrderById()
		{
			// Arrange
			var targetOrder = new Order(2, 2, new List<ProductItem>(), true);
			await sut.CreateOrderAsync(new Order(1, 1, new List<ProductItem>(), true));
			await sut.CreateOrderAsync(targetOrder);
			await sut.CreateOrderAsync(new Order(3, 3, new List<ProductItem>(), true));

			// Act
			var newOrder = targetOrder;
			newOrder.Completed = false;
			var actual = await sut.UpdateOrder(2, newOrder);

			Assert.False(actual.Completed);
		}

		[Fact]
		public async Task BeAbleToDeleteOrder()
		{
			// Arrange
			await sut.CreateOrderAsync(new Order(1, 1, new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(2, 2, new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(3, 3, new List<ProductItem>(), true));

			// Act 
			await sut.DeleteOrderAsync(2);
			var actual = await sut.GetAllAsync();
			// Assert
			Assert.Equal(2, actual.Count());
		}
	}
}
