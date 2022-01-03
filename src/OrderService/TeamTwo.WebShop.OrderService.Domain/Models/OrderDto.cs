﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTwo.WebShop.OrderService.Domain.Models
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ProductItem> ProductItems { get; set; }
		public bool Completed { get; set; }
	}
}