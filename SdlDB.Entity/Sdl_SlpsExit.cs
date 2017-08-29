/**
* 电子衡出场
* 2017-08-08 14:34:07
**/

namespace SdlDB.Entity
{
    public class Sdl_SlpsExit
    {
        public Sdl_SlpsExit()
        {

        }

        private string sapOrderNo;
        private string carNo;
        private string qrcodeScanResult;
        private string customerName;
        private string oaNo;
        private string transportType;
        private string distributionChannel;
        private string salesArea;
        private string salesDepartment;
        private string salesMan;
        private string orderType;
        private Sdl_SlpsExitDetail materialDetail;

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

        //客户名称
        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        //OA单号
        public string OaNo
        {
            get
            {
                return oaNo;
            }

            set
            {
                oaNo = value;
            }
        }

        //运输方式
        public string TransportType
        {
            get
            {
                return transportType;
            }

            set
            {
                transportType = value;
            }
        }

        //分销渠道
        public string DistributionChannel
        {
            get
            {
                return distributionChannel;
            }

            set
            {
                distributionChannel = value;
            }
        }

        //销售区域
        public string SalesArea
        {
            get
            {
                return salesArea;
            }

            set
            {
                salesArea = value;
            }
        }

        //销售科室
        public string SalesDepartment
        {
            get
            {
                return salesDepartment;
            }

            set
            {
                salesDepartment = value;
            }
        }

        //业务员
        public string SalesMan
        {
            get
            {
                return salesMan;
            }

            set
            {
                salesMan = value;
            }
        }

        //物料明细
        public Sdl_SlpsExitDetail MaterialDetail
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
    }
}
