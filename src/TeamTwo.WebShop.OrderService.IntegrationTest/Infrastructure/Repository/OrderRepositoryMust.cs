using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Domain.Repository;
using TeamTwo.WebShop.OrderService.Infrastructure.Context;
using TeamTwo.WebShop.OrderService.Infrastructure.Mappers;
using TeamTwo.WebShop.OrderService.Infrastructure.Repository;
using Xunit;
namespace TeamTwo.WebShop.OrderService.IntegrationTest.Infrastructure.Repository
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
			await sut.CreateOrderAsync(new Order(1, "test1", new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(2, "test2", new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(3, "test3", new List<ProductItem>(), true));

			// Act
			var actual = await sut.GetOrderAsync(2);

			Assert.Equal("test2", actual.Name);
		}
		[Fact]
		public async Task BeAbleToCreateOrder()
		{
			// Arrange & Act
			var actual = await sut.CreateOrderAsync(new Order(1, "test1", new List<ProductItem>(), true));

			Assert.Equal("test1", actual.Name);
		}
		[Fact]
		public async Task BeAbleToUpdateOrderById()
		{
			// Arrange
			var targetOrder = new Order(2, "test2", new List<ProductItem>(), true);
			await sut.CreateOrderAsync(new Order(1, "test1", new List<ProductItem>(), true));
			await sut.CreateOrderAsync(targetOrder);
			await sut.CreateOrderAsync(new Order(3, "test3", new List<ProductItem>(), true));

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
			await sut.CreateOrderAsync(new Order(1, "test1", new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(2, "test2", new List<ProductItem>(), true));
			await sut.CreateOrderAsync(new Order(3, "test3", new List<ProductItem>(), true));

			// Act 
			await sut.DeleteOrderAsync(2);
			var actual = await sut.GetAllAsync();
			// Assert
			Assert.Equal(2, actual.Count());
		}
	}
}
