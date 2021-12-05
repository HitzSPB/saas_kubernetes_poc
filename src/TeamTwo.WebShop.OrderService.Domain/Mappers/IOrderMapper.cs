using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Domain.Mappers
{
	public interface IOrderMapper
	{
		Order Create(OrderDto orderDto);
		OrderDto Map(Order order);
	}
}