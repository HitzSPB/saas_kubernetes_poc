using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly List<Order> _orders = new List<Order>();


		public async Task<IEnumerable<Order>> GetAllAsync()
		{
			return await Task.FromResult(_orders);
		}

		public async Task<Order> GetOrderAsync(int id)
		{
			return await Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
		}
		public async Task<Order> CreateOrderAsync(Order order)
		{
			_orders.Add(order);
			return await Task.FromResult(order);
		}

		public async Task<Order> UpdateOrder(int id, Order order)
		{
			var oldOrder = _orders.FirstOrDefault(o => o.Id == id);
			oldOrder = order;
			return await Task.FromResult(order);
		}

		public async Task DeleteOrderAsync(int id)
		{
			await Task.FromResult(_orders.Remove(_orders.FirstOrDefault(o => o.Id == id)));
		}
	}
}
