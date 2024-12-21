using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Common;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class StatusWriteRepository : WriteRepository<Status>, IStatusWriteRepository
    {
        public StatusWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
