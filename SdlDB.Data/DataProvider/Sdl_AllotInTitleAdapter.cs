using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AllotInTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_AllotInTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitleSet(where);
        }

        public static DataSet GetSdl_AllotInTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AllotInTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_AllotInTitleDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitleDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AllotInTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotInTitle(timeFlag, ebeln);
        }

        public static bool ExistsSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotInTitle(timeFlag, ebeln, trucknum);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AllotInTitle(Sdl_AllotInTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AllotInTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotInTitle(model);
        }

        public static void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotInTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_AllotInTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AllotInTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AllotInTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotInTitle(timeFlag, ebeln);
        }
        public static void DeleteSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotInTitle(timeFlag, ebeln, trucknum);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotInTitleByTimeFlag(Sdl_AllotInTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotInTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AllotInTitle> GetSdl_AllotInTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInTitleList(table);
        }

        #endregion  成员方法
    }
}
