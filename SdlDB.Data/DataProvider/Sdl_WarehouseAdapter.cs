using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_WarehouseAdapter
    {
        #region  成员方法
        public static DataSet GetSdl_WarehouseSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_WarehouseSet(where);
        }
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_Warehouse(string werks, string lgort)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_Warehouse(werks, lgort);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Warehouse(Sdl_Warehouse model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Warehouse(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Warehouse(Sdl_Warehouse model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Warehouse(model);
        }

        public static int AmendSdl_Warehouse(string id, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendSdl_Warehouse(id, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Warehouse(string werks, string lgort)
        {

            DatabaseProvider.GetInstance().DeleteSdl_Warehouse(werks, lgort);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Warehouse GetSdl_Warehouse(string werks, string lgort)
        {

            return DatabaseProvider.GetInstance().GetSdl_Warehouse(werks, lgort);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Sdl_Warehouse> GetSdl_WarehouseList(System.Data.DataTable table)
        {
            return DatabaseProvider.GetInstance().GetSdl_WarehouseList(table);
        }


        #endregion  成员方法
    }
}
