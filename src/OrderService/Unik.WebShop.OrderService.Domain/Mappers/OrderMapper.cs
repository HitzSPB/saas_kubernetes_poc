using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.OrderService.Domain.Models;

namespace Unik.WebShop.OrderService.Domain.Mappers
{
	public class OrderMapper : IOrderMapper
	{
		public Order Create(OrderDto orderDto)
		{
			return new Order()
			{
				Id = orderDto.Id,
				CustomerId = orderDto.CustomerId,
				ProductItems = orderDto.ProductItems,
				Completed = orderDto.Completed
			};
		}

		public OrderDto Map(Order order)
		{
			return new OrderDto()
			{
				Id = order.Id,
				Completed = order.Completed,
				CustomerId = order.CustomerId,
				ProductItems = order.ProductItems
			};
		}
	}
}
