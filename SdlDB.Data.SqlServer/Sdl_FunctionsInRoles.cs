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
        #region Sdl_FunctionsInRoles

        public DataSet GetSdl_FunctionsInRolesDataSet(string roleid)
        {
            string sql = "select * from Sdl_FunctionsInRoles where roleid='" + roleid + "'";
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_FunctionsInRolesDataSetWhere(string where)
        {
            string sql = "select * from Sdl_FunctionsInRoles " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool IsExistFunction(string functionId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(*) from Sdl_FunctionsInRoles ");
                strSql.Append("where functionid=@functionid ");
                SqlParameter[] parameters = {
					new SqlParameter("@functionid", SqlDbType.NVarChar,50)};
                parameters[0].Value = functionId;
                DataSet ds= SQLServerHelper.Query(strSql.ToString(), parameters);
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
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_FunctionsInRoles(Sdl_FunctionsInRoles model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_FunctionsInRoles(");
                strSql.Append("FUNCTIONID,ROLEID)");
                strSql.Append(" values (");
                strSql.Append("@functionid,@roleid)");
                SqlParameter[] parameters = {
					new SqlParameter("@functionid", SqlDbType.NVarChar,50),
                    new SqlParameter("@roleid", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.FUNCTIONID;
                parameters[1].Value = model.ROLEID;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FunctionsInRoles(string functionid, string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FunctionsInRoles where functionid=@functionid and roleid=@roleid");
            SqlParameter[] parameters = {
				new SqlParameter("@functionid", SqlDbType.NVarChar,50),
                new SqlParameter("@roleid", SqlDbType.NVarChar,50)};
            parameters[0].Value = functionid;
            parameters[1].Value = roleid;
            SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FunctionsInRoles(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FunctionsInRoles where roleid=@roleid");
            SqlParameter[] parameters = {
                new SqlParameter("@roleid", SqlDbType.NVarChar,50)};
            parameters[0].Value = roleid;
            SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        #endregion
    }
}
