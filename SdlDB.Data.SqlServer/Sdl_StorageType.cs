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
        #region Sdl_StorageType

        public DataSet GetSdl_StorageTypeDataSet(string where)
        {
            string sql = "select TYPEID, TYPENAME, TYPEDESC from sdl_StorageType " + where + " order by TYPEID";
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_StorageType(Sdl_StorageType model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into sdl_StorageType(");
                strSql.Append("TYPEID,TYPENAME,TYPEDESC)");
                strSql.Append(" values (");
                strSql.Append("@typeid,@typename,@typedesc)");
                SqlParameter[] parameters = {
                    new SqlParameter("@typeid", SqlDbType.Int),
                    new SqlParameter("@typename", SqlDbType.NVarChar,20),
                    new SqlParameter("@typedesc", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.TYPEID;
                parameters[1].Value = model.TYPENAME;
                parameters[2].Value = model.TYPEDESC;
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
        public void DeleteSdl_StorageType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sdl_StorageType");
            SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        #endregion Sdl_StorageType
    }
}
