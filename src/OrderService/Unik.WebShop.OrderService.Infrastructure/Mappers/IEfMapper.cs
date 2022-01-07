using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Infrastructure.Models;

namespace Unik.WebShop.OrderService.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		OrderEf Create(Order order);
		Order Map(OrderEf order);
	}
}