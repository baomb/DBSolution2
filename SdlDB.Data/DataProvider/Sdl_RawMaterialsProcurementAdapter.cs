using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialsProcurementAdapter
    {
        #region Sdl_RawMaterialsProcurement

        public static DataSet GetSdl_RawMaterialsProcurementDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialsProcurement(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialsProcurement(string timeFlag, string vbeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsProcurement(timeFlag, vbeln);
        }

        public static void DeleteSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsProcurement(timeflag, vbeln, posnr, lgort, bktxt, nkey);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurement(timeFlag, vbeln, posnr);
        }

        public static Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurement(timeFlag, vbeln, posnr, lgort, bktxt, nkey);
        }

        public static Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurement(timeFlag, vbeln);
        }

        /// <summary>
        /// 查询是否存在
        /// </summary>
        public static bool ExistsSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialsProcurement(timeflag, vbeln, posnr, lgort, bktxt, nkey);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        public static void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsProcurement(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        public static void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model, string vbeln, string lgort, string nkey, string bktxt, string posnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsProcurement(model, vbeln, lgort, nkey, bktxt, posnr);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Sdl_RawMaterialsProcurement> GetSdl_RawMaterialsProcurementList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsProcurementList(table);
        }

        #endregion Sdl_RawMaterialsProcurement
    }
}
