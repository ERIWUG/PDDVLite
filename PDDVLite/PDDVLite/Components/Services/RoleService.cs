using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace PDDVLite.Components.Roles
{
    public class RoleService: IRoleService {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public virtual async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            if(!await _roleManager.RoleExistsAsync(roleName))
            {

        
                return await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            IdentityError error = new IdentityError();
            error.Code = "405";
            error.Description = "Role Already Exist";


            return IdentityResult.Failed(error);
        }

        public virtual async Task<IdentityResult> DeleteRoleAsync(string roleName)
        {

            var role =await _roleManager.FindByNameAsync(roleName);

            if(role is not null)
            {
                return await _roleManager.DeleteAsync(role);
                
            }
            IdentityError error = new IdentityError();
            error.Code = "505";
            error.Description = "Role is not exist";
            return IdentityResult.Failed(error);
        }


    }





}
