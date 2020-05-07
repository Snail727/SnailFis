using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnailFis.Data.Models.BaseData;
using SnailFis.Data.Utilities;
using SnailFis.Model.BaseData;

namespace SnailFis.Data.BaseData
{
    /// <summary>
    /// 字典功能数据层
    /// </summary>
    public class DictionarysDal
    {
        public int SfId { get; }
        public int UserSn { get; }
        public DictionarysDal(int sfId, int userSn)
        {
            SfId = sfId;
            UserSn = userSn;
        }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <returns></returns>
        public List<DicModel> GetDicList()
        {
            var sql = "select * from bt_dic";
            var mainList = MySQlHelper.ExecuteListObject<DicDbModel>(sql,null);
            var list = new List<DicModel>();
            mainList.ForEach(v => list.Add(ToDicModel(v)));
            return list;
        }

        /// <summary>
        /// 获取字典内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DicModel GetDicModelById(int id)
        {
            var mainSql = $"select * from bt_dic where dic_id = {id}";
            var tempMain = MySQlHelper.ExecuteListObject<DicDbModel>(mainSql, null).FirstOrDefault();
            if (tempMain == null) { return null; };
            var model = ToDicModel(tempMain);
            var childSql = $"select * from bt_dice where dic_id = {id}";
            var childList = MySQlHelper.ExecuteListObject<DiceDbModel>(childSql, null);
            childList.ForEach(v => model.Items.Add(ToDiceModel(v)));
            return model;
        }

        #region 基类model转换为业务model
        /// <summary>
        /// 转换为字典业务model
        /// </summary>
        /// <param name="model">DicDbModel</param>
        /// <param name="items">DiceDbModelList</param>
        /// <returns></returns>
        private DicModel ToDicGroupModel(DicDbModel model, List<DiceDbModel> items)
        {
            if (model == null) { return null; }
            var tempModel = ToDicModel(model);
            if (items == null) { return tempModel; }
            items.ForEach(v => tempModel.Items.Add(ToDiceModel(v)));
            return tempModel;
        }
        /// <summary>
        /// 转换为字典主表业务model
        /// </summary>
        /// <param name="model">DicDbModel</param>
        /// <returns></returns>
        private DicModel ToDicModel(DicDbModel model)
        {
            if (model == null) { return null; }
            return new DicModel()
            {
                SfId = model.SfId,
                DicId = model.DicId,
                DicName = model.DicName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate
            };
        }
        /// <summary>
        /// 转换为字典子表业务model
        /// </summary>
        /// <param name="model">DiceDbModel</param>
        /// <returns></returns>
        private DiceModel ToDiceModel(DiceDbModel model)
        {
            if (model == null) { return null; }
            return new DiceModel()
            {
                SfId = model.SfId,
                DicId = model.DicId,
                DiceId = model.DiceId,
                DiceName = model.DiceName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate
            };
        }
        #endregion

        #region 业务model转换为基类model
        /// <summary>
        /// 转换为字典主表基类model
        /// </summary>
        /// <param name="model">DicModel</param>
        /// <returns></returns>
        private DicDbModel ToDicModel(DicModel model)
        {
            if (model == null) { return null; }
            return new DicDbModel()
            {
                SfId = model.SfId,
                DicId = model.DicId,
                DicName = model.DicName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate
            };
        }
        /// <summary>
        /// 转换为字典子表基类model
        /// </summary>
        /// <param name="model">DiceModel</param>
        /// <returns></returns>
        private DiceDbModel ToDiceModel(DiceModel model)
        {
            if (model == null) { return null; }
            return new DiceDbModel()
            {
                SfId = model.SfId,
                DicId = model.DicId,
                DiceId = model.DiceId,
                DiceName = model.DiceName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate
            };
        }
        #endregion

        /// <summary>
        /// 新增字典主表
        /// </summary>
        /// <param name="model">字典主表信息</param>
        /// <returns></returns>
        public void AddDic(DicModel model)
        {
            var nextId = new BaseOptionsDal(SfId, UserSn).GetNextId("dic_id", "bt_dic");
            var tempModel = ToDicModel(model);
            var sql = $@"insert into bt_dic(sf_id,dic_id,dic_name,created_by,created_date,modified_by,modified_date) 
                        values({SfId},{nextId},?dic_name,{UserSn},now(),{UserSn},now())";
            MySQlHelper.ExecuteScalar(sql, tempModel);
        }

        /// <summary>
        /// 修改字典主表
        /// </summary>
        /// <param name="model">字典主表信息</param>
        /// <returns></returns>
        public void UpdateDic(DicModel model)
        {
            var nextId = new BaseOptionsDal(SfId, UserSn).GetNextId("dic_id", "bt_dic");
            var tempModel = ToDicModel(model);
            var sql = $@"update bt_dic set dic_name=?dic_name,modified_by = {UserSn},modified_date = now() where sf_id={SfId} and dic_id=?dic_id;";
            MySQlHelper.ExecuteScalar(sql, tempModel);
        }

        /// <summary>
        /// 新增字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public void AddDice(DiceModel model)
        {
            var nextId = new BaseOptionsDal(SfId, UserSn).GetNextId("dice_id", "bt_dice");
            var tempModel = ToDiceModel(model);
            var sql = $@"insert into bt_dice(sf_id,dic_id,dice_id,dice_name,created_by,created_date,modified_by,modified_date)
                        values({SfId},?dic_id,{nextId},?dic_name,{UserSn},now(),{UserSn},now())";
            MySQlHelper.ExecuteScalar(sql, tempModel);
        }

        /// <summary>
        /// 修改字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public void UpdateDice(DiceModel model)
        {
            var nextId = new BaseOptionsDal(SfId,UserSn).GetNextId("dice_id","bt_dice");
            var tempModel = ToDiceModel(model);
            var sql = $@"update bt_dice set dice_name=?dice_name,modified_by = {UserSn},modified_date = now() where sf_id={SfId} and dice_id=?dice_id;";
            MySQlHelper.ExecuteScalar(sql, tempModel);
        }
    }
}
