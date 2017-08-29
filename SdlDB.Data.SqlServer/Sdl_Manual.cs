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
        /// <summary>
        /// 获取数据集合
        /// </summary>
        public DataSet GetSdl_ManualDataSet(string where)
        {
            string sql = "select * from Sdl_Manual " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Manual(Sdl_Manual model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Manual(");
                strSql.Append("TYPE,MANUAL) ");
                strSql.Append("values (");
                strSql.Append("@type,@manual)");
                SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@manual", SqlDbType.NVarChar,-1)};
                parameters[0].Value = model.TYPE;
                parameters[1].Value = model.MANUAL;

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
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Manual GetSdl_Manual(string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TYPE,MANUAL from Sdl_Manual ");
            strSql.Append("where type=@type");
            SqlParameter[] parameters = {
				new SqlParameter("@type", SqlDbType.NVarChar,50)};
            parameters[0].Value = type;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ManualRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateSdl_Manual(Sdl_Manual model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Manual set ");
            strSql.Append("manual=@manual ");
            strSql.Append("where type=@type");
            SqlParameter[] parameters = {
				new SqlParameter("@type", SqlDbType.NVarChar,50),
				new SqlParameter("@manual", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.TYPE;
            parameters[1].Value = model.MANUAL;
            return SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Manual(string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Manual ");
            strSql.Append("where type=@type");
            SqlParameter[] parameters = {
				new SqlParameter("@type", SqlDbType.NVarChar,50)};
            parameters[0].Value = type;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_Manual GetSdl_ManualRow(System.Data.DataRow row)
        {
            Sdl_Manual model = new Sdl_Manual();
            if (row != null)
            {
                if (row["TYPE"].ToString() != "")
                {
                    model.TYPE = row["TYPE"].ToString();
                }

                model.MANUAL = row["MANUAL"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
