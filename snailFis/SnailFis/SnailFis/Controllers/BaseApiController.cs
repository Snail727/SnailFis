using SnailFis.WebCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnailFis.Controllers
{
    public class BaseApiController : ApiController
    {
        public int UserSn { get; }
        public BaseApiController()
        {
            UserSn = CommonSettings.UserSn;
        }
    }

    public static class CommonSettings
    {
        /// <summary>
        /// 登陆用户的Token
        /// </summary>
        [ThreadStatic]
        public static TokenInfo TokenData;

        public static int UserSn = 0;
    }
}
