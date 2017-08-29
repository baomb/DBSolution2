using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDB.Entity;
using System.Data;

namespace SdlDB.Data
{
    public class Sdl_SysSettingAdapter
    {
        #region  成员方法

        /// <summary>
        /// 获取配置
        /// </summary>
        public static Sdl_SysSetting LoadSdl_SysSetting()
        {
            return DatabaseProvider.GetInstance().LoadSdl_SysSetting();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static bool SaveSdl_SysSetting(Sdl_SysSetting model)
        {
            return DatabaseProvider.GetInstance().SaveSdl_SysSetting(model);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public static Sdl_SysSetting GetSdl_SysSetting(string model)
        {
            return DatabaseProvider.GetInstance().GetSdl_SysSetting(model);
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSdl_SysSettingDataTable()
        {
            return DatabaseProvider.GetInstance().GetSdl_SysSettingDataTable();
        }

        /// <summary>
        /// 读取托盘配置
        /// </summary>
        /// <returns></returns>
        public static bool GetSdl_Tray(string WERKS)
        {
            return DatabaseProvider.GetInstance().GetSdl_Tray(WERKS);
        }

        /// <summary>
        /// 保存托盘配置
        /// </summary>
        /// <returns></returns>
        public static void SaveSdl_Tray(string WERKS, string TRAYFLAG)
        {
            DatabaseProvider.GetInstance().SaveSdl_Tray(WERKS, TRAYFLAG);
        }

        /// <summary>
        /// 是否存在托盘配置
        /// </summary>
        /// <returns></returns>
        public static bool ExistsSdl_Tray(string WERKS)
        {
           return DatabaseProvider.GetInstance().ExistsSdl_Tray(WERKS);
        }

        /// <summary>
        /// 添加托盘配置
        /// </summary>
        /// <returns></returns>
        public static void AddSdl_Tray(string WERKS, string TRAYFLAG)
        {
            DatabaseProvider.GetInstance().AddSdl_Tray(WERKS, TRAYFLAG);
        }
        #endregion  成员方法
    }
}
