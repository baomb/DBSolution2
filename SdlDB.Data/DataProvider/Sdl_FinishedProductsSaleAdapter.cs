using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsSaleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_FinishedProductsSaleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleSet(where);
        }

        public static DataSet GetSdl_FinishedProductsSaleSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_FinishedProductsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_FinishedProductsSale(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsSale(Sdl_FinishedProductsSale model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsSale(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSale(model);
        }

        public static void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, Sdl_FinishedProductsSale oldModel)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSale(model, oldModel);
        }

        public static void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, string vbeln, string lgort, string posnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsSale(model, vbeln, lgort, posnr);
        }

        public static int AmendSdl_FinishedProductsSale(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_FinishedProductsSale(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsSale(timeFlag, vbeln);
        }

        /// <summary>
        /// 删除一条数据vbeln
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="vbeln"></param>
        public static void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln, string lgort, string posnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsSale(timeFlag, vbeln, lgort, posnr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSale(timeFlag, vbeln);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSale(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsSale> GetSdl_FinishedProductsSaleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsSaleList(table);
        }

        #endregion  成员方法
    }
}
