using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Repository
{
	public interface IOrderRepository
	{
		Task<Order> CreateOrder(Order order);
		Task DeleteOrderAsync(int id);
		Task<IEnumerable<Order>> GetAll();
		Task<Order> GetOrderaAsync(int id);
		Task<Order> UpdateOrder(int id, Order order);
	}
}