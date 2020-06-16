using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.SysData
{
    /// <summary>
    /// 系统用户基类
    /// </summary>
    public class SysUserDbModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [DBColumn("UserSn")]
        public int UserSn { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DBColumn("UserName")]
        public string UserName { get; set; }

        // <summary>
        /// 密码
        /// </summary>
        [DBColumn("PassWord")]
        public string PassWord { get; set; }

        // <summary>
        /// 手机号
        /// </summary>
        [DBColumn("Phone")]
        public string Phone { get; set; }

        // <summary>
        /// 备注
        /// </summary>
        [DBColumn("Note")]
        public string Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBColumn("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DBColumn("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
