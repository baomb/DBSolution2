using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;
using System.Data.SqlClient;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  DemoTable

        public DataSet GetSdl_WarehouseSet(string where)
        {
            string sql = "select * from sdl_Warehouse " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_Warehouse(string werks,string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Warehouse ");
            strSql.Append(" where werks=@werks and lgort=@lgort ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,12),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,12)};
            parameters[0].Value = werks;
            parameters[1].Value = lgort;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Warehouse(Sdl_Warehouse model)
        {
            if (!ExistsSdl_Warehouse(model.Werks,model.Lgort))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Warehouse(");
                strSql.Append("bukrs,werks,lgort,lgobe,house_keeper)");
                strSql.Append(" values (");
                strSql.Append("@bukrs,@werks,@lgort,@lgobe,@house_keeper);");
                SqlParameter[] parameters = {
                    new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@werks", SqlDbType.NVarChar,50),
					new SqlParameter("@lgort", SqlDbType.NVarChar,50),
					new SqlParameter("@lgobe", SqlDbType.NVarChar,50),
                    new SqlParameter("@house_keeper", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.Bukrs;
                parameters[1].Value = model.Werks;
                parameters[2].Value = model.Lgort;
                parameters[3].Value = model.Lgobe;
                parameters[4].Value = model.House_Keeper;

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
        public void UpdateSdl_Warehouse(Sdl_Warehouse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Warehouse set ");
            strSql.Append("bukrs=@bukrs,");
            strSql.Append("werks=@werks,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("lgobe=@lgobe,");
            strSql.Append("house_keeper=@house_keeper ");
            strSql.Append(" where werks=@werks and lgort=@lgort ");
            SqlParameter[] parameters = {
                    new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@werks", SqlDbType.NVarChar,50),
					new SqlParameter("@lgort", SqlDbType.NVarChar,50),
					new SqlParameter("@lgobe", SqlDbType.NVarChar,50),
                    new SqlParameter("@house_keeper", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Bukrs;
            parameters[1].Value = model.Werks;
            parameters[2].Value = model.Lgort;
            parameters[3].Value = model.Lgobe;
            parameters[4].Value = model.House_Keeper;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_Warehouse(string werks, string columnName, Object value)
        {
            string sequel = "Update [Sdl_Warehouse] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where werks=@werks";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@werks", werks) };
            object obj = SQLServerHelper.GetSingle(sequel, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Warehouse(string werks,string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Warehouse ");
            strSql.Append(" where werks=@werks ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,50),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,50)};
            parameters[0].Value = werks;
            parameters[1].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Warehouse GetSdl_Warehouse(string werks, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bukrs,werks,lgort,lgobe,house_Keeper from Sdl_Warehouse ");
            strSql.Append(" where werks=@werks and lgort=@lgort ");
            SqlParameter[] parameters = {
					new SqlParameter("@werks", SqlDbType.NVarChar,50),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,50)};
            parameters[0].Value = werks;
            parameters[1].Value = lgort;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_WarehouseRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_Warehouse> GetSdl_WarehouseList(System.Data.DataTable table)
        {
            List<Sdl_Warehouse> list = new List<Sdl_Warehouse>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_WarehouseRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_Warehouse GetSdl_WarehouseRow(System.Data.DataRow row)
        {
            Sdl_Warehouse model = new Sdl_Warehouse();
            if (row != null)
            {
                model.Bukrs = row["Bukrs"].ToString();
                model.Werks = row["Werks"].ToString();

                model.Lgort = row["Lgort"].ToString();

                model.Lgobe = row["Lgobe"].ToString();

                model.House_Keeper = row["House_Keeper"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_Warehouse
    }
}
