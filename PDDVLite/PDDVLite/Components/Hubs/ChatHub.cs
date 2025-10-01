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

        public async Task AddUserToGroup(string user, string group) {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.All.SendAsync("Text",$"Пользователь {user} вошел в группу {group}");
        }

        public async Task SendToGroup(string user, string group, string message)
        {
            await Clients.Group(group).SendAsync("TextGroup",$"Внутри группы {group}",user, message);
        }

        public async Task ValueChange(string newValue)
        {
            await Clients.Group("Teacher").SendAsync("StudentTask", newValue);
        
        }

       
    }
}

