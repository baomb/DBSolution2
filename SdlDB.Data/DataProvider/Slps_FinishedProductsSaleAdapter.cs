using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_FinishedProductsSaleAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_FinishedProductsSaleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsSaleDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_FinishedProductsSale(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_FinishedProductsSale(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_FinishedProductsSale(Slps_FinishedProductsSale model)
        {
            return DatabaseProvider.GetInstance().AddSlps_FinishedProductsSale(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_FinishedProductsSale(Slps_FinishedProductsSale model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_FinishedProductsSale(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_FinishedProductsSale(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_FinishedProductsSale(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_FinishedProductsSale GetSlps_FinishedProductsSale(string qrcodeScanResult, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsSale(qrcodeScanResult, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_FinishedProductsSale> GetSlps_FinishedProductsSaleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_FinishedProductsSaleList(table);
        }


        #endregion  成员方法
    }
}
