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
        #region  Slps_RawMaterialsProcurementDetail

        public DataSet GetSlps_RawMaterialsProcurementDetailList(string where)
        {
            string sql = "select * from Slps_RawMaterialsProcurementDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public DataSet GetSlps_RawMaterialsProcurementDetailList(string qrcodeScanResult, string sapOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Slps_RawMaterialsProcurementDetail ");
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
        public bool ExistSlps_RawMaterialsProcurementDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Slps_RawMaterialsProcurementDetail ");
            strSql.Append("where qrcodeScanResult=@qrcodeScanResult");
            strSql.Append("and sapOrderNo = @sapOrderNo");
            strSql.Append("and lineItemNo = @lineItemNo");
            SqlParameter[] parameters = {
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@sapOrderNo", SqlDbType.NVarChar, 20),
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
        public int AddSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model)
        {
            if (!ExistSlps_RawMaterialsProcurementDetail(model.QrcodeScanResult, model.SapOrderNo, model.LineItemNo))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Slps_RawMaterialsProcurementDetail(");
                strSql.Append("qrcodeScanResult, sapOrderNo, lineItemNo, matnr, maktx,");
                strSql.Append(" lfimg, sfimg, pweight, pstyp, zfimg, dfimg, lgort, timeFlag, ");
                strSql.Append(" kg, sgtxt, storageType, realZfimg )");
                strSql.Append(" values (");
                strSql.Append("@qrcodeScanResult, @sapOrderNo, @lineItemNo, @matnr, @maktx,");
                strSql.Append("@lfimg, @sfimg, @pweight, @pstyp, @zfimg, @dfimg, @lgort, @timeFlag, ");
                strSql.Append("@kg, @sgtxt, @storageType, @realZfimg )");
                SqlParameter[] parameters = {
                    new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@sfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@pweight", SqlDbType.Decimal,13),
                    new SqlParameter("@pstyp", SqlDbType.NVarChar,10),
                    new SqlParameter("@zfimg", SqlDbType.Int),
                    new SqlParameter("@dfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeFlag", SqlDbType.NVarChar,20),
                    new SqlParameter("@kg", SqlDbType.VarChar,2),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,100),
                    new SqlParameter("@storageType", SqlDbType.NVarChar,10),
                    new SqlParameter("@realZfimg", SqlDbType.Int)
                    };
                parameters[0].Value = model.QrcodeScanResult;
                parameters[1].Value = model.SapOrderNo;
                parameters[2].Value = model.LineItemNo;
                parameters[3].Value = model.Matnr;
                parameters[4].Value = model.Maktx;
                parameters[5].Value = model.Lfimg;
                parameters[6].Value = model.Sfimg;
                parameters[7].Value = model.Pweight;
                parameters[8].Value = model.Pstyp;
                parameters[9].Value = model.Zfimg;
                parameters[10].Value = model.Dfimg;
                parameters[11].Value = model.Lgort;
                parameters[12].Value = model.TimeFlag;
                parameters[13].Value = model.Kg;
                parameters[14].Value = model.Sgtxt;
                parameters[15].Value = model.StorageType;
                parameters[16].Value = model.RealZfimg;

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
        public void UpdateSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Slps_RawMaterialsProcurementDetail set ");
            strSql.Append("matnr = @matnr,");
            strSql.Append("maktx = @maktx,");
            strSql.Append("lfimg = @lfimg, ");
            strSql.Append("sfimg = @sfimg, ");
            strSql.Append("pweight = @pweight, ");
            strSql.Append("pstyp = @pstyp, ");
            strSql.Append("zfimg = @zfimg, ");
            strSql.Append("dfimg = @dfimg, ");
            strSql.Append("lgort = @lgort, ");
            strSql.Append("kg = @kg, ");
            strSql.Append("sgtxt = @sgtxt, ");
            strSql.Append("storageType = @storageType, ");
            strSql.Append("realZfimg = @realZfimg ");
            strSql.Append("where lineItemNo=@lineItemNo ");
            strSql.Append("and sapOrderNo=@sapOrderNo ");
            strSql.Append("and qrcodeScanResult=@qrcodeScanResult ");
            SqlParameter[] parameters = {
                    new SqlParameter("@matnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@sfimg", SqlDbType.Decimal,13),
                    new SqlParameter("@pweight", SqlDbType.Decimal,13),
                    new SqlParameter("@pstyp", SqlDbType.NVarChar,10),
                    new SqlParameter("@zfimg", SqlDbType.Int),
                    new SqlParameter("@dfimg", SqlDbType.Int),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@kg", SqlDbType.VarChar,2),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,100),
                    new SqlParameter("@storageType", SqlDbType.NVarChar,10),
                    new SqlParameter("@lineItemNo", SqlDbType.NVarChar,10),
					new SqlParameter("@sapOrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@qrcodeScanResult", SqlDbType.NVarChar,50),
                    new SqlParameter("@realZfimg", SqlDbType.Int)
            };
            parameters[0].Value = model.Matnr;
            parameters[1].Value = model.Maktx;
            parameters[2].Value = model.Lfimg;
            parameters[3].Value = model.Sfimg;
            parameters[4].Value = model.Pweight;
            parameters[5].Value = model.Pstyp;
            parameters[6].Value = model.Zfimg;
            parameters[7].Value = model.Dfimg;
            parameters[8].Value = model.Lgort;
            parameters[9].Value = model.Kg;
            parameters[10].Value = model.Sgtxt;
            parameters[11].Value = model.StorageType;
            parameters[12].Value = model.LineItemNo;
            parameters[13].Value = model.SapOrderNo;
            parameters[14].Value = model.QrcodeScanResult;
            parameters[15].Value = model.RealZfimg;
            
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSlps_RawMaterialsProcurementDetail(string timeFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Slps_RawMaterialsProcurementDetail ");
            strSql.Append("where timeFlag=@timeFlag ");
            SqlParameter[] parameters = {
					new SqlParameter("@timeFlag", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Slps_RawMaterialsProcurementDetail GetSlps_RawMaterialsProcurementDetail(string timeFlag, string lineItemNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Slps_RawMaterialsProcurementDetail ");
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
                return GetSlps_RawMaterialsProcurementDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Slps_RawMaterialsProcurementDetail> GetSlps_RawMaterialsProcurementDetailList(DataTable table)
        {
            List<Slps_RawMaterialsProcurementDetail> list = new List<Slps_RawMaterialsProcurementDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSlps_RawMaterialsProcurementDetailRow(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 通过DataRow获取一个实例
        private Slps_RawMaterialsProcurementDetail GetSlps_RawMaterialsProcurementDetailRow(System.Data.DataRow row)
        {
            Slps_RawMaterialsProcurementDetail model = new Slps_RawMaterialsProcurementDetail();
            if (row != null)
            {
                model.QrcodeScanResult = row["QrcodeScanResult"].ToString();
                model.SapOrderNo = row["SapOrderNo"].ToString();
                model.LineItemNo = row["lineItemNo"].ToString();
                model.Matnr = row["matnr"].ToString();
                model.Maktx = row["maktx"].ToString();
                model.Lfimg = Convert.ToDecimal(row["lfimg"].ToString());
                model.Sfimg = Convert.ToDecimal(row["sfimg"].ToString());
                model.Pweight = Convert.ToDecimal(row["pweight"].ToString());
                model.Pstyp = row["pstyp"].ToString();
                model.Zfimg = Convert.ToInt32(row["zfimg"].ToString());
                model.RealZfimg = Convert.ToInt32(row["realZfimg"].ToString());
                model.Dfimg = Convert.ToInt32(row["dfimg"].ToString());
                model.Lgort = row["lgort"].ToString();
                model.TimeFlag = row["timeFlag"].ToString();
                model.Kg = row["kg"].ToString();
                model.Sgtxt = row["sgtxt"].ToString();
                model.StorageType = row["storageType"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  Slps_RawMaterialsProcurementDetail
    }
}
