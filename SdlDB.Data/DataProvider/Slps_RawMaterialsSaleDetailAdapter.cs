using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsSaleDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsSaleDetailList(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsSaleDetailList(where);
        }

        public static DataSet GetSlps_RawMaterialsSaleDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsSaleDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsSaleDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsSaleDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsSaleDetail(Slps_RawMaterialsSaleDetail model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsSaleDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsSaleDetail(Slps_RawMaterialsSaleDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsSaleDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsSaleDetail(string timeFlag)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsSaleDetail(timeFlag);
        }
        
        #endregion  成员方法
    }
}
