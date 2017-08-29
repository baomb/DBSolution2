/**
* 电子衡原材料采购明细
* 2017-08-19 10:16:34
**/
namespace SdlDB.Entity
{
    public class Slps_RawMaterialsProcurementDetail
    {
        public Slps_RawMaterialsProcurementDetail()
        {

        }

        private string qrcodeScanResult;    //扫码结果
        private string sapOrderNo;  //sap订单号
        private string lineItemNo;  //行项目号
        private string matnr;   //物料编号
        private string maktx;   //物料名称
        private decimal lfimg;  //原发吨数
        private decimal sfimg;  //实发吨数
        private decimal pweight; //包重
        private string pstyp;   //标准寄售
        private int zfimg;  //原发件数
        private int realZfimg;  //实发件数
        private int dfimg;  //亏件数量
        private string lgort;   //仓库
        private string timeFlag; //时间戳
        private string kg;  //单位千克
        private string sgtxt;   //项目文本
        private string storageType;    //仓储类型
        private decimal menge; //未收货数量

        public string QrcodeScanResult
        {
            get
            {
                return qrcodeScanResult;
            }

            set
            {
                qrcodeScanResult = value;
            }
        }

        public string SapOrderNo
        {
            get
            {
                return sapOrderNo;
            }

            set
            {
                sapOrderNo = value;
            }
        }

        public string LineItemNo
        {
            get
            {
                return lineItemNo;
            }

            set
            {
                lineItemNo = value;
            }
        }

        public string Matnr
        {
            get
            {
                return matnr;
            }

            set
            {
                matnr = value;
            }
        }

        public string Maktx
        {
            get
            {
                return maktx;
            }

            set
            {
                maktx = value;
            }
        }

        public decimal Lfimg
        {
            get
            {
                return lfimg;
            }

            set
            {
                lfimg = value;
            }
        }

        public decimal Sfimg
        {
            get
            {
                return sfimg;
            }

            set
            {
                sfimg = value;
            }
        }

        public decimal Pweight
        {
            get
            {
                return pweight;
            }

            set
            {
                pweight = value;
            }
        }

        public string Pstyp
        {
            get
            {
                return pstyp;
            }

            set
            {
                pstyp = value;
            }
        }

        public int Zfimg
        {
            get
            {
                return zfimg;
            }

            set
            {
                zfimg = value;
            }
        }

        public int Dfimg
        {
            get
            {
                return dfimg;
            }

            set
            {
                dfimg = value;
            }
        }

        public string Lgort
        {
            get
            {
                return lgort;
            }

            set
            {
                lgort = value;
            }
        }

        public string TimeFlag
        {
            get
            {
                return timeFlag;
            }

            set
            {
                timeFlag = value;
            }
        }

        public string Kg
        {
            get
            {
                return kg;
            }

            set
            {
                kg = value;
            }
        }

        public string Sgtxt
        {
            get
            {
                return sgtxt;
            }

            set
            {
                sgtxt = value;
            }
        }

        public string StorageType
        {
            get
            {
                return storageType;
            }

            set
            {
                storageType = value;
            }
        }

        public int RealZfimg
        {
            get
            {
                return realZfimg;
            }

            set
            {
                realZfimg = value;
            }
        }

        public decimal Menge
        {
            get
            {
                return menge;
            }

            set
            {
                menge = value;
            }
        }
    }
}
