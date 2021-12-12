using KubeCarrier.Core.Data;

namespace KubeCarrier.Core.Services
{
    public class ServiceBase
    {
        protected readonly KubeCarrierDbContext _context;

        public ServiceBase(KubeCarrierDbContext context)
        {
            _context = context;
        }
    }
}
