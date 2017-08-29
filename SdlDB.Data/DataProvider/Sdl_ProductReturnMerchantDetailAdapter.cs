using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_ProductReturnMerchantDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_ProductReturnMerchantDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDetailSet(where);
        }

        public static DataSet GetSdl_ProductReturnMerchantDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_ProductReturnMerchantDetail(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_ProductReturnMerchantDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnMerchantDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, string vbeln1, string lgort1, string posnr1)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnMerchantDetail(model, vbeln1, lgort1, posnr1);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, Sdl_ProductReturnMerchantDetail oldModel)
        {
            DatabaseProvider.GetInstance().UpdateSdl_ProductReturnMerchantDetail(model, oldModel);
        }

        public static int AmendSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_ProductReturnMerchantDetail(timeFlag, vbeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnMerchantDetail(timeFlag, vbeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string lgort, string posnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_ProductReturnMerchantDetail(timeFlag, vbeln, lgort, posnr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDetail(timeFlag, vbeln);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDetail(timeFlag, vbeln, posnr, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_ProductReturnMerchantDetail> GetSdl_ProductReturnMerchantDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_ProductReturnMerchantDetailList(table);
        }

        #endregion  成员方法
    }
}
