using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class DbParameterReadRepository : ReadRepository<DbParameter>, IDbParameterReadRepository
    {
        public DbParameterReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
