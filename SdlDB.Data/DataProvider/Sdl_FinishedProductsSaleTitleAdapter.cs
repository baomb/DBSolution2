using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsSaleTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsSaleTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitleSet(where);
        }


        public static DataSet GetSdl_FinishedProductsSaleTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_FinishedProductsSaleTitleExcelData(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitleExcelData(where);
        }


        public static DataSet GetSdl_FinishedProductsSaleTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string vbeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitle(truckNum, vbeln, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_FinishedProductsSaleTitleDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitleDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_FinishedProductsSaleTitle(timeFlag, vbeln);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsSaleTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSaleTitle(model);
        }
        public static void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model, string vbeln, string trucknum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSaleTitle(model, vbeln, trucknum);
        }

        public static void UpdateSdl_FinishedProductsSaleTitle_S(Sdl_FinishedProductsSaleTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSaleTitle_S(model);
        }

        public static int AmendSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_FinishedProductsSaleTitle(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsSaleTitle(timeFlag, vbeln);
        }

        public static void DeleteSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsSaleTitle(truckNum, timeFlag, vbeln);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsSaleTitle> GetSdl_FinishedProductsSaleTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleTitleList(table);
        }

        #endregion  成员方法
    }
}
