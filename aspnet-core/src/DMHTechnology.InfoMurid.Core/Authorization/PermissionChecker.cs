using Abp.Authorization;
using DMHTechnology.InfoMurid.Authorization.Roles;
using DMHTechnology.InfoMurid.Authorization.Users;

namespace DMHTechnology.InfoMurid.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
