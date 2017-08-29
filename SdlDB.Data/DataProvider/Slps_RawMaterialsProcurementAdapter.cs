using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Slps_RawMaterialsProcurementAdapter
    {
        #region  成员方法
        public static DataSet GetSlps_RawMaterialsProcurementDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementDataSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistSlps_RawMaterialsProcurement(string qrcodeScanResult, string sapOrderNo)
        {
            return DatabaseProvider.GetInstance().ExistSlps_RawMaterialsProcurement(qrcodeScanResult, sapOrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSlps_RawMaterialsProcurement(Slps_RawMaterialsProcurement model)
        {
            return DatabaseProvider.GetInstance().AddSlps_RawMaterialsProcurement(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSlps_RawMaterialsProcurement(Slps_RawMaterialsProcurement model)
        {
            DatabaseProvider.GetInstance().UpdateSlps_RawMaterialsProcurement(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSlps_RawMaterialsProcurement(string timeFlag, string carNo)
        {

            DatabaseProvider.GetInstance().DeleteSlps_RawMaterialsProcurement(timeFlag, carNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Slps_RawMaterialsProcurement GetSlps_RawMaterialsProcurement(string qrcodeScanResult, string carNo)
        {

            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurement(qrcodeScanResult, carNo);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        public static List<Slps_RawMaterialsProcurement> GetSlps_RawMaterialsProcurementList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSlps_RawMaterialsProcurementList(table);
        }


        #endregion  成员方法
    }
}
