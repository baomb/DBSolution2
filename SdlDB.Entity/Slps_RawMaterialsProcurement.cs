/**
* 原材料采购
* 2017-08-19 10:16:44
**/

namespace SdlDB.Entity
{
    public class Slps_RawMaterialsProcurement
    {
        public Slps_RawMaterialsProcurement()
        {

        }
        private string qrcodeScanResult;    //二维码扫描结果
        private string sapOrderNo;  //sap订单号
        private string carNo;   //车牌号
        private string factory; //工厂编号
        private string dbNum;   //地磅编号
        private string enterWeightMan;  //入场司磅员
        private string exitWeightMan;  //出场司磅员
        private string enterTime;   //入场时间
        private string exitTime;    //出场时间
        private decimal tare;   //皮重
        private decimal gross;  //毛重
        private decimal net;    //净重
        private string abald;   //卸货点
        private string wagon;   //车皮号
        private decimal cyNum;  //承运人亏吨
        private string bfimg;   //特殊包重
        private string freight; //破件
        private string wagonNum;//运费
        private string exitFlag;//空车出场标识
        private string hs_flag; //出场标识
        private string note;    //备注
        private string contract;//合同订单
        private string timeFlag; //时间戳
        private decimal balance; //扣杂
        private decimal trayWeight; //托盘标重
        private int trayQuantity;   //托盘数量


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

        public string Factory
        {
            get
            {
                return factory;
            }

            set
            {
                factory = value;
            }
        }

        public string DbNum
        {
            get
            {
                return dbNum;
            }

            set
            {
                dbNum = value;
            }
        }

        public string EnterWeightMan
        {
            get
            {
                return enterWeightMan;
            }

            set
            {
                enterWeightMan = value;
            }
        }

        public string ExitWeightMan
        {
            get
            {
                return exitWeightMan;
            }

            set
            {
                exitWeightMan = value;
            }
        }

        public string EnterTime
        {
            get
            {
                return enterTime;
            }

            set
            {
                enterTime = value;
            }
        }

        public string ExitTime
        {
            get
            {
                return exitTime;
            }

            set
            {
                exitTime = value;
            }
        }

        public decimal Tare
        {
            get
            {
                return tare;
            }

            set
            {
                tare = value;
            }
        }

        public decimal Gross
        {
            get
            {
                return gross;
            }

            set
            {
                gross = value;
            }
        }

        public decimal Net
        {
            get
            {
                return net;
            }

            set
            {
                net = value;
            }
        }

        public string Abald
        {
            get
            {
                return abald;
            }

            set
            {
                abald = value;
            }
        }

        public string Wagon
        {
            get
            {
                return wagon;
            }

            set
            {
                wagon = value;
            }
        }

        public decimal CyNum
        {
            get
            {
                return cyNum;
            }

            set
            {
                cyNum = value;
            }
        }

        public string Bfimg
        {
            get
            {
                return bfimg;
            }

            set
            {
                bfimg = value;
            }
        }

        public string Freight
        {
            get
            {
                return freight;
            }

            set
            {
                freight = value;
            }
        }

        public string WagonNum
        {
            get
            {
                return wagonNum;
            }

            set
            {
                wagonNum = value;
            }
        }

        public string ExitFlag
        {
            get
            {
                return exitFlag;
            }

            set
            {
                exitFlag = value;
            }
        }

        public string Hs_flag
        {
            get
            {
                return hs_flag;
            }

            set
            {
                hs_flag = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public string Contract
        {
            get
            {
                return contract;
            }

            set
            {
                contract = value;
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

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public decimal TrayWeight
        {
            get
            {
                return trayWeight;
            }

            set
            {
                trayWeight = value;
            }
        }

        public int TrayQuantity
        {
            get
            {
                return trayQuantity;
            }

            set
            {
                trayQuantity = value;
            }
        }
    }
}
