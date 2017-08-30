/**
* 成品赠送明细
* 2017-08-30 08:51:59
**/
namespace SdlDB.Entity
{
    public class Slps_FinishedProductsPresentationDetail
    {
        public Slps_FinishedProductsPresentationDetail()
        {

        }

        private string qrcodeScanResult;    //扫码结果
        private string sapOrderNo;  //sap订单号
        private string lineItemNo;  //行项目号
        private string timeFlag; //时间戳
        private string matnr;   //物料编号
        private string maktx;   //物料名称
        private decimal bdmng;  //预留剩余数量
        private decimal sfimg;  //实退数量
        private decimal realMenge;  //实发件数
        private string lgort;   //仓库
        private string bktxt;   //产地品牌

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

        public decimal Bdmng
        {
            get
            {
                return bdmng;
            }

            set
            {
                bdmng = value;
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

        public decimal RealMenge
        {
            get
            {
                return realMenge;
            }

            set
            {
                realMenge = value;
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

        public string Bktxt
        {
            get
            {
                return bktxt;
            }

            set
            {
                bktxt = value;
            }
        }
    }
}
