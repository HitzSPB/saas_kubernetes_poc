using Unik.WebShop.CustomerService.Domain.Models;

namespace Unik.WebShop.CustomerService.Domain.Mappers
{
	public interface ICustomerMapper
	{
		Customer Create(CustomerDto orderDto);
		CustomerDto Map(Customer order);
	}
}