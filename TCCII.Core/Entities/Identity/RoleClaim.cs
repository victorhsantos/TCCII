using Microsoft.AspNetCore.Identity;

namespace TCCII.Core.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}
