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
        #region Sdl_LoadometerDiff

        public DataSet GetSdl_LoadometerDiffDataSet(string where)
        {
            string sql = "select * from Sdl_LoadometerDiff " + where;
            return SQLServerHelper.Query(sql);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSdl_LoadometerDiff(Sdl_LoadometerDiff model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sdl_LoadometerDiff(");
                strSql.Append("ID,WERKS,DESCRIPTION,DIFF)");
                strSql.Append(" values (");
                strSql.Append("@id,@werks,@desc,@diff)");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,10),
                    new SqlParameter("@werks", SqlDbType.NVarChar,50),
                    new SqlParameter("@desc", SqlDbType.NVarChar,50),
					new SqlParameter("@diff", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.WERKS;
                parameters[2].Value = model.DESC;
                parameters[3].Value = model.DIFF;
                return SQLServerHelper.ExcuteCommand(strSql.ToString(), parameters);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取地磅误差数值
        /// </summary>
        /// <param name="id">地磅编号</param>
        /// <returns>误差数值</returns>
        public double GetSdl_LoadometerDiff(string id)
        {
            string sql = "select diff from Sdl_LoadometerDiff where id ='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID + "'";
            try
            {
                string diff = SQLServerHelper.Query(sql).Tables[0].Rows[0][0].ToString();
                return Convert.ToDouble(diff) / 1000.0;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteSdl_LoadometerDiff()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sdl_LoadometerDiff");
            SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        #endregion Sdl_LoadometerDiff
    }
}
