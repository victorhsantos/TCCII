using Microsoft.AspNetCore.Identity;

namespace TCCII.Deputados.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

        public virtual ICollection<UserDeputados> Deputados { get; set; }
    }
}
