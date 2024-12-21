using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class DbParameterTypeReadRepository : ReadRepository<DbParameterType>, IDbParameterTypeReadRepository
    {
        public DbParameterTypeReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
