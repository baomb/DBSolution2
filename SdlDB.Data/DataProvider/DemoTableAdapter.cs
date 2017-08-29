using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDB.Entity;
using System.Data;

namespace SdlDB.Data
{
    public class DemoTableAdapter
    {
        #region  成员方法

        public static DataSet GetDemoTableDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetDemoTableDataSet(where);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsDemoTable(int id)
        {
            return DatabaseProvider.GetInstance().ExistsDemoTable(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddDemoTable(DemoTable model)
        {
            return DatabaseProvider.GetInstance().AddDemoTable(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateDemoTable(DemoTable model)
        {
            DatabaseProvider.GetInstance().UpdateDemoTable(model);
        }

        public static int AmendDemoTable(int id, string columnName, Object value)
        {
            return DatabaseProvider.GetInstance().AmendDemoTable(id, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteDemoTable(int adminid)
        {

            DatabaseProvider.GetInstance().DeleteDemoTable(adminid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DemoTable GetDemoTable(int adminid)
        {

            return DatabaseProvider.GetInstance().GetDemoTable(adminid);
        }

        /// <summary>
        /// 通过管理员的帐号获取实例
        /// </summary>
        /// <param name="amdinName"></param>
        /// <returns></returns>
        public static DemoTable GetDemoTableById(int id)
        {
            return DatabaseProvider.GetInstance().GetDemoTableByID(id);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<DemoTable> GetDemoTableList(System.Data.DataTable dt)
        {
            return DatabaseProvider.GetInstance().GetDemoTableList(dt);
        }


        #endregion  成员方法
    }
}
