using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryAllotInTitleAdapter
    {
        #region  成员方法

        public static DataSet GetSdl_AccessoryAllotInTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitleSet(where);
        }

        public static DataSet GetSdl_AccessoryAllotInTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AccessoryAllotInTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_AccessoryAllotInTitleDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitleDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotInTitle GetSdl_AccessoryAllotInTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotInTitle GetSdl_AccessoryAllotInTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryAllotInTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryAllotInTitle(timeFlag, ebeln);
        }

        public static bool ExistsSdl_AccessoryAllotInTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryAllotInTitle(timeFlag, ebeln, trucknum);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryAllotInTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotInTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotInTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_AccessoryAllotInTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryAllotInTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotInTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotInTitle(timeFlag, ebeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotInTitle(string timeFlag, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotInTitle(timeFlag, ebeln, truckNum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotInTitleByTimeFlag(Sdl_AccessoryAllotInTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotInTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryAllotInTitle> GetSdl_AccessoryAllotInTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInTitleList(table);
        }

        #endregion  成员方法
    }
}
