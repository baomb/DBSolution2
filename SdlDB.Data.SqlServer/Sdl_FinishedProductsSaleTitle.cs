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
        #region  Sdl_FinishedProductsSaleTitle

        public DataSet GetSdl_FinishedProductsSaleTitleSet(string where)
        {
            string sql = "select * from Sdl_FinishedProductsSaleTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_FinishedProductsSaleTitlePageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 1000000000 *,case HS_FLAG when 'H' then 0 else Gross-tare end as NetValue from Sdl_FinishedProductsSaleTitle " + where + "  order by timeflag desc ";

            //            string sql = @" select top 1000000000 A.*,case A.HS_FLAG when 'H' then 0 else A.Gross-A.tare end as NetValue,
            //                        isnull(SUM(B.REALZFIMG),0) as REALZFIMG,isnull(SUM(B.LFIMG),0) as LFIMG,
            //                        case HS_FLAG when 'H' then 0 else A.Gross-A.tare-isnull(SUM(B.LFIMG),0) end as BValue 
            //                             from Sdl_FinishedProductsSaleTitle A  left outer join Sdl_FinishedProductsSale B on 
            //                             A.TIMEFLAG=B.TIMEFLAG AND A.VBELN=B.VBELN  " + where + @" GROUP BY A.TRUCKNUM,A.VBELN,A.KUNNR,A.NAME1,A.WEIGHMAN,A.TARE,A.TIMEFLAG,
            //                             A.ENTERTIME,A.EXITTIME,A.HS_FLAG,A.GROSS,A.WERKS,A.EXITWEIGHMAN,A.EXITFLAG    order by A.timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_FinishedProductsSaleTitleExcelData(string where)
        {
            string sql = "select top 1000000000 *,case HS_FLAG when 'H' then 0 else Gross-tare end as NetValue from Sdl_FinishedProductsSaleTitle " + where + "  order by timeflag desc ";

            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_FinishedProductsSaleTitleSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from Sdl_FinishedProductsSaleTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_FinishedProductsSaleTitle ");
            strSql.Append(" where timeFlag=@timeFlag and vbeln=@vbeln");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sdl_FinishedProductsSaleTitle(");
            strSql.Append("TRUCKNUM,VBELN,KUNNR,NAME1,WEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,EXITWEIGHMAN,EXITFLAG,DBNUM,NOTE,CONTRACT)");
            strSql.Append(" values (@trucknum,@vbeln,@kunnr,@name1,@weighman,@tare,@timeFlag,@entertime,@exittime,@hs_flag,@gross,@werks,@exitweighman,@exitflag,@dbnum,@note,@contract)");
            SqlParameter[] parameters = {
					new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
					new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
					new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
					new SqlParameter("@name1", SqlDbType.NVarChar,50),
                    new SqlParameter("@weighman", SqlDbType.NVarChar,10),
					new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
					new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@exitflag", SqlDbType.Int),
                    new SqlParameter("@note", SqlDbType.NVarChar,20),
                    new SqlParameter("@contract", SqlDbType.NVarChar,1)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.KUNNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HS_FLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.EXITFLAG;
            parameters[15].Value = model.NOTE;
            parameters[16].Value = model.CONTRACT;
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


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSaleTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("kunnr=@kunnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("werks=@werks, ");
            strSql.Append("trayweight=@trayweight, ");
            strSql.Append("trayquantity=@trayquantity ");
            strSql.Append("where timeFlag=@timeFlag and vbeln=@vbeln and trucknum=@trucknum ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
				new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.KUNNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HS_FLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.TRAYWEIGHT;
            parameters[13].Value = model.TRAYQUANTITY;
            parameters[14].Value = model.EXITWEIGHMAN;
            parameters[15].Value = model.DBNUM;
            parameters[16].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model, string vbeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSaleTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("kunnr=@kunnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("werks=@werks, ");
            strSql.Append("trayweight=@trayweight, ");
            strSql.Append("trayquantity=@trayquantity ");
            strSql.Append("where timeFlag=@timeFlag and vbeln=@vbeln1 and trucknum=@trucknum1 ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
				new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.KUNNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HS_FLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.TRAYWEIGHT;
            parameters[13].Value = model.TRAYQUANTITY;
            parameters[14].Value = model.EXITWEIGHMAN;
            parameters[15].Value = model.DBNUM;
            parameters[16].Value = model.EXITFLAG;
            parameters[17].Value = trucknum;
            parameters[18].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据,空车出厂。
        /// </summary>
        public void UpdateSdl_FinishedProductsSaleTitle_S(Sdl_FinishedProductsSaleTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_FinishedProductsSaleTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("werks=@werks, ");
            strSql.Append("trayweight=@trayweight, ");
            strSql.Append("trayquantity=@trayquantity ");
            strSql.Append("where timeFlag=@timeFlag and entertime=@entertime and trucknum=@trucknum ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.WEIGHMAN;
            parameters[2].Value = model.TARE;
            parameters[3].Value = model.TIMEFLAG;
            parameters[4].Value = model.ENTERTIME;
            parameters[5].Value = model.EXITTIME;
            parameters[6].Value = model.HS_FLAG;
            parameters[7].Value = model.GROSS;
            parameters[8].Value = model.WERKS;
            parameters[9].Value = model.TRAYWEIGHT;
            parameters[10].Value = model.TRAYQUANTITY;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.DBNUM;
            parameters[13].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_FinishedProductsSaleTitle] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where timeFlag=@timeFlag and vbeln=@vbeln";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Value", value), 
                new SqlParameter("@timeFlag", timeFlag), 
                new SqlParameter("@vbeln", vbeln) };
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
        public void DeleteSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsSaleTitle ");
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
        public void DeleteSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_FinishedProductsSaleTitle ");
            strSql.Append(" where truckNum=@trucknum and timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = truckNum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string vbeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,vbeln,KUNNR,NAME1,WEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,EXITWEIGHMAN,EXITFLAG,DBNUM,TRAYWEIGHT,TRAYQUANTITY,NOTE,CONTRACT from Sdl_FinishedProductsSaleTitle ");

            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' and vbeln='" + vbeln + "' ");
            //SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
            //                              new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)};

            //parameters[0].Value = timeFlag;
            //parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsSaleTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,vbeln,KUNNR,NAME1,WEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,EXITWEIGHMAN,EXITFLAG,DBNUM,TRAYWEIGHT,TRAYQUANTITY,NOTE,CONTRACT from Sdl_FinishedProductsSaleTitle ");

            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' ");
            //SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
            //                              new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)};

            //parameters[0].Value = timeFlag;
            //parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsSaleTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,ERDAT,DELIVERY_NUM,KUNNR,NAME1,WEIGHMAN,TARE,ENTERTIME,EXITTIME,HS_FLAG,GROSS,EXITWEIGHMAN,EXITFLAG,DBNUM,TRAYWEIGHT,TRAYQUANTITY,NOTE,CONTRACT from Sdl_FinishedProductsSaleTitle ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar, 30) };
            parameters[0].Value = timeFlag;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_FinishedProductsSaleTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="truckNum"></param>
        /// <param name="timeFlag"></param>
        /// <returns></returns>
        public DataTable GetSdl_FinishedProductsSaleTitleDataTable(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select vbeln from Sdl_FinishedProductsSaleTitle ");
            strSql.Append("where timeflag=@timeflag and truckNum=@truckNum");
            SqlParameter[] parameters = 
            { 
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)
            };
            parameters[0].Value = timeFlag;
            parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            return ds.Tables[0];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_FinishedProductsSaleTitle> GetSdl_FinishedProductsSaleTitleList(System.Data.DataTable table)
        {
            List<Sdl_FinishedProductsSaleTitle> list = new List<Sdl_FinishedProductsSaleTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_FinishedProductsSaleTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitleRow(System.Data.DataRow row)
        {
            Sdl_FinishedProductsSaleTitle model = new Sdl_FinishedProductsSaleTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.VBELN = row["VBELN"].ToString();
                model.KUNNR = row["KUNNR"].ToString();
                model.NAME1 = row["NAME1"].ToString();
                model.WEIGHMAN = row["WEIGHMAN"].ToString();
                model.TARE = double.Parse(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HS_FLAG = row["HS_FLAG"].ToString();
                model.GROSS = double.Parse(row["GROSS"].ToString());
                model.WERKS = row["WERKS"].ToString();
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.DBNUM = row["DBNUM"].ToString();
                model.NOTE = row["NOTE"].ToString();
                model.EXITFLAG = int.Parse(row["EXITFLAG"].ToString() == "" ? "0" : row["EXITFLAG"].ToString());
                if (row["TRAYWEIGHT"] == null || row["TRAYWEIGHT"].ToString() == "")
                    model.TRAYWEIGHT = 0;
                else
                    model.TRAYWEIGHT = Convert.ToInt16(row["TRAYWEIGHT"].ToString());
                if (row["TRAYQUANTITY"] == null || row["TRAYQUANTITY"].ToString() == "")
                    model.TRAYQUANTITY = 0;
                else
                    model.TRAYQUANTITY = Convert.ToInt16(row["TRAYQUANTITY"].ToString());
                model.CONTRACT = row["CONTRACT"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_FinishedProductsSaleTitle
    }
}
