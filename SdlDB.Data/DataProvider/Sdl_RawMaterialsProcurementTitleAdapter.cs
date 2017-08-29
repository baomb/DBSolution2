using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialsProcurementTitleAdapter
    {
        #region Sdl_RawMaterialsProcurement

        public static DataSet GetSdl_RawMaterialsProcurementTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementTitleDataSet(where);
        }

        public static DataSet GetSdl_RawMaterialsProcurementAndTitleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementAndTitleDataSet(where);
        }

        public static DataSet GetSdl_RawMaterialsProcurementTitlePageData(string pageNum, int pageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementTitlePageData(pageNum, pageSize, where);
        }

        public static DataSet GetSdl_RawMaterialsProcurementAndTitlePageData(string pageNum, int pageSize, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementAndTitlePageData(pageNum, pageSize, where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialsProcurementTitle GetSdl_RawMaterialsProcurementTitle(string truckNum, string vbeln, string timeFlag)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementTitle(truckNum, vbeln, timeFlag);
        }

        /// <summary>
        /// 得到对象实体集
        /// </summary>
        public static DataSet GetSdl_RawMaterialsProcurementTitleDataSetByField(string[] fieldNames, string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementTitleSetByField(fieldNames, where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialsProcurementTitle(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model, string vbeln, string truckNum)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsProcurementTitle(model, vbeln, truckNum);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialsProcurementTitleByTimeFlag(Sdl_RawMaterialsProcurementTitle model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsProcurementTitleByTimeFlag(model);
        }

        public static void DeleteSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string trucknum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsProcurementTitle(timeFlag, vbeln, trucknum);

        }

        public static bool ExistsSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string truckNum)
        {

            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialsProcurementTitle(timeFlag, vbeln, truckNum);

        }
        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_RawMaterialsProcurementTitle> GetSdl_RawMaterialsProcurementTitleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementTitleList(table);
        }

        #endregion Sdl_RawMaterialsProcurement
    }
}
