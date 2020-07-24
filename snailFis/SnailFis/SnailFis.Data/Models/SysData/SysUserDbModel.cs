using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.SysData
{
    /// <summary>
    /// 系统用户基类
    /// </summary>
    [Table("sys_user")]
    [Serializable]
    public class SysUserDbModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSn { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [StringLength(64)]
        public string UserName { get; set; }

        // <summary>
        /// 密码
        /// </summary>
        [StringLength(64)]
        public string PassWord { get; set; }

        // <summary>
        /// 手机号
        /// </summary>
        [StringLength(64)]
        public string Phone { get; set; }

        // <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
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
