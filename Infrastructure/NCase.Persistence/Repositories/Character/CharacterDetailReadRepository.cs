using NCase.Application.Repositories.Character;
using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Character
{
    public class CharacterDetailReadRepository : ReadRepository<CharacterDetail>, ICharacterDetailReadRepository
    {
        public CharacterDetailReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
