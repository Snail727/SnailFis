using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Model
{
    public class DBColumnAtrributes : Attribute
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class DBColumnAttribute : Attribute
        {
            public string ColumnName { get; set; }
            public DBColumnAttribute(string columnName)
            {
                ColumnName = columnName;
            }
        }
    }
}
