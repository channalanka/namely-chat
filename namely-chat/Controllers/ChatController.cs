using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using namelychat.Models;
using namelychat.Services.Chat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace namelychat.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        IChatService _chatService;

        public ChatController(IChatService chatService) {
            this._chatService = chatService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ChatRoom> Get()
        {
            return this._chatService.GetAllChatRooms();
        }

        // GET api/values/5
        [HttpGet("{chatroom}")]
        public IEnumerable<ChatMessage> Get(string chatroom)
        {
            return this._chatService.GetAllChatForRoom(chatroom); 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
