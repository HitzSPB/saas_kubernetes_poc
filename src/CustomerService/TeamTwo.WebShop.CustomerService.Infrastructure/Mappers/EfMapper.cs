using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.CustomerService.Domain.Models;
using TeamTwo.WebShop.CustomerService.Infrastructure.Models;

namespace TeamTwo.WebShop.CustomerService.Infrastructure.Mappers
{
	public class EfMapper : IEfMapper
	{
		public CustomerEf Create(Customer order)
		{
			return new CustomerEf()
			{
				Id = order.Id,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Age = order.Age
			};
		}

		public Customer Map(CustomerEf order)
		{
			return new Customer()
			{
				Id = order.Id,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Age = order.Age
			};
		}
	}
}