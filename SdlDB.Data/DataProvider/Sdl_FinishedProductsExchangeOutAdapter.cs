using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsExchangeOutAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsExchangeOutDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutDataSet(where);
        }

     
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsExchangeOut(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string id)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeOut(model, id);
        }

        public static void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string timeFlag, string oanum, string posnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeOut(model, timeFlag, oanum, posnr);
        }

        public static Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOut(timeFlag, oanum, posnr);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string oanum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeOut(timeFlag, oanum);
        }

        /// <summary>
        /// 删除一条数据vbeln
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="vbeln"></param>
        public static void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeOut(timeFlag, oanum, posnr);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsExchange> GetSdl_FinishedProductsExchangeOutList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeOutList(table);
        }

        #endregion  成员方法
    }
}
