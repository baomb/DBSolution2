using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_FinishedProductsPresentationTitle
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
        /// 预留单号
        /// </summary>
        public string RSNUM
        {
            set
            {
                rSNUM = value;
            }
            get
            {
                return rSNUM;
            }
        }
        private string rSNUM = string.Empty;


        /// <summary>
        /// 检斤员
        /// </summary>
        public string ENTERWEIGHMAN
        {
            set
            {
                eNTERWEIGHMAN = value;
            }
            get
            {
                return eNTERWEIGHMAN;
            }
        }
        private string eNTERWEIGHMAN = string.Empty;


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
        /// 扣杂
        /// </summary>
        public float BALANCE
        {
            set
            {
                bALANCE = value;
            }
            get
            {
                return bALANCE;
            }
        }
        private float bALANCE = 0;


        /// <summary>
        /// 进厂时间
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
        /// 出厂时间
        /// </summary>
        public SqlDateTime EXITTIME
        {
            set
            {
                eXITTIME = value;
            }
            get
            {
                return eXITTIME;
            }
        }
        private SqlDateTime eXITTIME = SqlDateTime.MinValue;


        /// <summary>
        /// 毛重
        /// </summary>
        public float GROSS
        {
            set
            {
                gROSS = value;
            }
            get
            {
                return gROSS;
            }
        }
        private float gROSS = 0;


        /// <summary>
        /// 净重
        /// </summary>
        public float NET
        {
            set
            {
                nET = value;
            }
            get
            {
                return nET;
            }
        }
        private float nET = 0;


        /// <summary>
        /// 进出厂标识
        /// </summary>
        public string HS_FLAG
        {
            set
            {
                hS_FLAG = value;
            }
            get
            {
                return hS_FLAG;
            }
        }
        private string hS_FLAG = string.Empty;


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
        /// 检斤员
        /// </summary>
        public string EXITWEIGHMAN
        {
            set
            {
                eXITWEIGHMAN = value;
            }
            get
            {
                return eXITWEIGHMAN;
            }
        }
        private string eXITWEIGHMAN = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int EXITFLAG
        {
            set
            {
                eXITFLAG = value;
            }
            get
            {
                return eXITFLAG;
            }
        }
        private int eXITFLAG = 0;

        /// <summary>
        /// 地磅编号
        /// </summary>
        public string DBNUM
        {
            set
            {
                dBNUM = value;
            }
            get
            {
                return dBNUM;
            }
        }
        private string dBNUM = string.Empty;
    }
}