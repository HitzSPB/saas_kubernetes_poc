using Microsoft.AspNetCore.Mvc;
using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Domain.Services;

namespace Unik.WebShop.OrderService.API.Controllers
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
			_logger.LogInformation("Order Api Controller have been called in the Get All route");
			return await _orderService.GetAllOrdersAsync();
		}

		[HttpGet(template: "{id}", Name = "GetSingleOrder")]
		public async Task<OrderDto> Get(int id)
		{
			_logger.LogInformation("Order Api Controller have been called in the Get specific id");
			return await _orderService.GetOrderByIdAsync(id);
		}

		[HttpPost(Name = "PostOrder")]
		public async Task<IActionResult> Post([FromBody] OrderDto orderDto)
		{
			_logger.LogInformation("Order Api Controller have been called with the post route");
			var customerDto = await _orderService.CreateOrderAsync(orderDto);
			if (customerDto == null)
				return new BadRequestResult();
			return new OkObjectResult(customerDto);
		}

		[HttpPatch(template: "{id}", Name = "UpdateOrder")]
		public async Task<IActionResult> Patch(int id, [FromBody] OrderDto orderDto)
		{
			_logger.LogInformation("Order Api Controller have been called with the update route with id {id}", id);
			var customerDto = _orderService.UpdateOrderAsync(id, orderDto);
			if (customerDto == null)
				return new BadRequestResult();
			return new OkObjectResult(customerDto);
		}

		[HttpDelete(template: "{id}", Name = "DeleteOrder")]
		public async Task Delete(int id)
		{
			_logger.LogInformation("Order Api Controller have been called with the delete route with id {id}", id);
			await _orderService.DeleteOrderAsync(id);
		}
	}
}