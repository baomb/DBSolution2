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
        #region Sdl_TruckWeight

        public DataSet GetSdl_TruckWeightDataSet(string where)
        {
            string sql = "select top 5 tare,timeflag,werks from Sdl_TruckWeight " + where + " order by entertime desc";
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_TruckWeight(Sdl_TruckWeight model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_TruckWeight(");
                strSql.Append("TRUCKNUM,ENTERTIME,TIMEFLAG,TARE,WERKS)");
                strSql.Append(" values (");
                strSql.Append("@TRUCKNUM,@ENTERTIME,@TIMEFLAG,@TARE,@WERKS)");
                SqlParameter[] parameters = {
					new SqlParameter("@TRUCKNUM", SqlDbType.NVarChar,10),
                    new SqlParameter("@ENTERTIME", SqlDbType.DateTime),
                    new SqlParameter("@timeflag", SqlDbType.NVarChar,30),
                    new SqlParameter("@TARE", SqlDbType.Float),
					new SqlParameter("@WERKS", SqlDbType.NVarChar,6)};
                parameters[0].Value = model.TRUCKNUM;
                parameters[1].Value = model.ENTERTIME;
                parameters[2].Value = model.TIMEFLAG;
                parameters[3].Value = model.TARE;
                parameters[4].Value = model.WERKS;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_TruckWeight(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_TruckWeight" + where);
            SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        #endregion
    }
}
