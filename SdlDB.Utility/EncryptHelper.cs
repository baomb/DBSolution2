using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SdlDB.Utility
{
    /// <summary>
    ///Encrypt 的摘要说明
    /// </summary>
    public class EncryptHelper
    {
        public EncryptHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        private static string Key
        {
            get { return @"P@+#wG+Z"; }
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        private static string IV
        {
            get { return @"L%n67}G\Mk@k%:~Y"; }
        }

        /// <summary>
        /// 加密
        /// </summary>
        public static string getDestSting(string plainStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return encrypt;
        }

        /// <summary>
        /// 解密
        /// </summary>
        public static string getSourceSting(string encryptStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            encryptStr = encryptStr.Replace(" ", "+");
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return decrypt;
        }

        /// <summary>
        /// 生成字母和数字的验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandWord(int length)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                {
                    code = (char)('0' + (char)(number % 10));
                }
                else
                {
                    code = (char)('A' + (char)(number % 26));
                }
                checkCode += code.ToString();
            }

            return checkCode;
        }
    }
}
