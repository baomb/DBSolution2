using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsProcurementDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsProcurementDetailList(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementDetailList(where);
        }

        public static DataSet GetSlps_RawMaterialsProcurementDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsProcurementDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsProcurementDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsProcurementDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsProcurementDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsProcurementDetail(string timeFlag)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsProcurementDetail(timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_RawMaterialsProcurementDetail GetSlps_RawMaterialsProcurementDetail(string qrcodeScanResult, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementDetail(qrcodeScanResult, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_RawMaterialsProcurementDetail> GetSlps_RawMaterialsProcurementDetailList(DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementDetailList(table);
        }

        #endregion  成员方法
    }
}
