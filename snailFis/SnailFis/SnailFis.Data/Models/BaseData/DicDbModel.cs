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
    /// 字典信息基类
    /// </summary>
    [Table("bt_dic")]
    public class DicDbModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        [Key]
        [DBColumn("SfId")]
        public int SfId { get; set; }

        /// <summary>
        /// 字典id
        /// </summary>
        [DBColumn("DicId")]
        public int DicId { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [DBColumn("DicName")]
        public string DicName { get; set; }

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
