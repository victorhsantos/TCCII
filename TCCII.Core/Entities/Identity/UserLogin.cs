using Microsoft.AspNetCore.Identity;

namespace TCCII.Deputados.Core.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }
    }
}
