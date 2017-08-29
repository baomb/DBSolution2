using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialsSaleAdapter
    {
        #region Sdl_RawMaterialsSaleAdapter

        public static DataSet GetSdl_RawMaterialsSaleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_RawMaterialsSale(Sdl_RawMaterialsSale model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialsSale(model);
        }

        public static bool ExistsSdl_RawMaterialsSale(string timeflag, string vbeln, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialsSale(timeflag, vbeln, posnr, lgort);
        }

        public static void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsSale(model);
        }

        public static void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model, string vbeln, string lgort, string posnr)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialsSale(model, vbeln, lgort, posnr);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialsSale(string timeFlag, string rsnum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsSale(timeFlag, rsnum);
        }

        public static void DeleteSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialsSale(timeFlag, vbeln, posnr, lgort);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string rsnum, string posnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSale(timeFlag, rsnum, posnr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string rsnum, string posnr, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSale(timeFlag, rsnum, posnr, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_RawMaterialsSale> GetSdl_RawMaterialsSaleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialsSaleList(table);
        }

        #endregion Sdl_RawMaterialsSaleAdapter
    }
}
