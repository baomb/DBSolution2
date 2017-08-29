using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryReturnDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_AccessoryReturnDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetailSet(where);
        }

        public static double GetSdl_AccessoryReturnDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetailOverNum(where);
        }

        public static DataSet GetSdl_AccessoryReturnDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string posnr)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryReturnDetail(timeFlag, ebeln, posnr);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryReturnDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryReturnDetail(model);
        }

        public static void UpdateSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model, string ebeln, string ebelp)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryReturnDetail(model, ebeln, ebelp);
        }

        public static int AmendSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryReturnDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryReturnDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryReturnDetail(timeFlag, ebeln);
        }

        public static void DeleteSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string ebelp)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryReturnDetail(timeFlag, ebeln, ebelp);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryReturnDetail GetSdl_AccessoryReturnDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetail(timeFlag, ebeln);
        }

        public static Sdl_AccessoryReturnDetail GetSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string ebelp)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetail(timeFlag, ebeln, ebelp);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryReturnDetail> GetSdl_AccessoryReturnDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryReturnDetailList(table);
        }

        #endregion  成员方法
    }
}
