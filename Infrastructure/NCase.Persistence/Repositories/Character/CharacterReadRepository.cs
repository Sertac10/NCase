using a=NCase.Domain.Entities.Character;
using NCase.Persistence.Context;
using NCase.Application.Repositories.Character;

namespace NCase.Persistence.Repositories.Character
{
    public class CharacterReadRepository : ReadRepository<a.Character>, ICharacterReadRepository
    {
        public CharacterReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
