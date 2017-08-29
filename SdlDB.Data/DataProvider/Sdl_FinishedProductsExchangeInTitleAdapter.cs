using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsExchangeInTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsExchangeInTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInTitleDataSet(where);
        }


        public static DataSet GetSdl_FinishedProductsExchangeInTitlePageData(string pageNum, int PageSize, string where)
        { 
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_FinishedProductsExchangeInTitleDataSetByField(string[] fieldNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInTitleDataSetByField(fieldNames,where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_FinishedProductsExchangeInTitle(string timeFlag, string oanum, string truckNum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_FinishedProductsExchangeInTitle(timeFlag, oanum, truckNum);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsExchangeInTitle(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeInTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeInTitleByTimeFlag(Sdl_FinishedProductsExchangeTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeInTitleByTimeFlag(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model, string truckNum, string oanum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeInTitle(model, truckNum, oanum);
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeInTitle(string truckNum, string oanum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInTitle(truckNum, oanum, timeFlag);
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsExchangeInTitle(string timeFlag, string oanum, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeInTitle(timeFlag, oanum, truckNum);
        }
        

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsExchangeTitle> GetSdl_FinishedProductsExchangeInTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInTitleList(table);
        }

        #endregion  成员方法
    }
}
