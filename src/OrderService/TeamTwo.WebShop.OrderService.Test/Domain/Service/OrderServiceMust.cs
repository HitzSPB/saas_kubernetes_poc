using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.External;
using TeamTwo.WebShop.OrderService.Domain.Mappers;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Domain.Repository;
using TeamTwo.WebShop.OrderService.Domain.Services;
using TeamTwo.WebShop.OrderService.Infrastructure.Context;
using TeamTwo.WebShop.OrderService.Infrastructure.Mappers;
using TeamTwo.WebShop.OrderService.Infrastructure.Repository;
using Xunit;

namespace TeamTwo.WebShop.OrderService.Test.Domain.Service
{
	public class OrderServiceMust
	{
		private readonly IOrderService _sut;
		public OrderServiceMust(IConfiguration configuration)
		{
			var context = new OrderContext(new Microsoft.EntityFrameworkCore.DbContextOptions<OrderContext>());
			var efMapper = new EfMapper();
			IOrderMapper orderMapper = new OrderMapper();
			IOrderRepository orderRepository = new OrderRepository(context, efMapper);
			ICustomerServiceCall customerServiceCall = new CustomerServiceCall(new System.Net.Http.HttpClient(), configuration) ;
			_sut = new OrderService.Domain.Services.OrderService(orderRepository, orderMapper, customerServiceCall);
		}

		[Fact]
		public async Task BeAbleToGetAllOrders()
		{
			// Arrange
			var orderDto = new OrderDto() { Completed = true, Id = 10, CustomerId = 1, ProductItems = new List<ProductItem>() };
			await _sut.CreateOrderAsync(orderDto);

			// Act
			var actual = await _sut.GetAllOrdersAsync();

			// Assert
			Assert.Single(actual);
			Assert.Equal(10, actual.First().Id);
		}
		[Fact]
		public async Task BeAbleToGetAllOrderById()
		{
			// Arrange
			var orderDto = new OrderDto() { Completed = true, Id = 10, CustomerId = 1, ProductItems = new List<ProductItem>() };
			await _sut.CreateOrderAsync(orderDto);

			// Act
			var actual = await _sut.GetOrderByIdAsync(orderDto.Id);

			// Assert
			Assert.Equal(orderDto.Id, actual.Id);
		}
		[Fact]
		public async Task BeAbleToCreateNewOrder()
		{
			// Arrange
			var orderDto = new OrderDto() { Completed = true, Id = 10, CustomerId = 1, ProductItems = new List<ProductItem>() };

			// Act
			var actual = await _sut.CreateOrderAsync(orderDto);

			// Assert
			Assert.Equal(orderDto.Id, actual.Id);
			Assert.NotStrictEqual(orderDto, actual);
		}
		[Fact]
		public async Task BeAbleToUpdateASpecificOrder()
		{
			// Arrange
			var orderDto = new OrderDto() { Completed = true, Id = 10, CustomerId = 1, ProductItems = new List<ProductItem>() };
			await _sut.CreateOrderAsync(orderDto);

			// Act
			orderDto.CustomerId = 1;
			var actual = await _sut.UpdateOrderAsync(orderDto.Id, orderDto);

			// Assert
			Assert.Equal(orderDto.CustomerId, actual.CustomerId);
			Assert.NotStrictEqual(orderDto, actual);
		}
		[Fact]
		public async Task BeAbleToDeleteASpecificOrder()
		{
			// Arrange
			var orderDto = new OrderDto() { Completed = true, Id = 10, CustomerId = 1, ProductItems = new List<ProductItem>() };

			// Act
			await _sut.DeleteOrderAsync(orderDto.Id);

			// Assert
			await Assert.ThrowsAsync<NullReferenceException>(() => _sut.GetOrderByIdAsync(orderDto.Id));
		}
	}
}
