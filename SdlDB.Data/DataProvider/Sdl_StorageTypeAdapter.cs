using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_StorageTypeAdapter
    {
        #region Sdl_StorageTypeAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_StorageTypeDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_StorageTypeDataSet(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_StorageType(Sdl_StorageType model)
        {
            return DatabaseProvider.GetInstance().AddSdl_StorageType(model);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_StorageType()
        {
            DatabaseProvider.GetInstance().DeleteSdl_StorageType();
        }

        #endregion Sdl_StorageTypeAdapter
    }
}
