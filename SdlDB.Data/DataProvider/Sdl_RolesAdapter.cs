using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_RolesAdapter
    {
        #region Sdl_RolesAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_RolesDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_RolesDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_Roles(Sdl_Roles model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Roles(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Roles(Sdl_Roles model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Roles(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_Roles(string roleid)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Roles(roleid);
        }


        /// <summary>
        /// 
        /// </summary>
        public static Sdl_Roles GetSdl_Roles(string roleid)
        {
            return DatabaseProvider.GetInstance().GetSdl_Roles(roleid);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Sdl_Roles GetSdl_RolesByRoleName(string rolename)
        {
            return DatabaseProvider.GetInstance().GetSdl_RolesByRoleName(rolename);
        }
        

        #endregion Sdl_RolesAdapter
    }
}
