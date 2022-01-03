using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Mappers
{
	public interface IEfMapper
	{
		OrderEf Create(Order order);
		Order Map(OrderEf order);
	}
}