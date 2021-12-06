using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Mappers
{
	public class EfMapper : IEfMapper
	{
		public OrderEf Create(Order order)
		{
			var list = new List<ProductItemEf>();
			foreach (var item in order.ProductItems)
			{
				list.Add(CreateProductItemEf(item));
			}
			return new OrderEf()
			{
				Id = order.Id,
				Name = order.Name,
				ProductItems = list,
				Completed = order.Completed
			};
		}

		public Order Map(OrderEf order)
		{
			var list = new List<ProductItem>();
			foreach (var item in order.ProductItems)
			{
				list.Add(CreateProductItem(item));
			}
			return new Order()
			{
				Id = order.Id,
				Completed = order.Completed,
				Name = order.Name,
				ProductItems = list
			};
		}

		private ProductItemEf CreateProductItemEf(ProductItem productItem)
		{
			return new ProductItemEf()
			{
				Id = productItem.Id,
				ProductId = productItem.ProductId,
				Name = productItem.Name,
				Price = productItem.Price,

			};
		}


		private ProductItem CreateProductItem(ProductItemEf productItemEf)
		{
			return new ProductItem()
			{
				Id = productItemEf.Id,
				ProductId = productItemEf.ProductId,
				Name = productItemEf.Name,
				Price = productItemEf.Price,

			};
		}
	}
}
