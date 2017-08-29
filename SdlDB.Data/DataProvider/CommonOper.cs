using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Data
{
    public class CommonOper
    {

        public static string GetContent(string table, string code, string content, string codevalue)
        {
            return DatabaseProvider.GetInstance().GetContent(table, code, content, codevalue);
        }

        public static object ExecuteSql(string sql)
        {
            return DatabaseProvider.GetInstance().ExecuteSql(sql);
        }

        public static int GetMaxID(string fieldName, string tableName)
        {
            return DatabaseProvider.GetInstance().GetMaxID(fieldName, tableName);
        }
    }
}
