using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsReturnDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsReturnDetailDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnDetailDataSet(where);
        }

        public static DataSet GetSlps_RawMaterialsReturnDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsReturnDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsReturnDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsReturnDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsReturnDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsReturnDetail(string timeFlag)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsReturnDetail(timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_RawMaterialsReturnDetail GetSlps_RawMaterialsReturnDetail(string timeFlag, string lineItemNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnDetail(timeFlag, lineItemNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_RawMaterialsReturnDetail> GetSlps_RawMaterialsReturnDetailList(DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnDetailList(table);
        }

        #endregion  成员方法
    }
}
