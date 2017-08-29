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
        #region Sdl_AllotInTitle


        public DataSet GetSdl_AllotInTitleSet(string where)
        {
            string sql = "select * from Sdl_AllotInTitle " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSdl_AllotInTitlePageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 10000000000 * from Sdl_AllotInTitle " + where + "  order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        public DataSet GetSdl_AllotInTitleSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from Sdl_AllotInTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_AllotInTitle(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AllotInTitle ");
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
        public bool ExistsSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AllotInTitle ");
            strSql.Append(" where timeFlag=@timeFlag and ebeln=@ebeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,20)                                        };
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = trucknum;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_AllotInTitle(Sdl_AllotInTitle model)
        {
            if (!ExistsSdl_AllotInTitle(model.TIMEFLAG, model.EBELN))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_AllotInTitle(");
                strSql.Append("TRUCKNUM,EBELN,TIMEFLAG,ENTERTIME,EXITTIME,HSFLAG,TARE,GROSS,RESWK,");
                strSql.Append("ENTERWEIGHMAN,DEDUCTNUM,EXITWEIGHMAN,EXITFLAG,WERKS,OUTTIMEFLAG,TRAYWEIGHT,TRAYNUM,DBNUM)");
                strSql.Append(" values (@trucknum,@ebeln,@timeflag,@entertime,@exittime,@hsflag,@tare,@gross,@reswk,");
                strSql.Append("@enterweighman,@deductnum,@exitweighman,@exitflag,@werks,@outtimeflag,@trayweight,@traynum,@dbnum)");
                SqlParameter[] parameters = {
                    new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@entertime", SqlDbType.DateTime),
                    new SqlParameter("@exittime", SqlDbType.DateTime),
                    new SqlParameter("@hsflag", SqlDbType.NVarChar),
                    new SqlParameter("@tare", SqlDbType.Decimal),
                    new SqlParameter("@gross", SqlDbType.Decimal),
                    new SqlParameter("@reswk", SqlDbType.NVarChar,10),
                    new SqlParameter("@enterweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@deductnum", SqlDbType.Decimal),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@exitflag", SqlDbType.Int),
                    new SqlParameter("@werks", SqlDbType.NVarChar,10),
                    new SqlParameter("@outtimeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@trayweight", SqlDbType.NVarChar,10),
                    new SqlParameter("@traynum", SqlDbType.NVarChar,10),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,10)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.EBELN;
                parameters[2].Value = model.TIMEFLAG;
                parameters[3].Value = model.ENTERTIME;
                parameters[4].Value = model.EXITTIME;
                parameters[5].Value = model.HSFLAG;
                parameters[6].Value = model.TARE;
                parameters[7].Value = model.GROSS;
                parameters[8].Value = model.RESWK;
                parameters[9].Value = model.ENTERWEIGHMAN;
                parameters[10].Value = model.DEDUCTNUM;
                parameters[11].Value = model.EXITWEIGHMAN;
                parameters[12].Value = model.EXITFLAG;
                parameters[13].Value = model.WERKS;
                parameters[14].Value = model.OUTTIMEFLAG;
                parameters[15].Value = model.TRAYWEIGHT;
                parameters[16].Value = model.TRAYNUM;
                parameters[17].Value = model.DBNUM;
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
        public void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotInTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("werks=@werks,");
            strSql.Append("outtimeflag=@outtimeflag,");
            strSql.Append("reswk=@reswk, ");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("traynum=@traynum ");
            strSql.Append("where timeFlag=@timeFlag and ebeln=@ebeln and trucknum=@trucknum ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@reswk", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@outtimeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@trayweight", SqlDbType.NVarChar,10),
                new SqlParameter("@traynum", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HSFLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.RESWK;
            parameters[10].Value = model.DEDUCTNUM;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.EXITFLAG;
            parameters[13].Value = model.WERKS;
            parameters[14].Value = model.OUTTIMEFLAG;
            parameters[15].Value = model.TRAYWEIGHT;
            parameters[16].Value = model.TRAYNUM;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model, string ebeln, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotInTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("werks=@werks,");
            strSql.Append("outtimeflag=@outtimeflag,");
            strSql.Append("reswk=@reswk, ");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("traynum=@traynum ");
            strSql.Append("where timeFlag=@timeFlag and ebeln=@ebeln1 and trucknum=@trucknum1");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@reswk", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@ebeln1", SqlDbType.NVarChar,20),
                new SqlParameter("@trucknum1", SqlDbType.NVarChar,20),
                new SqlParameter("@outtimeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@trayweight", SqlDbType.NVarChar,10),
                new SqlParameter("@traynum", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HSFLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.RESWK;
            parameters[10].Value = model.DEDUCTNUM;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.EXITFLAG;
            parameters[13].Value = model.WERKS;
            parameters[14].Value = ebeln;
            parameters[15].Value = truckNum;
            parameters[16].Value = model.OUTTIMEFLAG;
            parameters[17].Value = model.TRAYWEIGHT;
            parameters[18].Value = model.TRAYNUM;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AllotInTitleByTimeFlag(Sdl_AllotInTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AllotInTitle set ");
            strSql.Append("trucknum=@trucknum,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("enterweighman=@enterweighman,");
            strSql.Append("tare=@tare,");
            strSql.Append("timeFlag=@timeFlag,");
            strSql.Append("entertime=@entertime,");
            strSql.Append("exittime=@exittime,");
            strSql.Append("hsflag=@hsflag,");
            strSql.Append("gross=@gross,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("deductnum=@deductnum,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("werks=@werks,");
            strSql.Append("outtimeflag=@outtimeflag,");
            strSql.Append("reswk=@reswk, ");
            strSql.Append("trayweight=@trayweight, ");
            strSql.Append("traynum=@traynum ");
            strSql.Append("where timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@enterweighman", SqlDbType.NVarChar,10),
                new SqlParameter("@tare", SqlDbType.Decimal),
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@entertime", SqlDbType.DateTime),
                new SqlParameter("@exittime", SqlDbType.DateTime),
                new SqlParameter("@hsflag", SqlDbType.NVarChar,1),
                new SqlParameter("@gross", SqlDbType.Decimal),
                new SqlParameter("@reswk", SqlDbType.NVarChar,10),
                new SqlParameter("@deductnum", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag", SqlDbType.Int),
                new SqlParameter("@werks", SqlDbType.NVarChar,10),
                new SqlParameter("@outtimeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@trayweight", SqlDbType.NVarChar,10),
                new SqlParameter("@traynum", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.TRUCKNUM;
            parameters[1].Value = model.EBELN;
            parameters[2].Value = model.ENTERWEIGHMAN;
            parameters[3].Value = model.TARE;
            parameters[4].Value = model.TIMEFLAG;
            parameters[5].Value = model.ENTERTIME;
            parameters[6].Value = model.EXITTIME;
            parameters[7].Value = model.HSFLAG;
            parameters[8].Value = model.GROSS;
            parameters[9].Value = model.RESWK;
            parameters[10].Value = model.DEDUCTNUM;
            parameters[11].Value = model.EXITWEIGHMAN;
            parameters[12].Value = model.EXITFLAG;
            parameters[13].Value = model.WERKS;
            parameters[14].Value = model.OUTTIMEFLAG;
            parameters[15].Value = model.TRAYWEIGHT;
            parameters[16].Value = model.TRAYNUM;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_AllotInTitle(string timeFlag, string ebeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_AllotInTitle] set ";
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
        public void DeleteSdl_AllotInTitle(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotInTitle ");
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
        public void DeleteSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AllotInTitle ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@trucknum", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = trucknum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="truckNum"></param>
        /// <param name="timeFlag"></param>
        /// <returns></returns>
        public DataTable GetSdl_AllotInTitleDataTable(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ebeln from Sdl_AllotInTitle ");
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
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string ebeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,EBELN,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HSFLAG,GROSS,RESWK,DEDUCTNUM,EXITWEIGHMAN,EXITFLAG,WERKS,OUTTIMEFLAG,TRAYWEIGHT,TRAYNUM from Sdl_AllotInTitle ");

            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' and ebeln='" + ebeln + "' ");
            //SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
            //                              new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)};

            //parameters[0].Value = timeFlag;
            //parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotInTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,EBELN,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HSFLAG,GROSS,RESWK,DEDUCTNUM,EXITWEIGHMAN,EXITFLAG,WERKS,OUTTIMEFLAG,TRAYWEIGHT,TRAYNUM from Sdl_AllotInTitle ");

            strSql.Append(" where timeflag='" + timeFlag + "' and truckNum='" + truckNum + "' ");
            //SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
            //                              new SqlParameter("@truckNum", SqlDbType.NVarChar, 20)};

            //parameters[0].Value = timeFlag;
            //parameters[1].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotInTitleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AllotInTitle GetSdl_AllotInTitle(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TRUCKNUM,EBELN,ENTERWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,EXITTIME,HSFLAG,GROSS,RESWK,DEDUCTNUM,EXITWEIGHMAN,EXITFLAG,WERKS,OUTTIMEFLAG,TRAYWEIGHT,TRAYNUM from Sdl_AllotInTitle ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = { new SqlParameter("@timeflag", SqlDbType.NVarChar, 30) };
            parameters[0].Value = timeFlag;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AllotInTitleRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_AllotInTitle> GetSdl_AllotInTitleList(System.Data.DataTable table)
        {
            List<Sdl_AllotInTitle> list = new List<Sdl_AllotInTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_AllotInTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_AllotInTitle GetSdl_AllotInTitleRow(System.Data.DataRow row)
        {
            Sdl_AllotInTitle model = new Sdl_AllotInTitle();
            if (row != null)
            {
                if (row["timeflag"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }
                model.TRUCKNUM = row["TRUCKNUM"].ToString();
                model.EBELN = row["EBELN"].ToString();
                model.ENTERWEIGHMAN = row["ENTERWEIGHMAN"].ToString();
                model.TARE = double.Parse(row["TARE"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.ENTERTIME = DateTime.Parse(row["ENTERTIME"].ToString());
                model.EXITTIME = DateTime.Parse(row["EXITTIME"].ToString());
                model.HSFLAG = row["HSFLAG"].ToString();
                model.GROSS = double.Parse(row["GROSS"].ToString());
                model.RESWK = row["RESWK"].ToString();
                if (row["DEDUCTNUM"].ToString() == "")
                    model.DEDUCTNUM = 0;
                else
                    model.DEDUCTNUM = double.Parse(row["DEDUCTNUM"].ToString());
                model.EXITWEIGHMAN = row["EXITWEIGHMAN"].ToString();
                model.EXITFLAG = int.Parse(row["EXITFLAG"].ToString() == "" ? "0" : row["EXITFLAG"].ToString());
                model.WERKS = row["WERKS"].ToString();
                model.OUTTIMEFLAG = row["OUTTIMEFLAG"].ToString();
                model.TRAYWEIGHT = row["TRAYWEIGHT"].ToString();
                model.TRAYNUM = row["TRAYNUM"].ToString();

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
