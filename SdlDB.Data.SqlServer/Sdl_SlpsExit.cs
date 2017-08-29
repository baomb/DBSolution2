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
        #region  Sdl_SlpsExit

        public DataSet GetSdl_SlpsExitList(string where)
        {
            string sql = "select * from Sdl_SlpsExit " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_SlpsExit ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult ");
            strSql.Append("and sapOrderNo = @sapOrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_SlpsExit(Sdl_SlpsExit model)
        {
            if (!ExistSdl_SlpsExit(model.QrcodeScanResult, model.SapOrderNo))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_SlpsExit(");
                strSql.Append("sapOrderNo,carNo,qrcodeScanResult,customerName,oaNo,transportType,distributionChannel,salesArea,salesDepartment,salesMan,orderType)");
                strSql.Append(" values (");
                strSql.Append("@sapOrderNo,@carNo,@qrcodeScanResult,@customerName,@oaNo,@transportType,@distributionChannel,@salesArea,@salesDepartment,@salesMan,@orderType);");
                SqlParameter[] parameters = {
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@carNo", SqlDbType.NVarChar,50),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@customerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@oaNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@transportType", SqlDbType.NVarChar,50),
                    new SqlParameter("@distributionChannel", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesArea", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesDepartment", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@orderType", SqlDbType.NVarChar,10)
                };
                parameters[0].Value = model.SapOrderNo;
                parameters[1].Value = model.CarNo;
                parameters[2].Value = model.QrcodeScanResult;
                parameters[3].Value = model.CustomerName;
                parameters[4].Value = model.OaNo;
                parameters[5].Value = model.TransportType;
                parameters[6].Value = model.DistributionChannel;
                parameters[7].Value = model.SalesArea;
                parameters[8].Value = model.SalesDepartment;
                parameters[9].Value = model.SalesMan;
                parameters[10].Value = model.OrderType;

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
        public void UpdateSdl_SlpsExit(Sdl_SlpsExit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_SlpsExit set ");
            strSql.Append("customerName=@customerName,");
            strSql.Append("oaNo=@oaNo,");
            strSql.Append("transportType=@transportType,");
            strSql.Append("distributionChannel=@distributionChannel,");
            strSql.Append("salesArea=@salesArea,");
            strSql.Append("salesDepartment=@salesDepartment,");
            strSql.Append("salesMan=@salesMan,");
            strSql.Append("orderType=@orderType ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult");
            strSql.Append("and sapOrderNo=@sapOrderNo");
            strSql.Append("and carNo=@carNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@customerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@oaNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@transportType", SqlDbType.NVarChar,50),
                    new SqlParameter("@distributionChannel", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesArea", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesDepartment", SqlDbType.NVarChar,50),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,50),
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@carNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@orderType", SqlDbType.NVarChar,10)
            };
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.OaNo;
            parameters[2].Value = model.TransportType;
            parameters[3].Value = model.DistributionChannel;
            parameters[4].Value = model.SalesArea;
            parameters[5].Value = model.SalesDepartment;
            parameters[6].Value = model.SalesMan;
            parameters[7].Value = model.QrcodeScanResult;
            parameters[8].Value = model.SapOrderNo;
            parameters[9].Value = model.CarNo;
            parameters[10].Value = model.OrderType;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_SlpsExit ");
            strSql.Append(" where qrcodeScanResult=@qrcodeScanResult ");
            strSql.Append("and sapOrderNo=@sapOrderNo");
            strSql.Append("and carNo=@carNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            parameters[2].Value = carNo;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_SlpsExit GetSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sdl_SlpsExit ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult ");
            strSql.Append("and sapOrderNo=@sapOrderNo");
            strSql.Append("and carNo=@carNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@carNo", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            parameters[2].Value = carNo;

            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_SlpsExitRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_SlpsExit> GetSdl_SlpsExitList(System.Data.DataTable table)
        {
            List<Sdl_SlpsExit> list = new List<Sdl_SlpsExit>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_SlpsExitRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Sdl_SlpsExit GetSdl_SlpsExitRow(System.Data.DataRow row)
        {
            Sdl_SlpsExit model = new Sdl_SlpsExit();
            if (row != null)
            {
                model.QrcodeScanResult = row["QrcodeScanResult"].ToString();
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.CarNo = row["CarNo"].ToString();
                model.CustomerName = row["CustomerName"].ToString();
                model.OaNo = row["OaNo"].ToString();
                model.TransportType = row["TransportType"].ToString();
                model.DistributionChannel = row["DistributionChannel"].ToString();
                model.SalesArea = row["SalesArea"].ToString();
                model.SalesDepartment = row["SalesDepartment"].ToString();
                model.SalesMan = row["SalesMan"].ToString();
                model.QrcodeScanResult = row["QrcodeScanResult"].ToString();
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.CarNo = row["CarNo"].ToString();
                model.OrderType = row["OrderType"].ToString();
                
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_SlpsExit
    }
}
