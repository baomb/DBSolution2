using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_ManualAdapter
    {
        #region  Sdl_ManualAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_ManualDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ManualDataSet(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Manual(Sdl_Manual model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Manual(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateSdl_Manual(Sdl_Manual model)
        {
            return DatabaseProvider.GetInstance().UpdateSdl_Manual(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Manual(string type)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Manual(type);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Manual GetSdl_Manual(string type)
        {
            return DatabaseProvider.GetInstance().GetSdl_Manual(type);
        }

        #endregion  Sdl_ManualAdapter
    }
}
