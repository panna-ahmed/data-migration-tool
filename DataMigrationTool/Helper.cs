using System.Collections.Generic;
using System.Linq;

namespace DataMigrationTool
{
    public class Helper
    {
        public static string GetUpdateStatement(string source, string target, List<Column> columns)
        {
            var statement = string.Empty;

            foreach(var col in columns)
            {
                statement = statement + target + "." + col.SQLName + "=" + source + "." + col.SQLName + ",";
            }

            return statement.TrimEnd(',');
        }

        public static string GetInsertStatement(string source, List<Column> columns)
        {
            var statement =  string.Join("," + source + ".", columns.Select(c => c.SQLName).ToArray());
            statement = source + "." + statement;
            return statement;
        }

        public static string GetSelectStatement(List<Column> columns)
        {
            var selectStatement = string.Join(",", columns.Select(c => c.SQLName).ToArray());
            selectStatement.TrimEnd(',');
            return selectStatement;
        }

        public static string GetCreateStatement(List<Column> columns)
        {
            var statement = string.Empty;

            foreach (var col in columns)
            {
                statement = statement + col.SQLNameTypeLength;
                int length;
                if(int.TryParse(col.Length, out length))
                {
                    statement = statement + " COLLATE " + col.Collate;
                }

                statement = statement + ",";
            }

            return statement.TrimEnd(',');
        }
    }
}
