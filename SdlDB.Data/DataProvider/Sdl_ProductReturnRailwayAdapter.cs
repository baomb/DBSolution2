using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_ProductReturnRailwayAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_ProductReturnRailwaySet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwaySet(where);
        }

        public static DataSet GetSdl_ProductReturnRailwayPageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayPageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_ProductReturnRailwaySearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwaySearchSet(where);
        }

        public static DataSet GetSdl_ProductReturnRailwaySetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwaySetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailway(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string vbeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailway(truckNum, vbeln, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_ProductReturnRailwayDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_ProductReturnRailway(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_ProductReturnRailway(timeFlag, vbeln);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_ProductReturnRailway(Sdl_ProductReturnRailway model)
        {
            return DatabaseProvider.GetInstance().AddSdl_ProductReturnRailway(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnRailway(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model, string vbeln1, string truckNum1)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnRailway(model, vbeln1, truckNum1);
        }

        public static int AmendSdl_ProductReturnRailway(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_ProductReturnRailway(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnRailway(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnRailway(timeFlag, vbeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnRailwayByTimeFlag(string timeFlag, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnRailwayByTimeFlag(timeFlag, truckNum);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnRailway(string truckNum, string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnRailway(truckNum, timeFlag, vbeln);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_ProductReturnRailway> GetSdl_ProductReturnRailwayList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnRailwayList(table);
        }

        #endregion  成员方法
    }
}
