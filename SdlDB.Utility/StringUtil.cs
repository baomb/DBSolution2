using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SdlDB.Utility
{
    public class StringUtil
    {
        /// <summary>
        /// 限定字符长度 Unicode
        /// </summary>
        /// <param name="s"></param>
        /// <param name="MaxLength"></param>
        /// <param name="ShowPoint"></param>
        /// <returns></returns>
        public static string CutStr(string s, int MaxLength)
        {
            return CutStr(s, MaxLength, "");
        }
        /// <summary>
        /// 限定字符长度 Unicode
        /// </summary>
        /// <param name="s"></param>
        /// <param name="MaxLength"></param>
        /// <param name="ShowPoint"></param>
        /// <returns></returns>
        public static string CutStr(string s, int MaxLength, string strAppend)
        {
            int num1 = 0;
            int num2 = 0;
            string text1 = s;
            for (int num3 = 0; num3 < text1.Length; num3++)
            {
                char ch1 = text1[num3];
                if (ch1 > '\x007f')
                {
                    num1 += 2;
                }
                else
                {
                    num1++;
                }
                if (num1 > MaxLength)
                {
                    s = s.Substring(0, num2);

                    s = s + strAppend;

                    break;
                }
                num2++;

            }
            return s;
        }

        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex = startIndex - length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if (str.Length - startIndex < length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 生成一个随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandomNumber()
        {
            string randomNumber = "";
            randomNumber = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            Random rdm = new Random();
            randomNumber = randomNumber + rdm.Next(10000000, 100000000 - 1).ToString();
            rdm = null;
            return randomNumber;
        }



        /// <summary>
        /// object型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(object expression, int defValue)
        {
            return TypeConverter.ObjectToInt(expression, defValue);
        }


        /// <summary>
        /// 将字符串转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string expression, int defValue)
        {
            return TypeConverter.StrToInt(expression, defValue);
        }

        /// <summary>
        /// Object型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        /// <summary>
        /// 将字符转换成日期类型的数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string str)
        {
            if (IsDateTime(str))
            {
                return DateTime.Parse(str);
            }
            else
            {
                return DateTime.Parse("1900-1-1");
            }
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }


        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        #region 是否是时间格式
        /// <summary>
        /// 判断一个字符串是否时间格式
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(string inputData)
        {
            try
            {
                Convert.ToDateTime(inputData);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                    return new string[] { strContent };

                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
                return new string[0] { };
        }


        /// <summary>
        /// 字符串长度
        /// </summary>
        /// <param name="input">要判断字符串</param>
        /// <returns>字符串长度</returns>
        public static int StringLength(string input)
        {
            int n;
            if (string.IsNullOrEmpty(input))
            {
                n = 0;
            }
            else
            {
                n = Encoding.Default.GetByteCount(input);
            }
            return n;
        }


        /// <summary>
        /// 判断文本框混合输入长度
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="i">长度</param>
        /// <returns></returns>
        public static bool IsOverLength(string str, int i)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            int m = b.Length;
            if (m <= i)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
