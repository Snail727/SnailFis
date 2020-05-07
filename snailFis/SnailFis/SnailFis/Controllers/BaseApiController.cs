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
        public int SfId { get; }
        public int UserSn { get; }
        public BaseApiController()
        {
            SfId = 100000001;
            UserSn = 100001;
        }
    }
}
