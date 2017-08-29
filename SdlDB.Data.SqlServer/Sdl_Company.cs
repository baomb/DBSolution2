using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Sdl_Company

        public DataSet GetSdl_CompanyDataSet(string where)
        {
            string sql = "select * from Sdl_Company " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_Company(string bukrs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Company ");
            strSql.Append(" where bukrs=@bukrs ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,12)};
            parameters[0].Value = bukrs;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Company(Sdl_Company model)
        {
            if (!ExistsSdl_Company(model.BUKRS))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Company(");
                strSql.Append("bukrs,butxt)");
                strSql.Append(" values (");
                strSql.Append("@bukrs,@butxt);");
                SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@butxt", SqlDbType.NVarChar,75)};
                parameters[0].Value = model.BUKRS;
                parameters[1].Value = model.BUTXT;

                object obj = SQLServerHelper.GetSingle(strSql.ToString(), parameters);
                if (obj == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_Company(Sdl_Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Company set ");
            strSql.Append("bukrs=@bukrs,");
            strSql.Append("butxt=@butxt");
            strSql.Append(" where bukrs=@bukrs  ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@butxt", SqlDbType.NVarChar,75)};
            parameters[0].Value = model.BUKRS;
            parameters[1].Value = model.BUTXT;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Company(string bukrs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Company ");
            strSql.Append(" where bukrs=@bukrs ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50)};
            parameters[0].Value = bukrs;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Company GetSdl_Company(string bukrs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bukrs,butxt from Sdl_Company ");
            strSql.Append(" where bukrs=@bukrs  ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50)};
            parameters[0].Value = bukrs;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_CompanyRow(ds.Tables[0].Rows[0]);
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
        private Sdl_Company GetSdl_CompanyRow(System.Data.DataRow row)
        {
            Sdl_Company model = new Sdl_Company();
            if (row != null)
            {
                model.BUKRS = row["BUKRS"].ToString();
                model.BUTXT = row["BUTXT"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_Company
    }
}
