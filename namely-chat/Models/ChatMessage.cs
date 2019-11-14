namespace namelychat.Models
{
    public class ChatMessage
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string ChatRoom { get; set; }
        public string UserId { get; set; }
    }
}
