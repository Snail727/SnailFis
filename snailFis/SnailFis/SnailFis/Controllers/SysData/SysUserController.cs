using SnailFis.Business.SysData;
using SnailFis.Model;
using SnailFis.Models.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnailFis.Controllers.SysData
{
    /// <summary>
    /// 系统用户控制器
    /// </summary>
    public class SysUserController : BaseApiController
    {
        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        public MessageModel AddUser(SysUserEditModel model)
        {
            var msg = new MessageModel(true);
            new SysUser().AddUser(model.ToUserModel());
            return msg;
        }

        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        public MessageModel UpdateUser(SysUserEditModel model)
        {
            var msg = new MessageModel(true);
            model.UserSn = UserSn;
            new SysUser().UpdateUser(model.ToUserModel());
            return msg;
        }
    }
}
