using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common;
public class FFileWriteRepository : WriteRepository<FFile>, IFFileWriteRepository
{
    public FFileWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
