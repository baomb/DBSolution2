using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_LoadometerDiffAdapter
    {
        #region Sdl_LoadometerDiffAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_LoadometerDiffDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_LoadometerDiffDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_LoadometerDiff(Sdl_LoadometerDiff model)
        {
            return DatabaseProvider.GetInstance().AddSdl_LoadometerDiff(model);
        }

        /// <summary>
        /// 获取地磅误差数值
        /// </summary>
        public static double GetSdl_LoadometerDiff(string id)
        {
            return DatabaseProvider.GetInstance().GetSdl_LoadometerDiff(id);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_LoadometerDiff()
        {
            DatabaseProvider.GetInstance().DeleteSdl_LoadometerDiff();
        }

        #endregion
    }
}
