using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnailFis.Common;

namespace SnailFis.Models.SysData
{
    /// <summary>
    /// 登陆信息
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Validation(64, "手机号", true)]
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Validation(64, "密码", true)]
        public string PassWord { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VCode { get; set; }
    }
}