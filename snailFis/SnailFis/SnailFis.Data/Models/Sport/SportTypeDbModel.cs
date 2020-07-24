using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.Sport
{
    /// <summary>
    /// 运动类型信息基类
    /// </summary>
    [Table("sport_type")]
    [Serializable]
    public class SportTypeDbModel
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
        public int SportTypeId { get; set; }

        /// <summary>
        /// 运动类型名称
        /// </summary>
        [StringLength(64)]
        public string SportTypeName { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        public int UnitId { get; set; }

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
