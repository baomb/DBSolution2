using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialsSaleTitleAdapter
    {
        #region Sdl_RawMaterialsSaleTitle

        public static DataSet GetSdl_RawMaterialsSaleTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleTitleDataSet(where);
        }

        public static DataSet GetSdl_RawMaterialsSaleTitlePageData(string pageNum, int pageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleTitlePageData(pageNum, pageSize, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialsSaleTitle GetSdl_RawMaterialsSaleTitle(string truckNum, string vbeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleTitle(truckNum, vbeln, timeFlag);
        }

        /// <summary>
        /// 得到对象实体集
        /// </summary>
        public static DataSet GetSdl_RawMaterialsSaleTitleDataSetByField(string[] fieldNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleTitleDataSetByField(fieldNames, where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialsSaleTitle(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string trucknum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsSaleTitle(timeFlag, vbeln, trucknum);
        }

        public static bool ExistsSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string truckNum)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialsSaleTitle(timeFlag, vbeln, truckNum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsSaleTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model, string truckNum, string vbeln)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsSaleTitle(model, truckNum, vbeln);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_RawMaterialsSaleTitle> GetSdl_RawMaterialsSaleTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleTitleList(table);
        }

        #endregion Sdl_RawMaterialsSaleTitle
    }
}
