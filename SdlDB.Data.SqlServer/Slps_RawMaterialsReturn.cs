using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SdlDB.Entity;
using System.Data.SqlClient;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Slps_RawMaterialsReturn

        public DataSet GetSlps_RawMaterialsReturnDataSet(string where)
        {
            string sql = "select * from Slps_RawMaterialsReturn " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Slps_RawMaterialsReturn ");
            strSql.Append(" where timeFlag = @timeFlag");
            strSql.Append("and carNo = @carNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = timeFlag;
            parameters[1].Value = carNo;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model)
        {
            if (!ExistSlps_RawMaterialsReturn(model.QrcodeScanResult, model.SapOrderNo))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Slps_RawMaterialsReturn( ");
                strSql.Append(" qrcodeScanResult, sapOrderNo, carNo, factory, dbNum, enterWeightMan,");
                strSql.Append(" exitWeightMan, exitTime, tare, gross, net, exitFlag, hs_flag,");
                strSql.Append(" timeFlag, deuctNum, trayWeight, trayQuantity )");
                strSql.Append(" values ( ");
                strSql.Append(" @qrcodeScanResult, @sapOrderNo, @carNo, @factory, @dbNum, @enterWeightMan,");
                strSql.Append(" @exitWeightMan, @exitTime, @tare, @gross, @net, @exitFlag, @hs_flag,");
                strSql.Append(" @timeFlag, @deuctNum, @trayWeight, @trayQuantity )");
                SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,255),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,255),
					new SqlParameter("@carNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@factory", SqlDbType.NVarChar,10),
                    new SqlParameter("@dbNum", SqlDbType.NVarChar,20),
                    new SqlParameter("@enterWeightMan", SqlDbType.NVarChar,10),
                    new SqlParameter("@exitWeightMan", SqlDbType.NVarChar,10),
                    new SqlParameter("@exitTime", SqlDbType.DateTime),
                    new SqlParameter("@tare", SqlDbType.Decimal,13),
                    new SqlParameter("@gross", SqlDbType.Decimal,13),
                    new SqlParameter("@net", SqlDbType.Decimal,13),
                    new SqlParameter("@exitFlag", SqlDbType.NVarChar,2),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,2),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@deuctNum", SqlDbType.NVarChar,20),
                    new SqlParameter("@trayWeight", SqlDbType.NVarChar,20),
                    new SqlParameter("@trayQuantity", SqlDbType.NVarChar,20)

                };
                parameters[0].Value = model.QrcodeScanResult;
                parameters[1].Value = model.SapOrderNo;
                parameters[2].Value = model.CarNo;
                parameters[3].Value = model.Factory;
                parameters[4].Value = model.DbNum;
                parameters[5].Value = model.EnterWeightMan;
                parameters[6].Value = model.ExitWeightMan;
                parameters[7].Value = model.ExitTime;
                parameters[8].Value = model.Tare;
                parameters[9].Value = model.Gross;
                parameters[10].Value = model.Net;
                parameters[11].Value = model.ExitFlag;
                parameters[12].Value = model.Hs_flag;
                parameters[13].Value = model.TimeFlag;
                parameters[14].Value = model.DeuctNum;
                parameters[15].Value = model.TrayWeight;
                parameters[16].Value = model.TrayQuantity;

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
        public void UpdateSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Slps_RawMaterialsReturn set ");
            strSql.Append("factory=@factory, ");
            strSql.Append("dbNum=@dbNum, ");
            strSql.Append("enterWeightMan=@enterWeightMan, ");
            strSql.Append("exitWeightMan=@exitWeightMan, ");
            strSql.Append("exitTime=getdate(), ");
            strSql.Append("tare=@tare, ");
            strSql.Append("gross=@gross, ");
            strSql.Append("net = @net, ");
            strSql.Append("exitFlag=@exitFlag, ");
            strSql.Append("hs_flag=@hs_flag, ");
            strSql.Append("deuctNum=@deuctNum, ");
            strSql.Append("trayWeight=@trayWeight, ");
            strSql.Append("trayQuantity=@trayQuantity ");
            strSql.Append("where timeFlag=@timeFlag ");
            strSql.Append("and carNo=@carNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@factory", SqlDbType.NVarChar,10),
                    new SqlParameter("@dbNum", SqlDbType.NVarChar,20),
                    new SqlParameter("@enterWeightMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@exitWeightMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@exitTime", SqlDbType.DateTime),
                    new SqlParameter("@tare", SqlDbType.Decimal,13),
                    new SqlParameter("@gross", SqlDbType.Decimal,13),
                    new SqlParameter("@net", SqlDbType.Decimal,13),
                    new SqlParameter("@exitFlag", SqlDbType.NVarChar,2),
                    new SqlParameter("@hs_flag", SqlDbType.NVarChar,2),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,20),
                    new SqlParameter("@deuctNum", SqlDbType.NVarChar,20),
                    new SqlParameter("@trayWeight", SqlDbType.NVarChar,20),
                    new SqlParameter("@trayQuantity", SqlDbType.NVarChar,20)
            };
            
            parameters[1].Value = model.Factory;
            parameters[2].Value = model.DbNum;
            parameters[3].Value = model.EnterWeightMan;
            parameters[4].Value = model.ExitWeightMan;
            parameters[5].Value = model.ExitTime;
            parameters[6].Value = model.Tare;
            parameters[7].Value = model.Gross;
            parameters[8].Value = model.Net;
            parameters[9].Value = model.ExitFlag;
            parameters[10].Value = model.Hs_flag;
            parameters[11].Value = model.TimeFlag;
            parameters[12].Value = model.CarNo;
            parameters[13].Value = model.DeuctNum;
            parameters[14].Value = model.TrayWeight;
            parameters[15].Value = model.TrayQuantity;


            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Slps_RawMaterialsReturn ");
            strSql.Append("where timeFlag=@timeFlag ");
            strSql.Append("and carNo=@carNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = timeFlag;
            parameters[2].Value = carNo;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Slps_RawMaterialsReturn GetSlps_RawMaterialsReturn(string timeFlag, string carNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Slps_RawMaterialsReturn ");
            strSql.Append("where timeFlag = @timeFlag ");
            strSql.Append("and carNo = @carNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = timeFlag;
            parameters[1].Value = carNo;

            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSlps_RawMaterialsReturnRow(ds.Tables[0].Rows[0]);
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
        public List<Slps_RawMaterialsReturn> GetSlps_RawMaterialsReturnList(System.Data.DataTable table)
        {
            List<Slps_RawMaterialsReturn> list = new List<Slps_RawMaterialsReturn>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSlps_RawMaterialsReturnRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Slps_RawMaterialsReturn GetSlps_RawMaterialsReturnRow(System.Data.DataRow row)
        {
            Slps_RawMaterialsReturn model = new Slps_RawMaterialsReturn();
            if (row != null)
            {
                model.QrcodeScanResult = row["QrcodeScanResult"].ToString();
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.CarNo = row["CarNo"].ToString();
                model.Factory = row["factory"].ToString();
                model.DbNum = row["dbNum"].ToString();
                model.EnterWeightMan = row["enterWeightMan"].ToString();
                model.ExitWeightMan = row["exitWeightMan"].ToString();
                model.EnterTime = row["enterTime"].ToString();
                model.ExitTime = row["exitTime"].ToString();
                model.Tare = Convert.ToDecimal(row["tare"].ToString());
                model.Gross = Convert.ToDecimal(row["gross"].ToString());
                model.Net = Convert.ToDecimal(row["net"].ToString());
                model.ExitFlag = row["exitFlag"].ToString();
                model.Hs_flag = row["hs_flag"].ToString();
                model.TimeFlag = row["timeFlag"].ToString();
                model.DeuctNum = Convert.ToDecimal(row["deuctNum"].ToString());
                model.TrayWeight = Convert.ToDecimal(row["trayWeight"].ToString());
                model.TrayQuantity = Convert.ToDecimal(row["trayQuantity"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Slps_RawMaterialsReturn
    }
}
