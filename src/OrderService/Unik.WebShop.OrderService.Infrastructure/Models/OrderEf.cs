using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.WebShop.OrderService.Infrastructure.Models
{
	public class OrderEf
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public List<ProductItemEf> ProductItems { get; set; }
		public bool Completed { get; set; }
	}
}
