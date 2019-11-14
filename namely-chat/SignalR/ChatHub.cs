using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using namelychat.Services.Chat;

namespace namelychat.SignalR
{
    public class ChatHub: Hub
    {

        IChatService _chatService;
        public ChatHub(IChatService chatService) {

            this._chatService = chatService;
        }

        public async Task SendMessage( string message, string chatRoom)
        {
            var chatMessage = _chatService.AddNewMessage("Channa", message, chatRoom);
            await Clients.All.SendAsync("ReceiveMessage", "Channa", message);
        }
    }

}
