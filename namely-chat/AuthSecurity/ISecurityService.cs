using System;
namespace namelychat.AuthSecurity
{
    public interface ISecurityService
    {
        string GenerateToken(Token token);
        Token VerifyToken(string token);
        string GenerateHash(string data);
    }
}
