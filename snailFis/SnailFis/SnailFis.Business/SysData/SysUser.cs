using SnailFis.Business.Common;
using SnailFis.Common;
using SnailFis.Data.Dals.SysData;
using SnailFis.Model.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Business.SysData
{
    /// <summary>
    /// 系统用户逻辑层
    /// </summary>
    public class SysUser 
    {
        SysUserDal _dal;
        public SysUser() 
        {
            _dal = new SysUserDal();
        }

        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="model">系统用户信息</param>
        /// <returns></returns>
        public void AddUser(SysUserModel model)
        {
            model.PassWord = MD5Helper.MD5Encrypt32(model.PassWord) ;
            _dal.AddUser(model);
        }

        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model">系统用户信息</param>
        /// <returns></returns>
        public void UpdateUser(SysUserModel model)
        {
            model.PassWord = MD5Helper.MD5Encrypt32(model.PassWord);
            _dal.UpdateUser(model);
        }
    }
}
