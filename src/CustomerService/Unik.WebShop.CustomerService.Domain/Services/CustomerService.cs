using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.WebShop.CustomerService.Domain.Mappers;
using Unik.WebShop.CustomerService.Domain.Models;
using Unik.WebShop.CustomerService.Domain.Repositories;

namespace Unik.WebShop.CustomerService.Domain.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly ICustomerMapper _customerMapper;

		public CustomerService(ICustomerRepository customerRepository, ICustomerMapper customerMapper)
		{
			_customerRepository = customerRepository;
			_customerMapper = customerMapper;
		}

		public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
		{
			var customers = await _customerRepository.GetAllAsync();
			var customersDto = new List<CustomerDto>();
			foreach (var customer in customers)
			{
				customersDto.Add(_customerMapper.Map(customer));
			}
			return customersDto;
		}
		public async Task<CustomerDto> GetCustomerByIdAsync(int id)
		{
			var customer = await _customerRepository.GetCustomerAsync(id);
			return _customerMapper.Map(customer);
		}

		public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
		{
			var customer = await _customerRepository.CreateCustomerAsync(_customerMapper.Create(customerDto));
			return _customerMapper.Map(customer);
		}

		public async Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customerDto)
		{
			Customer customer = await _customerRepository.UpdateCustomer(id, _customerMapper.Create(customerDto));
			return _customerMapper.Map(customer);
		}
		public async Task DeleteCustomerAsync(int id)
		{
			await _customerRepository.DeleteCustomerAsync(id);
		}
	}
}
