using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_CompanyAdapter
    {
        #region  成员方法

        public static DataSet GetSdl_CompanyDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_CompanyDataSet(where);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_Company(string id)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_Company(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Company(Sdl_Company model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Company(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Company(Sdl_Company model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Company(model);
        }

      
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Company(string bukrs)
        {

            DatabaseProvider.GetInstance().DeleteSdl_Company(bukrs);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Company GetSdl_Company(string bukrs)
        {

            return DatabaseProvider.GetInstance().GetSdl_Company(bukrs);
        }


        #endregion  成员方法
    }
}
