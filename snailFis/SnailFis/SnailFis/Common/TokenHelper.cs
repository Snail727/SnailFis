using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Script.Serialization;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace SnailFis.Common
{
    public static class TokenHelper
    {
        public static string SecretKey = "This is a private key for Server";//这个服务端加密秘钥 属于私钥
        private static JavaScriptSerializer myJson = new JavaScriptSerializer();
        public static string GenToken(TokenInfo M)
        {
            var payload = new Dictionary<string, dynamic>
            {
                { "exp", DateTimeOffset.UtcNow.AddSeconds(10).ToUnixTimeSeconds() },//到期时间
                {"UserName", M.UserName},//用于存放当前登录人账户信息
                {"UserSn", M.UserSn}//用于存放当前登录人id信息
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(payload, SecretKey);
        }

        public static TokenInfo DecodeToken(string token)
        {
            try
            {
                var json = GetTokenJson(token);
                TokenInfo info = myJson.Deserialize<TokenInfo>(json);
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetTokenJson(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer,validator,urlEncoder,algorithm);
                var json = decoder.Decode(token, SecretKey, verify: true);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class TokenInfo
    {
        public TokenInfo()
        {
            UserName = "andrew";
            UserSn = "123456";
        }
        public string UserName { get; set; }
        public string UserSn { get; set; }
    }
}