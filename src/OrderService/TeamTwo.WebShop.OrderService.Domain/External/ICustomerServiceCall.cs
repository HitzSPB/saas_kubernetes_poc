using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Domain.External
{
	public interface ICustomerServiceCall
	{
		Task<Customer> GetCustomerByIdAsync(int id);
	}
}