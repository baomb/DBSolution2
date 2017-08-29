using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FunctionsInRolesAdapter
    {
        #region Sdl_FunctionsInRolesAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_FunctionsInRolesDataSet(string roleid)
        {
            return DatabaseProvider.GetInstance().GetSdl_FunctionsInRolesDataSet(roleid);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_FunctionsInRolesDataSetWhere(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FunctionsInRolesDataSetWhere(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_FunctionsInRoles(Sdl_FunctionsInRoles model)
        {
            return DatabaseProvider.GetInstance().AddSdl_FunctionsInRoles(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FunctionsInRoles(string functionid, string roleid)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FunctionsInRoles(functionid, roleid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_FunctionsInRoles(string roleid)
        {
            DatabaseProvider.GetInstance().DeleteSdl_FunctionsInRoles(roleid);
        }

        public static bool IsExistFunction(string functionId)
        {
            return DatabaseProvider.GetInstance().IsExistFunction(functionId);
        }
        #endregion
    }
}
