using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_PackWeightAdapter
    {
        #region Sdl_PackWeightAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_PackWeightDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_PackWeightDataSet(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_PackWeight(Sdl_PackWeight model)
        {
            return DatabaseProvider.GetInstance().AddSdl_PackWeight(model);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_PackWeight()
        {
            DatabaseProvider.GetInstance().DeleteSdl_PackWeight();
        }

        #endregion Sdl_PackWeightAdapter
    }
}
