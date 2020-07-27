using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Script.Serialization;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using SnailFis.Model;

namespace SnailFis.WebCommon
{
    public static class TokenHelper
    {
        public static string SecretKey = "This is a private key for Server";//这个服务端加密秘钥 属于私钥
        private static JavaScriptSerializer myJson = new JavaScriptSerializer();
        public static string GenToken(TokenInfo M)
        {
            var payload = new Dictionary<string, dynamic>
            {
                {"Sub", M.Sub },//到期时间
                {"Exp", M.Exp },//到期时间
                {"UserName", M.UserName},
                {"UserSn", M.UserSn},
                {"Phone", M.Phone},
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(payload, SecretKey);
        }

        public static MessageModel DecodeToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token)) { return new MessageModel(false, "token字符为空"); }
                var jsonMsg = GetTokenJson(token);
                if (!jsonMsg.Success) { return jsonMsg; }
                TokenInfo info = myJson.Deserialize<TokenInfo>(jsonMsg.Msg);
                var nowDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (nowDate > info.Exp) { return new MessageModel(false,"token已过期"); }
                return new MessageModel(true,info);
            }
            catch (Exception)
            {
                return new MessageModel(false,"token转换失败");
            }
        }

        public static MessageModel GetTokenJson(string token)
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
                return new MessageModel(true, json); 
            }
            catch (Exception)
            {
                return new MessageModel(false, "token解密失败");
            }
        }
    }

    public class TokenInfo
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string Sub { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public long Exp { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserSn { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
    }
}