using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region Sdl_Users

        public DataSet GetSdl_UsersDataSet(string where)
        {
            string sql = "select * from Sdl_Users " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_Users(Sdl_Users model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Users(");
                strSql.Append("USERID,USERNAME,PASSWORD,ROLE,USERDESC,ISLOCKED,WERKS,QUERY)");
                strSql.Append(" values (");
                strSql.Append("@userid,@username,@password,@role,@userdesc,@islocked,@werks,@query)");
                SqlParameter[] parameters = {
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,50),
                    new SqlParameter("@role", SqlDbType.NVarChar,50),
                    new SqlParameter("@userdesc", SqlDbType.NVarChar,50),
					new SqlParameter("@islocked", SqlDbType.Bit),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@query", SqlDbType.NVarChar,200)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.USERNAME;
                parameters[2].Value = model.PASSWORD;
                parameters[3].Value = model.ROLE;
                parameters[4].Value = model.USERDESC;
                parameters[5].Value = model.ISLOCKED;
                parameters[6].Value = model.WERKS;
                parameters[7].Value = model.QUERY;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsExistUserInFun(string roleId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(*) from Sdl_Users ");
                strSql.Append("where role=@roleId ");
                SqlParameter[] parameters = {
					new SqlParameter("@roleId", SqlDbType.NVarChar,50)};
                parameters[0].Value = roleId;
                DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
                if (ds.Tables[0] != null && int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在用户名
        /// </summary>
        public bool ExistsSdl_User(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Users ");
            strSql.Append("where username=@username");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50)};
            parameters[0].Value = username;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        public bool ValidateSdl_Users(string username, string password)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from Sdl_Users ");
                strSql.Append("where username=@username and password=@password");
                SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,50)};
                parameters[0].Value = username;
                parameters[1].Value = password;
                return SQLServerHelper.Exists(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_Users(Sdl_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Users set ");
            strSql.Append("username=@username,");
            strSql.Append("role=@role,");
            strSql.Append("userdesc=@userdesc,");
            strSql.Append("islocked=@islocked,");
            strSql.Append("werks=@werks,");
            strSql.Append("query=@query ");
            strSql.Append("where userid=@userid");
            SqlParameter[] parameters = {
				new SqlParameter("@username", SqlDbType.NVarChar,50),
                new SqlParameter("@role", SqlDbType.NVarChar,50),
				new SqlParameter("@userdesc", SqlDbType.NVarChar,50),
                new SqlParameter("@islocked", SqlDbType.Bit),
				new SqlParameter("@userid", SqlDbType.NVarChar,50),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@query", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.USERNAME;
            parameters[1].Value = model.ROLE;
            parameters[2].Value = model.USERDESC;
            parameters[3].Value = model.ISLOCKED;
            parameters[4].Value = model.ID;
            parameters[5].Value = model.WERKS;
            parameters[6].Value = model.QUERY;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        public void ChangePasswordSdl_Users(string username, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Users set ");
            strSql.Append("password=@password ");
            strSql.Append("where username=@username");
            SqlParameter[] parameters = {
				new SqlParameter("@password", SqlDbType.NVarChar,50),
                new SqlParameter("@username", SqlDbType.NVarChar,50)};
            parameters[0].Value = password;
            parameters[1].Value = username;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_Users(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Users where userid=@userid");
            SqlParameter[] parameters = {
				new SqlParameter("@userid", SqlDbType.NVarChar,50)};
            parameters[0].Value = userid;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Users GetSdl_Users(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 USERID,USERNAME,PASSWORD,ROLE,USERDESC,ISLOCKED,WERKS,QUERY from Sdl_Users ");
            strSql.Append("where username=@username");
            SqlParameter[] parameters = {
                new SqlParameter("@username", SqlDbType.NVarChar,50)};
            parameters[0].Value = username;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_UsersRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        private Sdl_Users GetSdl_UsersRow(System.Data.DataRow row)
        {
            Sdl_Users model = new Sdl_Users();
            if (row != null)
            {
                if (row["USERID"].ToString() != "")
                {
                    model.ID = row["USERID"].ToString();
                }
                model.USERNAME = row["USERNAME"].ToString();
                model.PASSWORD = row["PASSWORD"].ToString();
                model.ISLOCKED = Convert.ToBoolean(row["ISLOCKED"]);
                model.ROLE = row["ROLE"].ToString();
                model.USERDESC = row["USERDESC"].ToString();
                model.WERKS = row["WERKS"].ToString();
                model.QUERY = row["QUERY"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_Users
    }
}
