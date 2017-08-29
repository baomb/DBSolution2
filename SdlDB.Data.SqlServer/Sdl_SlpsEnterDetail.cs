using System;
using System.Text;
using System.Data;
using SdlDB.Entity;
using System.Data.SqlClient;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Sdl_SlpsEnterDetail

        public DataSet GetSdl_SlpsEnterDetailList(string where)
        {
            string sql = "select * from Sdl_SlpsEnterDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSdl_SlpsEnterDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sdl_SlpsEnterDetail ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult");
            strSql.Append("and sapOrderNo = @sapOrderNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,32),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar, 50)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            return SQLServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSdl_SlpsEnterDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_SlpsEnterDetail ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult");
            strSql.Append("and sapOrderNo = @sapOrderNo");
            strSql.Append("and lineItemNo = @lineItemNo");
            SqlParameter[] parameters = {
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,32),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar, 50),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar, 10)
            };
            parameters[0].Value = qrcodeScanResult;
            parameters[1].Value = sapOrderNo;
            parameters[2].Value = lineItemNo;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model)
        {
            if (!ExistSdl_SlpsEnterDetail(model.QrcodeScanResult, model.SapOrderNo, model.LineItemNo))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_SlpsEnterDetail(");
                strSql.Append("lineItemNo,sapOrderNo,qrcodeScanResult,skuCode,skuName,beforeSendTonQuantity,noReceiptQuantity)");
                strSql.Append(" values (");
                strSql.Append("@lineItemNo,@sapOrderNo,@qrcodeScanResult,@skuCode,@skuName,@beforeSendTonQuantity,@noReceiptQuantity);");
                SqlParameter[] parameters = {
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@beforeSendTonQuantity", SqlDbType.Decimal),
                    new SqlParameter("@noReceiptQuantity", SqlDbType.Decimal)
                    };
                parameters[0].Value = model.LineItemNo;
                parameters[1].Value = model.SapOrderNo;
                parameters[2].Value = model.QrcodeScanResult;
                parameters[3].Value = model.SkuCode;
                parameters[4].Value = model.SkuName;
                parameters[5].Value = model.BeforeSendTonQuantity;
                parameters[6].Value = model.NoReceiptQuantity;

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
        public void UpdateSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_SlpsEnterDetail set ");
            strSql.Append("skuCode=@skuCode,");
            strSql.Append("skuName=@skuName,");
            strSql.Append("beforeSendTonQuantity=@beforeSendTonQuantity, ");
            strSql.Append("beforeSendQuantity=@noReceiptQuantity ");
            strSql.Append("where lineItemNo=@lineItemNo ");
            strSql.Append("and sapOrderNo=@sapOrderNo ");
            strSql.Append("and qrcodeScanResult=@qrcodeScanResult ");
            SqlParameter[] parameters = {
                    new SqlParameter("@skuCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@beforeSendTonQuantity", SqlDbType.NVarChar,50),
                    new SqlParameter("@noReceiptQuantity", SqlDbType.NVarChar,50),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SkuCode;
            parameters[1].Value = model.SkuName;
            parameters[2].Value = model.BeforeSendTonQuantity;
            parameters[3].Value = model.NoReceiptQuantity;
            parameters[4].Value = model.LineItemNo;
            parameters[5].Value = model.SapOrderNo;
            parameters[6].Value = model.QrcodeScanResult;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_SlpsEnterDetail(string qrcodeScanResult)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_SlpsEnterDetail ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult ");
            SqlParameter[] parameters = {
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)};
            parameters[0].Value = qrcodeScanResult;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        

        #endregion  Sdl_SlpsEnterDetail
    }
}
