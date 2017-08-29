using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  DemoTable
        public DataSet GetDemoTableDataSet(string where)
        {
            string sql = "select * from DemoTable " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsDemoTable(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DemoTable");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddDemoTable(DemoTable model)
        {
            if (!ExistsDemoTable(model.Id))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into DemoTable(");
                strSql.Append("id,name,input_date)");
                strSql.Append(" values (");
                strSql.Append("@id,@name,@input_date)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@input_date", SqlDbType.DateTime)};
                parameters[0].Value = model.Id;
                parameters[1].Value = model.Name;
                parameters[2].Value = model.Input_Date;

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
        public void UpdateDemoTable(DemoTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DemoTable set ");
            strSql.Append("id=@id,");
            strSql.Append("name=@name,");
            strSql.Append("input_date=@input_date ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@input_date", SqlDbType.DateTime)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Input_Date;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendDemoTable(int id, string columnName, Object value)
        {
            string sequel = "Update [DemoTable] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@id", id) };
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
        public void DeleteDemoTable(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DemoTable ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DemoTable GetDemoTable(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,input_date from DemoTable ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetDemoTable(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DemoTable GetDemoTableByID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,input_date from DemoTable ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetDemoTable(ds.Tables[0].Rows[0]);
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
        public List<DemoTable> GetDemoTableList(System.Data.DataTable table)
        {
            List<DemoTable> list = new List<DemoTable>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetDemoTable(table.Rows[i]));
            }
            return list;
        }
        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private DemoTable GetDemoTable(System.Data.DataRow row)
        {
            DemoTable model = new DemoTable();
            if (row != null)
            {
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["name"].ToString() != "")
                {
                    model.Name = row["name"].ToString();
                }
                if (row["Input_Date"].ToString() != "")
                {
                    model.Input_Date = DateTime.Parse(row["Input_Date"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  DemoTable

        public string GetContent(string table, string code, string content, string codevalue)
        {
            return SQLServerHelper.GetSingle("select " + content + " from " + table + " where " + code + "='" + codevalue + "'").ToString();
        }

        public object ExecuteSql(string sql)
        {
            return SQLServerHelper.Query(sql);
        }

        public int GetMaxID(string fieldName, string tableName)
        {
            return SQLServerHelper.GetMaxID(fieldName, tableName);
        }
    }
}
