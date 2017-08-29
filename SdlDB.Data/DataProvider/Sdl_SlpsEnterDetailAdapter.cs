using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_SlpsEnterDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_SlpsEnterDetailList(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsEnterDetailList(where);
        }

        public static DataSet GetSdl_SlpsEnterDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsEnterDetailList(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSdl_SlpsEnterDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSdl_SlpsEnterDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_SlpsEnterDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_SlpsEnterDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_SlpsEnterDetail(string qrcodeScanResult)
        {
            DatabaseProvider.GetInstance().DeleteSdl_SlpsEnterDetail(qrcodeScanResult);
        }

        #endregion  成员方法
    }
}
