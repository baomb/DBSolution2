using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AllotTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_AllotTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitleSet(where);
        }

        public static DataSet GetSdl_AllotTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AllotTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotTitle GetSdl_AllotTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotTitle GetSdl_AllotTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_AllotTitleDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitleDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AllotTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotTitle(timeFlag, ebeln);
        }

        public static bool ExistsSdl_AllotTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotTitle(timeFlag, ebeln, trucknum);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AllotTitle(Sdl_AllotTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AllotTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotTitle(Sdl_AllotTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotTitle(model);
        }

        public static void UpdateSdl_AllotTitle(Sdl_AllotTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_AllotTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AllotTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AllotTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotTitle(timeFlag, ebeln);
        }

        public static void DeleteSdl_AllotTitle(string timeFlag, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotTitle(timeFlag, ebeln, truckNum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotTitleByTimeFlag(Sdl_AllotTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AllotTitle> GetSdl_AllotTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotTitleList(table);
        }

        #endregion  成员方法
    }
}
