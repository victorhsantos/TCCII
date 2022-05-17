using Microsoft.AspNetCore.Identity;

namespace TCCII.Core.Entities.Identity
{
    public class UserToken : IdentityUserToken<int>
    {
        public virtual User User { get; set; }
    }
}
