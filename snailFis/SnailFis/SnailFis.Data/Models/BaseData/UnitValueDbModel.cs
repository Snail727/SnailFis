﻿using System;
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
    /// 单位信息基类
    /// </summary>
    [Table("bt_unit_value")]
    public class UnitValueDbModel
    {
        /// <summary>
        /// 单位类别id
        /// </summary>
        [DBColumn("UnitTypeId")]
        public int UnitTypeId { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DBColumn("UnitId")]
        public int UnitId { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [DBColumn("UnitName")]
        [StringLength(64)]
        public string UnitName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBColumn("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DBColumn("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
