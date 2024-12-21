using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class DbParameterWriteRepository : WriteRepository<DbParameter>, IDbParameterWriteRepository
    {
        public DbParameterWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
