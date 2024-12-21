using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class ItemChangeReadRepository : ReadRepository<ItemChange>, IItemChangeReadRepository
    {
        public ItemChangeReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
