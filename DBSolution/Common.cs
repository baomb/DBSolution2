using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Data;
using System.Reflection;
using System.ComponentModel;
using SdlDB.Entity;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace DBSolution
{
    public class Common
    {

        public static string GetServerDate()
        {
            return DateTime.Parse(((DataSet)CommonOper.ExecuteSql("select getdate()")).Tables[0].Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetServerDate2()
        {
            DataSet ds = (DataSet)CommonOper.ExecuteSql("select CONVERT(varchar(30),getdate(),121)");
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static int Weight1 = 50;
        public static int Weight2 = 40;
        public static int Weight3 = 25;
        public static int Weight4 = 20;
        public static int Weight5 = 5;
        public static decimal Weight6 = 0.5M;
        public static int Weight7 = 10;
        public static int Weight8 = 1;
        public static int Weight9 = 1000;

        /// <summary>
        /// 日期增加一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string AddOneDay(string dateTime)
        {
            DateTime dt = DateTime.Parse(dateTime);
            dt = dt.AddDays(1);
            return dt.ToString("yyyy-MM-dd");
        }

        public static string GetAddOneDayDate(string strDate)
        {
            return Convert.ToDateTime(strDate).AddDays(1).ToString("yyyy-MM-dd");
        }

        /// <summary>    
        /// 获取枚举值的描述    
        /// </summary>    
        /// <param name="enumSubitem"></param>    
        /// <returns></returns>    
        public static string GetEnumDescription(object enumSubitem)
        {
            enumSubitem = (Enum)enumSubitem;
            string strValue = enumSubitem.ToString();

            FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);

            if (fieldinfo != null)
            {

                Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (objs == null || objs.Length == 0)
                {
                    return strValue;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    return da.Description;
                }
            }
            else
            {
                return "";
            }

        }

        public static double GetBalanceValue()
        {
            return Sdl_LoadometerDiffAdapter.GetSdl_LoadometerDiff(Sdl_SysSettingAdapter.LoadSdl_SysSetting().ID);
        }

        public static double GetProductBalanceValue()
        {
            return double.Parse(GetConfigApp("ProductBalance"));
        }

        public static bool GetReadPortFlag()
        {
            string flag = string.Empty;
            Sdl_SysSetting settings = Sdl_SysSettingAdapter.LoadSdl_SysSetting();
            if (settings != null)
                flag = settings.PORTFLAG;
            if (flag == "1")
            {
                return true;
            }
            return false;
        }

        public static int GetPageSize()
        {
            try
            {
                return int.Parse(GetConfigApp("PageSize"));
            }
            catch
            {

            }
            return 20;
        }


        private static string GetConfigApp(string keyName)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[keyName].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string GetHelpStr(string strTitle)
        {
            string returnValue = string.Empty;
            Sdl_Manual manual = Sdl_ManualAdapter.GetSdl_Manual(strTitle);
            if (manual != null)
                returnValue = manual.MANUAL;
            else
                returnValue = "";

            return returnValue;
        }

        public static Sdl_Users GetCurrentUser()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            string userName = principal.Identity.Name;
            Sdl_Users user = Sdl_UsersAdapter.GetSdl_Users(userName);
            return user;
        }


        public static void BindCBox(ComboBox cbWerks)
        {
            Sdl_Users user = Common.GetCurrentUser();
            string qWerks = user.QUERY;
            string[] strWerks = qWerks.Split(',');
            if (strWerks.Length > 0)
            {
                for (int i = 0; i < strWerks.Length; i++)
                {
                    cbWerks.Items.Add(strWerks[i].ToString());
                }
            }
            cbWerks.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ShowTruckWeight(string truckNum, DataGridView dgv)
        {
            DataSet ds = Sdl_TruckWeightAdapter.GetSdl_TruckWeightDataSet("where trucknum = '" + truckNum + "'");
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = ds.Tables[0];
        }

        public static void PlayWelcome()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path = path + "/Resources/welcome.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = path;
                player.Play();
            }
            catch
            {
            }
        }

        public static void PlayGoodBye()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path = path + "/Resources/goodbye.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = path;
                player.Play();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取四位顺序号
        /// </summary>
        /// <param name="maxnum"></param>
        /// <returns></returns>
        public static string GetNextNum(int maxnum)
        {
            string max = Convert.ToString(maxnum+1);
            if (max.Length == 1)
                return "000" + max;
            else if (max.Length == 2)
                return "00" + max;
            else if (max.Length == 3)
                return "0" + max;
            else
                return max;
        }

        /// <summary>
        /// 获取物料包重
        /// </summary>
        /// <param name="matnr"></param>
        /// <returns></returns>

        public static double GetMatnrWeight(string matnr)
        {
            string weight = string.Empty; ;
            if (matnr.Length >= 13)
                weight = matnr.Substring(matnr.Length - 4, 1);
            double returnValue = 0;
            switch (weight)
            {
                case "1":
                    returnValue = double.Parse(Weight1.ToString());
                    break;
                case "2":
                    returnValue = double.Parse(Weight2.ToString());
                    break;
                case "3":
                    returnValue = double.Parse(Weight3.ToString());
                    break;
                case "4":
                    returnValue = double.Parse(Weight4.ToString());
                    break;
                case "5":
                    returnValue = double.Parse(Weight5.ToString());
                    break;
                case "6":
                    returnValue = double.Parse(Weight6.ToString());
                    break;
                case "7":
                    returnValue = double.Parse(Weight7.ToString());
                    break;
                case "8":
                    returnValue = double.Parse(Weight8.ToString());
                    break;
                default:
                    returnValue = double.Parse(Weight1.ToString());
                    break;
            }
            return returnValue;
        }

    }
}
