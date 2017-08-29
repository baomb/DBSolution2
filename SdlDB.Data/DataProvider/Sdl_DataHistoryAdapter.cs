using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_DataHistoryAdapter
    {
        public static DataSet GetSdl_DataHistoryDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_DataHistoryDataSet(where);
        }

        public static DataSet GetSdl_DataHistoryPageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_DataHistoryPageData(pageNum, PageSize, where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_DataHistory(string editTime, string tableName, string field)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_DataHistory(editTime, tableName, field);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_DataHistory(Sdl_DataHistory model)
        {
            return DatabaseProvider.GetInstance().AddSdl_DataHistory(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_DataHistory(Sdl_DataHistory model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_DataHistory(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_DataHistory(string editTime, string tableName, string field)
        {
            DatabaseProvider.GetInstance().DeleteSdl_DataHistory(editTime, tableName, field);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_DataHistory GetSdl_DataHistory(string editTime, string tableName, string field)
        {
            return DatabaseProvider.GetInstance().GetSdl_DataHistory(editTime, tableName, field);
        }
    }
}
