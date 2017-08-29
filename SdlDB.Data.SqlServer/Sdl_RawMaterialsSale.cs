using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region Sdl_RawMaterialsSale

        public DataSet GetSdl_RawMaterialsSaleDataSet(string where)
        {
            string sql = "select * from Sdl_RawMaterialsSale " + where;
            return SQLServerHelper.Query(sql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_RawMaterialsSale(Sdl_RawMaterialsSale model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_RawMaterialsSale(");
                strSql.Append("MATNR,MAKTX,VBELN,SFIMG,REALZFIMG,LGORT,POSNR,TIMEFLAG,PWEIGHT,KUNNR,NAME1)");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@vbeln,@sfimg,@realzfimg,@lgort,@posnr,@timeflag,@pweight,@KUNNR,@NAME1)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@sfimg", SqlDbType.Decimal),
                    new SqlParameter("@realzfimg", SqlDbType.Int,4),
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@pweight", SqlDbType.Decimal),
                    new SqlParameter("@KUNNR", SqlDbType.NVarChar,20),
                    new SqlParameter("@NAME1", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.VBELN;
                parameters[3].Value = model.SFIMG;
                parameters[4].Value = model.REALZFIMG;
                parameters[5].Value = model.LGORT;
                parameters[6].Value = model.POSNR;
                parameters[7].Value = model.TIMEFLAG;
                parameters[8].Value = model.PWEIGHT;
                parameters[9].Value = model.KUNNR;
                parameters[10].Value = model.NAME1;

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
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,SFIMG,REALZFIMG,LGORT,POSNR,TIMEFLAG,PWEIGHT,KUNNR,NAME1 from Sdl_RawMaterialsSale ");
            strSql.Append("where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr");
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
                return GetSdl_RawMaterialsSaleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,VBELN,SFIMG,REALZFIMG,LGORT,POSNR,TIMEFLAG,PWEIGHT,KUNNR,NAME1 from Sdl_RawMaterialsSale ");
            strSql.Append("where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@lgort", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = lgort;
            parameters[3].Value = posnr;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_RawMaterialsSaleRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public bool ExistsSdl_RawMaterialsSale(string timeflag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_RawMaterialsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort", SqlDbType.NVarChar,20),};
            parameters[0].Value = timeflag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsSale set");
            strSql.Append("MATNR=@matnr,MAKTX=@maktx,VBELN=@vbeln,SFIMG=@sfimg,LGORT=@lgort,POSNR=@posnr,TIMEFLAG=@timeflag,REALZFIMG=@realzfimg,PWEIGHT=@pweight,kunnr=@kunnr,name1=@name1");
            strSql.Append("where TIMEFLAG=@timeflag and VBELN=@vbeln and POSNR=@posnr and LGORT=@lgort and BKTXT=@bktxt and NKEY=@nkey");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),                 
                    new SqlParameter("@sfimg", SqlDbType.Decimal),                  
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int,4),
                    new SqlParameter("@pweight", SqlDbType.Decimal),
                    new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50) };
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.SFIMG;
            parameters[4].Value = model.LGORT;
            parameters[5].Value = model.POSNR;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.REALZFIMG;
            parameters[8].Value = model.PWEIGHT;
            parameters[9].Value = model.KUNNR;
            parameters[10].Value = model.NAME1;
            SQLServerHelper.GetSingle(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model, string vbeln, string lgort, string posnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_RawMaterialsSale set ");
            strSql.Append("MATNR=@matnr,MAKTX=@maktx,VBELN=@vbeln,SFIMG=@sfimg,LGORT=@lgort,POSNR=@posnr,TIMEFLAG=@timeflag,REALZFIMG=@realzfimg,PWEIGHT=@pweight,kunnr=@kunnr,name1=@name1 ");
            strSql.Append("where TIMEFLAG=@timeflag and VBELN=@vbeln1 and POSNR=@posnr1 and LGORT=@lgort1");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@vbeln", SqlDbType.NVarChar,50),                 
                    new SqlParameter("@sfimg", SqlDbType.Decimal),                  
					new SqlParameter("@lgort", SqlDbType.NVarChar,10),
                    new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@realzfimg", SqlDbType.Int,4),
                    new SqlParameter("@pweight", SqlDbType.Decimal),
                    new SqlParameter("@kunnr", SqlDbType.NVarChar,20),
                    new SqlParameter("@vbeln1", SqlDbType.NVarChar,20),
                    new SqlParameter("@lgort1", SqlDbType.NVarChar,20),
                    new SqlParameter("@posnr1", SqlDbType.NVarChar,20),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50) };
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.VBELN;
            parameters[3].Value = model.SFIMG;
            parameters[4].Value = model.LGORT;
            parameters[5].Value = model.POSNR;
            parameters[6].Value = model.TIMEFLAG;
            parameters[7].Value = model.REALZFIMG;
            parameters[8].Value = model.PWEIGHT;
            parameters[9].Value = model.KUNNR;
            parameters[10].Value = vbeln;
            parameters[11].Value = lgort;
            parameters[12].Value = posnr;
            parameters[13].Value = model.NAME1;
            SQLServerHelper.GetSingle(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_RawMaterialsSale(string timeFlag, string vbeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsSale ");
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
        public void DeleteSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr, string lgort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_RawMaterialsSale ");
            strSql.Append(" where timeflag=@timeflag and vbeln=@vbeln and posnr=@posnr and lgort=@lgort");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@vbeln", SqlDbType.NVarChar,20),
                new SqlParameter("@posnr", SqlDbType.NVarChar,10),
                new SqlParameter("@lgort", SqlDbType.NVarChar,10)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = vbeln;
            parameters[2].Value = posnr;
            parameters[3].Value = lgort;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Sdl_RawMaterialsSale> GetSdl_RawMaterialsSaleList(System.Data.DataTable table)
        {
            List<Sdl_RawMaterialsSale> list = new List<Sdl_RawMaterialsSale>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_RawMaterialsSaleRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_RawMaterialsSale GetSdl_RawMaterialsSaleRow(System.Data.DataRow row)
        {
            Sdl_RawMaterialsSale model = new Sdl_RawMaterialsSale();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.VBELN = row["VBELN"].ToString();
                model.SFIMG = (row["SFIMG"] == null) ? 0 : Convert.ToSingle(row["SFIMG"].ToString());
                model.REALZFIMG = (row["REALZFIMG"] == null) ? 0 : Convert.ToInt32(row["REALZFIMG"].ToString());
                model.LGORT = row["LGORT"].ToString();
                model.POSNR = row["POSNR"].ToString();
                model.PWEIGHT = (row["PWEIGHT"] == null) ? 0 : Convert.ToDecimal(row["PWEIGHT"].ToString());
                model.KUNNR = row["KUNNR"].ToString();
                model.NAME1 = row["NAME1"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion Sdl_RawMaterialsSale
    }
}
