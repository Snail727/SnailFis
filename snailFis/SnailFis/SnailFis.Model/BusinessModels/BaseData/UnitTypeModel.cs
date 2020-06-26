using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model.BusinessModels.BaseData
{
    /// <summary>
    /// 单位类别信息逻辑类
    /// </summary>
    public class UnitTypeModel
    {
        public UnitTypeModel()
        {
            Items = new List<UnitValueModel>();
        }
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; set; }

        /// <summary>
        /// 单位类别id
        /// </summary>
        public int UnitTypeId { get; set; }

        /// <summary>
        /// 单位类别名称
        /// </summary>
        public string UnitTypeName { get; set; }

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
        /// 单位子表集合
        /// </summary>
        public List<UnitValueModel> Items { get; set; }
    }
}
