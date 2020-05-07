using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SnailFis.Model.DBColumnAtrributes;

namespace SnailFis.Common
{
    public class Utilitys
    {
        /// <summary>
        /// 通过datareader获取当前Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T GetGeneralledgerModel<T>(DbDataReader dr) where T : new()
        {
            T t = new T();
            var dbTable = dr.GetSchemaTable();
            var pis = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo pi in pis)
            {
                var columnAttrs = (DBColumnAttribute[])pi.GetCustomAttributes(typeof(DBColumnAttribute), false);
                if (columnAttrs.Count() > 0)
                {
                    var columnName = columnAttrs[0].ColumnName;

                    //dbTable.DefaultView.RowFilter = $"ColumnName='{columnName}'";

                    //if (dbTable.DefaultView.Count > 0 && dr[columnName] != DBNull.Value)
                    //{
                    //    pi.SetValue(t, dr[columnName], null);
                    //}
                }
            }
            return t;
        }
        public static List<T> GetGeneralledgerListModel<T>(DataTable dbTable) where T : new()
        {
            if (dbTable == null) return new List<T>();
            var ps = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var arr = new T[dbTable.Rows.Count];
            ThreadHelpers.LoopTask(new Action<int, int>((offset, size) =>
            {
                for (int i = offset; i < offset + size; i++)
                {
                    DataRow row = dbTable.Rows[i];
                    T t = new T();
                    foreach (PropertyInfo pi in ps)
                    {
                        var columnAttrs = (DBColumnAttribute[])pi.GetCustomAttributes(typeof(DBColumnAttribute), false);
                        if (columnAttrs.Count() <= 0) continue;
                        var columnName = columnAttrs[0].ColumnName;
                        if (!dbTable.Columns.Contains(columnName)) continue;
                        var r = row[columnName];
                        if (r == DBNull.Value) continue;
                        var pt = pi.PropertyType;
                        if (pt == typeof(decimal) || pt == typeof(decimal?))
                        {
                            pi.SetValue(t, Convert.ToDecimal(r));
                        }
                        else if (pt == typeof(long) || pt == typeof(long?))
                        {
                            pi.SetValue(t, Convert.ToInt64(r));
                        }
                        else if (pt == typeof(int) || pt == typeof(int?))
                        {
                            pi.SetValue(t, Convert.ToInt32(r));
                        }
                        else if (pi.PropertyType.BaseType == typeof(Enum))
                        {
                            try
                            {
                                pi.SetValue(t, Convert.ToInt32(r));
                            }
                            catch (OverflowException)
                            {
                                pi.SetValue(t, r);
                            }
                        }
                        else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                        {
                            pi.SetValue(t, Convert.ToDateTime(r));
                        }
                        else if (pi.PropertyType == typeof(bool) || pi.PropertyType == typeof(bool?))
                        {
                            pi.SetValue(t, Convert.ToBoolean(r));
                        }
                        else
                        {
                            pi.SetValue(t, r.ToString());
                        }
                    }
                    arr[i] = t;
                }
            }), dbTable.Rows.Count, 0);

            return arr.ToList();
        }

        
        /// <summary>
        /// 把模型对象转化为sql参数字典
        /// </summary>
        /// <typeparam name="T">需要转化的对象类型</typeparam>
        /// <param name="obj">需要转化的对象</param>
        /// <returns>参数字典</returns>
        public static Dictionary<string, object> ModleObj2SqlParas<T>(T obj)
        {
            var map = new Dictionary<string, object>();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in pi)
            {
                var columnAttrs = (DBColumnAttribute[])p.GetCustomAttributes(typeof(DBColumnAttribute), false);
                if (columnAttrs.Count() > 0)
                {
                    MethodInfo mi = p.GetGetMethod();
                    var columnName = columnAttrs[0].ColumnName;
                    if (mi != null && mi.IsPublic)
                    {
                        var value = mi.Invoke(obj, new object[] { });
                        if (value == null || (value is DateTime && (DateTime)value == default(DateTime)))
                        {
                            value = DBNull.Value;
                        }
                        map.Add(columnName, value);
                    }
                }
            }
            return map;
        }
    }
}
