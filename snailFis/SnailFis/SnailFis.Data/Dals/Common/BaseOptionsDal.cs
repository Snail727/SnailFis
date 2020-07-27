using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SnailFis.Common;
using SnailFis.Data.Common;
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

        #region GetRedisNextKey
        /// <summary>
        /// 根据redis获取下一个主键
        /// </summary>
        /// <param name="table">表信息</param>
        /// <param name="mainKey">主键</param>
        /// <param name="subKey">子键</param>
        /// <returns></returns>
        public int GetRedisNextKey(TableEnum table,int mainKey=0,int subKey=0) 
        {
            var tableKey = UserSn + "table" + table.ToString();
            if (RedisHelper.HasKey(tableKey))
            {
                return (int)RedisHelper.Increment(tableKey);
            }
            else 
            {
                string sql = GetSelectSql(table, mainKey, subKey);
                if (string.IsNullOrEmpty(sql)) { return (int)RedisHelper.IncrementInit(tableKey, 100000000); }
                var tempId = MySQlHelper.ExecuteScalar(sql);
                if (int.TryParse(tempId.ToString(), out int id))
                {
                    return (int)RedisHelper.IncrementInit(tableKey,(double)id);
                }
                else { return (int)RedisHelper.IncrementInit(tableKey,100000000); }
            }
        }
        private string GetSelectSql(TableEnum table, int mainKey, int subKey) 
        {
            string sql;
            switch (table)
            {
                case TableEnum.sys_user: sql = $"select max(UserSn) FROM `sys_user` "; break;
                case TableEnum.sys_common1: sql = $"select max(FirstKey) FROM `sys_common` "; break;
                case TableEnum.sys_common2: sql = $"select max(SecondKey) FROM `sys_common` where FirstKey={mainKey} "; break;
                case TableEnum.sys_common3: sql = $"select max(ThirdKey) FROM `sys_common` where FirstKey={mainKey} and SecondKey={subKey} "; break;
                case TableEnum.bt_unit_type: sql = $"select max(UnitTypeId) FROM `bt_unit_type` where UserSn={UserSn} "; break;
                case TableEnum.bt_unit_value: sql = $"select max(UnitId) FROM `bt_unit_value` where UserSn={UserSn} "; break;
                case TableEnum.sport_type: sql = $"select max(SportTypeId) FROM `sport_type` where UserSn={UserSn} "; break;
                case TableEnum.sport_main: sql = $"select max(SportId) FROM `sport_main` where UserSn={UserSn} "; break;
                case TableEnum.sport_child: sql = $"select max(SporteId) FROM `sport_child` where UserSn={UserSn} and SportId={mainKey} "; break;
                default: sql = ""; break;
            }
            return sql;
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
