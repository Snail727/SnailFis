using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Data.Models.Sport
{
    /// <summary>
    /// 运动项目主表信息基类
    /// </summary>
    [Table("sport_main")]
    [Serializable]
    public class SportMainDbModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSn { get; set; }

        /// <summary>
        /// 运动id
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SportId { get; set; }

        /// <summary>
        /// 运动详情id
        /// </summary>
        [StringLength(64)]
        public string SportNo { get; set; }

        /// <summary>
        /// 运动时间
        /// </summary>
        public DateTime SportDate { get; set; }

        /// <summary>
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
