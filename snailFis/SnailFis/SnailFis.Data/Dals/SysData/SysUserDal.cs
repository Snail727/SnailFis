using SnailFis.Data.Dals.Common;
using SnailFis.Data.EfModel;
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
        /// <summary>
        /// 获取系统用户内容
        /// </summary>
        /// <param name="userSn"></param>
        /// <returns></returns>
        public SysUserModel GetSysUserByUserSn(int userSn)
        {
            var db = new SnailFisDbContext();
            var tempModel =db.UserList.FirstOrDefault(v => v.UserSn == userSn);
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
            var db = new SnailFisDbContext();
            var tempList = db.UserList.Where(v=>v.Phone==phone).ToList();
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
            var nextUserSn = new BaseOptionsDal(0).GetNextUserSn();
            var tempModel = ToSysUserDbModel(model);
            using (var db = new SnailFisDbContext()) 
            {
                tempModel.CreatedDate = tempModel.ModifiedDate = DateTime.Now;
                tempModel.UserSn = Convert.ToInt32(nextUserSn);
                db.UserList.Add(tempModel);
                db.SaveChanges();
            }
            return tempModel.UserSn;
        }

        /// <summary>
        /// 修改系统用户主表
        /// </summary>
        /// <param name="model">系统用户主表信息</param>
        /// <returns></returns>
        public void UpdateUser(SysUserModel model)
        {
            using (var db = new SnailFisDbContext())
            {
                var tempUpdateModel = db.UserList.FirstOrDefault(v => v.UserSn == model.UserSn);
                if (tempUpdateModel == null) { throw new Exception("未找到该用户"); };
                tempUpdateModel.UserSn = model.UserSn;
                tempUpdateModel.UserName = model.UserName;
                tempUpdateModel.PassWord = model.PassWord;
                tempUpdateModel.Phone = model.Phone;
                tempUpdateModel.Note = model.Note;
                tempUpdateModel.ModifiedDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
