using AutoMapper;
using KubeTMS.Core.Data;

namespace KubeTMS.Core.Services
{
    public class ServiceBase
    {
        protected readonly KubeTMSDbContext _context;
        protected readonly IMapper _mapper;

        public ServiceBase(KubeTMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
