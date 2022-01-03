using TeamTwo.WebShop.CustomerService.Domain.Models;
using TeamTwo.WebShop.CustomerService.Infrastructure.Models;

namespace TeamTwo.WebShop.CustomerService.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		CustomerEf Create(Customer order);
		Customer Map(CustomerEf order);
	}
}