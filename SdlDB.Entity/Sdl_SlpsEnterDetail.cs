/**
* 电子衡入场明细
* 2017-08-08 14:34:07
**/
namespace SdlDB.Entity
{
    public class Sdl_SlpsEnterDetail
    {
        public Sdl_SlpsEnterDetail()
        {

        }
        private string lineItemNo;
        private string sapOrderNo;
        private string qrcodeScanResult;
        private string skuCode;
        private string skuName;
        private decimal beforeSendTonQuantity;
        private decimal noReceiptQuantity;

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

        //物料编码
        public string SkuCode
        {
            get
            {
                return skuCode;
            }

            set
            {
                skuCode = value;
            }
        }

        //物料名称
        public string SkuName
        {
            get
            {
                return skuName;
            }

            set
            {
                skuName = value;
            }
        }

        //原发吨量
        public decimal BeforeSendTonQuantity
        {
            get
            {
                return beforeSendTonQuantity;
            }

            set
            {
                beforeSendTonQuantity = value;
            }
        }

        //未收货数量
        public decimal NoReceiptQuantity
        {
            get
            {
                return noReceiptQuantity;
            }

            set
            {
                noReceiptQuantity = value;
            }
        }
    }
}
