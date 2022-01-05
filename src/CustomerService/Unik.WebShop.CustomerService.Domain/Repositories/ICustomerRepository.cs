using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.CustomerService.Domain.Models;

namespace Unik.WebShop.CustomerService.Domain.Repositories
{
	public interface ICustomerRepository
	{
		Task<Customer> CreateCustomerAsync(Customer order);
		Task DeleteCustomerAsync(int id);
		Task<IEnumerable<Customer>> GetAllAsync();
		Task<Customer> GetCustomerAsync(int id);
		Task<Customer> UpdateCustomer(int id, Customer order);
	}
}