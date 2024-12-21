using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class ItemChangeWriteRepository : WriteRepository<ItemChange>, IItemChangeWriteRepository
    {
        public ItemChangeWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
