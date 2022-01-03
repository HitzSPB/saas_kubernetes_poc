using TeamTwo.WebShop.CustomerService.Domain.Models;

namespace TeamTwo.WebShop.CustomerService.Domain.Mappers
{
	public interface ICustomerMapper
	{
		Customer Create(CustomerDto orderDto);
		CustomerDto Map(Customer order);
	}
}