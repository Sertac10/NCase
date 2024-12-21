using NCase.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace NCase.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
    
}
