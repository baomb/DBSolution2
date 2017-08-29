using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_ProductReturnRailway
    {
        public Sdl_ProductReturnRailway()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

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
        public string VBELN
        {
            set
            {
                vBELN = value;
            }
            get
            {
                return vBELN;
            }
        }
        private string vBELN = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string KUNNR
        {
            set
            {
                kUNNR = value;
            }
            get
            {
                return kUNNR;
            }
        }
        private string kUNNR = string.Empty;


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
        public int TYPEID
        {
            set
            {
                tYPEID = value;
            }
            get
            {
                return tYPEID;
            }
        }
        private int tYPEID = 0;

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
