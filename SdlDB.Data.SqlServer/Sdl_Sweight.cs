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
        #region Sdl_Sweight

        public DataSet GetSdl_SweightDataSet(string where)
        {
            string sql = "select * from Sdl_Sweight " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Sweight(Sdl_Sweight model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Sweight(");
                strSql.Append("Sweight,Stext )");
                strSql.Append(" values (");
                strSql.Append("@sweight,@stext )");
                SqlParameter[] parameters = {
					new SqlParameter("@sweight", SqlDbType.NVarChar,10),
                    new SqlParameter("@stext", SqlDbType.NVarChar,20)};
                parameters[0].Value = model.SWEIGHT;
                parameters[1].Value = model.STEXT;

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
        public Sdl_Sweight GetSdl_Sweight(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_Sweight ");
            strSql.Append("where ID = @ID");
            SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = Convert.ToInt32(ID);
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_SweightRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public bool ExistsSdl_Sweight(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Sweight ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = Convert.ToInt32(ID);

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_Sweight(Sdl_Sweight model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Sweight set ");
            strSql.Append("SWEIGHT=@sweight, ");
            strSql.Append("STEXT=@stext ");
            strSql.Append("where ID = @ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int),
					new SqlParameter("@sweight", SqlDbType.NVarChar,10),
                    new SqlParameter("@stext", SqlDbType.NVarChar,20)};
            parameters[0].Value = Convert.ToInt32(model.ID);
            parameters[1].Value = model.SWEIGHT;
            parameters[2].Value = model.STEXT;
            SQLServerHelper.GetSingle(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Sweight(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Sweight ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = Convert.ToInt32(ID);
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除所有数据
        /// </summary>
        public void DeleteAllSdl_Sweight()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Sweight ");
            SQLServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_Sweight> GetSdl_SweightList(System.Data.DataTable table)
        {
            List<Sdl_Sweight> list = new List<Sdl_Sweight>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_SweightRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_Sweight GetSdl_SweightRow(System.Data.DataRow row)
        {
            Sdl_Sweight model = new Sdl_Sweight();
            if (row != null)
            {
                model.ID = row["ID"].ToString();
                model.SWEIGHT = row["SWEIGHT"].ToString();
                model.STEXT = row["STEXT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_Sweight
    }
}
