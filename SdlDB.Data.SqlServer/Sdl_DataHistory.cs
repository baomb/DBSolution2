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
        #region  Sdl_DataHistory

        public DataSet GetSdl_DataHistoryDataSet(string where)
        {
            string sql = "select * from Sdl_DataHistory " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_DataHistoryPageData(string pageNum, int PageSize, string where)
        {
            string sql = "select distinct top 1000000000 EditTime,Module,TableName,UserName,DeleteFlag,InsertFlag,EditFlag from Sdl_DataHistory " + where + " order by edittime desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_DataHistory(string editTime, string tableName, string field)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_DataHistory ");
            strSql.Append("where EditTime=@EditTime ");
            strSql.Append("and TableName=@TableName ");
            strSql.Append("and Field=@Field ");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Field", SqlDbType.NVarChar,50)};
            parameters[0].Value = editTime;
            parameters[1].Value = tableName;
            parameters[2].Value = field;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_DataHistory(Sdl_DataHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sdl_DataHistory(");
            strSql.Append("EditTime,Module,TableName,Field,OldValue,Col6,Col1,Col2,Col3,Col4,Col5,ColField,NewValue,DeleteFlag,InsertFlag,EditFlag,Time,UserName,Random)");
            strSql.Append(" values (");
            strSql.Append("@EditTime,@Module,@TableName,@Field,@OldValue,@Col6,@Col1,@Col2,@Col3,@Col4,@Col5,@ColField,@NewValue,@DeleteFlag,@InsertFlag,@EditFlag,@Time,@UserName,@Random);");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Module", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Field", SqlDbType.NVarChar,50),
                    new SqlParameter("@OldValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col6", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col4", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col5", SqlDbType.NVarChar,50),
                    new SqlParameter("@ColField", SqlDbType.NVarChar,50),
                    new SqlParameter("@NewValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@DeleteFlag", SqlDbType.Bit),
                    new SqlParameter("@InsertFlag", SqlDbType.Bit),
                    new SqlParameter("@EditFlag", SqlDbType.Bit),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Random", SqlDbType.NVarChar,50),
                    new SqlParameter("@Time", SqlDbType.DateTime)};
            parameters[0].Value = model.EditTime;
            parameters[1].Value = model.Module;
            parameters[2].Value = model.TableName;
            parameters[3].Value = model.Field;
            parameters[4].Value = model.OldValue;
            parameters[5].Value = model.Col6;
            parameters[6].Value = model.Col1;
            parameters[7].Value = model.Col2;
            parameters[8].Value = model.Col3;
            parameters[9].Value = model.Col4;
            parameters[10].Value = model.Col5;
            parameters[11].Value = model.ColField;
            parameters[12].Value = model.NewValue;
            parameters[13].Value = model.DeleteFlag;
            parameters[14].Value = model.InsertFlag;
            parameters[15].Value = model.EditFlag;
            parameters[16].Value = model.UserName;
            parameters[17].Value = model.Random;
            parameters[18].Value = model.Time;
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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_DataHistory(Sdl_DataHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_DataHistory set ");
            strSql.Append("Module=@Module,");
            strSql.Append("OldValue=@OldValue,");
            strSql.Append("Col1=@Col1,");
            strSql.Append("Col2=@Col2,");
            strSql.Append("Col3=@Col3,");
            strSql.Append("Col4=@Col4,");
            strSql.Append("Col5=@Col5,");
            strSql.Append("Col6=@Col6,");
            strSql.Append("ColField=@ColField,");
            strSql.Append("NewValue=@NewValue,");
            strSql.Append("DeleteFlag=@DeleteFlag,");
            strSql.Append("InsertFlag=@InsertFlag,");
            strSql.Append("EditFlag=@EditFlag,");
            strSql.Append("Time=@Time ");
            strSql.Append("where EditTime=@EditTime ");
            strSql.Append("and TableName=@TableName ");
            strSql.Append("and Field=@Field ");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Module", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Field", SqlDbType.NVarChar,50),
                    new SqlParameter("@OldValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col6", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col4", SqlDbType.NVarChar,50),
                    new SqlParameter("@Col5", SqlDbType.NVarChar,50),
                    new SqlParameter("@ColField", SqlDbType.NVarChar,50),
                    new SqlParameter("@NewValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@DeleteFlag", SqlDbType.Bit),
                    new SqlParameter("@InsertFlag", SqlDbType.Bit),
                    new SqlParameter("@EditFlag", SqlDbType.Bit),
                    new SqlParameter("@Time", SqlDbType.DateTime)};
            parameters[0].Value = model.EditTime;
            parameters[1].Value = model.Module;
            parameters[2].Value = model.TableName;
            parameters[3].Value = model.Field;
            parameters[4].Value = model.OldValue;
            parameters[5].Value = model.Col6;
            parameters[6].Value = model.Col1;
            parameters[7].Value = model.Col2;
            parameters[8].Value = model.Col3;
            parameters[9].Value = model.Col4;
            parameters[10].Value = model.Col5;
            parameters[11].Value = model.ColField;
            parameters[12].Value = model.NewValue;
            parameters[13].Value = model.DeleteFlag;
            parameters[14].Value = model.InsertFlag;
            parameters[15].Value = model.EditFlag;
            parameters[16].Value = model.Time;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_DataHistory(string editTime, string tableName, string field)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Company ");
            strSql.Append("where EditTime=@EditTime ");
            strSql.Append("and TableName=@TableName ");
            strSql.Append("and Field=@Field ");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Field", SqlDbType.NVarChar,50)};
            parameters[0].Value = editTime;
            parameters[1].Value = tableName;
            parameters[2].Value = field;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_DataHistory GetSdl_DataHistory(string editTime, string tableName, string field)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_DataHistory ");
            strSql.Append("where EditTime=@EditTime ");
            strSql.Append("and TableName=@TableName ");
            strSql.Append("and Field=@Field ");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Field", SqlDbType.NVarChar,50)};
            parameters[0].Value = editTime;
            parameters[1].Value = tableName;
            parameters[2].Value = field;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_DataHistoryRow(ds.Tables[0].Rows[0]);
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
        private Sdl_DataHistory GetSdl_DataHistoryRow(System.Data.DataRow row)
        {
            Sdl_DataHistory model = new Sdl_DataHistory();
            if (row != null)
            {
                model.EditTime = row["EditTime"].ToString();
                model.Module = row["Module"].ToString();
                model.TableName = row["TableName"].ToString();
                model.Field = row["Field"].ToString();
                model.OldValue = row["OldValue"].ToString();
                model.Col6 = row["Col6"].ToString();
                model.Col1 = row["Col1"].ToString();
                model.Col2 = row["Col2"].ToString();
                model.Col3 = row["Col3"].ToString();
                model.Col4 = row["Col4"].ToString();
                model.Col5 = row["Col5"].ToString();
                model.ColField = row["ColField"].ToString();
                model.NewValue = row["NewValue"].ToString();
                model.DeleteFlag = Convert.ToBoolean(row["DeleteFlag"].ToString());
                model.InsertFlag = Convert.ToBoolean(row["InsertFlag"].ToString());
                model.EditFlag = Convert.ToBoolean(row["EditFlag"].ToString());
                model.Time = DateTime.Parse(row["Time"].ToString());
                model.UserName = row["UserName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_DataHistory
    }
}
