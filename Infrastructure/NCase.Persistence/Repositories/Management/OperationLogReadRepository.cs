using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class OperationLogReadRepository : ReadRepository<OperationLog>, IOperationLogReadRepository
    {
        public OperationLogReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
