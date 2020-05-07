using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Data.Models.BaseData
{
    /// <summary>
    /// 字典子表信息基类
    /// </summary>
    public class DiceDbModel
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
        /// 字典内容id
        /// </summary>
        [DBColumn("dice_id")]
        public int DiceId { get; set; }

        /// <summary>
        /// 字典内容名称
        /// </summary>
        [DBColumn("dice_name")]
        public string DiceName { get; set; }

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
