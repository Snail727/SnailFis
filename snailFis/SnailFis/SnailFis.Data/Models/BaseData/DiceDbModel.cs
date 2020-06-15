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
        [DBColumn("SfId")]
        public int SfId { get; set; }

        /// <summary>
        /// 字典id
        /// </summary>
        [DBColumn("DicId")]
        public int DicId { get; set; }

        /// <summary>
        /// 字典内容id
        /// </summary>
        [DBColumn("DiceId")]
        public int DiceId { get; set; }

        /// <summary>
        /// 字典内容名称
        /// </summary>
        [DBColumn("DiceName")]
        public string DiceName { get; set; }

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
