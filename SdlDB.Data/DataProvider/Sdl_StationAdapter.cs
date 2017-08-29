using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_StationAdapter
    {
        #region Sdl_StationAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_StationDataSet(string where, string field)
        {
            return DatabaseProvider.GetInstance().GetSdl_StationDataSet(where, field);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_Station(Sdl_Station model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Station(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_Station()
        {
            DatabaseProvider.GetInstance().DeleteSdl_Station();
        }

        #endregion Sdl_StationAdapter
    }
}
