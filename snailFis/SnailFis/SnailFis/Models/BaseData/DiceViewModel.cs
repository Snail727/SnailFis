using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnailFis.Models.BaseData
{
    /// <summary>
    /// 字典子表信息视图类
    /// </summary>
    public class DiceViewModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; set; }

        /// <summary>
        /// 字典id
        /// </summary>
        public int DicId { get; set; }

        /// <summary>
        /// 字典内容id
        /// </summary>e
        public int DiceId { get; set; }

        /// <summary>
        /// 字典内容名称
        /// </summary>
        public string DiceName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int ModifiedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}