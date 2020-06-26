using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnailFis.Business.Common;
using SnailFis.Data.Dals.BaseData;
using SnailFis.Model.BusinessModels.BaseData;

namespace SnailFis.Business.BaseData
{
    /// <summary>
    /// 字典功能逻辑层
    /// </summary>
    public class Dictionarys : BaseBusiness
    {
        DictionarysDal _dal;
        public Dictionarys(int sfId, int userSn):base(sfId,userSn) {
            _dal = new DictionarysDal(SfId,UserSn);
        }
        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <returns></returns>
        public List<DicModel> GetDicList()
        {
            return _dal.GetDicList();
        }

        /// <summary>
        /// 获取字典内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DicModel GetDicModelById(int id)
        {
            return _dal.GetDicModelById(id);
        }

        /// <summary>
        /// 新增字典主表
        /// </summary>
        /// <param name="model">字典主表信息</param>
        /// <returns></returns>
        public void AddDic(DicModel model)
        {
            _dal.AddDic(model);
        }

        /// <summary>
        /// 修改字典主表
        /// </summary>
        /// <param name="model">字典主表信息</param>
        /// <returns></returns>
        public void UpdateDic(DicModel model)
        {
            _dal.UpdateDic(model);
        }

        /// <summary>
        /// 新增字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public void AddDice(DiceModel model)
        {
            _dal.AddDice(model);
        }

        /// <summary>
        /// 修改字典子表
        /// </summary>
        /// <param name="model">字典子表信息</param>
        /// <returns></returns>
        public void UpdateDice(DiceModel model)
        {
            _dal.UpdateDice(model);
        }
    }
}
