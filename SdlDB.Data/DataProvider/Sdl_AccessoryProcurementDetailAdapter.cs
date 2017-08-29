using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryProcurementDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_AccessoryProcurementDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetailSet(where);
        }

        public static double GetSdl_AccessoryProcurementDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetailOverNum(where);
        }

        public static DataSet GetSdl_AccessoryProcurementDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string posnr)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryProcurementDetail(timeFlag, ebeln, posnr);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryProcurementDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryProcurementDetail(model);
        }

        public static void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model, string ebeln, string ebelp, string matnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryProcurementDetail(model, ebeln, ebelp, matnr);
        }

        public static int AmendSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryProcurementDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryProcurementDetail(timeFlag, ebeln);
        }
        public static void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryProcurementDetail(timeFlag, ebeln, ebelp, matnr);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetail(timeFlag, ebeln);
        }

        public static Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetail(timeFlag, ebeln, ebelp, matnr);
        }
        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryProcurementDetail> GetSdl_AccessoryProcurementDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementDetailList(table);
        }

        #endregion  成员方法
    }
}
