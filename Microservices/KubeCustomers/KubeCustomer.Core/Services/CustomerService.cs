using KubeCustomer.Core.Data;
using KubeCustomer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCustomer.Core.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
        Task<Customer> CreateAsync(Customer customer);
    }

    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(KubeCustomerDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

    }
}
