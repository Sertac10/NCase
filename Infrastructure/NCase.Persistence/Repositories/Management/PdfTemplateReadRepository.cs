using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class PdfTemplateReadRepository : ReadRepository<PdfTemplate>, IPdfTemplateReadRepository
    {
        public PdfTemplateReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
