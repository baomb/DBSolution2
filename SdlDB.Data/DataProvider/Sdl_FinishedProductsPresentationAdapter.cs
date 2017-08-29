using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FinishedProductsPresentationAdapter
    {
        #region Sdl_FinishedProductsPresentationAdapter

        public static DataSet GetSdl_FinishedProductsPresentationDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationDataSet(where);
        }

        public static double GetSdl_FinishedProductsPresentationOverNum(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationOverNum(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FinishedProductsPresentation(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsPresentation(timeFlag, rsnum);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FinishedProductsPresentation(timeFlag, rsnum, rspos, lgort);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model, string rsnum, string rspos, string lgort)
        {
            DatabaseProvider.GetInstance().UpdateSdl_FinishedProductsPresentation(model, rsnum, rspos, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string posnr)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentation(timeFlag, rsnum, posnr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentation(timeFlag, rsnum, rspos, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_FinishedProductsPresentation> GetSdl_FinishedProductsPresentationList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_FinishedProductsPresentationList(table);
        }

        #endregion Sdl_FinishedProductsPresentationAdapter
    }
}
