using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common;
public class FFileReadRepository : ReadRepository<FFile>, IFFileReadRepository
{
    public FFileReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
