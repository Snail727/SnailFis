using SnailFis.Business.BaseData;
using SnailFis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnailFis.Controllers.BaseData
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class TestController : BaseApiController
    {
        /// <summary>
        /// 获取字典内容
        /// </summary>
        /// <returns></returns>
        public MessageModel GetBankList()
        {
            var list = new XmlData(UserSn).GetBankList();
            return new MessageModel(true, list);
        }
    }
}