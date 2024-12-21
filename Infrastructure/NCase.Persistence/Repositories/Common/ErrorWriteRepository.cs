using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class ErrorWriteRepository : WriteRepository<Error>, IErrorWriteRepository
    {
        public ErrorWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
