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
        #region Sdl_Station

        public DataSet GetSdl_StationDataSet(string where, string field)
        {
            string sql = "select " + field + " from Sdl_Station " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_Station(Sdl_Station model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_Station(");
                strSql.Append("BUKRS,CITY,STATION,STATIONDESC)");
                strSql.Append(" values (");
                strSql.Append("@bukrs,@city,@station,@stationdesc)");
                SqlParameter[] parameters = {
					new SqlParameter("@bukrs", SqlDbType.NVarChar,10),
                    new SqlParameter("@city", SqlDbType.NVarChar,10),
                    new SqlParameter("@station", SqlDbType.NVarChar,10),
					new SqlParameter("@stationdesc", SqlDbType.NVarChar,20)};
                parameters[0].Value = model.BUKRS;
                parameters[1].Value = model.CITY;
                parameters[2].Value = model.STATION;
                parameters[3].Value = model.STATIONDESC;
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
        public void DeleteSdl_Station()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_Station");
            SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        #endregion Sdl_Station
    }
}
