using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_Delivery_TypeAdapter
    {
        public static DataSet GetSdl_Delivery_TypeDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_Delivery_TypeDataSet(where);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {
            return DatabaseProvider.GetInstance().ExistsSdl_Delivery_Type(bukrs, vkorg, vtweg);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSdl_Delivery_Type(Sdl_Delivery_Type model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Delivery_Type(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Delivery_Type(Sdl_Delivery_Type model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Delivery_Type(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {

            DatabaseProvider.GetInstance().DeleteSdl_Delivery_Type(bukrs, vkorg, vtweg);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Delivery_Type GetSdl_Delivery_Type(string bukrs, string vkorg, string vtweg)
        {

            return DatabaseProvider.GetInstance().GetSdl_Delivery_Type(bukrs, vkorg, vtweg);
        }
    }
}
