using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model.BusinessModels.BaseData
{
    /// <summary>
    /// 运功详情信息逻辑类
    /// </summary>
    public class SportValueModel
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; set; }

        /// <summary>
        /// 运动类型id
        /// </summary>
        public int SportId { get; set; }

        /// <summary>
        /// 运动详情id
        /// </summary>
        public int SporteId { get; set; }

        /// <summary>
        /// 运动开始时间
        /// </summary>
        public DateTime SportStartDate { get; set; }

        /// <summary>
        /// 运动结束时间
        /// </summary>
        public DateTime SportEndDate { get; set; }

        /// <summary>
        /// 运动基数
        /// </summary>
        public int SportNum { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

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
