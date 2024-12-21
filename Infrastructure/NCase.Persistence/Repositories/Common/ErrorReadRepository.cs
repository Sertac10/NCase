using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Common
{
    public class ErrorReadRepository : ReadRepository<Error>, IErrorReadRepository
    {
        public ErrorReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
