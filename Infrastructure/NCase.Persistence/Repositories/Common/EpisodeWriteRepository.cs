using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class EpisodeWriteRepository : WriteRepository<Episode>, IEpisodeWriteRepository
    {
        public EpisodeWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
