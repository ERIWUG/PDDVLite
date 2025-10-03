
using Microsoft.AspNetCore.Identity;

namespace PDDVLite.Components.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public virtual async Task AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userId);

            if (user != null && await _roleManager.RoleExistsAsync(roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }


        public virtual async Task RemoveRoleFromUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userId);

            if (user != null && await _roleManager.RoleExistsAsync(roleName))
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
        }


    }
}
