using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Common
{
    public static class ThreadHelpers
    {
        /// <summary>
        /// 分片处理数据量大的数据
        /// </summary>
        /// <param name="task">Action第一个参数是偏移量，第二个参数是当前分片大小</param>
        /// <param name="length">要分片的数据长度</param>
        /// <param name="offset">长度偏移量</param>
        public static void LoopTask(Action<int, int> task, int length, int offset)
        {
            var childTasks = new List<Task>();
            //pageSize:分片长度，每个线程处理的数量
            var pageSize = 100;
            ////size：分片数量，分多少线程处理
            //var size = Math.Ceiling(length / pageSize);
            while (length > 0)
            {
                int _offset = offset, _size = Math.Min(pageSize, length);
                childTasks.Add(Task.Factory.StartNew(() => task(_offset, _size)));
                length -= _size;
                offset += _size;
            }
            //堵塞以等待所有线程完成
            Task.WaitAll(childTasks.ToArray());
        }
    }
}
