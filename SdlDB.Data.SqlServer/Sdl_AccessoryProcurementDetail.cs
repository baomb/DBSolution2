using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SdlDB.Entity;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  Sdl_AccessoryProcurementDetail

        public DataSet GetSdl_AccessoryProcurementDetailSet(string where)
        {
            string sql = "select * from Sdl_AccessoryProcurementDetail " + where;
            return SQLServerHelper.Query(sql);
        }

        public double GetSdl_AccessoryProcurementDetailOverNum(string where)
        {
            string sql = "select sum(SENGE) as SENGE from Sdl_AccessoryProcurementDetail " + where;
            DataSet ds = SQLServerHelper.Query(sql);
            if (ds != null && ds.Tables[0] != null)
            {
                string num = ds.Tables[0].Rows[0][0].ToString();

                if (num == "")
                    return 0;

                return double.Parse(num);
            }
            return 0;
        }


        public DataSet GetSdl_AccessoryProcurementDetailSearchSet(string where)
        {
            string sql = "select B.* from  Sdl_AccessoryProcurementDetail B left outer join Sdl_AccessoryProcurementTitle A on B.EBELN=A.EBELN AND B.timeflag=A.timeFlag " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSdl_AccessoryProcurementDetail(string timeflag, string ebeln, string ebelp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_AccessoryProcurementDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp ");
            SqlParameter[] parameters = {
					new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeflag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_AccessoryProcurementDetail(");
                strSql.Append("MATNR,MAKTX,EBELN,EBELP,MENGE,ZFIMG,REALZFIMG,SENGE,TIMEFLAG,LIFNR,NAME1 )");
                strSql.Append(" values (");
                strSql.Append("@matnr,@maktx,@ebeln,@ebelp,@menge,@zfimg,@realzfimg,@senge,@timeflag,@lifnr,@name1)");
                SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp", SqlDbType.NVarChar,20),
                    new SqlParameter("@menge", SqlDbType.Decimal),
                    new SqlParameter("@zfimg", SqlDbType.Int),
					new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.MATNR;
                parameters[1].Value = model.MAKTX;
                parameters[2].Value = model.EBELN;
                parameters[3].Value = model.EBELP;
                parameters[4].Value = model.MENGE;
                parameters[5].Value = model.ZFIMG;
                parameters[6].Value = model.REALZFIMG;
                parameters[7].Value = model.SENGE;
                parameters[8].Value = model.TIMEFLAG;
                parameters[9].Value = model.LIFNR;
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
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AccessoryProcurementDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("realzfimg=@realzfimg,");
            strSql.Append("senge=@senge,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("lifnr=@lifnr,");
            strSql.Append("name1=@name1 ");
            strSql.Append(" where timeflag=@timeflag ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.Decimal),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@zfimg", SqlDbType.Int),
                  	new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.ZFIMG;
            parameters[6].Value = model.REALZFIMG;
            parameters[7].Value = model.SENGE;
            parameters[8].Value = model.TIMEFLAG;
            parameters[9].Value = model.LIFNR;
            parameters[10].Value = model.NAME1;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model, string ebeln, string ebelp, string matnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sdl_AccessoryProcurementDetail set ");
            strSql.Append("matnr=@matnr,");
            strSql.Append("maktx=@maktx,");
            strSql.Append("ebeln=@ebeln,");
            strSql.Append("ebelp=@ebelp,");
            strSql.Append("menge=@menge,");
            strSql.Append("zfimg=@zfimg,");
            strSql.Append("realzfimg=@realzfimg,");
            strSql.Append("senge=@senge,");
            strSql.Append("timeflag=@timeflag,");
            strSql.Append("lifnr=@lifnr,");
            strSql.Append("name1=@name1 ");
            strSql.Append("where timeflag=@timeflag ");
            strSql.Append("and ebeln=@ebeln1 ");
            strSql.Append("and ebelp=@ebelp1 ");
            strSql.Append("and matnr=@matnr1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@matnr", SqlDbType.NVarChar,20),
					new SqlParameter("@maktx", SqlDbType.NVarChar,50),
					new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                    new SqlParameter("@ebelp", SqlDbType.Decimal),
                    new SqlParameter("@menge", SqlDbType.Decimal),
					new SqlParameter("@zfimg", SqlDbType.Int),
                  	new SqlParameter("@realzfimg", SqlDbType.Int),
                    new SqlParameter("@senge", SqlDbType.Decimal),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@lifnr", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebeln1", SqlDbType.NVarChar,50),
                    new SqlParameter("@ebelp1", SqlDbType.NVarChar,50),
                    new SqlParameter("@matnr1", SqlDbType.NVarChar,50),
                    new SqlParameter("@name1", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.MATNR;
            parameters[1].Value = model.MAKTX;
            parameters[2].Value = model.EBELN;
            parameters[3].Value = model.EBELP;
            parameters[4].Value = model.MENGE;
            parameters[5].Value = model.ZFIMG;
            parameters[6].Value = model.REALZFIMG;
            parameters[7].Value = model.SENGE;
            parameters[8].Value = model.TIMEFLAG;
            parameters[9].Value = model.LIFNR;
            parameters[10].Value = ebeln;
            parameters[11].Value = ebelp;
            parameters[12].Value = matnr;
            parameters[13].Value = model.NAME1;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="timeFlag"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AmendSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string columnName, Object value)
        {
            string sequel = "Update [Sdl_AccessoryProcurementDetail] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where timeflag=@timeflag and ebeln=@ebeln";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Value", value), 
                new SqlParameter("@timeflag", timeFlag),
                new SqlParameter("@ebeln", ebeln),};
            object obj = SQLServerHelper.GetSingle(sequel, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AccessoryProcurementDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_AccessoryProcurementDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and matnr=@matnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@ebelp", SqlDbType.NVarChar,10), 
                new SqlParameter("@matnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = matnr;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string ebeln)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,ZFIMG,REALZFIMG,SENGE,TIMEFLAG,LIFNR,NAME1 from Sdl_AccessoryProcurementDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AccessoryProcurementDetailRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MATNR,MAKTX,EBELN,EBELP,MENGE,ZFIMG,REALZFIMG,SENGE,TIMEFLAG,LIFNR,NAME1 from Sdl_AccessoryProcurementDetail ");
            strSql.Append(" where timeflag=@timeflag and ebeln=@ebeln and ebelp=@ebelp and MATNR=@matnr");
            SqlParameter[] parameters = {
				new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                new SqlParameter("@ebeln", SqlDbType.NVarChar,20),
                new SqlParameter("@ebelp", SqlDbType.NVarChar,10), 
                new SqlParameter("@matnr", SqlDbType.NVarChar,20)};
            parameters[0].Value = timeFlag;
            parameters[1].Value = ebeln;
            parameters[2].Value = ebelp;
            parameters[3].Value = matnr;
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetSdl_AccessoryProcurementDetailRow(ds.Tables[0].Rows[0]);
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
        public List<Sdl_AccessoryProcurementDetail> GetSdl_AccessoryProcurementDetailList(System.Data.DataTable table)
        {
            List<Sdl_AccessoryProcurementDetail> list = new List<Sdl_AccessoryProcurementDetail>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetSdl_AccessoryProcurementDetailRow(table.Rows[i]));
            }
            return list;
        }


        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetailRow(System.Data.DataRow row)
        {
            Sdl_AccessoryProcurementDetail model = new Sdl_AccessoryProcurementDetail();
            if (row != null)
            {
                if (row["TIMEFLAG"].ToString() != "")
                {
                    model.TIMEFLAG = row["TIMEFLAG"].ToString();
                }

                model.MATNR = row["MATNR"].ToString();
                model.MAKTX = row["MAKTX"].ToString();
                model.EBELN = row["EBELN"].ToString();
                model.EBELP = row["EBELP"].ToString();
                model.ZFIMG = int.Parse(row["ZFIMG"].ToString());
                model.MENGE = double.Parse(row["MENGE"].ToString());
                model.SENGE = double.Parse(row["SENGE"].ToString());
                model.REALZFIMG = int.Parse(row["REALZFIMG"].ToString());
                model.TIMEFLAG = row["TIMEFLAG"].ToString();
                model.LIFNR = row["LIFNR"].ToString();
                model.NAME1 = row["NAME1"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
