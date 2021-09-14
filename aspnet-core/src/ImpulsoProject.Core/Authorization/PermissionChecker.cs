using Abp.Authorization;
using ImpulsoProject.Authorization.Roles;
using ImpulsoProject.Authorization.Users;

namespace ImpulsoProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
