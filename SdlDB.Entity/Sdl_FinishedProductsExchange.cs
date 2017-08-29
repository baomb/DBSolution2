using System;
using System.Data;
using System.Data.SqlTypes;
namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_FinishedProductsExchangeIn 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_FinishedProductsExchange
    {
        public Sdl_FinishedProductsExchange()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 入厂ID
        /// </summary>
        private int iD = 0;
        public int ID
        {
            set
            {
                iD = value;
            }
            get
            {
                return iD;
            }
        }

        /// <summary>
        /// OA单号
        /// </summary>
        private string oANUM = string.Empty;
        public string OANUM
        {
            set
            {
                oANUM = value;
            }
            get
            {
                return oANUM;
            }
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        private string tIMEFLAG = string.Empty;
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


        /// <summary>
        /// 行项目
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
        /// 物料编号
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
        /// 物料名称
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
        /// 原发吨数
        /// </summary>
        public decimal MENGE
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
        private decimal mENGE = 0;

        /// <summary>
        /// 实收件数
        /// </summary>
        public decimal REALZFIMG
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
        private decimal rEALZFIMG = 0;

        /// <summary>
        /// 实收吨数
        /// </summary>
        public decimal SENGE
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
        private decimal sENGE = 0;

        /// <summary>
        /// 实发件数
        /// </summary>
        public decimal ZFIMG
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
        private decimal zFIMG = 0;

        /// <summary>
        /// 实发吨数
        /// </summary>
        public decimal LFIMG
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
        private decimal lFIMG = 0;

        /// <summary>
        /// 库存地点
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
        /// 地磅编号
        /// </summary>
        private string dBNUM = string.Empty;
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

        /// <summary>
        /// 车牌号
        /// </summary>
        private string tRUCKNUM = string.Empty;
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
    }
}