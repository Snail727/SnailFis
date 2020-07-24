using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Common
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
    {
        /// 把对象序列化并返回相应的字节
        /// </summary>
        /// <param name="pObj">需要序列化的对象</param>
        /// <returns>byte[]</returns>
        public static byte[] SerializeObject(object pObj)
        {
            byte[] array;
            if (pObj == null)
            {
                pObj = new CacheNull();
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                formatter.Serialize(memoryStream, pObj);
                array = memoryStream.ToArray();
            }
            return array;
        }

        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="pBytes">字节流</param>
        /// <returns>object</returns>
        public static object DeserializeObject(byte[] pBytes)
        {
            object result = null;
            if (pBytes == null)
            {
                return result;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(pBytes, 0, pBytes.Length))
            {
                memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
                var retObj = formatter.Deserialize(memoryStream);
                result = retObj is CacheNull ? null : retObj;
            }
            return result;
        }
    }
    [Serializable]
    class CacheNull : ISerializable
    {
        public CacheNull()
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
