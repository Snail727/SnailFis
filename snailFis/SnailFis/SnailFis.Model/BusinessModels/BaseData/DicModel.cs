using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model.BusinessModels.BaseData
{
    /// <summary>
    /// 字典信息逻辑类
    /// </summary>
    public class DicModel
    {
        public DicModel()
        {
            Items = new List<DiceModel>();
        }
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; set; }

        /// <summary>
        /// 字典id
        /// </summary>
        public int DicId { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string DicName { get; set; }

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

        /// <summary>
        /// 字典子表集合
        /// </summary>
        public List<DiceModel> Items { get; set; }
    }
}
