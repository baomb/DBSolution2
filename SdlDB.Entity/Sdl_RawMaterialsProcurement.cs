using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_RawMaterialsProcurement
    {
        /// <summary>
        /// 物料编码
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
        /// 物料描述
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
        /// 采购订单号
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
        /// 原发吨数
        /// </summary>
        public float LFIMG
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
        private float lFIMG = 0;

        /// <summary>
        /// 实收吨数
        /// </summary>
        public float SFIMG
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
        private float sFIMG = 0;


        /// <summary>
        /// 亏件数量
        /// </summary>
        public int DFIMG
        {
            set
            {
                dFIMG = value;
            }
            get
            {
                return dFIMG;
            }
        }
        private int dFIMG = 0;


        /// <summary>
        /// 包重
        /// </summary>
        public int PWEIGHT
        {
            set
            {
                pWEIGHT = value;
            }
            get
            {
                return pWEIGHT;
            }
        }
        private int pWEIGHT = 0;


        /// <summary>
        /// 标准寄售
        /// </summary>
        public string PSTYP
        {
            set
            {
                pSTYP = value;
            }
            get
            {
                return pSTYP;
            }
        }
        private string pSTYP = string.Empty;


        /// <summary>
        /// 产地品牌
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


        /// <summary>
        /// 原发件数
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
        /// 实收件数
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
        /// 仓库
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
        /// 项目号
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
        /// 供应商编码
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
        /// 供应商名称
        /// </summary>
        public string MCOD1
        {
            set
            {
                mCOD1 = value;
            }
            get
            {
                return mCOD1;
            }
        }
        private string mCOD1 = string.Empty;


        /// <summary>
        /// 包车皮
        /// </summary>
        public string WAGON
        {
            set
            {
                wAGON = value;
            }
            get
            {
                return wAGON;
            }
        }
        private string wAGON = string.Empty;


        /// <summary>
        /// 项目文本
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


        /// <summary>
        /// 项目
        /// </summary>
        public int NKEY
        {
            set
            {
                nKEY = value;
            }
            get
            {
                return nKEY;
            }
        }
        private int nKEY = 0;

        /// <summary>
        /// 单位为KG
        /// </summary>
        public string KG
        {
            set
            {
                kG = value;
            }
            get
            {
                return kG;
            }
        }
        private string kG = string.Empty;

        /// <summary>
        /// 仓储类型
        /// </summary>
        public string STORAGETYPE
        {
            set
            {
                sTORAGETYPE = value;
            }
            get
            {
                return sTORAGETYPE;
            }
        }
        private string sTORAGETYPE = string.Empty;
    }
}

   
