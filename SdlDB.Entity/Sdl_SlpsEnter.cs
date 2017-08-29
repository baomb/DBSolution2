/**
* 电子衡入场
* 2017-08-08 14:34:07
**/

namespace SdlDB.Entity
{
    public class Sdl_SlpsEnter
    {
        public Sdl_SlpsEnter()
        {

        }
        private string qrcodeScanResult;
        private string sapOrderNo;
        private string carNo;
        private string orderStatus;
        private string orderType;
        private string timeFlag;
        private Sdl_SlpsEnterDetail materialDetail;

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

        //车牌号
        public string CarNo
        {
            get
            {
                return carNo;
            }

            set
            {
                carNo = value;
            }
        }

        //物料明细
        public Sdl_SlpsEnterDetail MaterialDetail
        {
            get
            {
                return materialDetail;
            }

            set
            {
                materialDetail = value;
            }
        }

        //订单状态
        public string OrderStatus
        {
            get
            {
                return orderStatus;
            }

            set
            {
                orderStatus = value;
            }
        }

        //订单类型
        public string OrderType
        {
            get
            {
                return orderType;
            }

            set
            {
                orderType = value;
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
