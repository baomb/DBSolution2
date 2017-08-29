using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_AllotInDetailAdapter
    {
        #region  成员方法


        public static DataSet GetSdl_AllotInDetailSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetailSet(where);
        }

        public static double GetSdl_AllotInDetailOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetailOverNum(where);
        }

        public static DataSet GetSdl_AllotInDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetailSearchSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_AllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_AllotInDetail(timeFlag, ebeln, ebelp, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_AllotInDetail(Sdl_AllotInDetail model)
        {
            return DatabaseProvider.GetInstance().AddSdl_AllotInDetail(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotInDetail(model);
        }

        public static void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model, string ebeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_AllotInDetail(model, ebeln, ebelp, lgort);
        }

        public static int AmendSdl_AllotInDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_AllotInDetail(timeFlag, ebeln, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_AllotInDetail(string timeFlag, string ebeln)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotInDetail(timeFlag, ebeln);
        }
        public static void DeleteSdl_AllotInDetail(string timeFlag, string vbeln, string ebelp, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_AllotInDetail(timeFlag, vbeln, ebelp, lgort);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string ebeln)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetail(timeFlag, ebeln);
        }
        public static Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetail(timeFlag, ebeln, ebelp, lgort);
        }
        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_AllotInDetail> GetSdl_AllotInDetailList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_AllotInDetailList(table);
        }

        #endregion  成员方法
    }
}
