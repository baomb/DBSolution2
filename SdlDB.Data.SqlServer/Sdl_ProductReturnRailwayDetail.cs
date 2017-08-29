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
        #region  Sdl_ProductReturnRailwayDetail

        public DataSet GetSdl_ProductReturnRailwayDetailSet(string where)
        {
            string sql = "select * from Sdl_ProductReturnRailwayDetail " + where;
            return SQLServerHelper.Query(sql);
        }


        public DataSet GetSdl_ProductReturnRailwayDetailSearchSet(string where)
        {
            string sql = "select B.*,A.KUNNR,A.NAME1 from  Sdl_ProductReturnRailwayDetail B left outer join Sdl_ProductReturnRailway A on B.VBELN=A.VBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_ProductReturnRailwayDetail(string timeflag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_ProductReturnRailwayDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln ");
            strSql.Append("and posnr=@posnr ");
            strSql.Append("and lgort=@lgort ");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeflag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model)
        {
            if (!ExistsSdl_ProductReturnRailwayDetail(model.TIMEFLAG, model.VBELN, model.POSNR, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_ProductReturnRailwayDetail(");
                strSql.Append("MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG,SFIMG,KUIJIAN )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@vbeln,@lfimg,@zfimg,@lgort,@posnr,@timeflag,@realzfimg,@sfimg,@kuijian)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Decimal),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Decimal,4),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@kuijian", SqlDbType.Decimal)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.VBELN;
                parameters[3].Value = model.LFIMG;
                parameters[4].Value = model.ZFIMG;
                parameters[5].Value = model.LGORT;
                parameters[6].Value = model.POSNR;
                parameters[7].Value = model.TIMEFLAG;
                parameters[8].Value = model.REALZFIMG;
                parameters[9].Value = model.SFIMG;
                parameters[10].Value = model.KUIJIAN;
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
        public void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnRailwayDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("realzfimg=@realzfimg,");
            strSql.Append("kuijian=@kuijian,");
            strSql.Append("sfimg=@sfimg");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Decimal),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Decimal,4),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@kuijian", SqlDbType.Decimal)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.LFIMG;
            parameters[4].Value = model.ZFIMG;
            parameters[5].Value = model.LGORT;
            parameters[6].Value = model.POSNR;
            parameters[7].Value = model.TIMEFLAG;
            parameters[8].Value = model.REALZFIMG;
            parameters[9].Value = model.SFIMG;
            parameters[10].Value = model.KUIJIAN;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="vbeln1"></param>
        /// <param name="lgort1"></param>
        /// <param name="posnr1"></param>
        public void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model, string vbeln1, string lgort1, string posnr1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnRailwayDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("kuijian=@kuijian,");
            strSql.Append("realzfimg=@realzfimg ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln1 ");
            strSql.Append("and lgort=@lgort1 ");
            strSql.Append("and posnr=@posnr1");
            SqlParameter[] parameters = 
            {
				new SqlParameter("@matnr", SqlDbType.NVarChar,20),
				new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                new SqlParameter("@lfimg", SqlDbType.Decimal),
                new SqlParameter("@zfimg", SqlDbType.Decimal),
				new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@sfimg", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@realzfimg", SqlDbType.Decimal,4),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort1", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr1", SqlDbType.NVarChar,10),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,10),
                new SqlParameter("@kuijian", SqlDbType.Decimal,4)
            };
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.LFIMG;
            parameters[3].Value = model.ZFIMG;
            parameters[4].Value = model.LGORT;
            parameters[5].Value = model.POSNR;
            parameters[6].Value = model.SFIMG;
            parameters[7].Value = model.TIMEFLAG;
            parameters[8].Value = model.REALZFIMG;
            parameters[9].Value = vbeln1;
            parameters[10].Value = lgort1;
            parameters[11].Value = posnr1;
            parameters[12].Value = model.VBELN;
            parameters[13].Value = model.KUIJIAN;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_ProductReturnRailwayDetail] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where timeflag=@timeflag and vbeln=@vbeln";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Value", value), 
                new SqlParameter("@timeflag", timeFlag),
                new SqlParameter("@vbeln", vbeln),};
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
        public void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnRailwayDetail ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
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
        public void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string lgort, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnRailwayDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln ");
            strSql.Append("and posnr=@posnr ");
            strSql.Append("and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG,SFIMG,KUIJIAN from Sdl_ProductReturnRailwayDetail ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnRailwayDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_ProductReturnRailwayDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln ");
            strSql.Append("and posnr=@posnr ");
            strSql.Append("and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnRailwayDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_ProductReturnRailwayDetail> GetSdl_ProductReturnRailwayDetailList(System.Data.DataTable table)
        {
            List<Sdl_ProductReturnRailwayDetail> list = new List<Sdl_ProductReturnRailwayDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_ProductReturnRailwayDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetailRow(System.Data.DataRow row)
        {
            Sdl_ProductReturnRailwayDetail model = new Sdl_ProductReturnRailwayDetail();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.VBELN = row["VBELN"].ToString();
                model.LFIMG = double.Parse(row["LFIMG"].ToString());
                model.ZFIMG = double.Parse(row["ZFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.POSNR = row["POSNR"].ToString();
                model.REALZFIMG = double.Parse(row["REALZFIMG"].ToString());
                model.SFIMG = double.Parse(row["SFIMG"].ToString());
                model.KUIJIAN = double.Parse(row["KUIJIAN"].ToString() == "" ? "0" : row["KUIJIAN"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_ProductReturnRailwayDetail
    }
}
