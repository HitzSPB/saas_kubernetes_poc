using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Mappers
{
	public class CustomerDtoMapper : ICustomerDtoMapper
	{
		public CustomerDto Create(Customer customer)
		{
			return new CustomerDto()
			{
				Id = customer.Id,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Age = customer.Age
			};
		}

		public Customer Map(CustomerDto customerDto)
		{
			return new Customer()
			{
				Id = customerDto.Id,
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				Age = customerDto.Age
			};
		}
	}
}
