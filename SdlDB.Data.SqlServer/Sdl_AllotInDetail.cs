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
        #region Sdl_AllotInDetail


        public DataSet GetSdl_AllotInDetailSet(string where)
        {
            string sql = "select * from Sdl_AllotInDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public double GetSdl_AllotInDetailOverNum(string where)
        {
            string sql = "select sum(senge) as senge from Sdl_AllotInDetail " + where;
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


        public DataSet GetSdl_AllotInDetailSearchSet(string where)
        {
            string sql = "select B.* from  Sdl_AllotInDetail B left outer join Sdl_AllotInTitle A on B.EBELN=A.EBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_AllotInDetail(string timeflag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AllotInDetail ");
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
        public int AddSdl_AllotInDetail(Sdl_AllotInDetail model)
        {
            if (!ExistsSdl_AllotInDetail(model.TIMEFLAG, model.EBELN, model.EBELP, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_AllotInDetail(");
                strSql.Append("MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS,YENGE,KFIMG )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@ebeln,@ebelp,@menge,@senge,@kenge,@yfimg,@sfimg,@lgort,@timeflag,@packageweight,@werks,@yenge,@kfimg)");
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
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@yenge", SqlDbType.Decimal),
                                            new SqlParameter("@kfimg", SqlDbType.Int)};
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
                parameters[13].Value = model.YENGE;
                parameters[14].Value = model.KFIMG;
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
        public void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotInDetail set ");
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
            strSql.Append("yenge=@yenge,");
            strSql.Append("kfimg=@kfimg,");
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
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@yenge", SqlDbType.Decimal),
                    new SqlParameter("@kfimg", SqlDbType.Int)};
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
            parameters[13].Value = model.YENGE;
            parameters[14].Value = model.KFIMG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotInDetail set ");
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
            strSql.Append("yenge=@yenge,");
            strSql.Append("kfimg=@kfimg,");
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
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@yenge", SqlDbType.Decimal),
                    new SqlParameter("@ebeln1", SqlDbType.NVarChar,10),
                    new SqlParameter("@ebelp1", SqlDbType.NVarChar,10),
                    new SqlParameter("@lgort1", SqlDbType.NVarChar,10),
                    new SqlParameter("@kfimg", SqlDbType.Int)};
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
            parameters[13].Value = model.YENGE;
            parameters[14].Value = ebeln;
            parameters[15].Value = ebelp;
            parameters[16].Value = lgort;
            parameters[17].Value = model.KFIMG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_AllotInDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_AllotInDetail] set ";
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
        public void DeleteSdl_AllotInDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotInDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_AllotInDetail(string timeFlag, string vbeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotInDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@vbeln and ebelp=@ebelp and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS,YENGE,KFIMG from Sdl_AllotInDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotInDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,SENGE,KENGE,YFIMG,SFIMG,LGORT,TIMEFLAG,PACKAGEWEIGHT,WERKS,YENGE,KFIMG from Sdl_AllotInDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
               	new SqlParameter("@ebelp", SqlDbType.NVarChar,10),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10)                         };
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = lgort;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotInDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_AllotInDetail> GetSdl_AllotInDetailList(System.Data.DataTable table)
        {
            List<Sdl_AllotInDetail> list = new List<Sdl_AllotInDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_AllotInDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_AllotInDetail GetSdl_AllotInDetailRow(System.Data.DataRow row)
        {
            Sdl_AllotInDetail model = new Sdl_AllotInDetail();
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
                model.YENGE = double.Parse(row["YENGE"].ToString());
                model.KFIMG = int.Parse(row["KFIMG"].ToString() == "" ? "0" : row["KFIMG"].ToString());
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
