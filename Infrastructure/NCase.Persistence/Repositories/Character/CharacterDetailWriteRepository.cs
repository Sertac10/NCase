using NCase.Application.Repositories.Character;
using NCase.Domain.Entities.Character;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Character
{
    public class CharacterDetailWriteRepository : WriteRepository<CharacterDetail>, ICharacterDetailWriteRepository
    {
        public CharacterDetailWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
