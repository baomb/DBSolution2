using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_SlpsEnterAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_SlpsEnterList(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsEnterList(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSdl_SlpsEnter(string qrcodeScanResult)
        {
            return DatabaseProvider.GetInstance().ExistSdl_SlpsEnter(qrcodeScanResult);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_SlpsEnter(Sdl_SlpsEnter model)
        {
            return DatabaseProvider.GetInstance().AddSdl_SlpsEnter(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_SlpsEnter(Sdl_SlpsEnter model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_SlpsEnter(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_SlpsEnter(string qrcodeScanResult)
        {

            DatabaseProvider.GetInstance().DeleteSdl_SlpsEnter(qrcodeScanResult);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_SlpsEnter GetSdl_SlpsEnter(string qrcodeScanResult)
        {

            return DatabaseProvider.GetInstance().GetSdl_SlpsEnter(qrcodeScanResult);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_SlpsEnter> GetSdl_SlpsEnterList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_SlpsEnterList(table);
        }


        #endregion  成员方法
    }
}
