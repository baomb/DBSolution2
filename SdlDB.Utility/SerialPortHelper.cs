using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SdlDB.Data;
using SdlDB.Entity;
using System.ComponentModel;
using System.Windows.Forms;

namespace SdlDB.Utility
{
    public enum DBStatus
    {
        [Description("正常")]
        Normal = 0,
        [Description("读取数据异常")]
        ReadError = 1,
        [Description("地磅数据异常")]
        DataError = 2
    }

    public class SerialPortHelper
    {
        string model = string.Empty;
        string regex = string.Empty;
        bool order = false;
        SerialPort serialport = null;

        public SerialPortHelper(ref SerialPort port)
        {
            Sdl_SysSetting sysSetting = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            port.BaudRate = sysSetting.Baudrate;
            port.DataBits = sysSetting.Databits;
            port.Parity = sysSetting.Parity;
            port.StopBits = sysSetting.Stopbits;
            port.PortName = sysSetting.Com;
            regex = sysSetting.Regex;
            order = sysSetting.Order;
            model = sysSetting.Model;
            this.serialport = port;
        }

        public double ShowWeight(ref DBStatus message)
        {
            Byte[] b = new byte[300];
            string weight = string.Empty;
            try
            {
                if (!serialport.IsOpen)
                {
                    serialport.Open();
                }
                serialport.Read(b, 0, 299);
                string readbyte = Encoding.ASCII.GetString(b);
                //MessageBox.Show(readbyte);
                Regex r = new Regex(regex);
                Match match = r.Match(readbyte);
                //MessageBox.Show(regex + "\n" + match);
                if (r.IsMatch(readbyte))
                {
                    try
                    {
                        weight = match.Groups["weight"].ToString();
                        //MessageBox.Show(weight+"   aaaa");
                        if (order)
                        {
                            char[] c = weight.ToCharArray();
                            Array.Reverse(c);
                            weight = new string(c);
                        }
                        serialport.DiscardInBuffer();
                        message = DBStatus.Normal;

                        //MessageBox.Show(weight + "   bbbb");
                        if (model.IndexOf("#TO#") < 0)
                            return Convert.ToDouble(weight) / 1000.0;
                        else
                            return Convert.ToDouble(weight);
                    }
                    catch
                    {
                        message = DBStatus.ReadError;
                        return 0;
                    }
                }
                message = DBStatus.DataError;
                return 0;
            }
            catch
            {
                message = DBStatus.ReadError;
                return 0;
            }
        }
    }
}
