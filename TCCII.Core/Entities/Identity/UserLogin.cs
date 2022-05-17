using Microsoft.AspNetCore.Identity;

namespace TCCII.Core.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }
    }
}
