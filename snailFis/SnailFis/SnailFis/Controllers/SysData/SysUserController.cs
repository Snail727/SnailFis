using SnailFis.Business.SysData;
using SnailFis.Common;
using SnailFis.Model;
using SnailFis.Models.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnailFis.Controllers.SysData
{
    /// <summary>
    /// 系统用户控制器
    /// </summary>
    public class SysUserController : BaseApiController
    {
        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        public MessageModel AddUser(SysUserEditModel model)
        {
            var validateMsg = ValidateDataSave(model);
            if (!validateMsg.Success) { return validateMsg; }
            new SysUser().AddUser(model.ToUserModel());
            return new MessageModel(true, "操作成功");
        }

        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        public MessageModel UpdateUser(SysUserEditModel model)
        {
            var validateMsg = ValidateDataSave(model);
            if (!validateMsg.Success) { return validateMsg; }
            new SysUser().UpdateUser(model.ToUserModel());
            return new MessageModel(true, "操作成功");
        }

        #region 验证数据
        /// <summary>
        /// 验证数据保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private MessageModel ValidateDataSave(SysUserEditModel model)
        {
            var sysUser = new SysUser();

            #region 基础验证
            if (model == null) { return new MessageModel(false, "参数错误！"); }
            var baseMsg = ValidationModel.Validate(model); //验证是否为空和长度
            if (!baseMsg.Success) { return baseMsg; }
            var sysUserList = sysUser.GetUserListByPhone(model.Phone);
            if (sysUserList.Count(v => v.Phone == model.Phone && v.UserSn != model.UserSn) > 0) { return new MessageModel(false, "该手机号已存在！"); }
            #endregion

            return new MessageModel(true);
        }
        #endregion

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="login">登陆信息</param>
        /// <returns></returns>
        public MessageModel UserLogin(LoginData login) 
        {
            if (login == null) { return new MessageModel(false, "参数错误！"); }
            var baseMsg = ValidationModel.Validate(login); //验证是否为空和长度
            if (!baseMsg.Success) { return baseMsg; }
            var sysUser = new SysUser();
            var user = sysUser.GetUserListByPhone(login.Phone).FirstOrDefault();
            if (user == null) { return new MessageModel(false, "该手机号尚未注册"); }
            var isLogin = new SysUser().UserLogin(user.PassWord,login.PassWord);
            if (!isLogin) { return new MessageModel(false, "密码错误"); }

            var accesstoken = TokenHelper.GenToken(new TokenInfo() { Sub= "accesstoken", UserName = user.UserName, UserSn = user.UserSn, Phone = user.Phone });
            var refreshtoken = TokenHelper.GenToken(new TokenInfo() { Sub= "refreshtoken", UserName = user.UserName, UserSn = user.UserSn, Phone = user.Phone });
            return new MessageModel(true, "登陆成功", new TokenViewModel() { Accesstoken=accesstoken,Refreshtoken=refreshtoken});
        }
    }
}
