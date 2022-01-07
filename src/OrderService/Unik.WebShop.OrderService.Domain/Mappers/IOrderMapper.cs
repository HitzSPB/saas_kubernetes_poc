using Unik.WebShop.OrderService.Domain.Models;

namespace Unik.WebShop.OrderService.Domain.Mappers
{
	public interface IOrderMapper
	{
		Order Create(OrderDto orderDto);
		OrderDto Map(Order order);
	}
}