using System.Collections.Generic;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsReturnAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsReturnDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsReturn(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsReturn(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_RawMaterialsReturn GetSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturn(timeFlag, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_RawMaterialsReturn> GetSlps_RawMaterialsReturnList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsReturnList(table);
        }


        #endregion  成员方法
    }
}
