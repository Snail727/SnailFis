﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Business.Common
{
    /// <summary>
    /// 业务逻辑基类
    /// </summary>
    public class BaseBusiness
    {
        /// <summary>
        /// 蜗居id
        /// </summary>
        public int SfId { get; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public int UserSn { get; }
        public BaseBusiness(int sfId, int userSn)
        {
            SfId = sfId;
            UserSn = userSn;
        }
    }
}
