namespace PDDVLite.Components.Services
{
    public interface IUserService
    {
        public abstract Task AssignRoleToUserAsync(string userId, string role);

        public abstract Task RemoveRoleFromUserAsync(string userId, string role);

    

    }
}
