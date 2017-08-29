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
        #region Sdl_FinishedProductsPresentation

        public DataSet GetSdl_FinishedProductsPresentationDataSet(string where)
        {
            string sql = "select * from Sdl_FinishedProductsPresentation " + where;
            return SQLServerHelper.Query(sql);
        }


        public double GetSdl_FinishedProductsPresentationOverNum(string where)
        {
            string sql = "select sum(SFIMG) as SFIMG from Sdl_FinishedProductsPresentation " + where;
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_FinishedProductsPresentation(");
                strSql.Append("MATNR,MAKTX,RSNUM,BDMNG,LGORT,RSPOS,TIMEFLAG,SFIMG,REALMENGE,SGTXT)");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@rsnum,@bdmng,@lgort,@rspos,@timeflag,@sfimg,@realmenge,@sgtxt)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@rsnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@bdmng", SqlDbType.Decimal),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20),
					new SqlParameter("@rspos", SqlDbType.NVarChar,20),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@realmenge", SqlDbType.Int,4),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.RSNUM;
                parameters[3].Value = model.BDMNG;
                parameters[4].Value = model.LGORT;
                parameters[5].Value = model.RSPOS;
                parameters[6].Value = model.TIMEFLAG;
                parameters[7].Value = model.SFIMG;
                parameters[8].Value = model.REALMENGE;
                parameters[9].Value = model.SGTXT;

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
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model, string rsnum, string rspos, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsPresentation set ");
            strSql.Append("MATNR=@MATNR,");
            strSql.Append("MAKTX=@MAKTX,");
            strSql.Append("RSNUM=@RSNUM,");
            strSql.Append("BDMNG=@BDMNG,");
            strSql.Append("LGORT=@LGORT,");
            strSql.Append("RSPOS=@RSPOS,");
            strSql.Append("SFIMG=@SFIMG,");
            strSql.Append("REALMENGE=@REALMENGE,");
            strSql.Append("SGTXT=@SGTXT ");
            strSql.Append("where timeFlag=@timeFlag and rsnum=@rsnum1 and rspos=@rspos1 and lgort=@lgort1 ");
            SqlParameter[] parameters = {
                new SqlParameter("@MATNR", SqlDbType.NVarChar,50),
                new SqlParameter("@MAKTX", SqlDbType.NVarChar,50),
                new SqlParameter("@RSNUM", SqlDbType.NVarChar,50),
                new SqlParameter("@BDMNG", SqlDbType.Decimal),
                new SqlParameter("@LGORT", SqlDbType.NVarChar,20),
                new SqlParameter("@RSPOS", SqlDbType.NVarChar,20),
                new SqlParameter("@SFIMG", SqlDbType.Decimal),
                new SqlParameter("@REALMENGE", SqlDbType.Decimal),
                new SqlParameter("@SGTXT", SqlDbType.NVarChar,20),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum1", SqlDbType.NVarChar,50),
                new SqlParameter("@rspos1", SqlDbType.NVarChar,50),
                new SqlParameter("@lgort1", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.RSNUM;
            parameters[3].Value = model.BDMNG;
            parameters[4].Value = model.LGORT;
            parameters[5].Value = model.RSPOS;
            parameters[6].Value = model.SFIMG;
            parameters[7].Value = model.REALMENGE;
            parameters[8].Value = model.SGTXT;
            parameters[9].Value = model.TIMEFLAG;
            parameters[10].Value = rsnum;
            parameters[11].Value = rspos;
            parameters[12].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,RSNUM,BDMNG,LGORT,RSPOS,TIMEFLAG,sFIMG,REALMENGE,SGTXT from Sdl_FinishedProductsPresentation ");
            strSql.Append("where timeflag=@timeflag and rsnum=@rsnum and rspos=@rspos");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@rspos", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = rspos;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsPresentationRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,RSNUM,BDMNG,LGORT,RSPOS,TIMEFLAG,sFIMG,REALMENGE,SGTXT from Sdl_FinishedProductsPresentation ");
            strSql.Append("where timeflag=@timeflag and rsnum=@rsnum and rspos=@rspos and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20),
                new SqlParameter("@rspos", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = lgort;
            parameters[3].Value = rspos;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsPresentationRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsPresentation ");
            strSql.Append(" where timeflag=@timeflag and rsnum=@rsnum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsPresentation ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and rsnum=@rsnum ");
            strSql.Append("and rspos=@rspos ");
            strSql.Append("and lgort=@lgort ");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@rspos", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = rspos;
            parameters[3].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_FinishedProductsPresentation> GetSdl_FinishedProductsPresentationList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsPresentation> list = new List<Sdl_FinishedProductsPresentation>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsPresentationRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentationRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsPresentation model = new Sdl_FinishedProductsPresentation();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.RSNUM = row["RSNUM"].ToString();
                model.BDMNG = (row["BDMNG"] == null) ? 0 : Convert.ToDouble(row["BDMNG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.RSPOS = row["RSPOS"].ToString();
                model.SFIMG = (row["SFIMG"] == null) ? 0 : Convert.ToDouble(row["SFIMG"].ToString());
                model.REALMENGE = (row["REALMENGE"] == null) ? 0 : Convert.ToInt16(row["REALMENGE"].ToString());
                model.SGTXT = row["SGTXT"].ToString();
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
