using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_FinishedProductsPresentationAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_FinishedProductsPresentationDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_FinishedProductsPresentation(string timeFlag, string carNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_FinishedProductsPresentation(timeFlag, carNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_FinishedProductsPresentation(Slps_FinishedProductsPresentation model)
        {
            return DatabaseProvider.GetInstance().AddSlps_FinishedProductsPresentation(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_FinishedProductsPresentation(Slps_FinishedProductsPresentation model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_FinishedProductsPresentation(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_FinishedProductsPresentation(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_FinishedProductsPresentation(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_FinishedProductsPresentation GetSlps_FinishedProductsPresentation(string timeFlag, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentation(timeFlag, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_FinishedProductsPresentation> GetSlps_FinishedProductsPresentationList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsPresentationList(table);
        }


        #endregion  成员方法
    }
}
