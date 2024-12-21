using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class DbParameterTypeWriteRepository : WriteRepository<DbParameterType>, IDbParameterTypeWriteRepository
    {
        public DbParameterTypeWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
