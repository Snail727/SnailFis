using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Data.Dals.Common
{
    /// <summary>
    /// 数据层基类
    /// </summary>
    public class BaseDal
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public int UserSn { get; }
        public BaseDal(int sfId, int userSn)
        {
            SfId = sfId;
            UserSn = userSn;
        }
    }
}
