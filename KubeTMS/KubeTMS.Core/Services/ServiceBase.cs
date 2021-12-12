using KubeTMS.Core.Data;

namespace KubeTMS.Core.Services
{
    public class ServiceBase
    {
        protected readonly KubeTMSDbContext _context;

        public ServiceBase(KubeTMSDbContext context)
        {
            _context = context;
        }
    }
}
