using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.BaseData
{
    /// <summary>
    /// 运功详情信息基类
    /// </summary>
    [Table("bt_sport_value")]
    public class SportValueDbModel
    {
        /// <summary>
        /// 运动类型id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DBColumn("SportId")]
        public int SportId { get; set; }

        /// <summary>
        /// 运动详情id
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DBColumn("SporteId")]
        public int SporteId { get; set; }

        /// <summary>
        /// 运动开始时间
        /// </summary>
        [DBColumn("SportStartDate")]
        public DateTime SportStartDate{ get; set; }

        /// <summary>
        /// 运动结束时间
        /// </summary>
        [DBColumn("SportEndDate")]
        public DateTime SportEndDate { get; set; }

        /// <summary>
        /// 运动基数
        /// </summary>
        [DBColumn("SportNum")]
        public int SportNum { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        [DBColumn("UnitId")]
        public int UnitId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
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
