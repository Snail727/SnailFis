using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Common
{
public static class RedisHelper
{
    private static readonly object lockObj = new object();//定义锁对象
    private static ConnectionMultiplexer redis = null;//定义redis连接
    public static ConnectionMultiplexer Redis//获取redis
    {
        get
        {
            if (redis == null)
            {
                lock (lockObj)//锁
                {
                    if (redis == null || !redis.IsConnected)
                    {
                        redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisServer"]);
                    }
                }
            }
            return redis;
        }
    }
    public static IDatabase Database => Redis.GetDatabase();//默认获取第一个库

    /// <summary>
    /// 是否存在指定的键
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool HasKey(string key)
    {
        return Database.KeyExists(key);//是否存在该键
    }
    /// <summary>
    /// 获取指定类型的键值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get<T>(string key)
    {
        object value = Utils.DeserializeObject(Database.StringGet(key));//根据传入的泛型将取到的值反序列化
        return value == null ? default(T) : (T)value;
    }
    /// <summary>
    /// 设置键、值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Set(string key, object value)
    {
        Set(key, value, TimeSpan.FromHours(2));//设置键值和2小时的过期时间
    }
    /// <summary>
    /// 设置键、值，并设定过期时间
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="silidingExpiration"></param>
    public static void Set(string key, object value, TimeSpan silidingExpiration)
    {
        Database.StringSet(key, Utils.SerializeObject(value), silidingExpiration);//设置键值和过期时间
    }
    /// <summary>
    /// 删除键值
    /// </summary>
    /// <param name="key"></param>
    public static void DeleteKey(string key)
    {
        Database.KeyDelete(key);//删除键值
    }
}
}
