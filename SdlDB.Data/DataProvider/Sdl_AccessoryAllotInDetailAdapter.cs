using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryAllotInDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_AccessoryAllotInDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetailSet(where);
        }

        public static double GetSdl_AccessoryAllotInDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetailOverNum(where);
        }

        public static DataSet GetSdl_AccessoryAllotInDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryAllotInDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryAllotInDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotInDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotInDetail(model, ebeln, ebelp, lgort);
        }

        public static int AmendSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryAllotInDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotInDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotInDetail(timeFlag, ebeln);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotInDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotInDetail GetSdl_AccessoryAllotInDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetail(timeFlag, ebeln);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotInDetail GetSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryAllotInDetail> GetSdl_AccessoryAllotInDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotInDetailList(table);
        }

        #endregion  成员方法
    }
}
