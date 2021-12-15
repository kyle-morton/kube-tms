using KubeCustomer.Core.Data;
using KubeCustomer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCustomer.Core.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
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
    }
}
