using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.WebShop.OrderService.Domain.Models
{
	public class ProductItem
	{
		public ProductItem()
		{
		}

		public ProductItem(int id, int productId, string name, decimal price)
		{
			Id = id;
			ProductId = productId;
			Name = name;
			Price = price;
		}

		public int Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}
