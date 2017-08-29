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
        #region  Slps_ProductsReturnDetail

        public DataSet GetSlps_ProductsReturnDetailDataSet(string where)
        {
            string sql = "select * from Slps_ProductsReturnDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSlps_ProductsReturnDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Slps_ProductsReturnDetail ");
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
        public bool ExistSlps_ProductsReturnDetail(string lineItemNo, string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Slps_ProductsReturnDetail ");
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
        public int AddSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model)
        {
            if (!ExistSlps_ProductsReturnDetail(model.LineItemNo, model.TimeFlag))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Slps_ProductsReturnDetail(");
                strSql.Append("sapOrderNo, lineItemNo,timeFlag, matnr, maktx,");
                strSql.Append(" lfimg, zfimg, lgort, realZfimg, sfimg, dfimg, qrcodeScanResult )");
                strSql.Append(" values (");
                strSql.Append("@sapOrderNo, @lineItemNo, @timeFlag, @matnr, @maktx,");
                strSql.Append("@lfimg, @zfimg, @lgort, @realZfimg, @sfimg, @dfimg, @qrcodeScanResult )");
                SqlParameter[] parameters = {
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@zfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@realZfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@sfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@dfimg", SqlDbType.Int),
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,255)
                    };
                parameters[0].Value = model.SapOrderNo;
                parameters[1].Value = model.LineItemNo;
                parameters[2].Value = model.TimeFlag;
                parameters[3].Value = model.Matnr;
                parameters[4].Value = model.Maktx;
                parameters[5].Value = model.Lfimg;
                parameters[6].Value = model.Zfimg;
                parameters[7].Value = model.Lgort;
                parameters[8].Value = model.RealZfimg;
                parameters[9].Value = model.Sfimg;
                parameters[10].Value = model.Dfimg;
                parameters[11].Value = model.QrcodeScanResult;


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
        public void UpdateSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Slps_ProductsReturnDetail set ");
            strSql.Append("matnr = @matnr,");
            strSql.Append("maktx = @maktx,");
            strSql.Append("lfimg = @lfimg, ");
            strSql.Append("zfimg = @zfimg, ");
            strSql.Append("lgort = @lgort, ");
            strSql.Append("realZfimg = @realZfimg, ");
            strSql.Append("sfimg = @sfimg, ");
            strSql.Append("dfimg = @dfimg ");
            strSql.Append("where lineItemNo=@lineItemNo ");
            strSql.Append("and sapOrderNo=@sapOrderNo ");
            strSql.Append("and timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@zfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@realZfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@sfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@dfimg", SqlDbType.Int),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,255),
					new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)
            };
            parameters[0].Value = model.Matnr;
            parameters[1].Value = model.Maktx;
            parameters[2].Value = model.Lfimg;
            parameters[3].Value = model.Zfimg;
            parameters[4].Value = model.Lgort;
            parameters[5].Value = model.RealZfimg;
            parameters[6].Value = model.Sfimg;
            parameters[7].Value = model.Dfimg;
            parameters[8].Value = model.LineItemNo;
            parameters[9].Value = model.SapOrderNo;
            parameters[10].Value = model.TimeFlag;
            
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSlps_ProductsReturnDetail(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Slps_ProductsReturnDetail ");
            strSql.Append("where timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
					new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Slps_ProductsReturnDetail GetSlps_ProductsReturnDetail(string timeFlag, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Slps_ProductsReturnDetail ");
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
                return GetSlps_ProductsReturnDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Slps_ProductsReturnDetail> GetSlps_ProductsReturnDetailList(DataTable table)
        {
            List<Slps_ProductsReturnDetail> list = new List<Slps_ProductsReturnDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSlps_ProductsReturnDetailRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Slps_ProductsReturnDetail GetSlps_ProductsReturnDetailRow(System.Data.DataRow row)
        {
            Slps_ProductsReturnDetail model = new Slps_ProductsReturnDetail();
            if (row != null)
            {
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.LineItemNo = row["lineItemNo"].ToString();
                model.TimeFlag = row["timeFlag"].ToString();
                model.Matnr = row["matnr"].ToString();
                model.Maktx = row["maktx"].ToString();
                model.Lfimg = Convert.ToDecimal(row["lfimg"].ToString());
                model.Zfimg = Convert.ToDecimal(row["zfimg"].ToString());
                model.RealZfimg = Convert.ToDecimal(row["realZfimg"].ToString());
                model.Sfimg = Convert.ToDecimal(row["sfimg"].ToString());
                model.Dfimg = Convert.ToInt32(row["dfimg"].ToString());
                model.Lgort = row["lgort"].ToString();
                model.QrcodeScanResult = row["qrcodeScanResult"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  Slps_ProductsReturnDetail
    }
}
