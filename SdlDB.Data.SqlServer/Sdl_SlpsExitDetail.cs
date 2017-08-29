using System;
using System.Text;
using System.Data;
using SdlDB.Entity;
using System.Data.SqlClient;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Sdl_SlpsExitDetail

        public DataSet GetSdl_SlpsExitDetailList(string where)
        {
            string sql = "select * from Sdl_SlpsExitDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_SlpsExitDetail ");
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
        public int AddSdl_SlpsExitDetail(Sdl_SlpsExitDetail model)
        {
            if (!ExistSdl_SlpsExitDetail(model.QrcodeScanResult, model.SapOrderNo, model.LineItemNo))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_SlpsExitDetail(");
                strSql.Append("lineItemNo,sapOrderNo,qrcodeScanResult,skuCode,skuName,beforeSendQuantity,actualTonQuantity,actualQuantity,wareHouse,weight)");
                strSql.Append(" values (");
                strSql.Append("@lineItemNo,@sapOrderNo,@qrcodeScanResult,@skuCode,@skuName,@beforeSendQuantity,@actualTonQuantity,@actualQuantity,@wareHouse,@weight);");
                SqlParameter[] parameters = {
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@beforeSendQuantity", SqlDbType.Decimal),
                    new SqlParameter("@actualTonQuantity", SqlDbType.Decimal),
                    new SqlParameter("@actualQuantity", SqlDbType.Decimal),
                    new SqlParameter("@wareHouse", SqlDbType.NVarChar,10),
                    new SqlParameter("@weight", SqlDbType.NVarChar,10)
                    };
                parameters[0].Value = model.LineItemNo;
                parameters[1].Value = model.SapOrderNo;
                parameters[2].Value = model.QrcodeScanResult;
                parameters[3].Value = model.SkuCode;
                parameters[4].Value = model.SkuName;
                parameters[5].Value = model.BeforeSendQuantity;
                parameters[6].Value = model.ActualTonQuantity;
                parameters[7].Value = model.ActualQuantity;
                parameters[8].Value = model.WareHouse;
                parameters[9].Value = model.Weight;

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
        public void UpdateSdl_SlpsExitDetail(Sdl_SlpsExitDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_SlpsExitDetail set ");
            strSql.Append("skuCode=@skuCode,");
            strSql.Append("skuName=@skuName,");
            strSql.Append("beforeSendQuantity=@beforeSendQuantity, ");
            strSql.Append("actualTonQuantity=@actualTonQuantity, ");
            strSql.Append("actualQuantity=@actualQuantity, ");
            strSql.Append("wareHouse=@wareHouse, ");
            strSql.Append("weight=@weight ");
            strSql.Append("where lineItemNo=@lineItemNo ");
            strSql.Append("and sapOrderNo=@sapOrderNo ");
            strSql.Append("and qrcodeScanResult=@qrcodeScanResult ");
            SqlParameter[] parameters = {
                    new SqlParameter("@skuCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@skuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@beforeSendQuantity", SqlDbType.Decimal),
                    new SqlParameter("@actualTonQuantity", SqlDbType.Decimal),
                    new SqlParameter("@actualQuantity", SqlDbType.Decimal),
                    new SqlParameter("@wareHouse", SqlDbType.NVarChar,50),
                    new SqlParameter("@weight", SqlDbType.NVarChar,50),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SkuCode;
            parameters[1].Value = model.SkuName;
            parameters[2].Value = model.BeforeSendQuantity;
            parameters[3].Value = model.ActualTonQuantity;
            parameters[4].Value = model.ActualQuantity;
            parameters[5].Value = model.WareHouse;
            parameters[6].Value = model.Weight;
            parameters[7].Value = model.LineItemNo;
            parameters[8].Value = model.SapOrderNo;
            parameters[9].Value = model.QrcodeScanResult;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_SlpsExitDetail ");
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
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        

        #endregion  Sdl_SlpsExitDetail
    }
}
