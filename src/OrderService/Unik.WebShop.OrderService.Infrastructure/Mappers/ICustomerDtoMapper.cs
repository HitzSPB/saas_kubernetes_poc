using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Infrastructure.Models;

namespace Unik.WebShop.OrderService.Infrastructure.Mappers
{
	public interface ICustomerDtoMapper
	{
		CustomerDto Create(Customer customer);
		Customer Map(CustomerDto customerDto);
	}
}