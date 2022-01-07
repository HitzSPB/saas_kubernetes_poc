using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Unik.WebShop.OrderService.Domain.External;
using Unik.WebShop.OrderService.Domain.Models;
using Unik.WebShop.OrderService.Infrastructure.Models;

namespace Unik.WebShop.OrderService.Infrastructure.Repository
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
			var response = await _client.GetStringAsync($"/api/Customer/{id}");
			if (string.IsNullOrWhiteSpace(response))
				return null;
			var customer = JsonSerializer.Deserialize<Customer>(response);
			return customer;
		}

	}
}
