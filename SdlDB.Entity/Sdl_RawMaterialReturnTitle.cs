using System;
using System.Data;
using System.Data.SqlTypes;
namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_RawMaterialReturnTitle 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_RawMaterialReturnTitle
    {
        public Sdl_RawMaterialReturnTitle()
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
        public string LIFNR
        {
            set
            {
                lIFNR = value;
            }
            get
            {
                return lIFNR;
            }
        }
        private string lIFNR = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string NAME1
        {
            set
            {
                nAME1 = value;
            }
            get
            {
                return nAME1;
            }
        }
        private string nAME1 = string.Empty;


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
        public string WEIGHMAN
        {
            set
            {
                wEIGHMAN = value;
            }
            get
            {
                return wEIGHMAN;
            }
        }
        private string wEIGHMAN = string.Empty;

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

        /// <summary>
        /// 托盘标重
        /// </summary>
        public Int16 TRAYWEIGHT
        {
            set
            {
                tRAYWEIGHT = value;
            }
            get
            {
                return tRAYWEIGHT;
            }
        }
        private Int16 tRAYWEIGHT = 0;

        /// <summary>
        /// 托盘数量
        /// </summary>
        public Int16 TRAYQUANTITY
        {
            set
            {
                tRAYQUANTITY = value;
            }
            get
            {
                return tRAYQUANTITY;
            }
        }
        private Int16 tRAYQUANTITY = 0;
    }
}