/**
* 电子衡入场明细
* 2017-08-08 14:34:07
**/
namespace SdlDB.Entity
{
    public class Slps_FinishedProductsSaleDetail
    {
        public Slps_FinishedProductsSaleDetail()
        {

        }

        private string qrcodeScanResult;    //扫码结果
        private string sapOrderNo;  //sap订单号
        private string lineItemNo;  //行项目号
        private string matnr;   //物料编号
        private string maktx;   //物料名称
        private decimal lfimg;  //原发吨数
        private int zfimg;      //原发数量
        private string lgort;   //仓库
        private decimal realZfimg;  //实发吨数
        private string timeFlag; //时间戳

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
    }
}
