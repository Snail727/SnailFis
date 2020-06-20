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
        /// 根据手机号获取用户列表
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public List<SysUserModel> GetUserListByPhone(string phone) 
        {
            return _dal.GetUserListByPhone(phone);
        }

        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="model">系统用户信息</param>
        /// <returns></returns>
        public int AddUser(SysUserModel model)
        {
            model.PassWord = MD5Helper.MD5Encrypt32(model.PassWord) ;
            return _dal.AddUser(model);
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

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="login">登陆信息</param>
        /// <returns></returns>
        public bool UserLogin(string userPass,string passWord)
        {
            if (userPass == MD5Helper.MD5Encrypt32(passWord)) { return true; }
            return false;
        }
    }
}
