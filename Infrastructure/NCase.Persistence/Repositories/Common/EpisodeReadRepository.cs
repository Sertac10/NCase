using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class EpisodeReadRepository : ReadRepository<Episode>, IEpisodeReadRepository
    {
        public EpisodeReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
