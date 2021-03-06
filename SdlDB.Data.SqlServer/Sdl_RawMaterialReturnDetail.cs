﻿using System;
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
        #region  Sdl_RawMaterialReturnDetail

        public DataSet GetSdl_RawMaterialReturnDetailSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialReturnDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public double GetSdl_RawMaterialReturnDetailOverNum(string where)
        {
            string sql = "select sum(senge) as senge from Sdl_RawMaterialReturnDetail " + where;
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds != null && ds.Tables[0] != null)
            {
                string num = ds.Tables[0].Rows[0][0].ToString();
                if (num == "")
                    return 0;
                if (num.Length > 0)
                    return double.Parse(num);
                return double.Parse(num);
            }
            return 0;
        }


        public DataSet GetSdl_RawMaterialReturnDetailSearchSet(string where)
        {
            string sql = "select B.*,A.LIFNR,A.NAME1 from  Sdl_RawMaterialReturnDetail B left outer join Sdl_RawMaterialReturnTitle A on B.EBELN=A.EBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_RawMaterialReturnDetail(string timeflag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialReturnDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and lgort=@lgort");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeflag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = lgort;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model)
        {
            if (!ExistsSdl_RawMaterialReturnDetail(model.TIMEFLAG, model.EBELN, model.EBELP, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialReturnDetail(");
                strSql.Append("MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,LGORT,TIMEFLAG,BKTXT )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@ebeln,@ebelp,@menge,@senge,@lgort,@timeflag,@bktxt)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,25)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.EBELN;
                parameters[3].Value = model.EBELP;
                parameters[4].Value = model.MENGE;
                parameters[5].Value = model.SENGE;
                parameters[6].Value = model.LGORT;
                parameters[7].Value = model.TIMEFLAG;
                parameters[8].Value = model.BKTXT;
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
        public void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialReturnDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("bktxt=@bktxt,");
            strSql.Append("lgort=@lgort ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.Decimal),
                    new SqlParameter("@menge", SqlDbType.Int),
					new SqlParameter("@senge", SqlDbType.NVarChar,10),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,25)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.SENGE;
            parameters[6].Value = model.LGORT;
            parameters[7].Value = model.TIMEFLAG;
            parameters[8].Value = model.BKTXT;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialReturnDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("bktxt=@bktxt,");
            strSql.Append("lgort=@lgort ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and ebeln=@ebeln1 ");
            strSql.Append("and ebelp=@ebelp1 ");
            strSql.Append("and lgort=@lgort1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.Decimal),
                    new SqlParameter("@menge", SqlDbType.Int),
					new SqlParameter("@senge", SqlDbType.NVarChar,10),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln1", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebelp1", SqlDbType.NVarChar,30),
                    new SqlParameter("@lgort1", SqlDbType.NVarChar,30),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,25)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.SENGE;
            parameters[6].Value = model.LGORT;
            parameters[7].Value = model.TIMEFLAG;
            parameters[8].Value = ebeln;
            parameters[9].Value = ebelp;
            parameters[10].Value = lgort;
            parameters[11].Value = model.BKTXT;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_RawMaterialReturnDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_RawMaterialReturnDetail] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where timeflag=@timeflag and ebeln=@ebeln";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Value", value), 
                new SqlParameter("@timeflag", timeFlag),
                new SqlParameter("@ebeln", vbeln),};
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
        public void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialReturnDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialReturnDetail ");
            strSql.Append("where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,30),
                new SqlParameter("@ebelp", SqlDbType.NVarChar,30),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,LGORT,TIMEFLAG,BKTXT from Sdl_RawMaterialReturnDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialReturnDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,LGORT,TIMEFLAG,BKTXT from Sdl_RawMaterialReturnDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,30),
                new SqlParameter("@ebelp", SqlDbType.NVarChar,30),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = lgort;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialReturnDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_RawMaterialReturnDetail> GetSdl_RawMaterialReturnDetailList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialReturnDetail> list = new List<Sdl_RawMaterialReturnDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialReturnDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetailRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialReturnDetail model = new Sdl_RawMaterialReturnDetail();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.EBELN = row["EBELN"].ToString();
                model.EBELP = row["EBELP"].ToString();
                model.MENGE = double.Parse(row["MENGE"].ToString());
                model.SENGE = double.Parse(row["SENGE"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.BKTXT = row["BKTXT"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_RawMaterialReturnDetail
    }
}
