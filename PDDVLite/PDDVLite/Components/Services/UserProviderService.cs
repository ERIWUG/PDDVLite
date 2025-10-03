using Microsoft.AspNetCore.SignalR;

namespace PDDVLite.Components.Services
{
    public class UserProviderService : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name??null;
        }
    }
}
