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
    /// 单位类别信息基类
    /// </summary>
    [Table("bt_unit_type")]
    [Serializable]
    public class UnitTypeDbModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSn { get; set; }

        /// <summary>
        /// 单位类别id
        /// </summary>
        [Key]
        [Column(Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitTypeId { get; set; }

        /// <summary>
        /// 单位类别名称
        /// </summary>
        [StringLength(64)]
        public string UnitTypeName { get; set; }

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
