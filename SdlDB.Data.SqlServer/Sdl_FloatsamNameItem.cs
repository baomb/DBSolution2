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
        #region Sdl_FloatsamNameItem

        public DataSet GetSdl_FloatsamNameItemDataSet(string where)
        {
            string sql = "select * from sdl_FloatsamNameItem " + where;
            return SQLServerHelper.Query(sql);
        }
        /// <summary>
        /// 是否存在code
        /// </summary>
        public bool ExistsFloatsamNameItem(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sdl_FloatsamNameItem ");
            strSql.Append("where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddFloatsamNameItem(sdl_FloatsamNameItem model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into sdl_FloatsamNameItem(");
                strSql.Append("ID,Code,Name,CreateBy,CreateTime)");
                strSql.Append(" values (");
                strSql.Append("@ID,@Code,@Name,@CreateBy,@CreateTime)");
                SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50),
                    new SqlParameter("@Code", SqlDbType.VarChar,50),
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@CreateBy", SqlDbType.VarChar,50),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.Code;
                parameters[2].Value = model.Name;
                parameters[3].Value = model.CreateBy;
                parameters[4].Value = model.CreateTime;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public sdl_FloatsamNameItem Getsdl_FloatsamNameItem(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,Code,Name,CreateBy,CreateTime from sdl_FloatsamNameItem ");
            strSql.Append("where Code=@Code");
            SqlParameter[] parameters = {
                new SqlParameter("@Code", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Getsdl_FloatsamNameItem(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        private sdl_FloatsamNameItem Getsdl_FloatsamNameItem(System.Data.DataRow row)
        {
            sdl_FloatsamNameItem model = new sdl_FloatsamNameItem();
            if (row != null)
            {
                if (row["ID"].ToString() != "")
                {
                    model.ID = row["ID"].ToString();
                }
                model.Code = row["Code"].ToString();
                model.Name = row["Name"].ToString();
                model.CreateBy = row["CreateBy"].ToString();
                if (row["CreateTime"] != DBNull.Value)
                    model.CreateTime =Convert.ToDateTime(row["CreateTime"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Updatesdl_FloatsamNameItem(sdl_FloatsamNameItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sdl_FloatsamNameItem set ");
            strSql.Append("Code=@Code,");
            strSql.Append("Name=@Name ");
            strSql.Append("where ID=@ID");
            SqlParameter[] parameters = {
				new SqlParameter("@Code", SqlDbType.VarChar,50),
                new SqlParameter("@Name", SqlDbType.VarChar,50),
				new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ID;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Deletesdl_FloatsamNameItem(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sdl_FloatsamNameItem where ID=@ID");
            SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = ID;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion Sdl_FloatsamNameItem
    }
}
