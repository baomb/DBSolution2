using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_FinishedProductsPresentation
    {
        /// <summary>
        /// 
        /// </summary>
        public int REALMENGE
        {
            set
            {
                rEALMENGE = value;
            }
            get
            {
                return rEALMENGE;
            }
        }
        private int rEALMENGE = 0;


        /// <summary>
        /// 
        /// </summary>
        public double BDMNG
        {
            set
            {
                bDMNG = value;
            }
            get
            {
                return bDMNG;
            }
        }
        private double bDMNG = 0;


        /// <summary>
        /// 
        /// </summary>
        public double SFIMG
        {
            set
            {
                sFIMG = value;
            }
            get
            {
                return sFIMG;
            }
        }
        private double sFIMG = 0;


        /// <summary>
        /// 
        /// </summary>
        public string MATNR
        {
            set
            {
                mATNR = value;
            }
            get
            {
                return mATNR;
            }
        }
        private string mATNR = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string MAKTX
        {
            set
            {
                mAKTX = value;
            }
            get
            {
                return mAKTX;
            }
        }
        private string mAKTX = string.Empty;


        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string LGORT
        {
            set
            {
                lGORT = value;
            }
            get
            {
                return lGORT;
            }
        }
        private string lGORT = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string RSPOS
        {
            set
            {
                rSPOS = value;
            }
            get
            {
                return rSPOS;
            }
        }
        private string rSPOS = string.Empty;


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
        public string SGTXT
        {
            set
            {
                sGTXT = value;
            }
            get
            {
                return sGTXT;
            }
        }
        private string sGTXT = string.Empty;



    }
}
