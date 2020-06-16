using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.SysData
{
    /// <summary>
    /// 系统蜗居基类
    /// </summary>
    public class SysSfDbModel
    {

        /// <summary>
        /// 蜗居id
        /// </summary>
        [DBColumn("SfId")]
        public int SfId { get; set; }

        /// <summary>
        /// 蜗居名称
        /// </summary>
        [DBColumn("SfName")]
        public string SfName { get; set; }

        // <summary>
        /// 备注
        /// </summary>
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
