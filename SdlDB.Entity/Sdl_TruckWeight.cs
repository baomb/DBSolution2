using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_TruckWeight
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string TRUCKNUM
        {
            set
            {
                tRUCKNUM = value;
            }
            get
            {
                return tRUCKNUM;
            }
        }
        private string tRUCKNUM = string.Empty;


        /// <summary>
        /// 入厂时间
        /// </summary>
        public SqlDateTime ENTERTIME
        {
            set
            {
                eNTERTIME = value;
            }
            get
            {
                return eNTERTIME;
            }
        }
        private SqlDateTime eNTERTIME = SqlDateTime.MinValue;


        /// <summary>
        /// 时间戳
        /// </summary>
        public string TIMEFLAG
        {
            set
            {
                tIMEFLAG = value;
            }
            get
            {
                return tIMEFLAG;
            }
        }
        private string tIMEFLAG = string.Empty;


        /// <summary>
        /// 皮重
        /// </summary>
        public float TARE
        {
            set
            {
                tARE = value;
            }
            get
            {
                return tARE;
            }
        }
        private float tARE = 0;


        /// <summary>
        /// 工厂
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
    }
}
