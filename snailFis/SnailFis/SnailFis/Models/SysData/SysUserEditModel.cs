using SnailFis.Common;
using SnailFis.Model.BusinessModels.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnailFis.Models.SysData
{
    /// <summary>
    /// 系统用户编辑类
    /// </summary>
    public class SysUserEditModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public int UserSn { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [Validation(64, "用户名称", true)]
        public string UserName { get; set; }

        // <summary>
        /// 密码
        /// </summary>
        [Validation(64, "密码", true)]
        public string PassWord { get; set; }

        // <summary>
        /// 手机号
        /// </summary>
        [Validation(64, "手机号", true)]
        public string Phone { get; set; }

        // <summary>
        /// 备注
        /// </summary>
        [Validation(64, "备注", false)]
        public string Note { get; set; }

        public SysUserModel ToUserModel()
        {
            return new SysUserModel()
            {
                UserSn = this.UserSn,
                UserName = this.UserName,
                PassWord = this.PassWord,
                Phone = this.Phone,
                Note = this.Note
            };
        }
    }
}