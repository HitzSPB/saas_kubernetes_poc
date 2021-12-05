using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Domain.Mappers
{
	public class OrderMapper : IOrderMapper
	{
		public Order Create(OrderDto orderDto)
		{
			return new Order()
			{
				Id = orderDto.Id,
				Name = orderDto.Name,
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
				Name = order.Name,
				ProductItems = order.ProductItems
			};
		}
	}
}
