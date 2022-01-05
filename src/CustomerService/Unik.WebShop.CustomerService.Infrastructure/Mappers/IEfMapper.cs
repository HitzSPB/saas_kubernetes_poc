using Unik.WebShop.CustomerService.Domain.Models;
using Unik.WebShop.CustomerService.Infrastructure.Models;

namespace Unik.WebShop.CustomerService.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		CustomerEf Create(Customer order);
		Customer Map(CustomerEf order);
	}
}