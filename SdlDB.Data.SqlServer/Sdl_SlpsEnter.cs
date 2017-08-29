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
        #region  Sdl_SlpsEnter

        public DataSet GetSdl_SlpsEnterList(string where)
        {
            string sql = "select * from Sdl_SlpsEnter " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSdl_SlpsEnter(string qrcodeScanResult)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_SlpsEnter ");
            strSql.Append(" where qrcodeScanResult=@qrcodeScanResult");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_SlpsEnter(Sdl_SlpsEnter model)
        {
            if (!ExistSdl_SlpsEnter(model.QrcodeScanResult))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_SlpsEnter( ");
                strSql.Append("qrcodeScanResult,sapOrderNo,carNo,orderStatus,orderType,timeFlag) ");
                strSql.Append(" values ( ");
                strSql.Append("@qrcodeScanResult,@sapOrderNo,@carNo,@orderStatus,@orderType,@timeFlag) ");
                SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@carNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@orderStatus", SqlDbType.NVarChar,10),
                    new SqlParameter("@orderType", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)
                };
                parameters[0].Value = model.QrcodeScanResult;
                parameters[1].Value = model.SapOrderNo;
                parameters[2].Value = model.CarNo;
                parameters[3].Value = model.OrderStatus;
                parameters[4].Value = model.OrderType;
                parameters[5].Value = model.TimeFlag;

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
        public void UpdateSdl_SlpsEnter(Sdl_SlpsEnter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_SlpsEnter set ");
            strSql.Append("qrcodeScanResult=@qrcodeScanResult,");
            strSql.Append("sapOrderNo=@sapOrderNo,");
            strSql.Append("carNo=@carNo, ");
            strSql.Append("orderStatus=@orderStatus, ");
            strSql.Append("orderType=@orderType, ");
            strSql.Append("timeFlag=@timeFlag ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@carNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@orderStatus", SqlDbType.NVarChar,10),
                    new SqlParameter("@orderType", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = model.QrcodeScanResult;
            parameters[1].Value = model.SapOrderNo;
            parameters[2].Value = model.CarNo;
            parameters[3].Value = model.OrderStatus;
            parameters[4].Value = model.TimeFlag;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_SlpsEnter(string qrcodeScanResult)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_SlpsEnter ");
            strSql.Append("where qrcodeScanResult = @qrcodeScanResult ");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_SlpsEnter GetSdl_SlpsEnter(string qrcodeScanResult)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sdl_SlpsEnter ");
            strSql.Append("where qrcodeScanResult = @qrcodeScanResult ");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = qrcodeScanResult;

            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_SlpsEnterRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_SlpsEnter> GetSdl_SlpsEnterList(System.Data.DataTable table)
        {
            List<Sdl_SlpsEnter> list = new List<Sdl_SlpsEnter>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_SlpsEnterRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Sdl_SlpsEnter GetSdl_SlpsEnterRow(System.Data.DataRow row)
        {
            Sdl_SlpsEnter model = new Sdl_SlpsEnter();
            if (row != null)
            {
                model.QrcodeScanResult = row["QrcodeScanResult"].ToString();
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.CarNo = row["CarNo"].ToString();
                model.OrderType = row["orderType"].ToString();
                model.OrderStatus = row["orderType"].ToString();
                model.TimeFlag = row["timeFlag"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Sdl_SlpsEnter
    }
}
