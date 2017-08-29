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
        #region  Sdl_RawMaterialsProcurementTitle

        public DataSet GetSdl_RawMaterialsProcurementTitleDataSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialsProcurementTitle " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_RawMaterialsProcurementAndTitleDataSet(string where)
        {
            string sql = "select rmp.MAKTX,rmp.MCOD1,rmpt.* from Sdl_RawMaterialsProcurementTitle rmpt left outer join Sdl_RawMaterialsProcurement rmp ON rmpt.VBELN=rmp.VBELN AND rmpt.TIMEFLAG = rmp.TIMEFLAG " + where + " order by rmpt.TIMEFLAG desc ";
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_RawMaterialsProcurementTitlePageData(string pageNum, int pageSize, string where)
        {
            string sql = "select top 1000000000 * from Sdl_RawMaterialsProcurementTitle " + where + " order by timeflag desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, pageSize, sql));
        }

        public DataSet GetSdl_RawMaterialsProcurementAndTitlePageData(string pageNum, int pageSize, string where)
        {
            string sql = "select DISTINCT top 1000000000 rmp.MAKTX,rmp.MCOD1,rmpt.* from Sdl_RawMaterialsProcurementTitle rmpt left outer join Sdl_RawMaterialsProcurement rmp ON rmpt.VBELN=rmp.VBELN AND rmpt.TIMEFLAG = rmp.TIMEFLAG " + where + " order by rmpt.TIMEFLAG desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, pageSize, sql));
        }

        public DataSet GetSdl_RawMaterialsProcurementTitleSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from Sdl_RawMaterialsProcurementTitle " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialsProcurementTitle ");
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
        public bool AddSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialsProcurementTitle(");
                strSql.Append("TRUCKNUM,VBELN,WEIGHMAN,EXITWEIGHMAN,TARE,TIMEFLAG,ENTERTIME,");
                strSql.Append("EXITTIME,HS_FLAG,GROSS,WERKS,NET,BALANCE,EXITFLAG,ABLAD,WAGON,");
                strSql.Append("DBNUM,CYNUM,TRAYWEIGHT,TRAYQUANTITY,BFIMG,FREIGHT,WAGONNUM,CONTRACT)");
                strSql.Append(" values (@trucknum,@vbeln,@weighman,@exitweighman,@tare,@timeFlag,@entertime,");
                strSql.Append("@exittime,@hs_flag,@gross,@werks,@net,@balance,@exitflag,@ablad,@wagon,@dbnum,");
                strSql.Append("@cynum,@trayweight,@trayquantity,@BFIMG,@FREIGHT,@WAGONNUM,@contract)");
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
                    new SqlParameter("@balance", SqlDbType.Decimal),
                    new SqlParameter("@ablad", SqlDbType.NVarChar,50),
                    new SqlParameter("@exitflag",SqlDbType.Bit),
                    new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                    new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                    new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@cynum", SqlDbType.Decimal),
                    new SqlParameter("@trayweight", SqlDbType.Decimal),
                    new SqlParameter("@trayquantity", SqlDbType.Int),
                    new SqlParameter("@BFIMG", SqlDbType.NVarChar,20),
                    new SqlParameter("@FREIGHT", SqlDbType.NVarChar,20),
                    new SqlParameter("@WAGONNUM", SqlDbType.NVarChar,20),
                    new SqlParameter("@contract", SqlDbType.NVarChar,1)
                    };
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
                parameters[11].Value = model.BALANCE;
                parameters[12].Value = model.ABLAD;
                parameters[13].Value = model.EXITFLAG;
                parameters[14].Value = model.EXITWEIGHMAN;
                parameters[15].Value = model.WAGON;
                parameters[16].Value = model.DBNUM;
                parameters[17].Value = model.CYNUM;
                parameters[18].Value = model.TRAYWEIGHT;
                parameters[19].Value = model.TRAYQUANTITY;
                parameters[20].Value = model.BFIMG;
                parameters[21].Value = model.FREIGHT;
                parameters[22].Value = model.WAGONNUM;
                parameters[23].Value = model.CONTRACT;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model, string vbeln, string truckNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsProcurementTitle set ");
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
            strSql.Append("net=@net,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("wagon=@wagon,");
            strSql.Append("cynum=@cynum,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("trayquantity=@trayquantity,");
            strSql.Append("ablad=@ablad,");
            strSql.Append("bfimg = @bfimg,");
            strSql.Append("freight = @freight,");
            strSql.Append("wagonnum = @wagonnum ");
            strSql.Append("where timeFlag=@timeFlag and trucknum=@trucknum1 and vbeln=@vbeln1 ");
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
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag",SqlDbType.Bit),
                new SqlParameter("@ablad", SqlDbType.NVarChar,50),
                new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@vbeln1", SqlDbType.NVarChar,50),
                new SqlParameter("@truckNum1", SqlDbType.NVarChar,50),
                new SqlParameter("@trayweight", SqlDbType.Decimal),
                new SqlParameter("@trayquantity", SqlDbType.Int),
                new SqlParameter("@cynum", SqlDbType.Decimal),
                new SqlParameter("@bfimg", SqlDbType.NVarChar,20),
                new SqlParameter("@freight", SqlDbType.NVarChar,20),
                new SqlParameter("@wagonnum", SqlDbType.NVarChar,20)
                                        };
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
            parameters[11].Value = model.NET;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.EXITFLAG;
            parameters[14].Value = model.ABLAD;
            parameters[15].Value = model.WAGON;
            parameters[16].Value = model.DBNUM;
            parameters[17].Value = vbeln;
            parameters[18].Value = truckNum;
            parameters[19].Value = model.TRAYWEIGHT;
            parameters[20].Value = model.TRAYQUANTITY;
            parameters[21].Value = model.CYNUM;
            parameters[22].Value = model.BFIMG;
            parameters[23].Value = model.FREIGHT;
            parameters[24].Value = model.WAGONNUM;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsProcurementTitleByTimeFlag(Sdl_RawMaterialsProcurementTitle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsProcurementTitle set ");
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
            strSql.Append("net=@net,");
            strSql.Append("exitweighman=@exitweighman,");
            strSql.Append("exitflag=@exitflag,");
            strSql.Append("wagon=@wagon,");
            strSql.Append("cynum=@cynum,");
            strSql.Append("dbnum=@dbnum,");
            strSql.Append("trayweight=@trayweight,");
            strSql.Append("trayquantity=@trayquantity,");
            strSql.Append("ablad=@ablad,");
            strSql.Append("bfimg = @bfimg,");
            strSql.Append("freight = @freight,");
            strSql.Append("wagonnum = @wagonnum ");
            strSql.Append("where timeFlag=@timeFlag and werks=@werks ");
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
                new SqlParameter("@net", SqlDbType.Decimal),
                new SqlParameter("@exitweighman", SqlDbType.NVarChar,20),
                new SqlParameter("@exitflag",SqlDbType.Bit),
                new SqlParameter("@ablad", SqlDbType.NVarChar,50),
                new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                new SqlParameter("@dbnum", SqlDbType.NVarChar,50),
                new SqlParameter("@trayweight", SqlDbType.Decimal),
                new SqlParameter("@trayquantity", SqlDbType.Int),
                new SqlParameter("@cynum", SqlDbType.Decimal),
                new SqlParameter("@bfimg", SqlDbType.NVarChar,20),
                new SqlParameter("@freight", SqlDbType.NVarChar,20),
                new SqlParameter("@wagonnum", SqlDbType.NVarChar,20)};
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
            parameters[11].Value = model.NET;
            parameters[12].Value = model.EXITWEIGHMAN;
            parameters[13].Value = model.EXITFLAG;
            parameters[14].Value = model.ABLAD;
            parameters[15].Value = model.WAGON;
            parameters[16].Value = model.DBNUM;
            parameters[17].Value = model.TRAYWEIGHT;
            parameters[18].Value = model.TRAYQUANTITY;
            parameters[19].Value = model.CYNUM;
            parameters[20].Value = model.BFIMG;
            parameters[21].Value = model.FREIGHT;
            parameters[22].Value = model.WAGONNUM;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string trucknum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsProcurementTitle ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and trucknum=@trucknum");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@TRUCKNUM", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = trucknum;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsProcurementTitle GetSdl_RawMaterialsProcurementTitle(string truckNum, string vbeln, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sdl_RawMaterialsProcurementTitle ");
            strSql.Append(" where timeflag='" + timeFlag + "' and trucknum='" + truckNum + "' and vbeln='" + vbeln + "' ");
            SqlParameter[] parameters = {
                new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar, 20),
                new SqlParameter("@truckNum", SqlDbType.NVarChar, 20),};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = truckNum;
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsProcurementTitleRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_RawMaterialsProcurementTitle> GetSdl_RawMaterialsProcurementTitleList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialsProcurementTitle> list = new List<Sdl_RawMaterialsProcurementTitle>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialsProcurementTitleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialsProcurementTitle GetSdl_RawMaterialsProcurementTitleRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialsProcurementTitle model = new Sdl_RawMaterialsProcurementTitle();
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
                model.NET = Convert.ToSingle(row["NET"].ToString());
                model.BALANCE = Convert.ToSingle(row["BALANCE"].ToString());
                model.ABLAD = row["ABLAD"].ToString();
                model.EXITFLAG = Convert.ToBoolean(row["EXITFLAG"]);
                model.WAGON = row["WAGON"] == null ? "" : row["WAGON"].ToString();
                model.DBNUM = row["DBNUM"] == null ? "" : row["DBNUM"].ToString();
                if (row["CYNUM"] == null || row["CYNUM"].ToString() == "")
                    model.CYNUM = 0;
                else
                    model.CYNUM = Convert.ToSingle(row["CYNUM"].ToString());
                if (row["TRAYWEIGHT"] == null || row["TRAYWEIGHT"].ToString() == "")
                    model.TRAYWEIGHT = 0;
                else
                    model.TRAYWEIGHT = Convert.ToInt16(row["TRAYWEIGHT"].ToString());
                if (row["TRAYQUANTITY"] == null || row["TRAYQUANTITY"].ToString() == "")
                    model.TRAYQUANTITY = 0;
                else
                    model.TRAYQUANTITY = Convert.ToInt16(row["TRAYQUANTITY"].ToString());
                model.BFIMG = row["BFIMG"].ToString();
                model.FREIGHT = row["FREIGHT"].ToString();
                model.WAGONNUM = row["WAGONNUM"].ToString();
                model.CONTRACT = row["CONTRACT"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_RawMaterialsProcurementTitle
    }
}
