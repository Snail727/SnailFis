using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Data.Models.SysData
{
    /// <summary>
    /// 运动类型信息基类
    /// </summary>
    [Table("sys_common")]
    [Serializable]
    public class SysCommonDbModel
    {
        /// <summary>
        /// 一级主键
        /// </summary>
        [Key]
        [Column(Order =0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FirstKey { get; set; }

        /// <summary>
        /// 二级主键
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SecondKey { get; set; }

        /// <summary>
        /// 三级主键
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThirdKey { get; set; }

        /// <summary>
        /// 数值1
        /// </summary>
        public decimal FValue1 { get; set; }
        /// <summary>
        /// 数值2
        /// </summary>
        public decimal FValue2 { get; set; }
        /// <summary>
        /// 数值3
        /// </summary>
        public decimal FValue3 { get; set; }

        /// <summary>
        /// 字符值1
        /// </summary>
        [StringLength(256)]
        public string StrValue1 { get; set; }

        /// <summary>
        /// 字符值2
        /// </summary>
        [StringLength(256)]
        public string StrValue2 { get; set; }

        /// <summary>
        /// 字符值3
        /// </summary>
        [StringLength(256)]
        public string StrValue3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
        public string Note { get; set; }
    }
}
