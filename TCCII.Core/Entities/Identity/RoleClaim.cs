using Microsoft.AspNetCore.Identity;

namespace TCCII.Deputados.Core.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}
