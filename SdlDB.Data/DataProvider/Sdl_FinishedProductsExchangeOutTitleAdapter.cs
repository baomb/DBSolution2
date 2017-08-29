using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsExchangeOutTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsExchangeOutTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutTitleDataSet(where);
        }


        public static DataSet GetSdl_FinishedProductsExchangeOutTitlePageData(string pageNum, int PageSize, string where)
        { 
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_FinishedProductsExchangeOutTitleDataSetByField(string[] fieldNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutTitleDataSetByField(fieldNames,where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_FinishedProductsExchangeOutTitle(timeFlag, oanum, truckNum);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsExchangeOutTitle(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeOutTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeOutTitleByTimeFlag(Sdl_FinishedProductsExchangeTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeOutTitleByTimeFlag(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model, string truckNum, string oanum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeOutTitle(model, truckNum, oanum);
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeOutTitle(string truckNum, string oanum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutTitle(truckNum, oanum, timeFlag);
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeOutTitle(timeFlag, oanum, truckNum);
        }
        

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsExchangeTitle> GetSdl_FinishedProductsExchangeOutTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutTitleList(table);
        }

        #endregion  成员方法
    }
}
