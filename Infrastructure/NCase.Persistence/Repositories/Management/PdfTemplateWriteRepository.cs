using NCase.Application.Repositories.Management;
using NCase.Domain.Entities.Management;
using NCase.Persistence.Context;

namespace NCase.Persistence.Repositories.Management
{
    public class PdfTemplateWriteRepository : WriteRepository<PdfTemplate>, IPdfTemplateWriteRepository
    {
        public PdfTemplateWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
