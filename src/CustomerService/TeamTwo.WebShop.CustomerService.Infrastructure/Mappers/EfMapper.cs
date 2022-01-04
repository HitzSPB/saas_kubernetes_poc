﻿using System;
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
		public CustomerEf Create(Customer customer)
		{
			return new CustomerEf()
			{
				Id = customer.Id,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Age = customer.Age
			};
		}

		public Customer Map(CustomerEf customerEf)
		{
			return new Customer()
			{
				Id = customerEf.Id,
				FirstName = customerEf.FirstName,
				LastName = customerEf.LastName,
				Age = customerEf.Age
			};
		}
	}
}