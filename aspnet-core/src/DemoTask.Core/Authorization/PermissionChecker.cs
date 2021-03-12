using Abp.Authorization;
using DemoTask.Authorization.Roles;
using DemoTask.Authorization.Users;

namespace DemoTask.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
