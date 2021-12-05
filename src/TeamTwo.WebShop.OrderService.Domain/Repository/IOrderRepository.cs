using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Repository
{
	public interface IOrderRepository
	{
		Task<Order> CreateOrderAsync(Order order);
		Task DeleteOrderAsync(int id);
		Task<IEnumerable<Order>> GetAllAsync();
		Task<Order> GetOrderAsync(int id);
		Task<Order> UpdateOrder(int id, Order order);
	}
}