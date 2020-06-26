using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model.BusinessModels.BaseData
{
    /// <summary>
    /// 运功项目逻辑类
    /// </summary>
    public class SportTypeModel
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
        /// 运动类型名称
        /// </summary>
        public string SportName { get; set; }

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
