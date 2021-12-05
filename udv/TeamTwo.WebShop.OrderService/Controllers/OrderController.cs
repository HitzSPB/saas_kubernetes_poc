using Microsoft.AspNetCore.Mvc;

namespace TeamTwo.WebShop.OrderService.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;

		public OrderController(ILogger<OrderController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetAllOrders")]
		public string Get()
		{
			return "test all";
		}

		[HttpGet(template: "{id}", Name = "GetSingleOrder")]
		public string Get(int id)
		{
			return "test by id";
		}

		[HttpPost(template: "{content}", Name = "PostOrder")]
		public string Post(string content)
		{
			return "Post order";
		}

		[HttpPatch(template: "{id}", Name = "UpdateOrder")]
		public string Patch(int id)
		{
			return $"Patch order {id}";
		}

		[HttpDelete(template: "{id}", Name = "DeleteOrder")]
		public string Delete(int id)
		{
			return "Deleted item";
		}
	}
}