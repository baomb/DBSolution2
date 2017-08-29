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
        #region  Sdl_FinishedProductsExchangeOutTitle

        public DataSet GetSdl_FinishedProductsExchangeOutTitleDataSet(string where)
        {
            string sql = "select * from sdl_FinishedProductsExchangeOutTittle " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_FinishedProductsExchangeOutTitlePageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 10000000000 * from sdl_FinishedProductsExchangeOutTittle " + where + "  order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_FinishedProductsExchangeOutTitleDataSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            fields = fields.TrimStart(',');
            string sql = "select " + fields + " from sdl_FinishedProductsExchangeOutTittle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sdl_FinishedProductsExchangeOutTittle ");
            strSql.Append("where timeFlag=@timeFlag and oanum=@oanum and truckNum=@truckNum");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeflag", SqlDbType.DateTime),
                    new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                    new SqlParameter("@truckNum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            parameters[2].Value = truckNum;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into sdl_FinishedProductsExchangeOutTittle(");
                strSql.Append("OANUM,TIMEFLAG,WERKS,TRUCKNUM,ENTERTIME,ENTERWEIGHT,EXITTIME,EXITWEIGHT,HS_FLAG,GROSS,TARE,NET,EXITFLAG,DBNUM,NOTE,ID,");
                strSql.Append("CNUM,CNAME,TTYPE,FXQD,YWY,XSQY,XSKS )");
                strSql.Append(" values (@oanum,@timeflag,@werks,@trucknum,@entertime,@enterweight,@exittime,@exitweight,@hs_flag,@gross,@tare,@net,@exitflag,@dbnum,@note,@id,");
                strSql.Append("@cnum,@cname,@ttype,@fxqd,@ywy,@xsqy,@xsks )");
                SqlParameter[] parameters = {
                    new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                    new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@enterweight", SqlDbType.NVarChar,20),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@exitweight", SqlDbType.NVarChar,20),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,2),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@net", SqlDbType.Decimal),
                    new SqlParameter("@exitflag", SqlDbType.Int),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@note", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.NVarChar,20),
                    new SqlParameter("@cnum", SqlDbType.NVarChar,30),
                    new SqlParameter("@cname", SqlDbType.NVarChar,30),
                    new SqlParameter("@ttype", SqlDbType.NVarChar,30),
                    new SqlParameter("@fxqd", SqlDbType.NVarChar,30),
                    new SqlParameter("@ywy", SqlDbType.NVarChar,30),
                    new SqlParameter("@xsqy", SqlDbType.NVarChar,30),
                    new SqlParameter("@xsks", SqlDbType.NVarChar,30)};
                parameters[0].Value = model.OANUM;
                parameters[1].Value = model.TIMEFLAG;
                parameters[2].Value = model.WERKS;
                parameters[3].Value = model.TRUCKNUM;
                parameters[4].Value = model.ENTERTIME;
                parameters[5].Value = model.ENTERWEIGHT;
                parameters[6].Value = model.EXITTIME;
                parameters[7].Value = model.EXITWEIGHT;
                parameters[8].Value = model.HS_FLAG;
                parameters[9].Value = model.GROSS;
                parameters[10].Value = model.TARE;
                parameters[11].Value = model.NET;
                parameters[12].Value = model.EXITFLAG;
                parameters[13].Value = model.DBNUM;
                parameters[14].Value = model.NOTE;
                parameters[15].Value = model.ID;
                parameters[16].Value = model.CNUM;
                parameters[17].Value = model.CNAME;
                parameters[18].Value = model.TTYPE;
                parameters[19].Value = model.FXQD;
                parameters[20].Value = model.YWY;
                parameters[21].Value = model.XSQY;
                parameters[22].Value = model.XSKS;

                SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
                return 1;
            }
            catch (Exception ex)
            {
               return 0;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sdl_FinishedProductsExchangeOutTittle set ");
            strSql.Append("TRUCKNUM=@trucknum,");
            strSql.Append("ENTERTIME=@entertime,");
            strSql.Append("ENTERWEIGHT=@enterweight,");
            strSql.Append("EXITTIME=@exittime,");
            strSql.Append("EXITWEIGHT=@exitweight,");
            strSql.Append("HS_FLAG=@hs_flag,");
            strSql.Append("GROSS=@gross,");
            strSql.Append("TARE=@tare,");
            strSql.Append("NET=@net,");
            strSql.Append("EXITFLAG=@exitflag,");
            strSql.Append("DBNUM=@dbnum,");
            strSql.Append("NOTE=@note, ");
            strSql.Append("CNUM=@cnum, ");
            strSql.Append("CNAME=@cname, ");
            strSql.Append("TTYPE=@ttype, ");
            strSql.Append("FXQD=@fxqd, ");
            strSql.Append("YWY=@ywy, ");
            strSql.Append("XSQY=@xsqy, ");
            strSql.Append("XSKS=@xsks ");
            strSql.Append(" where TIMEFLAG=@timeFlag and OANUM=@oanum and TRUCKNUM=@trucknum ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@enterweight", SqlDbType.NVarChar,20),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@exitweight", SqlDbType.NVarChar,20),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@note", SqlDbType.NVarChar,50),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@cnum", SqlDbType.NVarChar,30),
                new SqlParameter("@cname", SqlDbType.NVarChar,30),
                new SqlParameter("@ttype", SqlDbType.NVarChar,30),
                new SqlParameter("@fxqd", SqlDbType.NVarChar,30),
                new SqlParameter("@ywy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsqy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsks", SqlDbType.NVarChar,30)
            };
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.ENTERTIME;
            parameters[2].Value = model.ENTERWEIGHT;
            parameters[3].Value = model.EXITTIME;
            parameters[4].Value = model.EXITWEIGHT;
            parameters[5].Value = model.HS_FLAG;
            parameters[6].Value = model.GROSS;
            parameters[7].Value = model.TARE;
            parameters[8].Value = model.NET;
            parameters[9].Value = model.EXITFLAG;
            parameters[10].Value = model.DBNUM;
            parameters[11].Value = model.NOTE;
            parameters[12].Value = model.TIMEFLAG;
            parameters[13].Value = model.OANUM;
            parameters[14].Value = model.CNUM;
            parameters[15].Value = model.CNAME;
            parameters[16].Value = model.TTYPE;
            parameters[17].Value = model.FXQD;
            parameters[18].Value = model.YWY;
            parameters[19].Value = model.XSQY;
            parameters[20].Value = model.XSKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsExchangeOutTitleByTimeFlag(Sdl_FinishedProductsExchangeTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sdl_FinishedProductsExchangeOutTittle set ");
            strSql.Append("TRUCKNUM=@trucknum,");
            strSql.Append("ENTERTIME=@entertime,");
            strSql.Append("ENTERWEIGHT=@enterweight,");
            strSql.Append("EXITTIME=@exittime,");
            strSql.Append("EXITWEIGHT=@exitweight,");
            strSql.Append("HS_FLAG=@hs_flag,");
            strSql.Append("GROSS=@gross,");
            strSql.Append("TARE=@tare,");
            strSql.Append("NET=@net,");
            strSql.Append("EXITFLAG=@exitflag,");
            strSql.Append("DBNUM=@dbnum,");
            strSql.Append("NOTE=@note, ");
            strSql.Append("CNUM=@cnum, ");
            strSql.Append("CNAME=@cname, ");
            strSql.Append("TTYPE=@ttype, ");
            strSql.Append("FXQD=@fxqd, ");
            strSql.Append("YWY=@ywy, ");
            strSql.Append("XSQY=@xsqy, ");
            strSql.Append("XSKS=@xsks ");
            strSql.Append(" where TIMEFLAG=@timeFlag and WERKS=@werks ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@enterweight", SqlDbType.NVarChar,20),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@exitweight", SqlDbType.NVarChar,20),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@note", SqlDbType.NVarChar,50),
                new SqlParameter("@timeflag", SqlDbType.DateTime),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@cnum", SqlDbType.NVarChar,30),
                new SqlParameter("@cname", SqlDbType.NVarChar,30),
                new SqlParameter("@ttype", SqlDbType.NVarChar,30),
                new SqlParameter("@fxqd", SqlDbType.NVarChar,30),
                new SqlParameter("@ywy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsqy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsks", SqlDbType.NVarChar,30)
            };
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.ENTERTIME;
            parameters[2].Value = model.ENTERWEIGHT;
            parameters[3].Value = model.EXITTIME;
            parameters[4].Value = model.EXITWEIGHT;
            parameters[5].Value = model.HS_FLAG;
            parameters[6].Value = model.GROSS;
            parameters[7].Value = model.TARE;
            parameters[8].Value = model.NET;
            parameters[9].Value = model.EXITFLAG;
            parameters[10].Value = model.DBNUM;
            parameters[11].Value = model.NOTE;
            parameters[12].Value = model.TIMEFLAG;
            parameters[13].Value = model.WERKS;
            parameters[14].Value = model.CNUM;
            parameters[15].Value = model.CNAME;
            parameters[16].Value = model.TTYPE;
            parameters[17].Value = model.FXQD;
            parameters[18].Value = model.YWY;
            parameters[19].Value = model.XSQY;
            parameters[20].Value = model.XSKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model, string truckNum, string oanum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sdl_FinishedProductsExchangeOutTittle set ");
            strSql.Append("TRUCKNUM=@trucknum,");
            strSql.Append("ENTERTIME=@entertime,");
            strSql.Append("ENTERWEIGHT=@enterweight,");
            strSql.Append("EXITTIME=@exittime,");
            strSql.Append("EXITWEIGHT=@exitweight,");
            strSql.Append("HS_FLAG=@hs_flag,");
            strSql.Append("GROSS=@gross,");
            strSql.Append("TARE=@tare,");
            strSql.Append("NET=@net,");
            strSql.Append("EXITFLAG=@exitflag,");
            strSql.Append("DBNUM=@dbnum,");
            strSql.Append("NOTE=@note, ");
            strSql.Append("OANUM=@oanum, ");
            strSql.Append("CNUM=@cnum, ");
            strSql.Append("CNAME=@cname, ");
            strSql.Append("TTYPE=@ttype, ");
            strSql.Append("FXQD=@fxqd, ");
            strSql.Append("YWY=@ywy, ");
            strSql.Append("XSQY=@xsqy, ");
            strSql.Append("XSKS=@xsks ");
            strSql.Append(" where timeFlag=@timeFlag and oanum=@oanum1 and trucknum=@trucknum1 ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@enterweight", SqlDbType.NVarChar,20),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@exitweight", SqlDbType.NVarChar,20),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@note", SqlDbType.NVarChar,50),
                new SqlParameter("@timeflag", SqlDbType.DateTime),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@oanum1", SqlDbType.NVarChar,14),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,20),
                new SqlParameter("@cnum", SqlDbType.NVarChar,30),
                new SqlParameter("@cname", SqlDbType.NVarChar,30),
                new SqlParameter("@ttype", SqlDbType.NVarChar,30),
                new SqlParameter("@fxqd", SqlDbType.NVarChar,30),
                new SqlParameter("@ywy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsqy", SqlDbType.NVarChar,30),
                new SqlParameter("@xsks", SqlDbType.NVarChar,30)
            };
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.ENTERTIME;
            parameters[2].Value = model.ENTERWEIGHT;
            parameters[3].Value = model.EXITTIME;
            parameters[4].Value = model.EXITWEIGHT;
            parameters[5].Value = model.HS_FLAG;
            parameters[6].Value = model.GROSS;
            parameters[7].Value = model.TARE;
            parameters[8].Value = model.NET;
            parameters[9].Value = model.EXITFLAG;
            parameters[10].Value = model.DBNUM;
            parameters[11].Value = model.NOTE;
            parameters[12].Value = model.TIMEFLAG;
            parameters[13].Value = model.WERKS;
            parameters[14].Value = model.OANUM;
            parameters[15].Value = oanum;
            parameters[16].Value = truckNum;
            parameters[17].Value = model.CNUM;
            parameters[18].Value = model.CNAME;
            parameters[19].Value = model.TTYPE;
            parameters[20].Value = model.FXQD;
            parameters[21].Value = model.YWY;
            parameters[22].Value = model.XSQY;
            parameters[23].Value = model.XSKS;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeOutTitle(string truckNum, string oanum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from sdl_FinishedProductsExchangeOutTittle ");
            strSql.Append(" where timeflag='" + timeFlag + "' and trucknum='" + truckNum + "' and oanum='" + oanum + "' ");
            SqlParameter[] parameters = {
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar, 14),
                new SqlParameter("@truckNum", SqlDbType.NVarChar, 20),};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            parameters[2].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsExchangeOutTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sdl_FinishedProductsExchangeOutTittle ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and oanum=@oanum ");
            strSql.Append("and truckNum=@truckNum ");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@oanum", SqlDbType.NVarChar,14),
                new SqlParameter("@truckNum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = oanum;
            parameters[2].Value = truckNum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_FinishedProductsExchangeTitle> GetSdl_FinishedProductsExchangeOutTitleList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsExchangeTitle> list = new List<Sdl_FinishedProductsExchangeTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsExchangeOutTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeOutTitleRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsExchangeTitle model = new Sdl_FinishedProductsExchangeTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.ID = row["ID"].ToString();
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.OANUM = row["OANUM"].ToString();
                model.WERKS = row["WERKS"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.ENTERWEIGHT = row["ENTERWEIGHT"].ToString();
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.EXITWEIGHT = row["EXITWEIGHT"].ToString();
                model.HS_FLAG = row["HS_FLAG"].ToString();
                model.GROSS = Convert.ToDecimal(row["GROSS"].ToString());
                model.TARE = Convert.ToDecimal(row["TARE"].ToString());
                model.NET = Convert.ToDecimal(row["NET"].ToString());
                model.EXITFLAG = int.Parse(row["EXITFLAG"].ToString() == "" ? "0" : row["EXITFLAG"].ToString());
                model.DBNUM = row["DBNUM"].ToString();
                model.NOTE = row["NOTE"].ToString();
                model.CNUM = row["CNUM"].ToString();
                model.CNAME = row["CNAME"].ToString();
                model.TTYPE = row["TTYPE"].ToString();
                model.YWY = row["YWY"].ToString();
                model.XSQY = row["XSQY"].ToString();
                model.XSKS = row["XSKS"].ToString();
                model.FXQD = row["FXQD"].ToString();

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
