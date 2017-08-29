using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_TruckWeightAdapter
    {
        #region Sdl_TruckWeightAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_TruckWeightDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_TruckWeightDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_TruckWeight(Sdl_TruckWeight model)
        {
            return DatabaseProvider.GetInstance().AddSdl_TruckWeight(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_TruckWeight(string where)
        {
            DatabaseProvider.GetInstance().DeleteSdl_TruckWeight(where);
        }

        #endregion
    }
}
