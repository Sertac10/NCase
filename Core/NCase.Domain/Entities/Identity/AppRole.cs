using Microsoft.AspNetCore.Identity;

namespace NCase.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public bool isActive { get; set; }
    }
}
