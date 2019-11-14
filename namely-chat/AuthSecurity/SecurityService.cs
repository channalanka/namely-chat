using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace namelychat.AuthSecurity
{


    public class SecurityService
    {
        private const string SHARED_KEY = "U3vGpjrsQ8EQvfSRQCNhfhVuukK3Uqqox1tDfi14ECE=";

        public  string GenerateToken(Token token) {
            var data = JsonConvert.SerializeObject(token);
            var payloadBytes = Encoding.UTF8.GetBytes(data);
            var keyByte = Convert.FromBase64String(SHARED_KEY);
            string signedString = "";
            using(var hmac = new HMACSHA256(keyByte)) {
                var signedByte = hmac.ComputeHash(payloadBytes);
                signedString = Convert.ToBase64String(signedByte);
            }

            string payloadString = System.Convert.ToBase64String(payloadBytes);
            return string.Format("{0}.{1}", signedString, payloadString);
        }

        public  Token VerifyToken(string token) {
            var tokenData = token.Split('.');
            var payload = Convert.FromBase64String(tokenData[1]);
            var payloadStr = Encoding.UTF8.GetString(payload);
            var payloadByte = Encoding.UTF8.GetBytes(payloadStr);


            var keyByte = Convert.FromBase64String(SHARED_KEY);
            byte[] signedByte = null;
            using (var hmac = new HMACSHA256(keyByte))
            {
                 signedByte = hmac.ComputeHash(payloadByte);

            }

            var signedToken = Convert.FromBase64String(tokenData[0]);
            if(!compareTwobyteArray(signedToken, signedByte)) return null;
            return JsonConvert.DeserializeObject<Token>(payloadStr);
        }


         bool compareTwobyteArray(byte[] a1, byte[] a2) {
            bool bEqual = false;
            if (a1.Length == a2.Length)
            {
                int i = 0;
                while ((i < a1.Length) && (a1[i] == a2[i]))
                {
                    i += 1;
                }
                if (i == a1.Length)
                {
                    bEqual = true;
                }
            }

            return bEqual;

        }

        public  string GenerateHash(string data) {
            SHA256 sha = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
