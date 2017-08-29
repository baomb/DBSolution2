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
        #region Sdl_PackWeight

        public DataSet GetSdl_PackWeightDataSet(string where)
        {
            string sql = "select weight as 包重,packdesc as 说明,orderid as 排序 from Sdl_PackWeight " + where + " order by orderid";
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_PackWeight(Sdl_PackWeight model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_PackWeight(");
                strSql.Append("WEIGHT,PACKDESC,ORDERID)");
                strSql.Append(" values (");
                strSql.Append("@weight,@packdesc,@orderid)");
                SqlParameter[] parameters = {
					new SqlParameter("@weight", SqlDbType.NVarChar,6),
					new SqlParameter("@packdesc", SqlDbType.NVarChar,20),
                    new SqlParameter("@orderid", SqlDbType.TinyInt)};
                parameters[0].Value = model.WEIGHT;
                parameters[1].Value = model.PACKDESC;
                parameters[2].Value = model.ORDERID;
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
        public void DeleteSdl_PackWeight()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_PackWeight");
            SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        #endregion Sdl_PackWeight
    }
}
