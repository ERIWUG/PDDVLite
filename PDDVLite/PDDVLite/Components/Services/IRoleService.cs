using Microsoft.AspNetCore.Identity;

namespace PDDVLite.Components.Roles
{
    public interface IRoleService
    {
        public abstract Task<IdentityResult> CreateRoleAsync(string roleName);

        public abstract Task<IdentityResult> DeleteRoleAsync(string roleName);



    }
}
