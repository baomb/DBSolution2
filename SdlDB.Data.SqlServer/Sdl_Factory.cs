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
        #region  Sdl_Factory

        public DataSet GetSdl_FactoryDataSet(string where)
        {
            string sql = "select * from Sdl_Factory " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_Factory(string werks)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Factory ");
            strSql.Append(" where werks=@werks ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,12)};
            parameters[0].Value = werks;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Factory(Sdl_Factory model)
        {
            if (!ExistsSdl_Factory(model.WERKS))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Factory(");
                strSql.Append("bukrs,werks,name1,zbukrs,zwerks,zlgort,zlgobe)");
                strSql.Append(" values (");
                strSql.Append("@bukrs,@werks,@name1,@zbukrs,@zwerks,@zlgort,@zlgobe);");
                SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,12),
					new SqlParameter("@werks", SqlDbType.NVarChar,12),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50),
                    new SqlParameter("@zbukrs", SqlDbType.NVarChar,12),
					new SqlParameter("@zwerks", SqlDbType.NVarChar,12),
                    new SqlParameter("@zlgort", SqlDbType.NVarChar,50),
                    new SqlParameter("@zlgobe", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.BUKRS;
                parameters[1].Value = model.WERKS;
                parameters[2].Value = model.NAME1;
                parameters[3].Value = model.ZBUKRS;
                parameters[4].Value = model.ZWERKS;
                parameters[5].Value = model.ZLGORT;
                parameters[6].Value = model.ZLGOBE;
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
        public void UpdateSdl_Factory(Sdl_Factory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Factory set ");
            strSql.Append("bukrs=@bukrs,");
            strSql.Append("werks=@werks,");
            strSql.Append("name1=@name1,");
            strSql.Append("zbukrs=@zbukrs,");
            strSql.Append("zwerks=@zwerks,");
            strSql.Append("zlgort=@zlgort,");
            strSql.Append("zlgobe=@zlgobe");
            strSql.Append(" where werks=@werks  ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,12),
					new SqlParameter("@werks", SqlDbType.NVarChar,12),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50),
                    new SqlParameter("@zbukrs", SqlDbType.NVarChar,12),
					new SqlParameter("@zwerks", SqlDbType.NVarChar,12),
                    new SqlParameter("@zlgort", SqlDbType.NVarChar,50),
                    new SqlParameter("@zlgobe", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BUKRS;
            parameters[1].Value = model.WERKS;
            parameters[2].Value = model.NAME1;
            parameters[3].Value = model.ZBUKRS;
            parameters[4].Value = model.ZWERKS;
            parameters[5].Value = model.ZLGORT;
            parameters[6].Value = model.ZLGOBE;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Factory(string werks)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Company ");
            strSql.Append(" where werks=@werks ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,12)};
            parameters[0].Value = werks;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Factory GetSdl_Factory(string werks)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bukrs,werks,name1,zbukrs,zwerks,zlgort,zlgobe from Sdl_Factory ");
            strSql.Append(" where werks=@werks  ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,12)};
            parameters[0].Value = werks;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FactoryRow(ds.Tables[0].Rows[0]);
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
        private Sdl_Factory GetSdl_FactoryRow(System.Data.DataRow row)
        {
            Sdl_Factory model = new Sdl_Factory();
            if (row != null)
            {
                model.BUKRS = row["BUKRS"].ToString();
                model.WERKS = row["WERKS"].ToString();
                model.NAME1 = row["NAME1"].ToString();
                model.ZBUKRS = row["ZBUKRS"].ToString();
                model.ZWERKS = row["ZWERKS"].ToString();
                model.ZLGORT = row["ZLGORT"].ToString();
                model.ZLGOBE = row["ZLGOBE"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_Factory
    }
}
