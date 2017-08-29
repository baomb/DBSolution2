using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_ProductReturnMerchantDetail
    {
        public Sdl_ProductReturnMerchantDetail()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


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
        public double LFIMG
        {
            set
            {
                lFIMG = value;
            }
            get
            {
                return lFIMG;
            }
        }
        private double lFIMG = 0;


        /// <summary>
        /// 
        /// </summary>
        public double ZFIMG
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
        private double zFIMG = 0;

        /// <summary>
        /// 
        /// </summary>
        public double REALZFIMG
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
        private double rEALZFIMG = 0;


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
        public string POSNR
        {
            set
            {
                pOSNR = value;
            }
            get
            {
                return pOSNR;
            }
        }
        private string pOSNR = string.Empty;


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
