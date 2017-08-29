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
        #region  Sdl_Delivery_Type

        public DataSet GetSdl_Delivery_TypeDataSet(string where)
        {
            string sql = "select * from Sdl_Delivery_Type " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Delivery_Type ");
            strSql.Append(" where bukrs=@bukrs and vkorg=@vkorg and vtweg=@vtweg ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,12),
                                        new SqlParameter("@vkorg", SqlDbType.NVarChar,12),
                                        new SqlParameter("@vtweg", SqlDbType.NVarChar,12)};
            parameters[0].Value = bukrs;
            parameters[1].Value = vkorg;
            parameters[2].Value = vtweg;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_Delivery_Type(Sdl_Delivery_Type model)
        {
            if (!ExistsSdl_Delivery_Type(model.BUKRS,model.VKORG,model.VTWEG))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Delivery_Type(");
                strSql.Append("bukrs,vkorg,vtweg,ztext)");
                strSql.Append(" values (");
                strSql.Append("@bukrs,@vkorg,@vtweg,@ztext);");
                SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@vkorg", SqlDbType.NVarChar,50),
                    new SqlParameter("@vtweg", SqlDbType.NVarChar,50),
                    new SqlParameter("@ztext", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.BUKRS;
                parameters[1].Value = model.VKORG;
                parameters[2].Value = model.VTWEG;
                parameters[3].Value = model.ZTEXT;

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
        public void UpdateSdl_Delivery_Type(Sdl_Delivery_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_Delivery_Type set ");
            strSql.Append("bukrs=@bukrs,");
            strSql.Append("vkorg=@vkorg");
            strSql.Append("vtweg=@vtweg,");
            strSql.Append("ztext=@ztext");
            strSql.Append(" where bukrs=@bukrs and vkorg=@vkorg and  vtweg=@vtweg ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
					new SqlParameter("@vkorg", SqlDbType.NVarChar,50),
					new SqlParameter("@vtweg", SqlDbType.NVarChar,50),
					new SqlParameter("@ztext", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BUKRS;
            parameters[1].Value = model.VKORG;
            parameters[2].Value = model.VTWEG;
            parameters[3].Value = model.ZTEXT;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Delivery_Type ");
            strSql.Append(" where bukrs=@bukrs and vkorg=@vkorg and vtweg=@vtweg ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
                                        new SqlParameter("@vkorg", SqlDbType.NVarChar,50),
                                        new SqlParameter("@vtweg", SqlDbType.NVarChar,50)};
            parameters[0].Value = bukrs;
            parameters[1].Value = vkorg;
            parameters[2].Value = vtweg;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_Delivery_Type GetSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 bukrs,vkorg,vtweg,ztext from Sdl_Delivery_Type ");
            strSql.Append(" where bukrs=@bukrs and vkorg=@vkorg and vtweg=@vtweg ");
            SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,50),
                    new SqlParameter("@vkorg", SqlDbType.NVarChar,50),
                    new SqlParameter("@vtweg", SqlDbType.NVarChar,50)};
            parameters[0].Value = bukrs;
            parameters[1].Value = vkorg;
            parameters[2].Value = vtweg;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_Delivery_TypeRow(ds.Tables[0].Rows[0]);
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
        private Sdl_Delivery_Type GetSdl_Delivery_TypeRow(System.Data.DataRow row)
        {
            Sdl_Delivery_Type model = new Sdl_Delivery_Type();
            if (row != null)
            {
                model.BUKRS = row["BUKRS"].ToString();
                model.VKORG = row["VKORG"].ToString();
                model.VTWEG = row["VTWEG"].ToString();
                model.ZTEXT = row["ZTEXT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_Delivery_Type
    }
}
