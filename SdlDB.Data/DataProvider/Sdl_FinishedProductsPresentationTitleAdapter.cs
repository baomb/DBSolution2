using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsPresentationTitleAdapter
    {
        #region Sdl_FinishedProductsPresentationTitle

        public static DataSet GetSdl_FinishedProductsPresentationTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationTitleDataSet(where);
        }


        public static DataSet GetSdl_FinishedProductsPresentationTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationTitlePageData(pageNum, PageSize, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsPresentationTitle GetSdl_FinishedProductsPresentationTitle(string truckNum, string rsnum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationTitle(truckNum, rsnum, timeFlag);
        }

        /// <summary>
        /// 得到对象实体集
        /// </summary>
        public static DataSet GetSdl_FinishedProductsPresentationTitleDataSetByField(string[] fieldNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationTitleDataSetByField(fieldNames, where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsPresentationTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsPresentationTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model, string truckNum, string rsnum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsPresentationTitle(model, truckNum, rsnum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsPresentationTitleByTimeFlag(Sdl_FinishedProductsPresentationTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsPresentationTitleByTimeFlag(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsPresentationTitle(string timeFlag, string rsnum, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsPresentationTitle(timeFlag, rsnum, truckNum);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_FinishedProductsPresentationTitle> GetSdl_FinishedProductsPresentationTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationTitleList(table);
        }

        #endregion
    }
}
