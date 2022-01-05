using Unik.WebShop.OrderService.Domain.Models;

namespace Unik.WebShop.OrderService.Domain.External
{
	public interface ICustomerServiceCall
	{
		Task<Customer> GetCustomerByIdAsync(int id);
	}
}