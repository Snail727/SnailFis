using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SnailFis.Data.Utilities;

namespace SnailFis.Data.BaseData
{
    public class BaseOptionsDal
    {
        public int SfId { get; }
        public int UserSn { get; }
        public BaseOptionsDal(int sfId, int userSn)
        {
            SfId = sfId;
            UserSn = userSn;
        }

        #region 获取下一个id
        /// <summary>
        /// 获取下一个id
        /// </summary>
        /// <param name="idColumn">主键名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public int GetNextId(string idColumn, string tableName)
        {
            int id = 100000001;
            var sql = $"select max({idColumn}) FROM `{tableName}` where sf_id = {SfId};";
            var tempId = MySQlHelper.ExecuteScalar(sql);
            if (int.TryParse(tempId.ToString(), out id))
            {
                return id+1;
            }
            return id;
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="others">其他条件</param>
        /// <param name="pk">主键列</param>
        /// <param name="ids">ID列表</param>
        public void DeleteData(string tableName, string others, string pk, int[] ids)
        {
            if (ids == null || ids.Count() <= 0 || ids[0] <= 0) { return; }
            var sql = $"delete from {tableName} where sf_id={SfId} {others} and {pk} in ({string.Join(",", ids)})";
            MySQlHelper.ExecuteScalar(sql);
        }
        #endregion
    }
}
