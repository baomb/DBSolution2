using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_SlpsExitDetailAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_SlpsExitDetailList(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsExitDetailList(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            return DatabaseProvider.GetInstance().ExistSdl_SlpsExitDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_SlpsExitDetail(Sdl_SlpsExitDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_SlpsExitDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_SlpsExitDetail(Sdl_SlpsExitDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_SlpsExitDetail(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            DatabaseProvider.GetInstance().DeleteSdl_SlpsExitDetail(qrcodeScanResult, sapOrderNo, lineItemNo);
        }

        #endregion  成员方法
    }
}
