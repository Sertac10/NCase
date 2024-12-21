using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class OperationLogWriteRepository : WriteRepository<OperationLog>, IOperationLogWriteRepository
    {
        public OperationLogWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
