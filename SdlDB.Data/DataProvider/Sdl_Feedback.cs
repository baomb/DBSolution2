using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SdlDB.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class Sdl_FeedbackAdapter
    {
        #region Sdl_FeedbackAdapter

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public static DataSet GetSdl_FeedbackDataSet(string where)
        {
            return DatabaseProvider.GetInstance().GetSdl_FeedbackDataSet(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool AddSdl_Feedback(Sdl_Feedback model)
        {
            return DatabaseProvider.GetInstance().AddSdl_Feedback(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sdl_Feedback GetSdl_Feedback(int id)
        {
            return DatabaseProvider.GetInstance().GetSdl_Feedback(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateSdl_Feedback(Sdl_Feedback model)
        {
            DatabaseProvider.GetInstance().UpdateSdl_Feedback(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteSdl_Feedback(int id)
        {
            DatabaseProvider.GetInstance().DeleteSdl_Feedback(id);
        }

        #endregion
    }
}
