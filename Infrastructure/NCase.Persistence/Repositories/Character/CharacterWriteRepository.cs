using a=NCase.Domain.Entities.Character;
using NCase.Persistence.Context;
using NCase.Application.Repositories.Character;

namespace NCase.Persistence.Repositories.Character
{
    public class CharacterWriteRepository : WriteRepository<a.Character>, ICharacterWriteRepository
    {
        public CharacterWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
