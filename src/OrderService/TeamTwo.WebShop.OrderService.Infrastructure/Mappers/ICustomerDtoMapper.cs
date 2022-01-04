using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Mappers
{
	public interface ICustomerDtoMapper
	{
		CustomerDto Create(Customer customer);
		Customer Map(CustomerDto customerDto);
	}
}