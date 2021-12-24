using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Models
{
	public class ProductItemEf
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price { get; set; }
	}
}
