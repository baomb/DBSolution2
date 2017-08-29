using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region Sdl_ProductReturnRailway

        public DataSet GetSdl_ProductReturnRailwaySet(string where)
        {
            string sql = "select * from Sdl_ProductReturnRailway " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_ProductReturnRailwayPageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 10000000000 * from Sdl_ProductReturnRailway  " + where + " order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_ProductReturnRailwaySearchSet(string where)
        {
            string sql = "select B.*,A.KUNNR,A.NAME1 from Sdl_ProductReturnRailway A left outer join Sdl_ProductReturnRailwayDetail B on A.VBELN=B.VBELN AND A.timeflag=B.timeFlag " + where + " order by A.timeflag desc ";

            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_ProductReturnRailwaySetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from Sdl_ProductReturnRailway " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="truckNum"></param>
        /// <param name="timeFlag"></param>
        /// <returns></returns>
        public DataTable GetSdl_ProductReturnRailwayDataTable(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select vbeln from Sdl_ProductReturnRailway ");
            strSql.Append("where timeflag=@timeflag and truckNum=@truckNum");
            SqlParameter[] parameters = 
            { 
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)
            };
            parameters[0].Value = timeFlag;
            parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            DataTable vbeln = ds.Tables[0];
            return vbeln;
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_ProductReturnRailway(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_ProductReturnRailway ");
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
        public int AddSdl_ProductReturnRailway(Sdl_ProductReturnRailway model)
        {
            if (!ExistsSdl_ProductReturnRailway(model.TIMEFLAG, model.VBELN))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_ProductReturnRailway(");
                strSql.Append("TRUCKNUM,VBELN,KUNNR,NAME1,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HSFLAG,GROSS,WERKS,EXITWEIGHMAN,TYPEID,DBNUM)");
                strSql.Append(" values (@trucknum,@vbeln,@kunnr,@name1,@enterweighman,@tare,@timeFlag,@entertime,@exittime,@hsflag,@gross,@werks,@exitweighman,@typeid,@dbnum)");
                SqlParameter[] parameters = {
					new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
					new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
					new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
					new SqlParameter("@name1", SqlDbType.NVarChar,50),
                    new SqlParameter("@enterweighman", SqlDbType.NVarChar,10),
					new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
					new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@typeid", SqlDbType.Int)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.VBELN;
                parameters[2].Value = model.KUNNR;
                parameters[3].Value = model.NAME1;
                parameters[4].Value = model.ENTERWEIGHMAN;
                parameters[5].Value = model.TARE;
                parameters[6].Value = model.TIMEFLAG;
                parameters[7].Value = model.ENTERTIME;
                parameters[8].Value = model.EXITTIME;
                parameters[9].Value = model.HSFLAG;
                parameters[10].Value = model.GROSS;
                parameters[11].Value = model.WERKS;
                parameters[12].Value = model.EXITWEIGHMAN;
                parameters[13].Value = model.DBNUM;
                parameters[14].Value = model.TYPEID;
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
        public void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnRailway set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("kunnr=@kunnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("HSFLAG=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("typeid=@typeid,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeFlag=@timeFlag and vbeln=@vbeln and trucknum=@trucknum ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
				new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@typeid", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.KUNNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.ENTERWEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HSFLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.TYPEID;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model, string vbeln1, string truckNum1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_ProductReturnRailway set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("vbeln=@vbeln,");
            strSql.Append("kunnr=@kunnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("HSFLAG=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("typeid=@typeid,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeFlag=@timeFlag and vbeln=@vbeln1 and trucknum=@trucknum1 ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
				new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@typeid", SqlDbType.Int),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,50),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.VBELN;
            parameters[2].Value = model.KUNNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.ENTERWEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HSFLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.DBNUM;
            parameters[14].Value = model.TYPEID;
            parameters[15].Value = vbeln1;
            parameters[16].Value = truckNum1;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_ProductReturnRailway(string timeFlag, string vbeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_ProductReturnRailway] set ";
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
        public void DeleteSdl_ProductReturnRailway(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnRailway ");
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
        public void DeleteSdl_ProductReturnRailwayByTimeFlag(string timeFlag, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnRailway ");
            strSql.Append(" where timeflag=@timeflag and trucknum=@trucknum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = truckNum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_ProductReturnRailway(string truckNum, string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_ProductReturnRailway ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and vbeln=@vbeln ");
            strSql.Append("and trucknum=@trucknum");
            SqlParameter[] parameters = {
				new SqlParameter("@truckNum", SqlDbType.NVarChar,20),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = truckNum;
            parameters[1].Value = timeFlag;
            parameters[2].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string vbeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_ProductReturnRailway ");
            strSql.Append("where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' and vbeln='" + vbeln + "' ");
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnRailwayRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_ProductReturnRailway ");
            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' ");
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnRailwayRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_ProductReturnRailway ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar, 30) };
            parameters[0].Value = timeFlag;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_ProductReturnRailwayRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_ProductReturnRailway> GetSdl_ProductReturnRailwayList(System.Data.DataTable table)
        {
            List<Sdl_ProductReturnRailway> list = new List<Sdl_ProductReturnRailway>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_ProductReturnRailwayRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_ProductReturnRailway GetSdl_ProductReturnRailwayRow(System.Data.DataRow row)
        {
            Sdl_ProductReturnRailway model = new Sdl_ProductReturnRailway();
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
                model.ENTERWEIGHMAN = row["ENTERWEIGHMAN"].ToString();
                model.TARE = double.Parse(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HSFLAG = row["HSFLAG"].ToString();
                model.GROSS = double.Parse(row["GROSS"].ToString());
                model.WERKS = row["WERKS"].ToString();
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.DBNUM = row["DBNUM"].ToString();
                model.TYPEID = int.Parse(row["TYPEID"].ToString() == "" ? "0" : row["TYPEID"].ToString());
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
