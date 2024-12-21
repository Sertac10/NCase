using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class ServiceLogReadRepository : ReadRepository<ServiceLog>, IServiceLogReadRepository
    {
        public ServiceLogReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
