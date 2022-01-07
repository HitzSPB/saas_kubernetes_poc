using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.CustomerService.Domain.Models;

namespace Unik.WebShop.CustomerService.Domain.Mappers
{
	public class CustomerMapper : ICustomerMapper
	{
		public Customer Create(CustomerDto orderDto)
		{
			return new Customer()
			{
				Id = orderDto.Id,
				FirstName = orderDto.FirstName,
				LastName = orderDto.LastName,
				Age = orderDto.Age
			};
		}

		public CustomerDto Map(Customer order)
		{
			return new CustomerDto()
			{
				Id = order.Id,
				FirstName = order.FirstName,
				LastName = order.LastName,
				Age = order.Age
			};
		}
	}
}