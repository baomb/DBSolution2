using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDB.Entity;
using System.Data;

namespace SdlDB.Data
{
    public class Sdl_AccessoryReturnTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_AccessoryReturnTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitleSet(where);
        }

        public static DataSet GetSdl_AccessoryReturnTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AccessoryReturnTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryReturnTitle GetSdl_AccessoryReturnTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryReturnTitle GetSdl_AccessoryReturnTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryReturnTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryReturnTitle(timeFlag, ebeln);
        }

        public static bool ExistsSdl_AccessoryReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryReturnTitle(timeFlag, ebeln, trucknum);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryReturnTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryReturnTitle(model);
        }

        public static void UpdateSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryReturnTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_AccessoryReturnTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryReturnTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryReturnTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryReturnTitle(timeFlag, ebeln);
        }

        public static void DeleteSdl_AccessoryReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryReturnTitle(timeFlag, ebeln, trucknum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryReturnTitleByTimeFlag(Sdl_AccessoryReturnTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryReturnTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryReturnTitle> GetSdl_AccessoryReturnTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnTitleList(table);
        }

        #endregion  成员方法
    }
}
