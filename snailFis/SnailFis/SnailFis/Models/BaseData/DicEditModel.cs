using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnailFis.Model.BaseData;

namespace SnailFis.Models.BaseData
{
    /// <summary>
    /// 字典信息编辑类
    /// </summary>
    public class DicEditModel
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

        public DicModel ToDicModel()
        {
            return new DicModel()
            {
                SfId = this.SfId,
                DicId = this.DicId,
                DicName = this.DicName,
                CreatedBy = this.CreatedBy,
                CreatedDate = this.CreatedDate,
                ModifiedBy = this.ModifiedBy,
                ModifiedDate = this.ModifiedDate
            };
        }
    }
}