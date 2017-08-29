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
        #region Sdl_FinishedProductsExchangeOut

        public DataSet GetSdl_FinishedProductsExchangeOutDataSet(string where)
        {
            string sql = "select * from sdl_FinishedProductsExchangeOut " + where;
            return SQLServerHelper.Query(sql);
        }


        public double GetSdl_FinishedProductsExchangeOutOverNum(string where)
        {
            string sql = "select sum(SFIMG) as SFIMG from sdl_FinishedProductsExchangeOut " + where;
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
        public int AddSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into sdl_FinishedProductsExchangeOut(");
                strSql.Append("TIMEFLAG,POSNR,MATNR,MAKTX,LGORT,ZFIMG,LFIMG,DBNUM,OANUM,MENGE,TRUCKNUM)");
                strSql.Append(" values (");
                strSql.Append("@timeflag,@posnr,@matnr,@maktx,@lgort,@ZFIMG,@LFIMG,@dbnum,@oanum,@menge,@trucknum)");
                SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@matnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@ZFIMG", SqlDbType.Decimal),
                    new SqlParameter("@LFIMG", SqlDbType.Decimal),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                    new SqlParameter("@menge", SqlDbType.Decimal),
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,20)};
                parameters[0].Value = model.TIMEFLAG;
                parameters[1].Value = model.POSNR;
                parameters[2].Value = model.MATNR;
                parameters[3].Value = model.MAKTX;
                parameters[4].Value = model.LGORT;
                parameters[5].Value = model.ZFIMG;
                parameters[6].Value = model.LFIMG;
                parameters[7].Value = model.DBNUM;
                parameters[8].Value = model.OANUM;
                parameters[9].Value = model.MENGE;
                parameters[10].Value = model.TRUCKNUM;
                SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsExchangeOut set ");
            strSql.Append("MATNR=@matnr,");
            strSql.Append("MAKTX=@maktx,");
            strSql.Append("LGORT=@lgort,");
            strSql.Append("ZFIMG=@ZFIMG,");
            strSql.Append("LFIMG=@LFIMG,");
            strSql.Append("DBNUM=@dbnum ");
            strSql.Append("where ID=@id ");
            SqlParameter[] parameters = {
                new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                new SqlParameter("@lgort", SqlDbType.NVarChar,50),
                new SqlParameter("@ZFIMG", SqlDbType.Decimal),
                new SqlParameter("@LFIMG", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,20),
                new SqlParameter("@id", SqlDbType.Int)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.LGORT;
            parameters[3].Value = model.ZFIMG;
            parameters[4].Value = model.LFIMG;
            parameters[5].Value = model.DBNUM;
            parameters[6].Value = id;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string timeFlag, string oanum, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsExchangeOut set ");
            strSql.Append("MATNR=@matnr,");
            strSql.Append("MAKTX=@maktx,");
            strSql.Append("LGORT=@lgort,");
            strSql.Append("ZFIMG=@ZFIMG,");
            strSql.Append("LFIMG=@LFIMG,");
            strSql.Append("DBNUM=@dbnum ");
            strSql.Append("where TIMEFLAG=@timeFlag and OANUM=@oanum and POSNR=@posnr ");
            SqlParameter[] parameters = {
                new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                new SqlParameter("@lgort", SqlDbType.NVarChar,50),
                new SqlParameter("@ZFIMG", SqlDbType.Decimal),
                new SqlParameter("@LFIMG", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,20),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,20),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.LGORT;
            parameters[3].Value = model.ZFIMG;
            parameters[4].Value = model.LFIMG;
            parameters[5].Value = model.DBNUM;
            parameters[6].Value = timeFlag;
            parameters[7].Value = oanum;
            parameters[8].Value = posnr;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_FinishedProductsExchangeOut ");
            strSql.Append("where timeflag=@timeflag and oanum=@oanum and posnr=@posnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            parameters[2].Value = posnr;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsExchangeOutRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string oanum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsExchangeOut ");
            strSql.Append(" where timeflag=@timeflag and oanum=@oanum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sdl_FinishedProductsExchangeOut ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and oanum=@oanum ");
            strSql.Append("and posnr=@posnr ");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            parameters[2].Value = posnr;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_FinishedProductsExchange> GetSdl_FinishedProductsExchangeOutList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsExchange> list = new List<Sdl_FinishedProductsExchange>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsExchangeOutRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeOutRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsExchange model = new Sdl_FinishedProductsExchange();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.ID = Convert.ToInt16(row["ID"].ToString());
                model.OANUM = row["OANUM"].ToString();
                model.POSNR = row["POSNR"].ToString();
                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.LGORT = row["LGORT"].ToString();
                model.ZFIMG = (row["ZFIMG"] == null) ? 0 : Convert.ToDecimal(row["ZFIMG"].ToString());
                model.LFIMG = (row["LFIMG"] == null) ? 0 : Convert.ToDecimal(row["LFIMG"].ToString());
                model.DBNUM = row["DBNUM"].ToString();
                model.MENGE = (row["MENGE"] == null) ? 0 : Convert.ToDecimal(row["MENGE"].ToString());
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
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
