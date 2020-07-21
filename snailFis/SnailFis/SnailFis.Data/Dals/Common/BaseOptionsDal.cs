using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SnailFis.Data.Utilities;

namespace SnailFis.Data.Dals.Common
{
    public class BaseOptionsDal : BaseDal
    {
        public BaseOptionsDal(int userSn) : base(userSn)
        {
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
            var sql = $"select max({idColumn}) FROM `{tableName}` where UserSn = {UserSn};";
            var tempId = MySQlHelper.ExecuteScalar(sql);
            if (int.TryParse(tempId.ToString(), out int id))
            {
                return id + 1;
            }
            else { id = 100000001; }
            return id;
        }
        #endregion

        #region 获取下一个userSn
        /// <summary>
        /// 获取下一个userSn
        /// </summary>
        /// <returns></returns>
        public int GetNextUserSn()
        {
            var sql = $"select max(UserSn) FROM `sys_user`;";
            var tempUserSn = MySQlHelper.ExecuteScalar(sql);
            if (int.TryParse(tempUserSn.ToString(), out int userSn))
            {
                return userSn + 1;
            }
            else { userSn = 100001; }
            return userSn;
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
            var sql = $"delete from {tableName} where UserSn={UserSn} {others} and {pk} in ({string.Join(",", ids)})";
            MySQlHelper.ExecuteScalar(sql);
        }
        #endregion
    }
}
