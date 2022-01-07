using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.OrderService.Domain.External;
using Unik.WebShop.OrderService.Domain.Mappers;
using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Domain.Repository;

namespace Unik.WebShop.OrderService.Domain.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderMapper _orderMapper;
		private readonly ICustomerServiceCall _customerServiceCall;

		public OrderService(IOrderRepository orderRepository, IOrderMapper orderMapper, ICustomerServiceCall customerServiceCall)
		{
			_orderRepository = orderRepository;
			_orderMapper = orderMapper;
			_customerServiceCall = customerServiceCall;
		}

		public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
		{
		    var orders = await _orderRepository.GetAllAsync();
			var ordersDto = new List<OrderDto>();
			foreach (var order in orders)
			{
				ordersDto.Add(_orderMapper.Map(order));
			}
			return ordersDto;
		}
		public async Task<OrderDto> GetOrderByIdAsync(int id)
		{
			var order = await _orderRepository.GetOrderAsync(id);
			return _orderMapper.Map(order);
		}

		public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
		{
			var customer = await _customerServiceCall.GetCustomerByIdAsync(orderDto.CustomerId);

			if (customer == null)
				return null;
			var order = await _orderRepository.CreateOrderAsync(_orderMapper.Create(orderDto));
			return _orderMapper.Map(order);
		}

		public async Task<OrderDto> UpdateOrderAsync(int id, OrderDto orderDto)
		{
			var customer = await _customerServiceCall.GetCustomerByIdAsync(orderDto.CustomerId);

			if (customer == null)
				return null;
			Order order = await _orderRepository.UpdateOrder(id, _orderMapper.Create(orderDto));
			return _orderMapper.Map(order);
		}
		public async Task DeleteOrderAsync(int id)
		{
			await _orderRepository.DeleteOrderAsync(id);
		}
	}
}
