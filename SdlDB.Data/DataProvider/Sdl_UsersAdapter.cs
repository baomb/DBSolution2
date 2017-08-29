using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_UsersAdapter
    {
        #region Sdl_UsersAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_UsersDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_UsersDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_Users(Sdl_Users model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Users(model);
        }

        /// <summary>
        /// 是否存在用户名
        /// </summary>
        public static bool ExistsSdl_User(string username)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_User(username);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Users GetSdl_Users(string username)
        {
            return DatabaseProvider.GetInstance().GetSdl_Users(username);
        }

        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        public static bool ValidateSdl_Users(string username, string password)
        {
            return DatabaseProvider.GetInstance().ValidateSdl_Users(username, password);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Users(Sdl_Users model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Users(model);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public static void ChangePasswordSdl_Users(string username, string password)
        {
            DatabaseProvider.GetInstance().ChangePasswordSdl_Users(username, password);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_Users(string userid)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Users(userid);
        }

        public static bool IsExistUserInFun(string roleId)
        {
            return DatabaseProvider.GetInstance().IsExistUserInFun(roleId);
        }


        #endregion Sdl_UsersAdapter
    }
}
