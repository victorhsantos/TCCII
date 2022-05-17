using Microsoft.AspNetCore.Identity;

namespace TCCII.Core.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role() : base() {}
        public Role(string roleName) : this()
        {
            Name = roleName;
        }

        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
