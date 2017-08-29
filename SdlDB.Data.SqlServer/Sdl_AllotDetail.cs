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
        #region Sdl_AllotDetail

        public DataSet GetSdl_AllotDetailSet(string where)
        {
            string sql = "select * from Sdl_AllotDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataTable GetSdl_AllotDetailMengeAndSfimg(string where)
        {
            DataTable dt = new DataTable();
            string sql = "select isnull(sum(senge),0) as senge,isnull(sum(Sfimg),0) as Sfimg from Sdl_AllotDetail " + where;
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds.Tables[0] != null)
                dt = ds.Tables[0];
            return dt;

        }

        public double GetSdl_AllotDetailOverNum(string where)
        {
            string sql = "select sum(senge) as senge from Sdl_AllotDetail " + where;
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


        public DataSet GetSdl_AllotDetailSearchSet(string where)
        {
            string sql = "select B.* from  Sdl_AllotDetail B left outer join Sdl_AllotTitle A on B.EBELN=A.EBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_AllotDetail(string timeflag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AllotDetail ");
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
        public int AddSdl_AllotDetail(Sdl_AllotDetail model)
        {
            if (!ExistsSdl_AllotDetail(model.TIMEFLAG, model.EBELN, model.EBELP, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_AllotDetail(");
                strSql.Append("MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@ebeln,@ebelp,@menge,@senge,@kenge,@yfimg,@sfimg,@lgort,@timeflag,@packageweight,@werks)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@kenge", SqlDbType.Decimal),
                    new SqlParameter("@yfimg", SqlDbType.Int),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@packageweight", SqlDbType.Int),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.EBELN;
                parameters[3].Value = model.EBELP;
                parameters[4].Value = model.MENGE;
                parameters[5].Value = model.SENGE;
                parameters[6].Value = model.KENGE;
                parameters[7].Value = model.YFIMG;
                parameters[8].Value = model.SFIMG;
                parameters[9].Value = model.LGORT;
                parameters[10].Value = model.TIMEFLAG;
                parameters[11].Value = model.PACKAGEWEIGHT;
                parameters[12].Value = model.WERKS;
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
        public void UpdateSdl_AllotDetail(Sdl_AllotDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("kenge=@kenge,");
            strSql.Append("yfimg=@yfimg,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("packageweight=@packageweight,");
            strSql.Append("werks=@werks ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@kenge", SqlDbType.Decimal),
                    new SqlParameter("@yfimg", SqlDbType.Int),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@packageweight", SqlDbType.Int),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.SENGE;
            parameters[6].Value = model.KENGE;
            parameters[7].Value = model.YFIMG;
            parameters[8].Value = model.SFIMG;
            parameters[9].Value = model.LGORT;
            parameters[10].Value = model.TIMEFLAG;
            parameters[11].Value = model.PACKAGEWEIGHT;
            parameters[12].Value = model.WERKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AllotDetail(Sdl_AllotDetail model, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("senge=@senge,");
            strSql.Append("kenge=@kenge,");
            strSql.Append("yfimg=@yfimg,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("packageweight=@packageweight,");
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
                    new SqlParameter("@kenge", SqlDbType.Decimal),
                    new SqlParameter("@yfimg", SqlDbType.Int),
                    new SqlParameter("@sfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@packageweight", SqlDbType.Int),
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
            parameters[6].Value = model.KENGE;
            parameters[7].Value = model.YFIMG;
            parameters[8].Value = model.SFIMG;
            parameters[9].Value = model.LGORT;
            parameters[10].Value = model.TIMEFLAG;
            parameters[11].Value = model.PACKAGEWEIGHT;
            parameters[12].Value = ebeln;
            parameters[13].Value = ebelp;
            parameters[14].Value = lgort;
            parameters[15].Value = model.WERKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_AllotDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_AllotDetail] set ";
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
        public void DeleteSdl_AllotDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotDetail ");
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
        public void DeleteSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotDetail ");
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
        public Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS from Sdl_AllotDetail ");
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
                return GetSdl_AllotDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS from Sdl_AllotDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_AllotDetail> GetSdl_AllotDetailList(System.Data.DataTable table)
        {
            List<Sdl_AllotDetail> list = new List<Sdl_AllotDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_AllotDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_AllotDetail GetSdl_AllotDetailRow(System.Data.DataRow row)
        {
            Sdl_AllotDetail model = new Sdl_AllotDetail();
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
                model.KENGE = double.Parse(row["KENGE"].ToString());
                model.YFIMG = int.Parse(row["YFIMG"].ToString());
                model.SFIMG = int.Parse(row["SFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.WERKS = row["WERKS"].ToString();
                model.PACKAGEWEIGHT = int.Parse(row["PACKAGEWEIGHT"].ToString());
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
