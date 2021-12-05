using Microsoft.AspNetCore.Mvc;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Domain.Services;

namespace TeamTwo.WebShop.OrderService.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;
		private readonly IOrderService _orderService;

		public OrderController(ILogger<OrderController> logger, IOrderService orderService)
		{
			_logger = logger;
			_orderService = orderService;
		}

		[HttpGet(Name = "GetAllOrders")]
		public async Task<IEnumerable<OrderDto>> Get()
		{
			return await _orderService.GetAllOrdersAsync();
		}

		[HttpGet(template: "{id}", Name = "GetSingleOrder")]
		public async Task<OrderDto> Get(int id)
		{
			return await _orderService.GetOrderByIdAsync(id);
		}

		[HttpPost(Name = "PostOrder")]
		public async Task<OrderDto> Post([FromBody] OrderDto orderDto)
		{
			return await _orderService.CreateOrderAsync(orderDto);
		}

		[HttpPatch(template: "{id}", Name = "UpdateOrder")]
		public async Task<OrderDto> Patch(int id, [FromBody] OrderDto orderDto)
		{
			return await _orderService.UpdateOrderAsync(id, orderDto);
		}

		[HttpDelete(template: "{id}", Name = "DeleteOrder")]
		public async Task Delete(int id)
		{
			await _orderService.DeleteOrderAsync(id);
		}
	}
}