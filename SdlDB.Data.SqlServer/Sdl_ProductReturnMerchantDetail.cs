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
        #region  Sdl_ProductReturnMerchantDetail
        public DataSet GetSdl_ProductReturnMerchantDetailSet(string where)
        {
            string sql = "select * from Sdl_ProductReturnMerchantDetail " + where;
            return SQLServerHelper.Query(sql);
        }


        public DataSet GetSdl_ProductReturnMerchantDetailSearchSet(string where)
        {
            string sql = "select B.*,A.KUNNR,A.NAME1 from Sdl_ProductReturnMerchantDetail B left outer join Sdl_ProductReturnMerchant A on B.VBELN=A.VBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_ProductReturnMerchantDetail(string timeflag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_ProductReturnMerchantDetail ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln ");
            strSql.Append("and posnr=@posnr ");
            strSql.Append("and lgort=@lgort");
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
        public int AddSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model)
        {
            if (!ExistsSdl_ProductReturnMerchantDetail(model.TIMEFLAG, model.VBELN, model.POSNR, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_ProductReturnMerchantDetail(");
                strSql.Append("MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG,SFIMG )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@vbeln,@lfimg,@zfimg,@lgort,@posnr,@timeflag,@realzfimg,@sfimg)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Decimal),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Decimal)};
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
        public void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnMerchantDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("realzfimg=@realzfimg,");
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
                                        new SqlParameter("@realzfimg", SqlDbType.Decimal),
                                        new SqlParameter("@sfimg", SqlDbType.Decimal)};
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
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        public void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, Sdl_ProductReturnMerchantDetail oldmodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnMerchantDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("sfimg=@sfimg,");
            strSql.Append("realzfimg=@realzfimg ");
            strSql.Append("where timeflag=@timeflag and vbeln=@vbeln1 and lgort=@lgort1 and posnr=@posnr1");
            SqlParameter[] parameters = 
            {
				new SqlParameter("@matnr", SqlDbType.NVarChar,20),
				new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                new SqlParameter("@lfimg", SqlDbType.Decimal),
                new SqlParameter("@zfimg", SqlDbType.Int),
				new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@sfimg", SqlDbType.Decimal),
                new SqlParameter("@realzfimg", SqlDbType.Decimal),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort1", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr1", SqlDbType.NVarChar,10)
            };
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.LFIMG;
            parameters[3].Value = model.ZFIMG;
            parameters[4].Value = model.LGORT;
            parameters[5].Value = model.POSNR;
            parameters[6].Value = oldmodel.TIMEFLAG;
            parameters[7].Value = model.SFIMG;
            parameters[8].Value = model.REALZFIMG;
            parameters[9].Value = oldmodel.VBELN;
            parameters[10].Value = oldmodel.LGORT;
            parameters[11].Value = oldmodel.POSNR;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        public void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, string vbeln1, string lgort1, string posnr1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnMerchantDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("sfimg=@sfimg,");
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
                new SqlParameter("@zfimg", SqlDbType.Int),
				new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@sfimg", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@realzfimg", SqlDbType.Int,4),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort1", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr1", SqlDbType.NVarChar,10),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,10)
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
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_ProductReturnMerchantDetail] set ";
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
        public void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnMerchantDetail ");
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
        public void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string lgort, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnMerchantDetail ");
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
        public Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG,sfimg from Sdl_ProductReturnMerchantDetail ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnMerchantDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG,sfimg from Sdl_ProductReturnMerchantDetail ");
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
                return GetSdl_ProductReturnMerchantDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_ProductReturnMerchantDetail> GetSdl_ProductReturnMerchantDetailList(System.Data.DataTable table)
        {
            List<Sdl_ProductReturnMerchantDetail> list = new List<Sdl_ProductReturnMerchantDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_ProductReturnMerchantDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetailRow(System.Data.DataRow row)
        {
            Sdl_ProductReturnMerchantDetail model = new Sdl_ProductReturnMerchantDetail();
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
