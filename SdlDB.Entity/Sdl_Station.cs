using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Station
    {
        /// <summary>
        /// 公司代码
        /// </summary>
        public string BUKRS
        {
            set
            {
                bUKRS = value;
            }
            get
            {
                return bUKRS;
            }
        }
        private string bUKRS = string.Empty;


        /// <summary>
        /// 公司城市
        /// </summary>
        public string CITY
        {
            set
            {
                cITY = value;
            }
            get
            {
                return cITY;
            }
        }
        private string cITY = string.Empty;


        /// <summary>
        /// 站点
        /// </summary>
        public string STATION
        {
            set
            {
                sTATION = value;
            }
            get
            {
                return sTATION;
            }
        }
        private string sTATION = string.Empty;


        /// <summary>
        /// 站点描述
        /// </summary>
        public string STATIONDESC
        {
            set
            {
                sTATIONDESC = value;
            }
            get
            {
                return sTATIONDESC;
            }
        }
        private string sTATIONDESC = string.Empty;
    }
}