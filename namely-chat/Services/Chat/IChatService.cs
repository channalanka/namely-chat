using System;
using System.Collections.Generic;
using namelychat.Models;

namespace namelychat.Services.Chat
{
    public interface IChatService
    {
        ChatMessage AddNewMessage(string userId, string message, string chatRoom);
        IEnumerable<ChatMessage> GetAllChatForRoom(string chatRoom);
        IEnumerable<ChatRoom> GetAllChatRooms();
    }
}
