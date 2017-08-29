using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FloatsamNameItemAdapter
    {
        #region Sdl_FloatsamNameItem

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_FloatsamNameItemDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FloatsamNameItemDataSet(where);
        }

        /// <summary>
        /// 是否存在货物编码
        /// </summary>
        public static bool ExistsFloatsamNameItem(string code)
        {
            return DatabaseProvider.GetInstance().ExistsFloatsamNameItem(code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddFloatsamNameItem(sdl_FloatsamNameItem model)
        {
            return DatabaseProvider.GetInstance().AddFloatsamNameItem(model);
        }

        /// <summary>
        /// 根据code获取实体
        /// </summary>
        public static  sdl_FloatsamNameItem Getsdl_FloatsamNameItem(string code)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamNameItem(code);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        public static void Deletesdl_FloatsamNameItem(string ID)
        {
            DatabaseProvider.GetInstance().Deletesdl_FloatsamNameItem(ID);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public static void Updatesdl_FloatsamNameItem(sdl_FloatsamNameItem model)
        {
            DatabaseProvider.GetInstance().Updatesdl_FloatsamNameItem(model);
        }
       
        #endregion Sdl_UsersAdapter
    }
}
