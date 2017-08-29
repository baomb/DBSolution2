using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_ProductsReturnDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_ProductsReturnDetailDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnDetailDataSet(where);
        }

        public static DataSet GetSlps_ProductsReturnDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_ProductsReturnDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_ProductsReturnDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_ProductsReturnDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_ProductsReturnDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_ProductsReturnDetail(string timeFlag)
        {

            DatabaseProvider.GetInstance().DeleteSlps_ProductsReturnDetail(timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_ProductsReturnDetail GetSlps_ProductsReturnDetail(string timeFlag, string lineItemNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnDetail(timeFlag, lineItemNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_ProductsReturnDetail> GetSlps_ProductsReturnDetailList(DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnDetailList(table);
        }

        #endregion  成员方法
    }
}
