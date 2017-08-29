using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FunctionsAdapter
    {
        #region Sdl_FunctionsAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_FunctionsDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FunctionsDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_Functions(Sdl_Functions model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Functions(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Functions(Sdl_Functions model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Functions(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_Functions(string functionid)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Functions(functionid);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Sdl_Functions GetSdl_Functions(string functionid)
        {
            return DatabaseProvider.GetInstance().GetSdl_Functions(functionid);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsExistChildFunction(string functionId)
        {
            return DatabaseProvider.GetInstance().IsExistChildFunction(functionId);
        }

       
        #endregion Sdl_FunctionsAdapter
    }
}
