using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsSaleAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsSaleDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsSaleDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsSale(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsSale(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsSale(Slps_RawMaterialsSale model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsSale(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsSale(Slps_RawMaterialsSale model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsSale(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsSale(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsSale(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_RawMaterialsSale GetSlps_RawMaterialsSale(string qrcodeScanResult, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsSale(qrcodeScanResult, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_RawMaterialsSale> GetSlps_RawMaterialsSaleList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsSaleList(table);
        }


        #endregion  成员方法
    }
}
