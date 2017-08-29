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
        #region  Sdl_FinishedProductsSale

        public DataSet GetSdl_FinishedProductsSaleSet(string where)
        {
            string sql = "select * from Sdl_FinishedProductsSale " + where;
            return SQLServerHelper.Query(sql);
        }


        public DataSet GetSdl_FinishedProductsSaleSearchSet(string where)
        {
            string sql = "select B.*,A.KUNNR,A.NAME1 from  Sdl_FinishedProductsSaleTitle A left outer join Sdl_FinishedProductsSale B on A.VBELN=B.VBELN AND A.timeflag=B.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_FinishedProductsSale(string timeflag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_FinishedProductsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort");
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
        public int AddSdl_FinishedProductsSale(Sdl_FinishedProductsSale model)
        {
            if (!ExistsSdl_FinishedProductsSale(model.TIMEFLAG, model.VBELN, model.POSNR, model.LGORT))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_FinishedProductsSale(");
                strSql.Append("MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@vbeln,@lfimg,@zfimg,@lgort,@posnr,@timeflag,@realzfimg)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Int,4),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int,4)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.VBELN;
                parameters[3].Value = model.LFIMG;
                parameters[4].Value = model.ZFIMG;
                parameters[5].Value = model.LGORT;
                parameters[6].Value = model.POSNR;
                parameters[7].Value = model.TIMEFLAG;
                parameters[8].Value = model.REALZFIMG;

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
        public void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSale set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("realzfimg=@realzfimg");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Int),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                                        new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                                        new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                                        new SqlParameter("@realzfimg", SqlDbType.Int,4)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.LFIMG;
            parameters[4].Value = model.ZFIMG;
            parameters[5].Value = model.LGORT;
            parameters[6].Value = model.POSNR;
            parameters[7].Value = model.TIMEFLAG;
            parameters[8].Value = model.REALZFIMG;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, Sdl_FinishedProductsSale oldmodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSale set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
            strSql.Append("realzfimg=@realzfimg");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln1 and lgort=@lgort1 and posnr=@posnr1");
            SqlParameter[] parameters = 
            {
				new SqlParameter("@matnr", SqlDbType.NVarChar,20),
				new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                new SqlParameter("@lfimg", SqlDbType.Decimal),
                new SqlParameter("@zfimg", SqlDbType.Int),
				new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@realzfimg", SqlDbType.Int,4),
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
            parameters[7].Value = model.REALZFIMG;
            parameters[8].Value = oldmodel.VBELN;
            parameters[9].Value = oldmodel.LGORT;
            parameters[10].Value = oldmodel.POSNR;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, string vbeln1, string lgort1, string posnr1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSale set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("lfimg=@lfimg,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("lgort=@lgort,");
            strSql.Append("posnr=@posnr,");
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
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.REALZFIMG;
            parameters[8].Value = vbeln1;
            parameters[9].Value = lgort1;
            parameters[10].Value = posnr1;
            parameters[11].Value = model.VBELN;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_FinishedProductsSale(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_FinishedProductsSale] set ";
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
        public void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln, string lgort, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and lgort=@lgort and posnr=@posnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = lgort;
            parameters[3].Value = posnr;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG from Sdl_FinishedProductsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsSaleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,ZFIMG,LGORT,POSNR,TIMEFLAG,REALZFIMG from Sdl_FinishedProductsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and lgort=@lgort and posnr=@posnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsSaleRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_FinishedProductsSale> GetSdl_FinishedProductsSaleList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsSale> list = new List<Sdl_FinishedProductsSale>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsSaleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsSale GetSdl_FinishedProductsSaleRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsSale model = new Sdl_FinishedProductsSale();
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
                model.ZFIMG = Convert.ToInt32(row["ZFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.POSNR = row["POSNR"].ToString();
                model.REALZFIMG = int.Parse(row["REALZFIMG"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Sdl_FinishedProductsSale
    }
}
