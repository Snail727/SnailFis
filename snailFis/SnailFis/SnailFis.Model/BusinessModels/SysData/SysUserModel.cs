using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model.BusinessModels.SysData
{
    /// <summary>
    /// 系统用户逻辑类
    /// </summary>
    public class SysUserModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public int UserSn { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        // <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        // <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        // <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
