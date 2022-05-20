using Microsoft.AspNetCore.Identity;

namespace TCCII.Deputados.Core.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
