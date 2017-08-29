using System;
using System.Text;
using System.Data;
using SdlDB.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Slps_RawMaterialsReturnDetail

        public DataSet GetSlps_RawMaterialsReturnDetailDataSet(string where)
        {
            string sql = "select * from Slps_RawMaterialsReturnDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSlps_RawMaterialsReturnDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Slps_RawMaterialsReturnDetail ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult ");
            strSql.Append("and sapOrderNo = @sapOrderNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar, 20)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            return SQLServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSlps_RawMaterialsReturnDetail(string lineItemNo, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Slps_RawMaterialsReturnDetail ");
            strSql.Append("where lineItemNo=@lineItemNo");
            strSql.Append("and timeFlag = @timeFlag");
            SqlParameter[] parameters = {
					new SqlParameter("@lineItemNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar, 20)
            };
            parameters[0].Value = lineItemNo;
            parameters[1].Value = timeFlag;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model)
        {
            if (!ExistSlps_RawMaterialsReturnDetail(model.LineItemNo, model.TimeFlag))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Slps_RawMaterialsReturnDetail(");
                strSql.Append("sapOrderNo, lineItemNo,timeFlag, matnr, maktx,");
                strSql.Append(" menge, senge, lgort, bktxt, qrcodeScanResult )");
                strSql.Append(" values (");
                strSql.Append("@sapOrderNo, @lineItemNo, @timeFlag, @matnr, @maktx,");
                strSql.Append("@menge, @senge, @lgort, @bktxt, @qrcodeScanResult )");
                SqlParameter[] parameters = {
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@menge", SqlDbType.Decimal,13),
                    new SqlParameter("@senge", SqlDbType.Decimal,13),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,255)
                    };
                parameters[0].Value = model.SapOrderNo;
                parameters[1].Value = model.LineItemNo;
                parameters[2].Value = model.TimeFlag;
                parameters[3].Value = model.Matnr;
                parameters[4].Value = model.Maktx;
                parameters[5].Value = model.Menge;
                parameters[6].Value = model.Senge;
                parameters[7].Value = model.Lgort;
                parameters[8].Value = model.Bktxt;
                parameters[9].Value = model.QrcodeScanResult;


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
        public void UpdateSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Slps_RawMaterialsReturnDetail set ");
            strSql.Append("matnr = @matnr,");
            strSql.Append("maktx = @maktx,");
            strSql.Append("menge = @menge, ");
            strSql.Append("senge = @senge, ");
            strSql.Append("lgort = @lgort, ");
            strSql.Append("bktxt = @bktxt ");
            strSql.Append("where lineItemNo=@lineItemNo ");
            strSql.Append("and sapOrderNo=@sapOrderNo ");
            strSql.Append("and timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@menge", SqlDbType.Decimal,13),
                    new SqlParameter("@senge", SqlDbType.Decimal,13),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,255),
					new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = model.Matnr;
            parameters[1].Value = model.Maktx;
            parameters[2].Value = model.Menge;
            parameters[3].Value = model.Senge;
            parameters[4].Value = model.Lgort;
            parameters[5].Value = model.Bktxt;
            parameters[6].Value = model.LineItemNo;
            parameters[7].Value = model.SapOrderNo;
            parameters[8].Value = model.TimeFlag;
            
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSlps_RawMaterialsReturnDetail(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Slps_RawMaterialsReturnDetail ");
            strSql.Append("where timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
					new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Slps_RawMaterialsReturnDetail GetSlps_RawMaterialsReturnDetail(string timeFlag, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Slps_RawMaterialsReturnDetail ");
            strSql.Append("where timeFlag = @timeFlag ");
            strSql.Append("and lineItemNo = @lineItemNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = timeFlag;
            parameters[1].Value = lineItemNo;

            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSlps_RawMaterialsReturnDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Slps_RawMaterialsReturnDetail> GetSlps_RawMaterialsReturnDetailList(DataTable table)
        {
            List<Slps_RawMaterialsReturnDetail> list = new List<Slps_RawMaterialsReturnDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSlps_RawMaterialsReturnDetailRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Slps_RawMaterialsReturnDetail GetSlps_RawMaterialsReturnDetailRow(System.Data.DataRow row)
        {
            Slps_RawMaterialsReturnDetail model = new Slps_RawMaterialsReturnDetail();
            if (row != null)
            {
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.LineItemNo = row["lineItemNo"].ToString();
                model.TimeFlag = row["timeFlag"].ToString();
                model.Matnr = row["matnr"].ToString();
                model.Maktx = row["maktx"].ToString();
                model.Menge = Convert.ToDecimal(row["menge"].ToString());
                model.Senge = Convert.ToDecimal(row["senge"].ToString());
                model.Bktxt = row["bktxt"].ToString();
                model.Lgort = row["lgort"].ToString();
                model.QrcodeScanResult = row["qrcodeScanResult"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  Slps_RawMaterialsReturnDetail
    }
}
