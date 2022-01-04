using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeamTwo.WebShop.OrderService.Domain.External;
using TeamTwo.WebShop.OrderService.Domain.Models;
using TeamTwo.WebShop.OrderService.Infrastructure.Models;

namespace TeamTwo.WebShop.OrderService.Infrastructure.Repository
{
	public class CustomerServiceCall : ICustomerServiceCall
	{
		private readonly HttpClient _client;
		public CustomerServiceCall(HttpClient httpClient, IConfiguration configuration)
		{
			httpClient.BaseAddress = new Uri(configuration["CustomerServiceBasepath"]);
			_client = httpClient;
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			var response = await _client.GetAsync($"/api/Customer/{id}");
			var customer = JsonSerializer.Deserialize<Customer>(response.Content.ToString());
			return customer;
		}

	}
}
