using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using SdlDB.Entity;
using System.IO;
using System.Data.SqlClient;

namespace SdlDB.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region Sdl_SysSetting

        string userPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string portFlag;

        /// <summary>
        /// 加载设置
        /// </summary>
        public Sdl_SysSetting LoadSdl_SysSetting()
        {
            DataSet ds = new DataSet();
            DataSet dsTemp = new DataSet();
            DataRow dr;

            //复制配置信息
            if (!File.Exists(userPath + "/DBSolution/SdlDB.Settings.dll"))
            {
                Directory.CreateDirectory(userPath + "/DBSolution");
                DirectoryInfo di = new DirectoryInfo(userPath + "/DBSolution");
                FileAttributes attr = File.GetAttributes(userPath + "/DBSolution");
                File.SetAttributes(userPath + "/DBSolution", attr | FileAttributes.Hidden);
                File.Copy("SdlDB.Settings.Temp.dll", userPath + "/DBSolution/SdlDB.Settings.dll");
            }
            //读取原有工厂信息
            else if (File.Exists(userPath + "/DBSolution/SdlDB.Settings.dll") && File.Exists("SdlDB.Settings.Temp.dll"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(userPath + "/DBSolution/SdlDB.Settings.dll");
                XmlDocument xdTemp = new XmlDocument();
                xdTemp.Load("SdlDB.Settings.Temp.dll");
                XmlNode xn = xd.SelectSingleNode("/settings/current");
                XmlNode xnTemp = xdTemp.SelectSingleNode("/settings/current");
                xnTemp.InnerXml = xn.InnerXml;
                xdTemp.Save(userPath + "/DBSolution/SdlDB.Settings.dll");
                File.Delete("SdlDB.Settings.Temp.dll");
            }

            //读取配置信息
            try
            {
                Sdl_SysSetting model = new Sdl_SysSetting();
                ds.ReadXml(userPath + "/DBSolution/SdlDB.Settings.dll");
                dr = ds.Tables["current"].Rows[0];
                model.WERKS = dr["werks"].ToString();
                model.Com = dr["com"].ToString();
                model.ID = dr["id"].ToString();
                model.DB = dr["db"].ToString();
                model.PORTFLAG = dr["portflag"].ToString();
                portFlag = model.PORTFLAG;

                dr = ds.Tables[model.DB].Rows[0];
                model.Model = dr["Model"] == null ? "" : dr["Model"].ToString();
                model.Baudrate = dr["Baudrate"] == null ? 0 : Convert.ToInt16(dr["Baudrate"].ToString());
                string parity = dr["Parity"] == null ? "" : dr["Parity"].ToString();
                switch (parity)
                {
                    case "None":
                        model.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "Even":
                        model.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "Mark":
                        model.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "Odd":
                        model.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "Space":
                        model.Parity = System.IO.Ports.Parity.Space;
                        break;
                    default:
                        break;
                }
                model.Databits = dr["databits"] == null ? 0 : Convert.ToInt16(dr["databits"].ToString());
                string stopbits = dr["stopbits"] == null ? "" : dr["stopbits"].ToString();
                switch (stopbits)
                {
                    case "One":
                        model.Stopbits = System.IO.Ports.StopBits.One;
                        break;
                    case "None":
                        model.Stopbits = System.IO.Ports.StopBits.None;
                        break;
                    case "OnePointFive":
                        model.Stopbits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "Two":
                        model.Stopbits = System.IO.Ports.StopBits.Two;
                        break;
                    default:
                        break;
                }
                model.Order = (dr["Order"] != null && dr["Order"].ToString() == "true") ? true : false;
                model.Regex = dr["regex"] == null ? "" : dr["regex"].ToString();
                return model;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 获取设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Sdl_SysSetting GetSdl_SysSetting(string model)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(userPath + "/DBSolution/SdlDB.Settings.dll");
                DataTable dt = ds.Tables[model];
                Sdl_SysSetting setting = new Sdl_SysSetting();
                setting.Baudrate = Convert.ToInt16(dt.Rows[0]["Baudrate"]);
                setting.Databits = Convert.ToInt16(dt.Rows[0]["Databits"]);
                setting.ID = dt.Rows[0]["ID"].ToString();
                setting.WERKS = dt.Rows[0]["WERKS"].ToString();
                setting.Model = dt.Rows[0]["Model"].ToString();
                setting.Order = Convert.ToBoolean(dt.Rows[0]["Order"]);
                setting.Regex = dt.Rows[0]["Regex"].ToString();
                setting.PORTFLAG = portFlag;
                switch (dt.Rows[0]["Stopbits"].ToString())
                {
                    case "One":
                        setting.Stopbits = System.IO.Ports.StopBits.One;
                        break;
                    case "None":
                        setting.Stopbits = System.IO.Ports.StopBits.None;
                        break;
                    case "OnePointFive":
                        setting.Stopbits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "Two":
                        setting.Stopbits = System.IO.Ports.StopBits.Two;
                        break;
                    default:
                        break;
                }
                switch (dt.Rows[0]["Parity"].ToString())
                {
                    case "None":
                        setting.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "Even":
                        setting.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "Mark":
                        setting.Parity = System.IO.Ports.Parity.Mark;
                        break;
                    case "Odd":
                        setting.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "Space":
                        setting.Parity = System.IO.Ports.Parity.Space;
                        break;
                    default:
                        break;
                }
                return setting;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 保存设置
        /// </summary>
        public bool SaveSdl_SysSetting(Sdl_SysSetting model)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(userPath + "/DBSolution/SdlDB.Settings.dll");
                DataRow dr = ds.Tables["current"].Rows[0];
                dr["werks"] = model.WERKS;
                dr["com"] = model.Com;
                dr["id"] = model.ID;
                dr["db"] = model.DB;
                dr["portflag"] = model.PORTFLAG;
                ds.WriteXml(userPath + "/DBSolution/SdlDB.Settings.dll");
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 读取数据
        /// </summary>
        public DataTable GetSdl_SysSettingDataTable()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(userPath + "/DBSolution/SdlDB.Settings.dll");
            XmlDocument doc = new XmlDocument();
            doc.Load(userPath + "/DBSolution/SdlDB.Settings.dll");
            int count = Convert.ToInt16(doc.SelectSingleNode("settings").SelectSingleNode("info").ChildNodes.Count);
            DataTable dt = new DataTable();
            DataRow dr = null;
            DataColumn dc = new DataColumn();
            dt.Columns.Add("db");
            dt.Columns.Add("id");
            for (int i = 1; i <= count; i++)
            {
                dr = dt.NewRow();
                dr["db"] = "db" + i.ToString();
                dr["id"] = ds.Tables["db" + i].Rows[0]["id"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
 
        /// <summary>
        /// 读取托盘配置信息
        /// </summary>
        public bool GetSdl_Tray(string WERKS)
        { 
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select TRAYFLAG from Sdl_Tray WHERE WERKS =" + WERKS );
              
                DataSet ds = SQLServerHelper.Query(strSql.ToString());
                if (ds.Tables[0] != null && ds.Tables[0].Rows[0][0].ToString() =="1")
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存托盘配置信息
        /// </summary>
        /// 
        public void SaveSdl_Tray(string WERKS, string TRAYFLAG)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TRAYFLAG from Sdl_Tray WHERE WERKS =" + WERKS);
            DataSet ds = SQLServerHelper.Query(strSql.ToString());
            strSql.Append("update Sdl_Tray set ");
            strSql.Append("TRAYFLAG=" + TRAYFLAG);
            strSql.Append("where WERKS=" + WERKS);
            SQLServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 添加托盘配置信息
        /// </summary>
        /// 
        public void AddSdl_Tray(string WERKS, string TRAYFLAG)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sdl_Tray ");
            strSql.Append("(WERKS,TRAYFLAG)");
            strSql.Append("values(" + WERKS + "," + TRAYFLAG+")");
            SQLServerHelper.ExcuteCommand(strSql.ToString());
          }

        /// <summary>
        /// 是否存在托盘配置
        /// </summary>
        public bool ExistsSdl_Tray(string WERKS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sdl_Tray ");
            strSql.Append("where WERKS=@WERKS");
            SqlParameter[] parameters = {
					new SqlParameter("@WERKS", SqlDbType.NVarChar,50)};
            parameters[0].Value = WERKS;
            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        #endregion
    }
}
