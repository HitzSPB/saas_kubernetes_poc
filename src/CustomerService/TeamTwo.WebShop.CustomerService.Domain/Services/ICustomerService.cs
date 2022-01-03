using TeamTwo.WebShop.CustomerService.Domain.Models;

namespace TeamTwo.WebShop.CustomerService.Domain.Services
{
	public interface ICustomerService
	{
		Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
		Task DeleteCustomerAsync(int id);
		Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
		Task<CustomerDto> GetCustomerByIdAsync(int id);
		Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customerDto);
	}
}