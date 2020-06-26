using SnailFis.Data.Dals.Common;
using SnailFis.Data.Models.SysData;
using SnailFis.Data.Utilities;
using SnailFis.Model.BusinessModels.SysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Data.Dals.SysData
{
    /// <summary>
    /// 系统用户数据层
    /// </summary>
    public class SysUserDal
    {
        public SysUserDal()
        { }

        /// <summary>
        /// 获取系统用户内容
        /// </summary>
        /// <param name="userSn"></param>
        /// <returns></returns>
        public SysUserModel GetSysUserByUserSn(int userSn)
        {
            var sql = $"select * from sys_user where UserSn = {userSn}";
            var tempModel = MySQlHelper.ExecuteListObject<SysUserDbModel>(sql, null).FirstOrDefault();
            if (tempModel == null) { return null; };
            var model = ToSysUserModel(tempModel);
            return model;
        }

        /// <summary>
        /// 根据手机号获取用户列表
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public List<SysUserModel> GetUserListByPhone(string phone)
        {
            var sql = $"select * from sys_user where Phone = {phone}";
            var tempList = MySQlHelper.ExecuteListObject<SysUserDbModel>(sql, null);
            if (tempList == null) { return null; };
            var list = tempList.Select(v => ToSysUserModel(v)).ToList();
            return list;
        }

        #region 基类model转换为业务model
        /// <summary>
        /// 转换为系统用户业务model
        /// </summary>
        /// <param name="model">DicDbModel</param>
        /// <returns></returns>
        private SysUserModel ToSysUserModel(SysUserDbModel model)
        {
            if (model == null) { return null; }
            return new SysUserModel()
            {
                UserSn = model.UserSn,
                UserName = model.UserName,
                PassWord = model.PassWord,
                Phone = model.Phone,
                Note = model.Note,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate
            };
        }
        #endregion

        #region 业务model转换为基类model
        /// <summary>
        /// 转换为系统用户主表基类model
        /// </summary>
        /// <param name="model">DicModel</param>
        /// <returns></returns>
        private SysUserDbModel ToSysUserDbModel(SysUserModel model)
        {
            if (model == null) { return null; }
            return new SysUserDbModel()
            {
                UserSn = model.UserSn,
                UserName = model.UserName,
                PassWord = model.PassWord,
                Phone = model.Phone,
                Note = model.Note,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate
            };
        }
        #endregion

        /// <summary>
        /// 新增系统用户主表
        /// </summary>
        /// <param name="model">系统用户主表信息</param>
        /// <returns></returns>
        public int AddUser(SysUserModel model)
        {
            var nextUserSn = new BaseOptionsDal(0, 0).GetNextUserSn();
            var tempModel = ToSysUserDbModel(model);
            var sql = $@"insert into sys_user(UserSn,UserName,PassWord,Phone,Note,CreatedDate,ModifiedDate) 
                        values({nextUserSn},?UserName,?PassWord,?Phone,?Note,now(),now())";
            MySQlHelper.ExecuteScalar(sql, tempModel);
            return Convert.ToInt32(nextUserSn);
        }

        /// <summary>
        /// 修改系统用户主表
        /// </summary>
        /// <param name="model">系统用户主表信息</param>
        /// <returns></returns>
        public void UpdateUser(SysUserModel model)
        {
            var tempModel = ToSysUserDbModel(model);
            var sql = $@"update sys_user set UserName=?UserName,PassWord=?PassWord,Phone=?Phone,Note=?Note,ModifiedDate = now() where UserSn={model.UserSn};";
            MySQlHelper.ExecuteScalar(sql, tempModel);
        }
    }
}
