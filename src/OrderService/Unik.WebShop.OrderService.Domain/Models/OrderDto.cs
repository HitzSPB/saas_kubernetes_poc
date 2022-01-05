using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.WebShop.OrderService.Domain.Models
{
	public class OrderDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public List<ProductItem> ProductItems { get; set; }
		public bool Completed { get; set; }
	}
}
