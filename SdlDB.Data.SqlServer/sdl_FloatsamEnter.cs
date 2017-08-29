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
        #region  sdl_FloatsamEnter
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Addsdl_FloatsamEnter(sdl_FloatsamEnter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sdl_FloatsamEnter(");
            strSql.Append("FloatsamID,TruckNum,Werks,Buyer,FloatsamName,Unit,Tare,EnterWeightMan,EnterTime,ExitFlag,EnterDBNum,SortNum,TimeFlag)");
            strSql.Append(" values (@FloatsamID,@TruckNum,@Werks,@Buyer,@FloatsamName,@Unit,@Tare,@EnterWeightMan,@EnterTime,@ExitFlag,@EnterDBNum,@SortNum,@TimeFlag)");
            SqlParameter[] parameters = {
					new SqlParameter("@FloatsamID", SqlDbType.VarChar,50),
					new SqlParameter("@TruckNum", SqlDbType.VarChar,50),
					new SqlParameter("@Werks", SqlDbType.VarChar,50),
					new SqlParameter("@Buyer", SqlDbType.VarChar,50),
                    new SqlParameter("@FloatsamName",SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
                    new SqlParameter("@Tare", SqlDbType.Decimal),
					new SqlParameter("@EnterWeightMan", SqlDbType.VarChar,50),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime),
                    new SqlParameter("@ExitFlag", SqlDbType.Int),
                    new SqlParameter("@EnterDBNum", SqlDbType.VarChar,50),
                    new SqlParameter("@SortNum", SqlDbType.Int),
                    new SqlParameter("@TimeFlag", SqlDbType.VarChar,50)};
            parameters[0].Value = model.FloatsamID;
            parameters[1].Value = model.TruckNum;
            parameters[2].Value = model.Werks;
            parameters[3].Value = model.Buyer;
            parameters[4].Value = model.FloatsamName;
            parameters[5].Value = model.Unit;
            parameters[6].Value = model.Tare;
            parameters[7].Value = model.EnterWeightMan;
            parameters[8].Value = model.EnterTime;
            parameters[9].Value = model.ExitFlag;
            parameters[10].Value = model.EnterDBNum;
            parameters[11].Value = model.SortNum;
            parameters[12].Value = model.TimeFlag;
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

        public DataSet Getsdl_FlotsamDetailSearchSet(string where)
        {
            string sql = "select * from sdl_FlotsamDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        //查询数据量
        public  int Getsdl_FlotsamEnterCount(string where)
        {
            string sql = "select COUNT(*) from sdl_FloatsamEnter " + where;
            DataSet ds= SQLServerHelper.Query(sql);
            if (ds.Tables.Count>0&&ds.Tables[0].Rows.Count > 0 )
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <param name="TimeFlag"></param>
        /// <returns></returns>
        public int GetMaxSortNum(string TimeFlag)
        {
            string sql = "select MAX(SortNum) as MAX from  sdl_FloatsamEnter where TimeFlag='" + TimeFlag + "'";
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        public DataSet Getsdl_FloatsamEnterSetByField(string[] fieldNames, string where)
        {
            string fields = "";
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields += "," + fieldNames[i];
            }
            if (fields.Length > 0)
                fields = fields.Substring(1);
            string sql = "select " + fields + " from sdl_FloatsamEnter " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public sdl_FloatsamEnter Getsdl_FloatsamEnter(string truckNum, string EnterTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 FloatsamID,TruckNum,Werks,Buyer,FloatsamName,Unit,Tare,Gross,Stuff,Net,EnterWeightMan,EnterTime,ExitFlag,EnterDBNum,SortNum,TimeFlag,SaleMan,ExitWeightMan,ExitTime,Remarks,IsEmptyOut,Lgort,Passer from sdl_FloatsamEnter ");
            strSql.Append(" where EnterTime='" + EnterTime + "' and TruckNum='" + truckNum + "' ");
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Getsdl_FloatsamEnterRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private sdl_FloatsamEnter Getsdl_FloatsamEnterRow(System.Data.DataRow row)
        {
            sdl_FloatsamEnter model = new sdl_FloatsamEnter();
            if (row != null)
            {
                model.FloatsamID = row["FloatsamID"].ToString();
                model.TruckNum = row["TruckNum"].ToString();
                model.Werks = row["Werks"].ToString();
                model.Buyer = row["Buyer"].ToString();
                model.FloatsamName = row["FloatsamName"].ToString();
                if (row["Unit"] != DBNull.Value)
                {
                    model.Unit = row["Unit"].ToString();
                }
                model.Tare = Convert.ToSingle(row["Tare"]);
                if (row["Gross"] != DBNull.Value)
                    model.Gross = Convert.ToSingle(row["Gross"]);
                if (row["Stuff"] != DBNull.Value)
                    model.Stuff = Convert.ToSingle(row["Stuff"]);
                if (row["Net"] != DBNull.Value)
                    model.Net = Convert.ToSingle(row["Net"]);
                model.EnterWeightMan = row["EnterWeightMan"].ToString();
                if (row["EnterTime"] != DBNull.Value)
                {
                    model.EnterTime = Convert.ToDateTime(row["EnterTime"]);
                }
                model.ExitFlag = Convert.ToInt32(row["ExitFlag"]);
                model.EnterDBNum = row["EnterDBNum"].ToString();
                model.SortNum = int.Parse(row["SortNum"].ToString() == "" ? "0" : row["SortNum"].ToString());
                model.TimeFlag = row["TimeFlag"].ToString();
                if (row["SaleMan"] != DBNull.Value)
                    model.SaleMan = row["SaleMan"].ToString();
                if (row["ExitWeightMan"] != DBNull.Value)
                    model.ExitWeightMan = row["ExitWeightMan"].ToString();
                if (row["ExitTime"] != DBNull.Value)
                    model.ExitTime = Convert.ToDateTime(row["ExitTime"]);
                if (row["Remarks"] != DBNull.Value)
                    model.Remarks = row["Remarks"].ToString();
                if (row["IsEmptyOut"] != DBNull.Value)
                    model.IsEmptyOut = row["IsEmptyOut"].ToString();
                if (row["Lgort"] != DBNull.Value)
                    model.Lgort = row["Lgort"].ToString();
                if (row["Passer"] != DBNull.Value)
                    model.Passer = row["Passer"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Updatesdl_FloatsamEnter(sdl_FloatsamEnter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sdl_FloatsamEnter set ");
            strSql.Append("FloatsamID=@FloatsamID,");
            strSql.Append("TruckNum=@TruckNum,");
            strSql.Append("Werks=@Werks,");
            strSql.Append("Buyer=@Buyer,");
            strSql.Append("FloatsamName=@FloatsamName,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Tare=@Tare,");
            strSql.Append("EnterWeightMan=@EnterWeightMan,");
            strSql.Append("EnterTime=@EnterTime,");
            strSql.Append("ExitFlag=@ExitFlag,");
            strSql.Append("EnterDBNum=@EnterDBNum,");
            strSql.Append("SortNum=@SortNum,");
            strSql.Append("TimeFlag=@TimeFlag,");
            strSql.Append("Gross=@Gross,");
            strSql.Append("Stuff=@Stuff,");
            strSql.Append("Net=@Net,");
            strSql.Append("ExitTime=@ExitTime,");
            strSql.Append("SaleMan=@SaleMan,");
            strSql.Append("ExitWeightMan=@ExitWeightMan, ");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("IsEmptyOut=@IsEmptyOut,");
            strSql.Append("Lgort=@Lgort,");
            strSql.Append("Passer=@Passer ");
            strSql.Append("where FloatsamID=@FloatsamID ");
            SqlParameter[] parameters = {
		            new SqlParameter("@FloatsamID", SqlDbType.VarChar,50),
					new SqlParameter("@TruckNum", SqlDbType.VarChar,50),
					new SqlParameter("@Werks", SqlDbType.VarChar,50),
					new SqlParameter("@Buyer", SqlDbType.VarChar,50),
                    new SqlParameter("@FloatsamName",SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
                    new SqlParameter("@Tare", SqlDbType.Decimal),
					new SqlParameter("@EnterWeightMan", SqlDbType.VarChar,50),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime),
                    new SqlParameter("@ExitFlag", SqlDbType.Int),
                    new SqlParameter("@EnterDBNum", SqlDbType.VarChar,50),
                    new SqlParameter("@SortNum", SqlDbType.Int),
                    new SqlParameter("@TimeFlag", SqlDbType.VarChar,50),
                    new SqlParameter("@Gross", SqlDbType.Decimal),
                    new SqlParameter("@Stuff", SqlDbType.Decimal),
                    new SqlParameter("@Net", SqlDbType.Decimal),
                    new SqlParameter("@SaleMan", SqlDbType.VarChar,50),
                    new SqlParameter("@ExitWeightMan",SqlDbType.VarChar,50),
                    new SqlParameter("@ExitTime", SqlDbType.DateTime),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,1000),
                    new SqlParameter("@IsEmptyOut", SqlDbType.Char,1),
                    new SqlParameter("@Lgort", SqlDbType.VarChar,100),
                    new SqlParameter("@Passer", SqlDbType.VarChar,50)};
            parameters[0].Value = model.FloatsamID;
            parameters[1].Value = model.TruckNum;
            parameters[2].Value = model.Werks;
            parameters[3].Value = model.Buyer;
            parameters[4].Value = model.FloatsamName;
            parameters[5].Value = model.Unit;
            parameters[6].Value = model.Tare;
            parameters[7].Value = model.EnterWeightMan;
            parameters[8].Value = model.EnterTime;
            parameters[9].Value = model.ExitFlag;
            parameters[10].Value = model.EnterDBNum;
            parameters[11].Value = model.SortNum;
            parameters[12].Value = model.TimeFlag;
            parameters[13].Value = model.Gross;
            parameters[14].Value = model.Stuff;
            parameters[15].Value = model.Net;
            parameters[16].Value = model.SaleMan;
            parameters[17].Value = model.ExitWeightMan;      
            if (model.ExitTime == DateTime.MinValue)
            {
                parameters[18].Value = DBNull.Value;
            }
            else
            {
                parameters[18].Value = model.ExitTime;
            }
            parameters[19].Value = model.Remarks;
            parameters[20].Value = model.IsEmptyOut;
            parameters[21].Value = model.Lgort;
            parameters[22].Value = model.Passer;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 取得该车的最近入厂信息
        /// </summary>
        /// <param name="trucknum"></param>
        /// <returns></returns>
        public int Getsdl_FloatsamEnterExitFlag(string trucknum)
        {
            string sql = "select top 1 ExitFlag  from  sdl_FloatsamEnter where TruckNum='" + trucknum + "' order by EnterTime desc";
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet Getsdl_FloatsamEnterPageData(string pageNum, int PageSize, string where)
        {
            string sql = "select top 1000000000 * from sdl_FloatsamEnter inner join sdl_FloatsamNameItem on FloatsamName=Code " + where + "  order by EnterTime desc ";
            return SQLServerHelper.Query(PageSqlHelper.GetCanPageSql(pageNum, PageSize, sql));
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet Getsdl_FloatsamEnterData(string where)
        {
            string sql = "select FloatsamID,Werks,TruckNum,Name,EnterWeightMan,ExitWeightMan,SaleMan,Tare,Gross,Stuff,Net,EnterTime,ExitTime, CASE IsEmptyOut WHEN '0' THEN '否' ELSE '是' END from sdl_FloatsamEnter inner join sdl_FloatsamNameItem on FloatsamName=Code " + where + "  order by EnterTime desc ";
            return SQLServerHelper.Query(sql);
        }

        #endregion  sdl_FloatsamEnter
    }
}
