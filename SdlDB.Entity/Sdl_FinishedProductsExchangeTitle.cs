using System;
using System.Data;
using System.Data.SqlTypes;
namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_FinishedProductsExchangeInTitle 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_FinishedProductsExchangeTitle
    {
        public Sdl_FinishedProductsExchangeTitle()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 入厂ID
        /// </summary>
        /// 
        private string iD = string.Empty;
        public string ID
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
        /// OA申请单号
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

        /// <summary>
        /// 入场时间
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
        /// 入厂司磅员
        /// </summary>
        public string ENTERWEIGHT
        {
            set
            {
                eNTERWEIGHT = value;
            }
            get
            {
                return eNTERWEIGHT;
            }
        }
        private string eNTERWEIGHT = string.Empty;

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
        /// 出厂司磅员
        /// </summary>
        public string EXITWEIGHT
        {
            set
            {
                eXITWEIGHT = value;
            }
            get
            {
                return eXITWEIGHT;
            }
        }
        private string eXITWEIGHT = string.Empty;

        /// <summary>
        /// 重车出厂标识
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
        /// 毛重
        /// </summary>
        public decimal GROSS
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
        private decimal gROSS = 0;



        /// <summary>
        /// 皮重
        /// </summary>
        public decimal TARE
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
        private decimal tARE = 0;

        /// <summary>
        /// 净重
        /// </summary>
        public decimal NET
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
        private decimal nET = 0;

        /// <summary>
        /// 出厂标识
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
        /// 备注
        /// </summary>
        public string NOTE
        {
            set
            {
                nOTE = value;
            }
            get
            {
                return nOTE;
            }
        }
        private string nOTE = string.Empty;

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CNUM
        {
            set
            {
                cNUM = value;
            }
            get
            {
                return cNUM;
            }
        }
        private string cNUM = string.Empty;

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CNAME
        {
            set
            {
                cNAME = value;
            }
            get
            {
                return cNAME;
            }
        }
        private string cNAME = string.Empty;

        /// <summary>
        /// 发运方式
        /// </summary>
        public string TTYPE
        {
            set
            {
                tTYPE = value;
            }
            get
            {
                return tTYPE;
            }
        }
        private string tTYPE = string.Empty;

        /// <summary>
        /// 分销渠道
        /// </summary>
        public string FXQD
        {
            set
            {
                fXQD = value;
            }
            get
            {
                return fXQD;
            }
        }
        private string fXQD = string.Empty;

        /// <summary>
        /// 业务员
        /// </summary>
        public string YWY
        {
            set
            {
                yWY = value;
            }
            get
            {
                return yWY;
            }
        }
        private string yWY = string.Empty;

        /// <summary>
        /// 销售区域
        /// </summary>
        public string XSQY
        {
            set
            {
                xSQY = value;
            }
            get
            {
                return xSQY;
            }
        }
        private string xSQY = string.Empty;

        /// <summary>
        /// 销售科室
        /// </summary>
        public string XSKS
        {
            set
            {
                xSKS = value;
            }
            get
            {
                return xSKS;
            }
        }
        private string xSKS = string.Empty;

        /// <summary>
        /// 出厂标志
        /// </summary>
        public string ISOUT
        {
            set
            {
                iSOUT = value;
            }
            get
            {
                return iSOUT;
            }
        }
        private string iSOUT = string.Empty;
    }
}