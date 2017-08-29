using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_RawMaterialsProcurementTitle
    {
        /// <summary>
        /// 车牌号
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
        /// 检斤员
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
        /// 检斤员
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
        /// 皮重
        /// </summary>
        public float TARE
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
        private float tARE = 0;


        /// <summary>
        /// 进厂时间
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
        /// 出厂时间
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
        /// 毛重
        /// </summary>
        public float GROSS
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
        private float gROSS = 0;


        /// <summary>
        /// 净重
        /// </summary>
        public float NET
        {
            set
            {
                nET = value;
            }
            get
            {
                return nET;
            }
        }
        private float nET = 0;


        /// <summary>
        /// 扣杂
        /// </summary>
        public float BALANCE
        {
            set
            {
                bALANCE = value;
            }
            get
            {
                return bALANCE;
            }
        }
        private float bALANCE = 0;


        /// <summary>
        /// 进出厂标识
        /// </summary>
        public string HS_FLAG
        {
            set
            {
                hS_FLAG = value;
            }
            get
            {
                return hS_FLAG;
            }
        }
        private string hS_FLAG = string.Empty;


        /// <summary>
        /// 重车出厂标识
        /// </summary>
        public bool EXITFLAG
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
        private bool eXITFLAG = false;


        /// <summary>
        /// 工厂
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
        /// 卸货点/站点
        /// </summary>
        public string ABLAD
        {
            set
            {
                aBLAD = value;
            }
            get
            {
                return aBLAD;
            }
        }
        private string aBLAD = string.Empty;

        /// <summary>
        /// 车皮号
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
        /// 承运人亏吨
        /// </summary>
        public float CYNUM
        {
            set
            {
                cYNUM = value;
            }
            get
            {
                return cYNUM;
            }
        }
        private float cYNUM = 0;

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
        public Decimal TRAYWEIGHT
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
        private Decimal tRAYWEIGHT = 0;

        /// <summary>
        /// 托盘数量
        /// </summary>
        public int TRAYQUANTITY
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
        private int tRAYQUANTITY = 0;

        /// <summary>
        /// 特殊包重
        /// </summary>
        public string BFIMG
        {
            set
            {
                bFIMG = value;
            }
            get
            {
                return bFIMG;
            }
        }
        private string bFIMG = string.Empty;


        /// <summary>
        /// 破件
        /// </summary>
        public string FREIGHT
        {
            set
            {
                fREIGHT = value;
            }
            get
            {
                return fREIGHT;
            }
        }
        private string fREIGHT = string.Empty;

        /// <summary>
        /// 运费
        /// </summary>
        public string WAGONNUM
        {
            set
            {
                wAGONNUM = value;
            }
            get
            {
                return wAGONNUM;
            }
        }
        private string wAGONNUM = string.Empty;

        /// <summary>
        /// 合同订单
        /// </summary>
        public string CONTRACT
        {
            set
            {
                cONTRACT = value;
            }
            get
            {
                return cONTRACT;
            }
        }
        private string cONTRACT = string.Empty;
    }
}