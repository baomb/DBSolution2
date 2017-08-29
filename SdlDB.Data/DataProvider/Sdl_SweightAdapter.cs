using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_SweightAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_SweightDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_SweightDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_Sweight(string ID)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_Sweight(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Sweight(Sdl_Sweight model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Sweight(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Sweight(Sdl_Sweight model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Sweight(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Sweight(string ID)
        {

            DatabaseProvider.GetInstance().DeleteSdl_Sweight(ID);
        }

        public static void DeleteAllSdl_Sweight()
        {

            DatabaseProvider.GetInstance().DeleteAllSdl_Sweight();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Sweight GetSdl_Sweight(string ID)
        {

            return DatabaseProvider.GetInstance().GetSdl_Sweight(ID);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_Sweight> GetSdl_SweightList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_SweightList(table);
        }


        #endregion  成员方法
    }
}
