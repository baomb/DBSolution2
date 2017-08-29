using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryAllotOutTitleAdapter
    {
        #region  成员方法

        public static DataSet GetSdl_AccessoryAllotOutTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitleSet(where);
        }

        public static DataSet GetSdl_AccessoryAllotOutTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_AccessoryAllotOutTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSdl_AccessoryAllotOutTitleDataTable(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitleDataTable(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotOutTitle GetSdl_AccessoryAllotOutTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotOutTitle GetSdl_AccessoryAllotOutTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryAllotOutTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryAllotOutTitle(timeFlag, ebeln);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryAllotOutTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotOutTitle(model);
        }

        public static void UpdateSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotOutTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_AccessoryAllotOutTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryAllotOutTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotOutTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotOutTitle(timeFlag, ebeln);
        }

        public static void DeleteSdl_AccessoryAllotOutTitle(string timeFlag, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotOutTitle(timeFlag, ebeln, truckNum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotOutTitleByTimeFlag(Sdl_AccessoryAllotOutTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotOutTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryAllotOutTitle> GetSdl_AccessoryAllotOutTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutTitleList(table);
        }

        #endregion  成员方法
    }
}
