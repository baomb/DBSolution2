using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialReturnTitleAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_RawMaterialReturnTitleSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitleSet(where);
        }
        /// <summary>
        /// 得到所有查询结果到DataSet中
        /// </summary>
        public static DataSet GetSdl_RawMaterialReturnTitleSetByField(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitleSetByField(where);

        }
        public static DataSet GetSdl_RawMaterialReturnTitlePageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitlePageData(pageNum, PageSize, where);
        }

        public static DataSet GetSdl_RawMaterialReturnTitleSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitleSetByField(feildNames, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitle(truckNum, timeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string ebeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitle(truckNum, ebeln, timeFlag);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialReturnTitle(timeFlag, ebeln);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialReturnTitle(timeFlag, ebeln, trucknum);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialReturnTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialReturnTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model, string ebeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialReturnTitle(model, ebeln, truckNum);
        }

        public static int AmendSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_RawMaterialReturnTitle(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialReturnTitle(timeFlag, ebeln);
        }

        public static void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialReturnTitle(timeFlag, ebeln, trucknum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialReturnTitleByTimeFlag(Sdl_RawMaterialReturnTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialReturnTitleByTimeFlag(model);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_RawMaterialReturnTitle> GetSdl_RawMaterialReturnTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnTitleList(table);
        }

        #endregion  成员方法
    }
}
