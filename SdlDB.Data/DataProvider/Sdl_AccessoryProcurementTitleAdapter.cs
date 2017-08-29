using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryProcurementTitleAdapter
    {
        #region  成员方法

        public static DataSet GetSdl_AccessoryProcurementTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitleSet(where);
        }

        public static DataSet GetSdl_AccessoryProcurementTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AccessoryProcurementTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryProcurementTitle GetSdl_AccessoryProcurementTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryProcurementTitle GetSdl_AccessoryProcurementTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryProcurementTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryProcurementTitle(timeFlag, ebeln);
        }

        public static bool ExistsSdl_AccessoryProcurementTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryProcurementTitle(timeFlag, ebeln, trucknum);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryProcurementTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryProcurementTitle(model);
        }

        public static void UpdateSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model, string trucknum, string ebeln)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryProcurementTitle(model, trucknum, ebeln);
        }

        public static int AmendSdl_AccessoryProcurementTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryProcurementTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryProcurementTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryProcurementTitle(timeFlag, ebeln);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryProcurementTitleByTimeFlag(Sdl_AccessoryProcurementTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryProcurementTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryProcurementTitle> GetSdl_AccessoryProcurementTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryProcurementTitleList(table);
        }

        #endregion  成员方法
    }
}
