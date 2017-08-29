/**
* 电子衡入场明细
* 2017-08-08 14:34:07
**/
namespace SdlDB.Entity
{
    public class Slps_RawMaterialsSaleDetail
    {
        public Slps_RawMaterialsSaleDetail()
        {

        }

        private string qrcodeScanResult;    //扫码结果
        private string sapOrderNo;  //sap订单号
        private string lineItemNo;  //行项目号
        private string matnr;   //物料编号
        private string maktx;   //物料名称
        private decimal sfimg;  //原发吨数
        private string lgort;   //仓库
        private decimal realZfimg;  //实发吨数
        private string timeFlag; //时间戳
        private decimal pweight; //包重

        //行项目序号
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

        //SAP订单号
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

        //二维码扫描结果
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

        public decimal RealZfimg
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
    }
}
