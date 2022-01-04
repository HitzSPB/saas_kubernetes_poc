using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Mappers;
using TeamTwo.WebShop.OrderService.Domain.Models;
using Xunit;
namespace TeamTwo.WebShop.OrderService.Test.Domain.Mappers
{
	public class OrderMapperMust
	{
		[Fact]
		public void BeAbleToMapToDto()
		{
			IOrderMapper sut = new OrderMapper();
			var actual = sut.Map(new Order(10, 2, new List<ProductItem>(), true));
			Assert.NotNull(actual);
		}
		[Fact]
		public void BeAbleToMapToDomainObject()
		{
			IOrderMapper sut = new OrderMapper();
			var actual = sut.Create(new OrderDto() { Completed = true, Id = 10, CustomerId = 2, ProductItems = new List<ProductItem>()});
			Assert.NotNull(actual);
		}
	}
}
