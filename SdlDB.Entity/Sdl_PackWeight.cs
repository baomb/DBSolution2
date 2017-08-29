using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_PackWeight
    {
        /// <summary>
        /// 包重
        /// </summary>
        public string WEIGHT
        {
            set
            {
                wEIGHT = value;
            }
            get
            {
                return wEIGHT;
            }
        }
        private string wEIGHT = string.Empty;


        /// <summary>
        /// 包重描述
        /// </summary>
        public string PACKDESC
        {
            set
            {
                pACKDESC = value;
            }
            get
            {
                return pACKDESC;
            }
        }
        private string pACKDESC = string.Empty;


        /// <summary>
        /// 包重顺序
        /// </summary>
        public Int16 ORDERID
        {
            set
            {
                oRDERID = value;
            }
            get
            {
                return oRDERID;
            }
        }
        private Int16 oRDERID = 0;
    }
}