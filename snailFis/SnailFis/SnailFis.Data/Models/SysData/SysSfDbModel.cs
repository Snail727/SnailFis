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
    /// 系统蜗居基类
    /// </summary>
    [Table("sys_sf")]
    public class SysSfDbModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DBColumn("SfId")]
        public int SfId { get; set; }

        /// <summary>
        /// 蜗居名称
        /// </summary>
        [StringLength(64)]
        [DBColumn("SfName")]
        public string SfName { get; set; }

        // <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
        [DBColumn("Note")]
        public string Note { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DBColumn("CreatedBy")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBColumn("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [DBColumn("ModifiedBy")]
        public int ModifiedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DBColumn("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
