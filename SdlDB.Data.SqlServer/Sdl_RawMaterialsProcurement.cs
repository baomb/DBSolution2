using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region Sdl_RawMaterialsProcurement

        public DataSet GetSdl_RawMaterialsProcurementDataSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialsProcurement " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialsProcurement(");
                strSql.Append("MATNR,MAKTX,VBELN,LFIMG,SFIMG,PSTYP,BKTXT,ZFIMG,DFIMG,LGORT,POSNR,TIMEFLAG,");
                strSql.Append("REALZFIMG,PWEIGHT,LIFNR,MCOD1,WAGON,SGTXT,NKEY,KG,STORAGETYPE)");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@vbeln,@lfimg,@sfimg,@pstyp,@bktxt,@zfimg,@dfimg,@lgort,@posnr,");
                strSql.Append("@timeflag,@realzfimg,@pweight,@lifnr,@mcod1,@wagon,@sgtxt,@nkey,@kg,@storagetype)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@pstyp", SqlDbType.NVarChar,10),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@zfimg", SqlDbType.Int),
                    new SqlParameter("@dfimg", SqlDbType.Int),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@pweight", SqlDbType.Int),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@mcod1", SqlDbType.NVarChar,50),
                    new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,50),
                    new SqlParameter("@nkey", SqlDbType.Int),
                    new SqlParameter("@kg", SqlDbType.NVarChar,2),
                    new SqlParameter("@storagetype", SqlDbType.NVarChar,10)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.VBELN;
                parameters[3].Value = model.LFIMG;
                parameters[4].Value = model.SFIMG;
                parameters[5].Value = model.PSTYP;
                parameters[6].Value = model.BKTXT;
                parameters[7].Value = model.ZFIMG;
                parameters[8].Value = model.DFIMG;
                parameters[9].Value = model.LGORT;
                parameters[10].Value = model.POSNR;
                parameters[11].Value = model.TIMEFLAG;
                parameters[12].Value = model.REALZFIMG;
                parameters[13].Value = model.PWEIGHT;
                parameters[14].Value = model.LIFNR;
                parameters[15].Value = model.MCOD1;
                parameters[16].Value = model.WAGON;
                parameters[17].Value = model.SGTXT;
                parameters[18].Value = model.NKEY;
                parameters[19].Value = model.KG;
                parameters[20].Value = model.STORAGETYPE;
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
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsProcurement set ");
            strSql.Append("MATNR=@matnr,MAKTX=@maktx,VBELN=@vbeln,LFIMG=@lfimg,SFIMG=@sfimg,");
            strSql.Append("PSTYP=@pstyp,BKTXT=@bktxt,ZFIMG=@zfimg,DFIMG=@dfimg,LGORT=@lgort,");
            strSql.Append("POSNR=@posnr,TIMEFLAG=@timeflag,REALZFIMG=@realzfimg,PWEIGHT=@pweight,");
            strSql.Append("LIFNR=@lifnr,MCOD1=@mcod1,WAGON=@wagon,SGTXT=@sgtxt,NKEY=@nkey,KG=@kg, ");
            strSql.Append("STORAGETYPE=@storagetype ");
            strSql.Append("where TIMEFLAG=@timeflag and VBELN=@vbeln and POSNR=@posnr and LGORT=@lgort and BKTXT=@bktxt and NKEY=@nkey");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@pstyp", SqlDbType.NVarChar,10),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@zfimg", SqlDbType.Int),
                    new SqlParameter("@dfimg", SqlDbType.Int),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@pweight", SqlDbType.Int),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@mcod1", SqlDbType.NVarChar,50),
                    new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,50),
                    new SqlParameter("@nkey", SqlDbType.Int),
                    new SqlParameter("@kg", SqlDbType.NVarChar,2),
                    new SqlParameter("@storagetype", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.LFIMG;
            parameters[4].Value = model.SFIMG;
            parameters[5].Value = model.PSTYP;
            parameters[6].Value = model.BKTXT;
            parameters[7].Value = model.ZFIMG;
            parameters[8].Value = model.DFIMG;
            parameters[9].Value = model.LGORT;
            parameters[10].Value = model.POSNR;
            parameters[11].Value = model.TIMEFLAG;
            parameters[12].Value = model.REALZFIMG;
            parameters[13].Value = model.PWEIGHT;
            parameters[14].Value = model.LIFNR;
            parameters[15].Value = model.MCOD1;
            parameters[16].Value = model.WAGON;
            parameters[17].Value = model.SGTXT;
            parameters[18].Value = model.NKEY;
            parameters[19].Value = model.KG;
            parameters[20].Value = model.STORAGETYPE;
            SQLServerHelper.GetSingle(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model, string vbeln, string lgort, string nkey, string bktxt, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsProcurement set ");
            strSql.Append("MATNR=@matnr,MAKTX=@maktx,VBELN=@vbeln,LFIMG=@lfimg,SFIMG=@sfimg,PSTYP=@pstyp,");
            strSql.Append("BKTXT=@bktxt,ZFIMG=@zfimg,DFIMG=@dfimg,LGORT=@lgort,POSNR=@posnr,TIMEFLAG=@timeflag,");
            strSql.Append("REALZFIMG=@realzfimg,PWEIGHT=@pweight,LIFNR=@lifnr,MCOD1=@mcod1,WAGON=@wagon,");
            strSql.Append("SGTXT=@sgtxt,NKEY=@nkey,KG=@kg,STORAGETYPE=@storagetype ");
            strSql.Append("where TIMEFLAG=@timeflag ");
            strSql.Append("and VBELN=@vbeln1 ");
            strSql.Append("and lgort=@lgort1 ");
            strSql.Append("and nkey=@nkey1 ");
            strSql.Append("and bktxt=@bktxt1 ");
            strSql.Append("and posnr=@posnr1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@lfimg", SqlDbType.Decimal),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@pstyp", SqlDbType.NVarChar,10),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@zfimg", SqlDbType.Int),
                    new SqlParameter("@dfimg", SqlDbType.Int),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@pweight", SqlDbType.Int),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@mcod1", SqlDbType.NVarChar,50),
                    new SqlParameter("@wagon", SqlDbType.NVarChar,50),
                    new SqlParameter("@sgtxt", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort1", SqlDbType.NVarChar,50),
                    new SqlParameter("@nkey1", SqlDbType.Int),
                    new SqlParameter("@bktxt1", SqlDbType.NVarChar,50),
                    new SqlParameter("@posnr1", SqlDbType.NVarChar,50),
                    new SqlParameter("@nkey", SqlDbType.Int),
                    new SqlParameter("@kg", SqlDbType.NVarChar,2),
                    new SqlParameter("@storagetype", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.LFIMG;
            parameters[4].Value = model.SFIMG;
            parameters[5].Value = model.PSTYP;
            parameters[6].Value = model.BKTXT;
            parameters[7].Value = model.ZFIMG;
            parameters[8].Value = model.DFIMG;
            parameters[9].Value = model.LGORT;
            parameters[10].Value = model.POSNR;
            parameters[11].Value = model.TIMEFLAG;
            parameters[12].Value = model.REALZFIMG;
            parameters[13].Value = model.PWEIGHT;
            parameters[14].Value = model.LIFNR;
            parameters[15].Value = model.MCOD1;
            parameters[16].Value = model.WAGON;
            parameters[17].Value = model.SGTXT;
            parameters[18].Value = vbeln;
            parameters[19].Value = lgort;
            parameters[20].Value = nkey;
            parameters[21].Value = bktxt;
            parameters[22].Value = posnr;
            parameters[23].Value = model.NKEY;
            parameters[24].Value = model.KG;
            parameters[25].Value = model.STORAGETYPE;
            SQLServerHelper.GetSingle(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <summary>
        public bool ExistsSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort and bktxt=@bktxt and nkey=@nkey");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@nkey", SqlDbType.Int)};
            parameters[0].Value = timeflag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            parameters[4].Value = bktxt;
            parameters[5].Value = nkey;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);

        }


        ///
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,SFIMG,PSTYP,BKTXT,ZFIMG,DFIMG,LGORT,POSNR,REALZFIMG,PWEIGHT,LIFNR,MCOD1,TIMEFLAG,WAGON,SGTXT,NKEY,KG,STORAGETYPE from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsProcurementRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,SFIMG,PSTYP,BKTXT,ZFIMG,DFIMG,LGORT,POSNR,REALZFIMG,PWEIGHT,LIFNR,MCOD1,TIMEFLAG,WAGON,SGTXT,NKEY,KG,STORAGETYPE from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort and bktxt=@bktxt and nkey=@nkey");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                new SqlParameter("@nkey", SqlDbType.Int)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            parameters[4].Value = bktxt;
            parameters[5].Value = nkey;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsProcurementRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        ///
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,LFIMG,SFIMG,PSTYP,BKTXT,ZFIMG,DFIMG,LGORT,POSNR,REALZFIMG,PWEIGHT,LIFNR,MCOD1,TIMEFLAG,WAGON,SGTXT,NKEY,POSNR,KG,STORAGETYPE from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsProcurementRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialsProcurement(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsProcurement ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort and bktxt=@bktxt and nkey=@nkey");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20),
                    new SqlParameter("@bktxt", SqlDbType.NVarChar,30),
                    new SqlParameter("@nkey", SqlDbType.Int)};
            parameters[0].Value = timeflag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            parameters[4].Value = bktxt;
            parameters[5].Value = nkey;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_RawMaterialsProcurement> GetSdl_RawMaterialsProcurementList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialsProcurement> list = new List<Sdl_RawMaterialsProcurement>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialsProcurementRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurementRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialsProcurement model = new Sdl_RawMaterialsProcurement();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.VBELN = row["VBELN"].ToString();
                model.LFIMG = (row["LFIMG"] == null) ? 0 : Convert.ToSingle(row["LFIMG"].ToString());
                model.SFIMG = (row["SFIMG"] == null) ? 0 : Convert.ToSingle(row["SFIMG"].ToString());
                model.PSTYP = row["PSTYP"].ToString();
                model.BKTXT = row["BKTXT"].ToString();
                model.ZFIMG = (row["ZFIMG"] == null) ? 0 : Convert.ToInt32(row["ZFIMG"].ToString());
                model.DFIMG = (row["DFIMG"] == null) ? 0 : Convert.ToInt32(row["DFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.POSNR = row["POSNR"].ToString();
                model.REALZFIMG = (row["REALZFIMG"] == null) ? 0 : Convert.ToInt32(row["REALZFIMG"].ToString());
                model.PWEIGHT = (row["PWEIGHT"] == null) ? 0 : Convert.ToInt32(row["PWEIGHT"].ToString());
                model.LIFNR = row["LIFNR"].ToString();
                model.MCOD1 = row["MCOD1"].ToString();
                model.WAGON = row["WAGON"].ToString();
                model.SGTXT = row["SGTXT"].ToString();
                model.NKEY = int.Parse(row["NKEY"] == null ? "0" : row["NKEY"].ToString());
                model.KG = row["KG"].ToString();
                model.KG = row["STORAGETYPE"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_RawMaterialsProcurement
    }
}
