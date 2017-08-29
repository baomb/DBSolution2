using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_LoadometerDiff
    {
        /// <summary>
        /// 地磅编号
        /// </summary>
        public string ID
        {
            set
            {
                iD = value;
            }
            get
            {
                return iD;
            }
        }
        private string iD = string.Empty;


        /// <summary>
        /// 工厂名称
        /// </summary>
        public string WERKS
        {
            set
            {
                wERKS = value;
            }
            get
            {
                return wERKS;
            }
        }
        private string wERKS = string.Empty;


        /// <summary>
        /// 地磅描述
        /// </summary>
        public string DESC
        {
            set
            {
                dESC = value;
            }
            get
            {
                return dESC;
            }
        }
        private string dESC = string.Empty;


        /// <summary>
        /// 地磅误差
        /// </summary>
        public string DIFF
        {
            set
            {
                dIFF = value;
            }
            get
            {
                return dIFF;
            }
        }
        private string dIFF = string.Empty;
    }
}
