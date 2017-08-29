/**
* 电子衡出场明细
* 2017-08-08 14:34:07
**/

namespace SdlDB.Entity
{
    public class Sdl_SlpsExitDetail
    {
        public Sdl_SlpsExitDetail()
        {

        }
        private string qrcodeScanResult;    //二维码扫描结果
        private string lineItemNo;          //行项目序号
        private string sapOrderNo;          //SAP订单号
        private string skuCode;             //物料编号
        private string skuName;             //物料名称
        private decimal beforeSendQuantity; //原发数量
        private decimal actualTonQuantity;  //实发数量
        private decimal actualQuantity;     //实发件数
        private string wareHouse;           //仓库
        private decimal weight;             //包重

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

        //原发数量
        public decimal BeforeSendQuantity
        {
            get
            {
                return beforeSendQuantity;
            }

            set
            {
                beforeSendQuantity = value;
            }
        }

        //实发数量
        public decimal ActualTonQuantity
        {
            get
            {
                return actualTonQuantity;
            }

            set
            {
                actualTonQuantity = value;
            }
        }

        //实发件数
        public decimal ActualQuantity
        {
            get
            {
                return actualQuantity;
            }

            set
            {
                actualQuantity = value;
            }
        }

        //仓库编码
        public string WareHouse
        {
            get
            {
                return wareHouse;
            }

            set
            {
                wareHouse = value;
            }
        }

        //包重
        public decimal Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }
    }
}
