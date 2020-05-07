using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model
{
    public class MessageModel
    {
        public MessageModel()
            : this(null)
        { }
        public MessageModel(object data)
            : this(false, string.Empty, data)
        { }
        public MessageModel(bool state)
            : this(state, string.Empty)
        { }
        public MessageModel(bool state, object data)
            : this(state, string.Empty, data)
        { }
        public MessageModel(bool state, string message)
            : this(state, message, null)
        { }
        public MessageModel(bool state, string message, object data)
        {
            Success = state;
            Msg = message;
            Data = data;
        }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
