using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnailFis.Common
{

    public class TokenException : Exception
    {
        public TokenException(string msg) : base(msg) { }
    }
}