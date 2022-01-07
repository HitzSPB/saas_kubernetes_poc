using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.CustomerService.Domain.Models;
using Unik.WebShop.CustomerService.Domain.Repositories;
using Unik.WebShop.CustomerService.Infrastructure.Context;
using Unik.WebShop.CustomerService.Infrastructure.Mappers;

namespace Unik.WebShop.CustomerService.Infrastructure.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly CustomerContext _customerContext;
		private readonly IEfMapper _efMapper;
		public CustomerRepository(CustomerContext customerContext, IEfMapper efMapper)
		{
			_customerContext = customerContext;
			_efMapper = efMapper;
		}

		public async Task<IEnumerable<Customer>> GetAllAsync()
		{
			var list = new List<Customer>();
			foreach (var customer in _customerContext.Customers)
			{
				list.Add(_efMapper.Map(customer));
			}
			return await Task.FromResult(list);
		}

		public async Task<Customer> GetCustomerAsync(int id)
		{
			var customerEf = await _customerContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
			if(customerEf != null)
			{
				return _efMapper.Map(customerEf);
			}
			return null;
		}
		public async Task<Customer> CreateCustomerAsync(Customer customer)
		{
			var storedObject = await _customerContext.Customers.AddAsync(_efMapper.Create(customer));
			await _customerContext.SaveChangesAsync();
			return _efMapper.Map(storedObject.Entity);
		}

		public async Task<Customer> UpdateCustomer(int id, Customer customer)
		{
			var customerEf = await _customerContext.Customers.FirstOrDefaultAsync(o => o.Id == id);
			customerEf = _efMapper.Create(customer);
			await _customerContext.SaveChangesAsync();
			return await Task.FromResult(customer);
		}

		public async Task DeleteCustomerAsync(int id)
		{
			await Task.FromResult(_customerContext.Customers.Remove(await _customerContext.Customers.FirstOrDefaultAsync(x => x.Id == id)));
		}
	}
}
