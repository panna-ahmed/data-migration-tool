using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrationTool
{
    public class Column
    {
        public string Name { get; set; }
        public string SQLType { get; set; }
        public string Length { get; set; }
        public string Collate { get; set; }

        public string TypeLength {
            get
            {
                return string.Format("{0}({1})", SQLType, Length);
            }
        }

        public string SQLName
        {
            get
            {
                return string.Format("[{0}]", Name);
            }
        }

        public string SQLNameTypeLength
        {
            get
            {
                return string.Format("{0} {1}({2})", SQLName, SQLType, Length);
            }
        }
    }
}
