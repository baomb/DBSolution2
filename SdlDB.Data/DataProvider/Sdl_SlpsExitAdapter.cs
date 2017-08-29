using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_SlpsExitAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_SlpsExitList(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsExitList(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().ExistSdl_SlpsExit(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_SlpsExit(Sdl_SlpsExit model)
        {
            return DatabaseProvider.GetInstance().AddSdl_SlpsExit(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_SlpsExit(Sdl_SlpsExit model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_SlpsExit(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSdl_SlpsExit(qrcodeScanResult, sapOrderNo, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_SlpsExit GetSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSdl_SlpsExit(qrcodeScanResult, sapOrderNo, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_SlpsExit> GetSdl_SlpsExitList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsExitList(table);
        }


        #endregion  成员方法
    }
}
