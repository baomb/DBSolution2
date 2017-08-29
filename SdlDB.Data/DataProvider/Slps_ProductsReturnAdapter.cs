using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_ProductsReturnAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_ProductsReturnDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_ProductsReturn(string timeFlag, string carNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_ProductsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_ProductsReturn(Slps_ProductsReturn model)
        {
            return DatabaseProvider.GetInstance().AddSlps_ProductsReturn(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_ProductsReturn(Slps_ProductsReturn model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_ProductsReturn(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_ProductsReturn(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_ProductsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_ProductsReturn GetSlps_ProductsReturn(string timeFlag, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_ProductsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_ProductsReturn> GetSlps_ProductsReturnList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_ProductsReturnList(table);
        }


        #endregion  成员方法
    }
}
