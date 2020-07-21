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
    /// 运动类型信息基类
    /// </summary>
    [Table("bt_sport_type")]
    public class SportTypeDbModel
    {
        /// <summary>
        /// 运动类型id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DBColumn("SportId")]
        public int SportId { get; set; }

        /// <summary>
        /// 运动类型名称
        /// </summary>
        [StringLength(64)]
        [DBColumn("SportName")]
        public string SportName { get; set; }

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
