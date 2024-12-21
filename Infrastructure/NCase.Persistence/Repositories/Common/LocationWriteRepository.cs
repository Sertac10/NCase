using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class LocationWriteRepository : WriteRepository<Location>, ILocationWriteRepository
    {
        public LocationWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
