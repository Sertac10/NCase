using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class ServiceLogWriteRepository : WriteRepository<ServiceLog>, IServiceLogWriteRepository
    {
        public ServiceLogWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
