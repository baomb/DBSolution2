using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    /// <summary>
    /// Sdl_AccessoryProcurementDetail 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_AccessoryProcurementDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public int ZFIMG
        {
            set
            {
                zFIMG = value;
            }
            get
            {
                return zFIMG;
            }
        }
        private int zFIMG = 0;


        /// <summary>
        /// 
        /// </summary>
        public int REALZFIMG
        {
            set
            {
                rEALZFIMG = value;
            }
            get
            {
                return rEALZFIMG;
            }
        }
        private int rEALZFIMG = 0;


        /// <summary>
        /// 
        /// </summary>
        public double MENGE
        {
            set
            {
                mENGE = value;
            }
            get
            {
                return mENGE;
            }
        }
        private double mENGE = 0;


        /// <summary>
        /// 
        /// </summary>
        public double SENGE
        {
            set
            {
                sENGE = value;
            }
            get
            {
                return sENGE;
            }
        }
        private double sENGE = 0;


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
        public string EBELP
        {
            set
            {
                eBELP = value;
            }
            get
            {
                return eBELP;
            }
        }
        private string eBELP = string.Empty;


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


      
    }
}
