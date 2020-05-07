using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.BaseData
{
    /// <summary>
    /// 字典信息基类
    /// </summary>
    public class DicDbModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        [DBColumn("sf_id")]
        public int SfId { get; set; }

        /// <summary>
        /// 字典id
        /// </summary>
        [DBColumn("dic_id")]
        public int DicId { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [DBColumn("dic_name")]
        public string DicName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DBColumn("created_by")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBColumn("created_date")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [DBColumn("modified_by")]
        public int ModifiedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DBColumn("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
