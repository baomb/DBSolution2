using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FactoryAdapter
    {
        public static DataSet GetSdl_FactoryDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FactoryDataSet(where);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_Factory(string id)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_Factory(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Factory(Sdl_Factory model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Factory(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Factory(Sdl_Factory model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Factory(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Factory(string werks)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Factory(werks);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Factory GetSdl_Factory(string werks)
        {
            return DatabaseProvider.GetInstance().GetSdl_Factory(werks);
        }

    }
}
