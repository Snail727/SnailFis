using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.BaseData
{
    /// <summary>
    /// 单位信息基类
    /// </summary>
    public class UnitValueDbModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        [DBColumn("SfId")]
        public int SfId { get; set; }

        /// <summary>
        /// 单位类别id
        /// </summary>
        [DBColumn("UnitTypeId")]
        public int UnitTypeId { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        [DBColumn("UnitId")]
        public int UnitId { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [DBColumn("UnitName")]
        public string UnitName { get; set; }

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
