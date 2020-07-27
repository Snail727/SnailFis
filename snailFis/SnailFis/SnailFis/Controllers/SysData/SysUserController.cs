using SnailFis.Business.SysData;
using SnailFis.WebCommon;
using SnailFis.Model;
using SnailFis.Models.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SnailFis.Common;

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
        [AllowAnonymous]
        public MessageModel AddUser(SysUserEditModel model)
        {
            var validateMsg = ValidateDataSave(model);
            if (!validateMsg.Success) { return validateMsg; }
            model.UserSn = new SysUser().AddUser(model.ToUserModel());

            return new MessageModel(true, "操作成功", CreatTokenData(model.UserName, model.UserSn, model.Phone));
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
            return new MessageModel(true, "操作成功", CreatTokenData(model.UserName, model.UserSn, model.Phone));
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
        [AllowAnonymous]
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

            return new MessageModel(true, "登陆成功", CreatTokenData(user.UserName, user.UserSn, user.Phone));
        }

        /// <summary>
        /// 刷新accesstoken
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public MessageModel RefreshToken(TokenViewModel token)
        {
            var refMsg = TokenHelper.DecodeToken(token.Refreshtoken);
            if (!refMsg.Success){ throw new HttpResponseException(HttpStatusCode.Unauthorized); }

            var tokenInfo = (TokenInfo)refMsg.Data;
            var user = new SysUser().GetUserListByPhone(tokenInfo.Phone).FirstOrDefault();
            if (user == null) { return new MessageModel(false, "该手机号尚未注册"); }

            /*redis获取refreshtoken并进行比对*/
            var refreshtoken = RedisHelper.Get<string>("refreshtoken");
            if (refreshtoken != token.Refreshtoken) { throw new HttpResponseException(HttpStatusCode.Unauthorized); }

            var tokenData = CreatTokenData(user.UserName, user.UserSn, user.Phone);
            return new MessageModel(true, "刷新成功", tokenData);
        }

        private TokenViewModel CreatTokenData(string userName,int userSn,string phone) 
        {
            var accesstokenExp = DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds();
            var refreshtokenExp = DateTimeOffset.UtcNow.AddDays(30).ToUnixTimeSeconds();
            var accesstoken = TokenHelper.GenToken(new TokenInfo()
            {
                Sub = "accesstoken",
                Exp = accesstokenExp,
                UserName = userName,
                UserSn = userSn,
                Phone = phone
            });
            var refreshtoken = TokenHelper.GenToken(new TokenInfo()
            {
                Sub = "refreshtoken",
                Exp = refreshtokenExp,
                UserName = userName,
                UserSn = userSn,
                Phone = phone
            });
            /*redis储存refreshtoken*/
            RedisHelper.Set(userSn+ "refreshtoken", refreshtoken);
            var tokenData = new TokenViewModel()
            {
                Accesstoken = accesstoken,
                Refreshtoken = refreshtoken,
                Exp = accesstokenExp,
            };
            return tokenData;
        }
    }
}
