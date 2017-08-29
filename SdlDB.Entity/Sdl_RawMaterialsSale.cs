using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_RawMaterialsSale
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
        /// 销售订单号
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


        ///// <summary>
        ///// 原发吨数
        ///// </summary>
        //public float LFIMG
        //{
        //    set
        //    {
        //        lFIMG = value;
        //    }
        //    get
        //    {
        //        return lFIMG;
        //    }
        //}
        //private float lFIMG = 0;

        /// <summary>
        /// 实发吨数
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


        ///// <summary>
        ///// 亏件数量
        ///// </summary>
        //public int DFIMG
        //{
        //    set
        //    {
        //        dFIMG = value;
        //    }
        //    get
        //    {
        //        return dFIMG;
        //    }
        //}
        //private int dFIMG = 0;


        /// <summary>
        /// 包重
        /// </summary>
        public decimal PWEIGHT
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
        private decimal pWEIGHT = 0;


        ///// <summary>
        ///// 标准寄售
        ///// </summary>
        //public string PSTYP
        //{
        //    set
        //    {
        //        pSTYP = value;
        //    }
        //    get
        //    {
        //        return pSTYP;
        //    }
        //}
        //private string pSTYP = string.Empty;


        ///// <summary>
        ///// 产地品牌
        ///// </summary>
        //public string BKTXT
        //{
        //    set
        //    {
        //        bKTXT = value;
        //    }
        //    get
        //    {
        //        return bKTXT;
        //    }
        //}
        //private string bKTXT = string.Empty;


        ///// <summary>
        ///// 实发件数
        ///// </summary>
        //public int ZFIMG
        //{
        //    set
        //    {
        //        zFIMG = value;
        //    }
        //    get
        //    {
        //        return zFIMG;
        //    }
        //}
        //private int zFIMG = 0;


        /// <summary>
        /// 实发件数
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
        /// 客户编码
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
        /// 客户名称
        /// </summary>
        public string NAME1
        {
            set
            {
                nNAME1 = value;
            }
            get
            {
                return nNAME1;
            }
        }
        private string nNAME1 = string.Empty;
    }
}