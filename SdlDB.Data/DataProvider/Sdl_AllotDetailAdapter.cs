using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AllotDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_AllotDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetailSet(where);
        }

        public static double GetSdl_AllotDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetailOverNum(where);
        }

        public static DataTable GetSdl_AllotDetailMengeAndSfimg(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetailMengeAndSfimg(where);
        }

        public static DataSet GetSdl_AllotDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AllotDetail(Sdl_AllotDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AllotDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotDetail(Sdl_AllotDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotDetail(model);
        }

        public static void UpdateSdl_AllotDetail(Sdl_AllotDetail model, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotDetail(model, ebeln, ebelp, lgort);
        }

        public static int AmendSdl_AllotDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AllotDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AllotDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotDetail(timeFlag, ebeln);
        }

        public static void DeleteSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetail(timeFlag, ebeln);
        }

        public static Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AllotDetail> GetSdl_AllotDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotDetailList(table);
        }

        #endregion  成员方法
    }
}
