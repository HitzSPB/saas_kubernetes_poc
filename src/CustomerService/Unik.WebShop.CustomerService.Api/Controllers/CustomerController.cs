using Microsoft.AspNetCore.Mvc;
using Unik.WebShop.CustomerService.Domain.Models;
using Unik.WebShop.CustomerService.Domain.Services;

namespace Unik.WebShop.CustomerService.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICustomerService _customerService;

		public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
		{
			_logger = logger;
			_customerService = customerService;
		}

		[HttpGet(Name = "GetAllCustomers")]
		public async Task<IEnumerable<CustomerDto>> Get()
		{
			_logger.LogInformation("Customer Api Controller have been called in the Get All route");
			return await _customerService.GetAllCustomersAsync();
		}

		[HttpGet(template: "{id}", Name = "GetSingleCustomer")]
		public async Task<CustomerDto> Get(int id)
		{
			_logger.LogInformation("Customer Api Controller have been called in the Get specific id");
			var customerDto = await _customerService.GetCustomerByIdAsync(id);
			return customerDto;
		}

		[HttpPost(Name = "PostCustomer")]
		public async Task<CustomerDto> Post([FromBody] CustomerDto customerDto)
		{
			_logger.LogInformation("Customer Api Controller have been called with the post route");
			return await _customerService.CreateCustomerAsync(customerDto);
		}

		[HttpPatch(template: "{id}", Name = "UpdateCustomer")]
		public async Task<CustomerDto> Patch(int id, [FromBody] CustomerDto customerDto)
		{
			_logger.LogInformation("Customer Api Controller have been called with the update route with id {id}", id);
			return await _customerService.UpdateCustomerAsync(id, customerDto);
		}

		[HttpDelete(template: "{id}", Name = "DeleteCustomer")]
		public async Task Delete(int id)
		{
			_logger.LogInformation("Customer Api Controller have been called with the delete route with id {id}", id);
			await _customerService.DeleteCustomerAsync(id);
		}
	}
}