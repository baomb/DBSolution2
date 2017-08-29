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
        #region Sdl_Functions

        public DataSet GetSdl_FunctionsDataSet(string where)
        {
            string sql = "select * from Sdl_Functions " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_Functions(Sdl_Functions model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Functions(");
                strSql.Append("FUNCTIONID,FUNCTIONNAME,FUNCTIONDESC,FUNCTIONKEY,FUNCTIONPARENT)");
                strSql.Append(" values (");
                strSql.Append("@functionid,@functionname,@functiondesc,@functionkey,@functionparent)");
                SqlParameter[] parameters = {
					new SqlParameter("@functionid", SqlDbType.NVarChar,36),
                    new SqlParameter("@functionname", SqlDbType.NVarChar,50),
                    new SqlParameter("@functiondesc", SqlDbType.NVarChar,1024),
                    new SqlParameter("@functionkey", SqlDbType.NVarChar,50),
                    new SqlParameter("@functionparent", SqlDbType.NVarChar,36)};
                parameters[0].Value = model.FUNCTIONID;
                parameters[1].Value = model.FUNCTIONNAME;
                parameters[2].Value = model.FUNCTIONDESC;
                parameters[3].Value = model.FUNCTIONKEY;
                parameters[4].Value = model.FUNCTIONPARENT;
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
        public void UpdateSdl_Functions(Sdl_Functions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Functions set ");
            strSql.Append("functionname=@functionname,");
            strSql.Append("functionkey=@functionkey,");
            strSql.Append("functionparent=@functionparent,");
            strSql.Append("functiondesc=@functiondesc ");
            strSql.Append("where functionid=@functionid");
            SqlParameter[] parameters = {
				new SqlParameter("@functionid", SqlDbType.NVarChar,36),
                new SqlParameter("@functionname", SqlDbType.NVarChar,50),
                new SqlParameter("@functiondesc", SqlDbType.NVarChar,50),
                new SqlParameter("@functionkey", SqlDbType.NVarChar,50),
                new SqlParameter("@functionparent", SqlDbType.NVarChar,36)};
            parameters[0].Value = model.FUNCTIONID;
            parameters[1].Value = model.FUNCTIONNAME;
            parameters[2].Value = model.FUNCTIONDESC;
            parameters[3].Value = model.FUNCTIONKEY;
            parameters[4].Value = model.FUNCTIONPARENT;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_Functions(string functionid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Functions where functionid=@functionid");
            SqlParameter[] parameters = {
				new SqlParameter("@functionid", SqlDbType.NVarChar,36)};
            parameters[0].Value = functionid;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 判断是否有子
        /// </summary>
        public bool IsExistChildFunction(string functionId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(*) from Sdl_Functions ");
                strSql.Append("where functionParent=@functionid ");
                SqlParameter[] parameters = {
					new SqlParameter("@functionid", SqlDbType.NVarChar,50)};
                parameters[0].Value = functionId;
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
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Functions GetSdl_Functions(string functionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 FUNCTIONID,FUNCTIONNAME,FUNCTIONDESC,FUNCTIONKEY,FUNCTIONPARENT from Sdl_Functions ");
            strSql.Append(" where functionid=@functionid ");
            SqlParameter[] parameters = { new SqlParameter("@functionid", SqlDbType.NVarChar, 36) };
            parameters[0].Value = functionId;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FunctionsRow(ds.Tables[0].Rows[0]);
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
        private Sdl_Functions GetSdl_FunctionsRow(System.Data.DataRow row)
        {
            Sdl_Functions model = new Sdl_Functions();
            if (row != null)
            {
                if (row["FUNCTIONID"].ToString() != "")
                {
                    model.FUNCTIONID = row["FUNCTIONID"].ToString();
                }
                model.FUNCTIONNAME = row["FUNCTIONNAME"].ToString();
                model.FUNCTIONDESC = row["FUNCTIONDESC"].ToString();
                model.FUNCTIONKEY = row["FUNCTIONKEY"].ToString();
                model.FUNCTIONPARENT = row["FUNCTIONPARENT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_Functions
    }
}
