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
        #region Sdl_Feedback

        public DataSet GetSdl_FeedbackDataSet(string where)
        {
            string sql = "select * from Sdl_Feedback " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_Feedback(Sdl_Feedback model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Feedback(");
                strSql.Append("USERNAME,TITLE,COMMENT,DATETIME,RESULT,RESPONSE,RESPNAME,RESPTIME,RESOLVED)");
                strSql.Append(" values (");
                strSql.Append("@username,@title,@comment,@datetime,@result,@response,@respname,@resptime,@resolved)");
                SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@title", SqlDbType.NVarChar,50),
                    new SqlParameter("@comment", SqlDbType.NVarChar,-1),
                    new SqlParameter("@datetime", SqlDbType.DateTime),
					new SqlParameter("@result", SqlDbType.Bit),
                    new SqlParameter("@response", SqlDbType.NVarChar,-1),
                    new SqlParameter("@respname", SqlDbType.NVarChar,50),
                    new SqlParameter("@resptime", SqlDbType.DateTime),
                    new SqlParameter("@resolved", SqlDbType.Bit)};
                parameters[0].Value = model.USERNAME;
                parameters[1].Value = model.TITLE;
                parameters[2].Value = model.COMMENT;
                parameters[3].Value = model.DATETIME;
                parameters[4].Value = model.RESULT;
                parameters[5].Value = model.RESPONSE;
                parameters[6].Value = model.RESPNAME;
                parameters[7].Value = model.RESPTIME;
                parameters[8].Value = model.RESOLVED;
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
        public void UpdateSdl_Feedback(Sdl_Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Feedback set ");
            strSql.Append("username=@username,");
            strSql.Append("title=@title,");
            strSql.Append("comment=@comment,");
            strSql.Append("datetime=@datetime,");
            strSql.Append("response=@response,");
            strSql.Append("respname=@respname,");
            strSql.Append("resptime=@resptime,");
            strSql.Append("resolved=@resolved,");
            strSql.Append("result=@result ");
            strSql.Append("where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.NVarChar,50),
                new SqlParameter("@username", SqlDbType.NVarChar,50),
                new SqlParameter("@title", SqlDbType.NVarChar,50),
                new SqlParameter("@comment", SqlDbType.NVarChar,-1),
                new SqlParameter("@datetime", SqlDbType.DateTime),
			    new SqlParameter("@result", SqlDbType.Bit),
                new SqlParameter("@response", SqlDbType.NVarChar,-1),
                new SqlParameter("@respname", SqlDbType.NVarChar,50),
                new SqlParameter("@resptime", SqlDbType.DateTime),
                new SqlParameter("@resolved", SqlDbType.Bit)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.USERNAME;
            parameters[2].Value = model.TITLE;
            parameters[3].Value = model.COMMENT;
            parameters[4].Value = model.DATETIME;
            parameters[5].Value = model.RESULT;
            parameters[6].Value = model.RESPONSE;
            parameters[7].Value = model.RESPNAME;
            parameters[8].Value = model.RESPTIME;
            parameters[9].Value = model.RESOLVED;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_Feedback(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Feedback where id=@id");
            SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int)};
            parameters[0].Value = id;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Feedback GetSdl_Feedback(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,USERNAME,TITLE,COMMENT,DATETIME,RESULT,RESPONSE,RESPNAME,RESPTIME,RESOLVED from Sdl_Feedback ");
            strSql.Append("where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int)};
            parameters[0].Value = id;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FeedbackRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        private Sdl_Feedback GetSdl_FeedbackRow(System.Data.DataRow row)
        {
            Sdl_Feedback model = new Sdl_Feedback();
            if (row != null)
            {
                if (row["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt32(row["ID"].ToString());
                }
                model.USERNAME = row["USERNAME"].ToString();
                model.TITLE = row["TITLE"].ToString();
                model.RESOLVED = Convert.ToBoolean(row["RESOLVED"]);
                model.RESULT = Convert.ToBoolean(row["RESULT"]);
                model.COMMENT = row["COMMENT"].ToString();
                model.DATETIME = DateTime.Parse(row["DATETIME"].ToString());
                model.RESPONSE = row["RESPONSE"].ToString();
                model.RESPNAME = row["RESPNAME"].ToString();
                model.RESPTIME = DateTime.Parse(row["RESPTIME"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
