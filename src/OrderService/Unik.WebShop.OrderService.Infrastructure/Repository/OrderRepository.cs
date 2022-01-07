using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Domain.Repository;
using Unik.WebShop.OrderService.Infrastructure.Context;
using Unik.WebShop.OrderService.Infrastructure.Mappers;
using Unik.WebShop.OrderService.Infrastructure.Models;

namespace Unik.WebShop.OrderService.Infrastructure.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrderContext _orderContext;
		private readonly IEfMapper _efMapper;
		public OrderRepository(OrderContext orderContext, IEfMapper efMapper)
		{
			_orderContext = orderContext;
			_efMapper = efMapper;
		}
		//private readonly List<Order> _orders = new List<Order>();

		public async Task<IEnumerable<Order>> GetAllAsync()
		{
			var list = new List<Order>();
			foreach (var order in _orderContext.Orders)
			{
				list.Add(_efMapper.Map(order));
			}
			return await Task.FromResult(list);
		}

		public async Task<Order> GetOrderAsync(int id)
		{
			return _efMapper.Map(await _orderContext.Orders.FirstOrDefaultAsync(x => x.Id == id));
		}
		public async Task<Order> CreateOrderAsync(Order order)
		{
			var storedObject = await _orderContext.Orders.AddAsync(_efMapper.Create(order));
			await _orderContext.SaveChangesAsync();
			return _efMapper.Map(storedObject.Entity);
		}

		public async Task<Order> UpdateOrder(int id, Order order)
		{
			var orderEf = await _orderContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
			orderEf = _efMapper.Create(order);
			await _orderContext.SaveChangesAsync();
			return await Task.FromResult(order);
		}

		public async Task DeleteOrderAsync(int id)
		{
			await Task.FromResult(_orderContext.Orders.Remove(await _orderContext.Orders.FirstOrDefaultAsync(x => x.Id == id)));
		}
	}
}
