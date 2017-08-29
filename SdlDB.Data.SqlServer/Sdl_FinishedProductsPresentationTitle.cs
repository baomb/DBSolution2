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
        #region  Sdl_FinishedProductsPresentationTitle

        public DataSet GetSdl_FinishedProductsPresentationTitleDataSet(string where)
        {
            string sql = "select * from Sdl_FinishedProductsPresentationTitle " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_FinishedProductsPresentationTitlePageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 10000000000 * from Sdl_FinishedProductsPresentationTitle " + where + "  order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_FinishedProductsPresentationTitleDataSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            fields = fields.TrimStart(',');
            string sql = "select " + fields + " from Sdl_FinishedProductsPresentationTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_FinishedProductsPresentationTitle(string timeFlag, string rsnum, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_FinishedProductsPresentationTitle ");
            strSql.Append("where timeFlag=@timeFlag and rsnum=@rsnum and truckNum=@truckNum");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                    new SqlParameter("@truckNum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = truckNum;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_FinishedProductsPresentationTitle(");
                strSql.Append("TRUCKNUM,RSNUM,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,NET,BALANCE,EXITWEIGHMAN,EXITFLAG,DBNUM)");
                strSql.Append(" values (@trucknum,@rsnum,@enterweighman,@tare,@timeFlag,@entertime,@exittime,@hs_flag,@gross,@werks,@net,@balance,@exitweighman,@exitflag,@dbnum)");
                SqlParameter[] parameters = {
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                    new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                    new SqlParameter("@enterweighman", SqlDbType.NVarChar,50),
                    new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@net", SqlDbType.Decimal),
                    new SqlParameter("@balance", SqlDbType.Decimal),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,50),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@exitflag", SqlDbType.Int)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.RSNUM;
                parameters[2].Value = model.ENTERWEIGHMAN;
                parameters[3].Value = model.TARE;
                parameters[4].Value = model.TIMEFLAG;
                parameters[5].Value = model.ENTERTIME;
                parameters[6].Value = model.EXITTIME;
                parameters[7].Value = model.HS_FLAG;
                parameters[8].Value = model.GROSS;
                parameters[9].Value = model.WERKS;
                parameters[10].Value = model.NET;
                parameters[11].Value = model.BALANCE;
                parameters[12].Value = model.EXITWEIGHMAN;
                parameters[13].Value = model.DBNUM;
                parameters[14].Value = model.EXITFLAG;
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
        public void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsPresentationTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("rsnum=@rsnum,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("werks=@werks,");
            strSql.Append("balance=@balance,");
            strSql.Append("net=@net, ");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("exitweighman=@exitweighman ");
            strSql.Append(" where timeFlag=@timeFlag and rsnum=@rsnum and trucknum=@trucknum ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@balance", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.RSNUM;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HS_FLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.WERKS;
            parameters[10].Value = model.BALANCE;
            parameters[11].Value = model.NET;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsPresentationTitleByTimeFlag(Sdl_FinishedProductsPresentationTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsPresentationTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("rsnum=@rsnum,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("werks=@werks,");
            strSql.Append("balance=@balance,");
            strSql.Append("net=@net, ");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("exitweighman=@exitweighman ");
            strSql.Append(" where timeFlag=@timeFlag and werks=@werks ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@balance", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.RSNUM;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HS_FLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.WERKS;
            parameters[10].Value = model.BALANCE;
            parameters[11].Value = model.NET;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model, string truckNum, string rsnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsPresentationTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("rsnum=@rsnum,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("werks=@werks,");
            strSql.Append("balance=@balance,");
            strSql.Append("net=@net, ");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("exitweighman=@exitweighman ");
            strSql.Append(" where timeFlag=@timeFlag and rsnum=@rsnum1 and trucknum=@trucknum1 ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@balance", SqlDbType.Decimal),
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,50),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@rsnum1", SqlDbType.NVarChar,50),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.RSNUM;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HS_FLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.WERKS;
            parameters[10].Value = model.BALANCE;
            parameters[11].Value = model.NET;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = rsnum;
            parameters[15].Value = truckNum;
            parameters[16].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsPresentationTitle GetSdl_FinishedProductsPresentationTitle(string truckNum, string rsnum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,RSNUM,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,NET,BALANCE,EXITWEIGHMAN,EXITFLAG,DBNUM from Sdl_FinishedProductsPresentationTitle ");
            strSql.Append(" where timeflag='" + timeFlag + "' and trucknum='" + truckNum + "' and rsnum='" + rsnum + "' ");
            SqlParameter[] parameters = {
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar, 20),
                new SqlParameter("@truckNum", SqlDbType.NVarChar, 20),};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsPresentationTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_FinishedProductsPresentationTitle(string timeFlag, string rsnum, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsPresentationTitle ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and rsnum=@rsnum ");
            strSql.Append("and truckNum=@truckNum ");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@rsnum", SqlDbType.NVarChar,20),
                new SqlParameter("@truckNum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = rsnum;
            parameters[2].Value = truckNum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_FinishedProductsPresentationTitle> GetSdl_FinishedProductsPresentationTitleList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsPresentationTitle> list = new List<Sdl_FinishedProductsPresentationTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsPresentationTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsPresentationTitle GetSdl_FinishedProductsPresentationTitleRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsPresentationTitle model = new Sdl_FinishedProductsPresentationTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.RSNUM = row["RSNUM"].ToString();
                model.ENTERWEIGHMAN = row["ENTERWEIGHMAN"].ToString();
                model.TARE = Convert.ToSingle(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HS_FLAG = row["HS_FLAG"].ToString();
                model.GROSS = Convert.ToSingle(row["GROSS"].ToString());
                model.WERKS = row["WERKS"].ToString();
                model.NET = Convert.ToSingle(row["NET"].ToString());
                model.BALANCE = Convert.ToSingle(row["BALANCE"].ToString());
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.DBNUM = row["DBNUM"].ToString();
                model.EXITFLAG = int.Parse(row["EXITFLAG"].ToString() == "" ? "0" : row["EXITFLAG"].ToString());
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
