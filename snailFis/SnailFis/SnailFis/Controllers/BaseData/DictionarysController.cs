using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SnailFis.Business.BaseData;
using SnailFis.Model;
using SnailFis.Model.BusinessModels.BaseData;
using SnailFis.Models.BaseData;

namespace SnailFis.Controllers.BaseData
{
    /// <summary>
    /// 字典功能控制器
    /// </summary>
    public class DictionarysController : BaseApiController
    {
        /// <summary>
        /// 获取字典内容
        /// </summary>
        /// <returns></returns>
        public MessageModel GetDicList()
        {
            var list = new List<DicViewModel>();
            var tempList = new Dictionarys(SfId, UserSn).GetDicList();
            tempList.ForEach(v => list.Add(ToDicViewModel(v)));
            return new MessageModel(true,list);
        }

        /// <summary>
        /// 获取字典内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel GetDicModelById(int? id)
        {
            var msg = new MessageModel(false);
            if (id.HasValue && id.Value > 0)
            {
                var tempModel = new Dictionarys(SfId, UserSn).GetDicModelById(id.Value);
                if (tempModel == null) { return msg; }
                var model = ToDicGroupModel(tempModel, tempModel.Items);
                msg.Success = true;
                msg.Data = model;
            }
            return msg;
        }

        #region 业务model转换为视图model
        /// <summary>
        /// 转换为字典视图model
        /// </summary>
        /// <param name="model">DicModel</param>
        /// <param name="items">DiceModelList</param>
        /// <returns></returns>
        private DicViewModel ToDicGroupModel(DicModel model, List<DiceModel> items)
        {
            if (model == null) { return null; }
            var tempModel = ToDicViewModel(model);
            if (items == null) { return tempModel; }
            items.ForEach(v => tempModel.Items.Add(ToDiceViewModel(v)));
            return tempModel;
        }
        /// <summary>
        /// 转换为字典主表视图model
        /// </summary>
        /// <param name="model">DicModel</param>
        /// <returns></returns>
        private DicViewModel ToDicViewModel(DicModel model)
        {
            if (model == null) { return null; }
            return new DicViewModel()
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
        /// 转换为字典子表视图model
        /// </summary>
        /// <param name="model">DiceModel</param>
        /// <returns></returns>
        private DiceViewModel ToDiceViewModel(DiceModel model)
        {
            if (model == null) { return null; }
            return new DiceViewModel()
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
        public MessageModel AddDic(DicEditModel model)
        {
            var msg = new MessageModel(true);
            new Dictionarys(SfId, UserSn).AddDic(model.ToDicModel());
            return msg;
        }

        /// <summary>
        /// 修改字典主表
        /// </summary>
        /// <param name="model">字典主表信息</param>
        /// <returns></returns>
        public MessageModel UpdateDic(DicEditModel model)
        {
            var msg = new MessageModel(true);
            new Dictionarys(SfId, UserSn).UpdateDic(model.ToDicModel());
            return msg;
        }

        /// <summary>
        /// 新增字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public MessageModel AddDice(DiceEditModel model)
        {
            var msg = new MessageModel(true);
            new Dictionarys(SfId, UserSn).AddDice(model.ToDiceModel());
            return msg;
        }

        /// <summary>
        /// 修改字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public MessageModel UpdateDice(DiceEditModel model)
        {
            var msg = new MessageModel(true);
            new Dictionarys(SfId, UserSn).UpdateDice(model.ToDiceModel());
            return msg;
        }
    }
}
