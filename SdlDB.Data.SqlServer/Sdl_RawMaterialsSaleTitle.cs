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
        #region  Sdl_RawMaterialsSaleTitle

        public DataSet GetSdl_RawMaterialsSaleTitleDataSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialsSaleTitle " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_RawMaterialsSaleTitlePageData(string pageNum, int pageSize, string where)
        {
            string sql = "select top 1000000000 * from Sdl_RawMaterialsSaleTitle " + where + " order by timeflag asc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, pageSize, sql));
        }

        public DataSet GetSdl_RawMaterialsSaleTitleDataSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            fields = fields.TrimStart(',');
            string sql = "select " + fields + " from Sdl_RawMaterialsSaleTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialsSaleTitle ");
            strSql.Append(" where timeFlag=@timeFlag and vbeln=@vbeln and truckNum=@truckNum");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@truckNum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = truckNum;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialsSaleTitle(");
                strSql.Append("TRUCKNUM,VBELN,WEIGHMAN,EXITWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,NET,BALANCE,EXITFLAG,DBNUM)");
                strSql.Append(" values (@trucknum,@vbeln,@weighman,@exitweighman,@tare,@timeFlag,@entertime,@exittime,@hs_flag,@gross,@werks,@net,@balance,@exitflag,@dbnum)");
                SqlParameter[] parameters = {
					new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
					new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@weighman", SqlDbType.NVarChar,50),
					new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
					new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@net", SqlDbType.Decimal),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@exitflag",SqlDbType.Bit),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@balance", SqlDbType.Decimal)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.VBELN;
                parameters[2].Value = model.WEIGHMAN;
                parameters[3].Value = model.TARE;
                parameters[4].Value = model.TIMEFLAG;
                parameters[5].Value = model.ENTERTIME;
                parameters[6].Value = model.EXITTIME;
                parameters[7].Value = model.HS_FLAG;
                parameters[8].Value = model.GROSS;
                parameters[9].Value = model.WERKS;
                parameters[10].Value = model.NET;
                parameters[11].Value = model.EXITWEIGHMAN;
                parameters[12].Value = model.EXITFLAG;
                parameters[13].Value = model.DBNUM;
                parameters[14].Value = model.BALANCE;

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
        public void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsSaleTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("werks=@werks,");
            strSql.Append("balance=@balance,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("net=@net ");
            strSql.Append("where timeFlag=@timeFlag");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@weighman", SqlDbType.NVarChar,50),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@balance", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag",SqlDbType.Bit),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@net", SqlDbType.Decimal)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.WEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HS_FLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.WERKS;
            parameters[10].Value = model.BALANCE;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.EXITFLAG;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.NET;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model, string truckNum, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsSaleTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hs_flag=@hs_flag,");
            strSql.Append("gross=@gross,");
            strSql.Append("werks=@werks,");
            strSql.Append("balance=@balance,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("net=@net ");
            strSql.Append("where timeFlag=@timeFlag ");
            strSql.Append("and truckNum=@truckNum1 ");
            strSql.Append("and vbeln=@vbeln1");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@weighman", SqlDbType.NVarChar,50),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hs_flag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@balance", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag",SqlDbType.Bit),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@truckNum1", SqlDbType.NVarChar,50),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,50),
                new SqlParameter("@net", SqlDbType.Decimal)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.WEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HS_FLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.WERKS;
            parameters[10].Value = model.BALANCE;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.EXITFLAG;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = truckNum;
            parameters[15].Value = vbeln;
            parameters[16].Value = model.NET;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsSaleTitle ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@trucknum", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = trucknum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsSaleTitle GetSdl_RawMaterialsSaleTitle(string truckNum, string vbeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,VBELN,WEIGHMAN,EXITWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HS_FLAG,GROSS,WERKS,NET,BALANCE,EXITFLAG,DBNUM from Sdl_RawMaterialsSaleTitle ");
            strSql.Append(" where timeflag='" + timeFlag + "' and trucknum='" + truckNum + "' and vbeln='" + vbeln + "' ");
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsSaleTitleRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_RawMaterialsSaleTitle> GetSdl_RawMaterialsSaleTitleList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialsSaleTitle> list = new List<Sdl_RawMaterialsSaleTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialsSaleTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialsSaleTitle GetSdl_RawMaterialsSaleTitleRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialsSaleTitle model = new Sdl_RawMaterialsSaleTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.VBELN = row["VBELN"].ToString();
                model.WEIGHMAN = row["WEIGHMAN"].ToString();
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.TARE = Convert.ToSingle(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HS_FLAG = row["HS_FLAG"].ToString();
                model.GROSS = Convert.ToSingle(row["GROSS"].ToString());
                model.WERKS = row["WERKS"].ToString();
                model.NET = float.Parse(row["NET"].ToString());
                model.BALANCE = float.Parse(row["BALANCE"].ToString());
                model.EXITFLAG = Convert.ToBoolean(row["EXITFLAG"]);
                model.DBNUM = row["DBNUM"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_RawMaterialsSaleTitle
    }
}
