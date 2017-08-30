using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_FinishedProductsPresentationDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_FinishedProductsPresentationDetailDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationDetailDataSet(where);
        }

        public static DataSet GetSlps_FinishedProductsPresentationDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_FinishedProductsPresentationDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_FinishedProductsPresentationDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_FinishedProductsPresentationDetail(Slps_FinishedProductsPresentationDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_FinishedProductsPresentationDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_FinishedProductsPresentationDetail(Slps_FinishedProductsPresentationDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_FinishedProductsPresentationDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_FinishedProductsPresentationDetail(string timeFlag)
        {

            DatabaseProvider.GetInstance().DeleteSlps_FinishedProductsPresentationDetail(timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_FinishedProductsPresentationDetail GetSlps_FinishedProductsPresentationDetail(string timeFlag, string lineItemNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationDetail(timeFlag, lineItemNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_FinishedProductsPresentationDetail> GetSlps_FinishedProductsPresentationDetailList(DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationDetailList(table);
        }

        #endregion  成员方法
    }
}
