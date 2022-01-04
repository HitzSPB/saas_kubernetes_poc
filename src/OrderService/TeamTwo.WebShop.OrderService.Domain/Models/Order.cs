using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTwo.WebShop.OrderService.Domain.Models
{
	public class Order
	{
		public Order()
		{

		}
		public Order(int id, int customerId, List<ProductItem> productItems, bool completed)
		{
			Id = id;
			CustomerId = customerId;
			ProductItems = productItems;
			Completed = completed;
		}

		public int Id { get; set; }
		public int CustomerId { get; set; }
		public List<ProductItem> ProductItems { get; set; }
		public bool Completed { get; set; }
	}
}
