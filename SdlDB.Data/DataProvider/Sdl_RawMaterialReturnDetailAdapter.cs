using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RawMaterialReturnDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_RawMaterialReturnDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetailSet(where);
        }

        public static double GetSdl_RawMaterialReturnDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetailOverNum(where);
        }

        public static DataSet GetSdl_RawMaterialReturnDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_RawMaterialReturnDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_RawMaterialReturnDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialReturnDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_RawMaterialReturnDetail(model, ebeln, ebelp, lgort);
        }

        public static int AmendSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_RawMaterialReturnDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialReturnDetail(timeFlag, ebeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_RawMaterialReturnDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetail(timeFlag, ebeln);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_RawMaterialReturnDetail> GetSdl_RawMaterialReturnDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_RawMaterialReturnDetailList(table);
        }

        #endregion  成员方法
    }
}
