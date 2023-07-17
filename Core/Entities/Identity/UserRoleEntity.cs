using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public virtual required UserEntity User { get; set; }
        public virtual required RoleEntity Role { get; set; }
    }
}
