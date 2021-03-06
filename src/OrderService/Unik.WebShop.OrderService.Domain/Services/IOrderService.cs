using Unik.WebShop.OrderService.Domain.Models;

namespace Unik.WebShop.OrderService.Domain.Services
{
	public interface IOrderService
	{
		Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
		Task DeleteOrderAsync(int id);
		Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
		Task<OrderDto> GetOrderByIdAsync(int id);
		Task<OrderDto> UpdateOrderAsync(int id, OrderDto order);
	}
}