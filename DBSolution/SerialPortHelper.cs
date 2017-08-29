using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;

namespace DBSolution
{
    public class SerialPortHelper
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="setting"></param>
        private void InitSerialPort(SerialPort port, Sdl_SysSetting setting)
        {
            port.PortName = setting.Com;
            port.BaudRate = setting.Baudrate;
            port.DataBits = setting.Databits;
            port.Parity = setting.Parity;
            port.StopBits = setting.Stopbits;
            port.Open();
        }

        /// <summary>
        /// 调用显示地磅数据
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        private string ShowWeight(SerialPort port,string rex,bool order)
        {
            Byte[] b = new byte[100];
            string weight = string.Empty;
            port.Read(b, 0, 99);
            string readbyte = Encoding.ASCII.GetString(b);
            Regex regex = new Regex(rex);
            Match match = regex.Match(readbyte);
            if (regex.IsMatch(readbyte))
            {
                try
                {
                    weight = match.Groups["weight"].ToString();
                    if (order)
                    {
                        char[] c = weight.ToCharArray();
                        Array.Reverse(c);
                        weight = new string(c);
                    }
                    return Convert.ToInt32(weight).ToString();
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }
    }
}
