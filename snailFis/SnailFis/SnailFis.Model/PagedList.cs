using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model
{
    public class PagedList<T>
    {
        /// <summary>
        /// 数据总数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> List { get; set; }
    }
}
