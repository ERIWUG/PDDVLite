using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace PDDVLite.Components.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

