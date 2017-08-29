using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    public class Sdl_SysSetting
    {
        private string werks;//工厂编号
        private string id;//地磅编号
        private string com;//地磅串口
        private string db;//所选地磅控制器
        private string model;//品牌
        private int baudrate;//波特率
        private System.IO.Ports.Parity parity;//parity
        private int databits;//databits
        private System.IO.Ports.StopBits stopbits;//stopbits
        private bool order;//order
        private string regex;//regex
        private string portflag;//regex
        private bool tray; //托盘

        /// <summary>
        /// 工厂编号
        /// </summary>
        public string WERKS
        {
            get { return werks; }
            set { werks = value; }
        }

        /// <summary>
        /// 读取地磅数据
        /// </summary>
        public string PORTFLAG
        {
            get { return portflag; }
            set { portflag = value; }
        }

        /// <summary>
        /// 地磅编号
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 地磅串口
        /// </summary>
        public string Com
        {
            get { return com; }
            set { com = value; }
        }

        /// <summary>
        /// 地磅控制器所选ID
        /// </summary>
        public string DB
        {
            get { return db; }
            set { db = value; }
        }

        /// <summary>
        /// Model
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// Baudrate
        /// </summary>
        public int Baudrate
        {
            get { return baudrate; }
            set { baudrate = value; }
        }

        /// <summary>
        /// Parity
        /// </summary>
        public System.IO.Ports.Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        /// <summary>
        /// Databits
        /// </summary>
        public int Databits
        {
            get { return databits; }
            set { databits = value; }
        }

        /// <summary>
        /// Stopbits
        /// </summary>
        public System.IO.Ports.StopBits Stopbits
        {
            get { return stopbits; }
            set { stopbits = value; }
        }

        /// <summary>
        /// Order
        /// </summary>
        public bool Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// Regex
        /// </summary>
        public string Regex
        {
            get { return regex; }
            set { regex = value; }
        }

        /// <summary>
        /// Tray
        /// </summary>
        public bool Tray
        {
            get { return tray; }
            set { tray = value; }
        }
    }
}
