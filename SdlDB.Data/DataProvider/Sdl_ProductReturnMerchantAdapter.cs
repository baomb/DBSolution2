using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_ProductReturnMerchantAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_ProductReturnMerchantSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantSet(where);
        }

        public static DataSet GetSdl_ProductReturnMerchantPageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantPageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_ProductReturnMerchantSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantSearchSet(where);
        }

        public static DataSet GetSdl_ProductReturnMerchantSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnMerchant GetSdl_ProductReturnMerchant(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchant(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnMerchant GetSdl_ProductReturnMerchant(string truckNum, string vbeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchant(truckNum, vbeln, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_ProductReturnMerchantDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_ProductReturnMerchant(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_ProductReturnMerchant(timeFlag, vbeln);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model)
        {
            return DatabaseProvider.GetInstance().AddSdl_ProductReturnMerchant(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnMerchant(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model, string vbeln1, string truckNum1)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnMerchant(model, vbeln1, truckNum1);
        }

        public static int AmendSdl_ProductReturnMerchant(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_ProductReturnMerchant(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnMerchant(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnMerchant(timeFlag, vbeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnMerchantByTimeFlag(string timeFlag, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnMerchantByTimeFlag(timeFlag, truckNum);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnMerchant(string truckNum, string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnMerchant(truckNum, timeFlag, vbeln);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_ProductReturnMerchant> GetSdl_ProductReturnMerchantList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantList(table);
        }

        #endregion  成员方法
    }
}
