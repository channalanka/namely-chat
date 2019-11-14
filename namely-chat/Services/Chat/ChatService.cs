using System;
using System.Linq;
using System.Collections.Generic;
using namelychat.Models;

namespace namelychat.Services.Chat
{
    public class ChatService: IChatService
    {
        private IEnumerable<ChatMessage> _chatList;
        private IEnumerable<ChatRoom> _chatRooms;

        public ChatService()
        {
            _chatList = new List<ChatMessage>();
            _chatRooms = new List<ChatRoom>
            {
                new ChatRoom
                {
                    ChatRoomId= 1,
                    Name = "Chat Room 1",
                    Status = "Active"

                },
                 new ChatRoom
                {
                    ChatRoomId= 3,
                    Name = "Chat Room 3",
                    Status = "Active"

                },  new ChatRoom
                {
                    ChatRoomId= 2,
                    Name = "Chat Room 3",
                    Status = "Active"

                }
            };

        }

        public ChatMessage AddNewMessage(string userId, string message, string chatRoom)
        {
            var chatMessage = new ChatMessage();
            chatMessage.MessageId = _chatList.Count() + 1;
            chatMessage.Message = message;
            chatMessage.ChatRoom = chatRoom;
            chatMessage.UserId = userId;
            this._chatList.Concat(new ChatMessage[] { chatMessage });
            return chatMessage;
        }

        public IEnumerable<ChatMessage> GetAllChatForRoom(string chatRoom)
        {
            return this._chatList.Where(x => x.ChatRoom == chatRoom);
        }

        public IEnumerable<ChatRoom> GetAllChatRooms()
        {
            return this._chatRooms;
        }
    }
}
