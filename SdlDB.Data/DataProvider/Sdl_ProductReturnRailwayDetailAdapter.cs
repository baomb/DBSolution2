using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_ProductReturnRailwayDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_ProductReturnRailwayDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDetailSet(where);
        }

        public static DataSet GetSdl_ProductReturnRailwayDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_ProductReturnRailwayDetail(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_ProductReturnRailwayDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnRailwayDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model, string vbeln1, string lgort1, string posnr1)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnRailwayDetail(model, vbeln1, lgort1, posnr1);
        }

        public static int AmendSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_ProductReturnRailwayDetail(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnRailwayDetail(timeFlag, vbeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string lgort, string posnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnRailwayDetail(timeFlag, vbeln, lgort, posnr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDetail(timeFlag, vbeln);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDetail(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_ProductReturnRailwayDetail> GetSdl_ProductReturnRailwayDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDetailList(table);
        }

        #endregion  成员方法
    }
}
