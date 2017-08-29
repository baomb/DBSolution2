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
        #region Sdl_Roles

        public DataSet GetSdl_RolesDataSet(string where)
        {
            string sql = "select * from Sdl_Roles " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_Roles(Sdl_Roles model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Roles(");
                strSql.Append("ROLEID,ROLENAME,ROLEDESC)");
                strSql.Append(" values (");
                strSql.Append("@roleid,@rolename,@roledesc)");
                SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.NVarChar,50),
                    new SqlParameter("@rolename", SqlDbType.NVarChar,50),
                    new SqlParameter("@roledesc", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.ROLEID;
                parameters[1].Value = model.ROLENAME;
                parameters[2].Value = model.ROLEDESC;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_Roles(Sdl_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Roles set ");
            strSql.Append("rolename=@rolename,");
            strSql.Append("roledesc=@roledesc ");
            strSql.Append("where roleid=@roleid");
            SqlParameter[] parameters = {
				new SqlParameter("@rolename", SqlDbType.NVarChar,50),
				new SqlParameter("@roledesc", SqlDbType.NVarChar,50),
                new SqlParameter("@roleid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ROLENAME;
            parameters[1].Value = model.ROLEDESC;
            parameters[2].Value = model.ROLEID;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_Roles(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Roles where roleid=@roleid");
            SqlParameter[] parameters = {
				new SqlParameter("@roleid", SqlDbType.NVarChar,50)};
            parameters[0].Value = roleid;
            SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Roles GetSdl_RolesByRoleName(string rolename)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ROLEID,ROLENAME,ROLEDESC from Sdl_Roles ");
            strSql.Append(" where rolename=@rolename ");
            SqlParameter[] parameters = { new SqlParameter("@rolename", SqlDbType.NVarChar, 100) };
            parameters[0].Value = rolename;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RolesRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Roles GetSdl_Roles(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ROLEID,ROLENAME,ROLEDESC from Sdl_Roles ");
            strSql.Append(" where roleid=@roleid ");
            SqlParameter[] parameters = { new SqlParameter("@roleid", SqlDbType.NVarChar, 36) };
            parameters[0].Value = roleid;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RolesRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_Roles GetSdl_RolesRow(System.Data.DataRow row)
        {
            Sdl_Roles model = new Sdl_Roles();
            if (row != null)
            {
                if (row["ROLEID"].ToString() != "")
                {
                    model.ROLEID = row["ROLEID"].ToString();
                }
                model.ROLENAME = row["ROLENAME"].ToString();
                model.ROLEDESC = row["ROLEDESC"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_Roles
    }
}
