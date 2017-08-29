using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsExchangeInAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsExchangeInDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInDataSet(where);
        }

     
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsExchangeIn(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model, string id)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeIn(model, id);
        }

        public static void UpdateSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model, string timeFlag, string oanum, string posnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsExchangeIn(model, timeFlag, oanum, posnr);
        }

        public static Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeIn(string timeFlag, string oanum, string posnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeIn(timeFlag, oanum, posnr);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsExchangeIn(string timeFlag, string oanum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeIn(timeFlag, oanum);
        }

        /// <summary>
        /// 删除一条数据vbeln
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="vbeln"></param>
        public static void DeleteSdl_FinishedProductsExchangeIn(string timeFlag, string oanum, string posnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsExchangeIn(timeFlag, oanum, posnr);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsExchange> GetSdl_FinishedProductsExchangeInList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsExchangeInList(table);
        }

        #endregion  成员方法
    }
}
