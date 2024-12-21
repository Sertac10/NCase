using NCase.Application.Repositories.Common;
using NCase.Domain.Entities.Common;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class StatusReadRepository : ReadRepository<Status>, IStatusReadRepository
    {
        public StatusReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
