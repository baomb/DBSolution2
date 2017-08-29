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
        #region Sdl_AccessoryAllotOutDetail

        public DataSet GetSdl_AccessoryAllotOutDetailSet(string where)
        {
            string sql = "select * from Sdl_AccessoryAllotOutDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataTable GetSdl_AccessoryAllotOutDetailMengeAndSfimg(string where)
        {
            DataTable dt = new DataTable();
            string sql = "select isnull(sum(senge),0) as senge,isnull(sum(Sfimg),0) as Sfimg from Sdl_AccessoryAllotOutDetail " + where;
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds.Tables[0] != null)
                dt = ds.Tables[0];
            return dt;

        }

        public double GetSdl_AccessoryAllotOutDetailOverNum(string where)
        {
            string sql = "select sum(senge) as senge from Sdl_AccessoryAllotOutDetail " + where;
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds != null && ds.Tables[0] != null)
            {
                string num = ds.Tables[0].Rows[0][0].ToString();
                if (num == "")
                    return 0;
                return double.Parse(num);
            }
            return 0;
        }


        public DataSet GetSdl_AccessoryAllotOutDetailSearchSet(string where)
        {
            string sql = "select B.* from  Sdl_AccessoryAllotOutDetail B left outer join Sdl_AccessoryAllotOutTitle A on B.EBELN=A.EBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_AccessoryAllotOutDetail(string timeflag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AccessoryAllotOutDetail ");
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
        public int AddSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model)
        {
            if (!ExistsSdl_AccessoryAllotOutDetail(model.TIMEFLAG, model.EBELN, model.EBELP, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_AccessoryAllotOutDetail(");
                strSql.Append("MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,SFIMG,LGORT,TIMEFLAG,WERKS )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@ebeln,@ebelp,@menge,@senge,@sfimg,@lgort,@timeflag,@werks)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.EBELN;
                parameters[3].Value = model.EBELP;
                parameters[4].Value = model.MENGE;
                parameters[5].Value = model.SENGE;
                parameters[6].Value = model.SFIMG;
                parameters[7].Value = model.LGORT;
                parameters[8].Value = model.TIMEFLAG;
                parameters[9].Value = model.WERKS;
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
        public void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AccessoryAllotOutDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("werks=@werks ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.SENGE;
            parameters[6].Value = model.SFIMG;
            parameters[7].Value = model.LGORT;
            parameters[8].Value = model.TIMEFLAG;
            parameters[9].Value = model.WERKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AccessoryAllotOutDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and ebeln=@ebeln1 ");
            strSql.Append("and ebelp=@ebelp1 ");
            strSql.Append("and lgort=@lgort1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln1", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebelp1", SqlDbType.NVarChar,30),
                    new SqlParameter("@lgort1", SqlDbType.NVarChar,30),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.SENGE;
            parameters[6].Value = model.SFIMG;
            parameters[7].Value = model.LGORT;
            parameters[8].Value = model.TIMEFLAG;
            parameters[9].Value = ebeln;
            parameters[10].Value = ebelp;
            parameters[11].Value = lgort;
            parameters[12].Value = model.WERKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_AccessoryAllotOutDetail] set ";
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
        public void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AccessoryAllotOutDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AccessoryAllotOutDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and ebeln=@ebeln ");
            strSql.Append("and ebelp=@ebelp ");
            strSql.Append("and lgort=@lgort ");
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
        public Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,SFIMG,LGORT,TIMEFLAG,WERKS from Sdl_AccessoryAllotOutDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AccessoryAllotOutDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,SFIMG,LGORT,TIMEFLAG,WERKS from Sdl_AccessoryAllotOutDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and ebeln=@ebeln ");
            strSql.Append("and ebelp=@ebelp ");
            strSql.Append("and lgort=@lgort ");
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
                return GetSdl_AccessoryAllotOutDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_AccessoryAllotOutDetail> GetSdl_AccessoryAllotOutDetailList(System.Data.DataTable table)
        {
            List<Sdl_AccessoryAllotOutDetail> list = new List<Sdl_AccessoryAllotOutDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_AccessoryAllotOutDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetailRow(System.Data.DataRow row)
        {
            Sdl_AccessoryAllotOutDetail model = new Sdl_AccessoryAllotOutDetail();
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
                model.SFIMG = int.Parse(row["SFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.WERKS = row["WERKS"].ToString();
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
