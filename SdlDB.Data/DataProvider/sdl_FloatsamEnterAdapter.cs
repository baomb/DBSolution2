using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public class sdl_FloatsamEnterAdapter
    {
        #region  成员方法  
   
        public static DataSet Getsdl_FloatsamEnterSetByFeild(string[] feildNames, string where)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamEnterSetByField(feildNames, where);
        }

        public static DataSet Getsdl_FlotsamDetailSearchSet(string where)
        {
            return DatabaseProvider.GetInstance().Getsdl_FlotsamDetailSearchSet(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Addsdl_FloatsamEnter(sdl_FloatsamEnter model)
        {
            return DatabaseProvider.GetInstance().Addsdl_FloatsamEnter(model);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        public static int GetMaxSortNum(string TimeFlag)
        {
            return DatabaseProvider.GetInstance().GetMaxSortNum(TimeFlag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static sdl_FloatsamEnter Getsdl_FloatsamEnter(string truckNum, string timeFlag)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamEnter(truckNum, timeFlag);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void Updatesdl_FloatsamEnter(sdl_FloatsamEnter model)
        {
            DatabaseProvider.GetInstance().Updatesdl_FloatsamEnter(model);
        }
        /// <summary>
        /// 取得该车的入厂信息
        /// </summary>
        /// <param name="trucknum"></param>
        /// <returns></returns>
        public static int Getsdl_FloatsamEnterExitFlag(string trucknum)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamEnterExitFlag(trucknum);
        }

        //查询分页
        public static DataSet Getsdl_FloatsamEnterPageData(string pageNum, int PageSize, string where)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamEnterPageData(pageNum, PageSize, where);
        }

        //查询数据
        public static DataSet Getsdl_FloatsamEnterData(string where)
        {
            return DatabaseProvider.GetInstance().Getsdl_FloatsamEnterData(where);
        }

        //查询数据
        public static int Getsdl_FlotsamEnterCount(string where)
        {
            return DatabaseProvider.GetInstance().Getsdl_FlotsamEnterCount(where);
        }

        #endregion  成员方法
    }
}
