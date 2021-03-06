using System;
using System.Data;
namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_RawMaterialReturnDetail 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_RawMaterialReturnDetail
    {
        public Sdl_RawMaterialReturnDetail()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


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
        public string BKTXT
        {
            set
            {
                bKTXT = value;
            }
            get
            {
                return bKTXT;
            }
        }
        private string bKTXT = string.Empty;



    }
}