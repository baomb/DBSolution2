using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SdlDB.Entity
{
    /// <summary>
    /// Sdl_AccessoryProcurementTitle 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_AccessoryProcurementTitle
    {
        public Sdl_AccessoryProcurementTitle()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }



        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        public double TARE
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
        private double tARE = 0;


        /// <summary>
        /// 
        /// </summary>
        public double GROSS
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
        private double gROSS = 0;


        /// <summary>
        /// 
        /// </summary>
        public string HSFLAG
        {
            set
            {
                hSFLAG = value;
            }
            get
            {
                return hSFLAG;
            }
        }
        private string hSFLAG = string.Empty;


        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string EBELN
        {
            set
            {
                eBELN = value;
            }
            get
            {
                return eBELN;
            }
        }
        private string eBELN = string.Empty;


        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        public double DEDUCTNUM
        {
            set
            {
                dEDUCTNUM = value;
            }
            get
            {
                return dEDUCTNUM;
            }
        }
        private double dEDUCTNUM = 0;


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
