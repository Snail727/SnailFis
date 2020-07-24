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
    /// 运动项目子表信息基类
    /// </summary>
    [Table("sport_child")]
    [Serializable]
    public class SportChildDbModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSn { get; set; }

        /// <summary>
        /// 运动类型id
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SportId { get; set; }

        /// <summary>
        /// 运动详情id
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SporteId { get; set; }

        /// <summary>
        /// 运动项目类别id
        /// </summary>
        public int SportTypeId { get; set; }

        /// <summary>
        /// 运动开始时间
        /// </summary>
        public DateTime SportStartDate { get; set; }

        /// <summary>
        /// 运动结束时间
        /// </summary>
        public DateTime SportEndDate { get; set; }

        /// <summary>
        /// 运动基数
        /// </summary>
        public int SportNum { get; set; }

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
