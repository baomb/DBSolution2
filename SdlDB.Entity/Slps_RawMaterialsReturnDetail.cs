/**
* y原材料退货明细
* 2017-08-28 16:33:56
**/
namespace SdlDB.Entity
{
    public class Slps_RawMaterialsReturnDetail
    {
        public Slps_RawMaterialsReturnDetail()
        {

        }

        private string qrcodeScanResult;    //扫码结果
        private string sapOrderNo;  //sap订单号
        private string lineItemNo;  //行项目号
        private string timeFlag; //时间戳
        private string matnr;   //物料编号
        private string maktx;   //物料名称
        private decimal menge;  //可退货数量
        private decimal senge;  //实退数量
        private string lgort;   //仓库
        private string bktxt;

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

        public decimal Senge
        {
            get
            {
                return senge;
            }

            set
            {
                senge = value;
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
