using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class LocationReadRepository : ReadRepository<Location>, ILocationReadRepository
    {
        public LocationReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
