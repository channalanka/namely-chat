using System;
namespace namelychat.AuthSecurity
{
    public class Token
    {
        public Payload Payload { get; set; }
        public DateTime Expired { get; set; }
    }


    public class Payload {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int[] Actions { get; set; }
    }
}
