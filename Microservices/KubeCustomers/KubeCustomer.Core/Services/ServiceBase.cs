using KubeCustomer.Core.Data;

namespace KubeCustomer.Core.Services
{
    public class ServiceBase
    {
        protected readonly KubeCustomerDbContext _context;

        public ServiceBase(KubeCustomerDbContext context)
        {
            _context = context;
        }
    }
}
