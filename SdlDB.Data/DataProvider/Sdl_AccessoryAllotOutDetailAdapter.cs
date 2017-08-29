using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AccessoryAllotOutDetailAdapter
    {
        #region  成员方法

        public static DataSet GetSdl_AccessoryAllotOutDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetailSet(where);
        }

        public static double GetSdl_AccessoryAllotOutDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetailOverNum(where);
        }

        public static DataTable GetSdl_AccessoryAllotOutDetailMengeAndSfimg(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetailMengeAndSfimg(where);
        }

        public static DataSet GetSdl_AccessoryAllotOutDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AccessoryAllotOutDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AccessoryAllotOutDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotOutDetail(model);
        }

        public static void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AccessoryAllotOutDetail(model, ebeln, ebelp, lgort);
        }

        public static int AmendSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AccessoryAllotOutDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotOutDetail(timeFlag, ebeln);
        }

        public static void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AccessoryAllotOutDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetail(timeFlag, ebeln);
        }

        public static Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AccessoryAllotOutDetail> GetSdl_AccessoryAllotOutDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AccessoryAllotOutDetailList(table);
        }

        #endregion  成员方法
    }
}
