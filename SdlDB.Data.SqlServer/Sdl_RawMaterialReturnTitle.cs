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
        #region  Sdl_RawMaterialReturnTitle

        public DataSet GetSdl_RawMaterialReturnTitleSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialReturnTitle " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_RawMaterialReturnTitlePageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 10000000000 * from Sdl_RawMaterialReturnTitle " + where + "  order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_RawMaterialReturnTitleSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from Sdl_RawMaterialReturnTitle " + where;
            return SQLServerHelper.Query(sql);
        }
        /// <summary>
        /// 返回所有查询记录到DataSet中
        /// </summary>
        public DataSet GetSdl_RawMaterialReturnTitleSetByField(string where)
        {
            string sql = "select *  from Sdl_RawMaterialReturnTitle " + where;
            return SQLServerHelper.Query(sql);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeFlag=@timeFlag and ebeln=@ebeln");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeFlag=@timeFlag and ebeln=@ebeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,10),
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = trucknum;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model)
        {
            if (!ExistsSdl_RawMaterialReturnTitle(model.TIMEFLAG, model.EBELN))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialReturnTitle(");
                strSql.Append("TRUCKNUM,EBELN,TIMEFLAG,LIFNR,NAME1,ENTERTIME,EXITTIME,HSFLAG,TARE,GROSS,WERKS,WEIGHMAN,DEDUCTNUM,EXITWEIGHMAN,EXITFLAG,DBNUM,TRAYWEIGHT,TRAYQUANTITY)");
                strSql.Append(" values (@trucknum,@ebeln,@timeflag,@lifnr,@name1,@entertime,@exittime,@hsflag,@tare,@gross,@werks,@weighman,@deductnum,@exitweighman,@exitflag,@dbnum,@trayweight,@trayquantity)");
                SqlParameter[] parameters = {
					new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
					new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
					new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50),
					new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
					new SqlParameter("@hsflag", SqlDbType.NVarChar),
                    new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@weighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@deductnum", SqlDbType.Decimal),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@trayweight", SqlDbType.TinyInt),
                    new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                    new SqlParameter("@exitflag", SqlDbType.Int)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.EBELN;
                parameters[2].Value = model.TIMEFLAG;
                parameters[3].Value = model.LIFNR;
                parameters[4].Value = model.NAME1;
                parameters[5].Value = model.ENTERTIME;
                parameters[6].Value = model.EXITTIME;
                parameters[7].Value = model.HSFLAG;
                parameters[8].Value = model.TARE;
                parameters[9].Value = model.GROSS;
                parameters[10].Value = model.WERKS;
                parameters[11].Value = model.WEIGHMAN;
                parameters[12].Value = model.DEDUCTNUM;
                parameters[13].Value = model.EXITWEIGHMAN;
                parameters[14].Value = model.DBNUM;
                parameters[15].Value = model.TRAYWEIGHT;
                parameters[16].Value = model.TRAYQUANTITY;
                parameters[17].Value = model.EXITFLAG;
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
        public void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialReturnTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("lifnr=@lifnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("trayquantity=@trayquantity,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeFlag=@timeFlag and ebeln=@ebeln and trucknum=@trucknum ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
				new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.LIFNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HSFLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.DEDUCTNUM;
            parameters[13].Value = model.EXITWEIGHMAN;
            parameters[14].Value = model.DBNUM;
            parameters[15].Value = model.TRAYWEIGHT;
            parameters[16].Value = model.TRAYQUANTITY;
            parameters[17].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model, string ebeln, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialReturnTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("lifnr=@lifnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("trayquantity=@trayquantity,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeFlag=@timeFlag and ebeln=@ebeln1 and trucknum=@trucknum1 ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
				new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@ebeln1", SqlDbType.NVarChar,50),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,50),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.LIFNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HSFLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.DEDUCTNUM;
            parameters[13].Value = model.EXITWEIGHMAN;
            parameters[14].Value = model.DBNUM;
            parameters[15].Value = ebeln;
            parameters[16].Value = truckNum;
            parameters[17].Value = model.TRAYWEIGHT;
            parameters[18].Value = model.TRAYQUANTITY;
            parameters[19].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialReturnTitleByTimeFlag(Sdl_RawMaterialReturnTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialReturnTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("lifnr=@lifnr,");
            strSql.Append("name1=@name1,");
            strSql.Append("weighman=@weighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("trayquantity=@trayquantity,");
            strSql.Append("werks=@werks ");
            strSql.Append("where timeFlag=@timeFlag and werks=@werks ");
            SqlParameter[] parameters = {
				new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
				new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
				new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
				new SqlParameter("@name1", SqlDbType.NVarChar,50),
                new SqlParameter("@weighman", SqlDbType.NVarChar,10),
				new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
				new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@trayweight", SqlDbType.TinyInt),
                new SqlParameter("@trayquantity", SqlDbType.TinyInt),
                new SqlParameter("@exitflag", SqlDbType.Int)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.LIFNR;
            parameters[3].Value = model.NAME1;
            parameters[4].Value = model.WEIGHMAN;
            parameters[5].Value = model.TARE;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.ENTERTIME;
            parameters[8].Value = model.EXITTIME;
            parameters[9].Value = model.HSFLAG;
            parameters[10].Value = model.GROSS;
            parameters[11].Value = model.WERKS;
            parameters[12].Value = model.DEDUCTNUM;
            parameters[13].Value = model.EXITWEIGHMAN;
            parameters[14].Value = model.DBNUM;
            parameters[15].Value = model.TRAYWEIGHT;
            parameters[16].Value = model.TRAYQUANTITY;
            parameters[17].Value = model.EXITFLAG;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_RawMaterialReturnTitle] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where timeFlag=@timeFlag and ebeln=@ebeln";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Value", value), 
                new SqlParameter("@timeFlag", timeFlag), 
                new SqlParameter("@ebeln", ebeln) };
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
        public void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="ebeln"></param>
        public void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@trucknum", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = trucknum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string ebeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' and ebeln='" + ebeln + "' ");
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialReturnTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_RawMaterialReturnTitle ");

            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' ");
            //SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
            //                              new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)};

            //parameters[0].Value = timeFlag;
            //parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialReturnTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sdl_RawMaterialReturnTitle ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar, 30) };
            parameters[0].Value = timeFlag;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialReturnTitleRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_RawMaterialReturnTitle> GetSdl_RawMaterialReturnTitleList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialReturnTitle> list = new List<Sdl_RawMaterialReturnTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialReturnTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitleRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialReturnTitle model = new Sdl_RawMaterialReturnTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.EBELN = row["EBELN"].ToString();
                model.LIFNR = row["LIFNR"].ToString();
                model.NAME1 = row["NAME1"].ToString();
                model.WEIGHMAN = row["WEIGHMAN"].ToString();
                model.TARE = double.Parse(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HSFLAG = row["HSFLAG"].ToString();
                model.DBNUM = row["DBNUM"].ToString();
                model.GROSS = double.Parse(row["GROSS"].ToString());
                model.WERKS = row["WERKS"].ToString();
                if (row["DEDUCTNUM"].ToString() == "")
                    model.DEDUCTNUM = 0;
                else
                    model.DEDUCTNUM = double.Parse(row["DEDUCTNUM"].ToString());
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.EXITFLAG = int.Parse(row["EXITFLAG"].ToString() == "" ? "0" : row["EXITFLAG"].ToString());
                if (row["TRAYWEIGHT"] == null || row["TRAYWEIGHT"].ToString() == "")
                    model.TRAYWEIGHT = 0;
                else
                    model.TRAYWEIGHT = Convert.ToInt16(row["TRAYWEIGHT"].ToString());
                if (row["TRAYQUANTITY"] == null || row["TRAYQUANTITY"].ToString() == "")
                    model.TRAYQUANTITY = 0;
                else
                    model.TRAYQUANTITY = Convert.ToInt16(row["TRAYQUANTITY"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_RawMaterialReturnTitle
    }
}
