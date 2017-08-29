using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_FinishedProductsSaleDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_FinishedProductsSaleDetailList(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsSaleDetailList(where);
        }

        public static DataSet GetSlps_FinishedProductsSaleDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsSaleDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_FinishedProductsSaleDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_FinishedProductsSaleDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_FinishedProductsSaleDetail(Slps_FinishedProductsSaleDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_FinishedProductsSaleDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_FinishedProductsSaleDetail(Slps_FinishedProductsSaleDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_FinishedProductsSaleDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_FinishedProductsSaleDetail(string qrcodeScanResult)
        {

            DatabaseProvider.GetInstance().DeleteSlps_FinishedProductsSaleDetail(qrcodeScanResult);
        }
        
        #endregion  成员方法
    }
}
