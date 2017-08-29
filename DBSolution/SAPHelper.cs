using System;
using SAPFunctionsOCX;
using SAPLogonCtrl;
using SAPTableFactoryCtrl;
using System.Collections.Specialized;
using System.Data;
namespace DBSolution
{
    public class SAPHelper
    {
        private static string ApplicationServer = GetConfigApp("ApplicationServer");
        private static string Client = GetConfigApp("Client");
        private static string Language = GetConfigApp("Language");
        private static string User = GetConfigApp("User");
        private static string Password = GetConfigApp("Password");
        private static int SystemNumber = int.Parse(GetConfigApp("SystemNumber"));


        private static string GetConfigApp(string keyName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[keyName].ToString();
        }

        /// <summary>
        /// 登陆SAP系统
        /// </summary>
        /// <returns>登陆连接</returns>
        public static Connection GetSAPConn()
        {
            try
            {
                SAPLogonCtrl.SAPLogonControlClass logon = new SAPLogonCtrl.SAPLogonControlClass();
                logon.ApplicationServer = ApplicationServer;     //SAP系统IP
                logon.Client = Client;                           //SAP客户端号
                logon.Language = Language;                       //SAP登陆语言
                logon.User = User;                               //用户帐号
                logon.Password = Password;                       //用户密码
                logon.SystemNumber = SystemNumber;               //SAP系统编号
                Connection Conn = (SAPLogonCtrl.Connection)logon.NewConnection();
                return Conn;
            }
            catch (Exception exc)
            {
                throw (new Exception(exc.Message));
            }
        }


        /// <summary>
        /// 调用SAP系统函数模块,返回SAP Tables
        /// </summary>
        /// <param name="strFunName">函数名称</param>
        /// <param name="strArgs">输入参数字典</param>
        /// <param name="strRetTabs">返回表结果字典</param>
        /// <param name="strResult">返回程序运行结果</param>
        /// <returns>返回表SAP结果集</returns>
        public static Tables GetSAPFunTables(string strFunName, ListDictionary strArgs, ListDictionary strRetTabs, ref ListDictionary strResult)
        {
            try
            {
                string[] array = new string[strResult.Count];
                strResult.Keys.CopyTo(array, 0);
                Connection conn = GetSAPConn();
                Tables ENQs = new Tables();
                if (conn.Logon(0, true))
                {
                    SAPFunctionsClass func = new SAPFunctionsClass();
                    func.Connection = conn;
                    //(1)
                    IFunction ifunc = (IFunction)func.Add(strFunName);               //调用函数模块
                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];                                //设置参数值               
                    }
                    ifunc.Call(); //调用函数模块
                    //(2)
                    foreach (string ret in array)
                    {
                        IParameter NUMBER = (IParameter)ifunc.get_Imports(ret);      //返回程序运行结果
                        strResult[ret] = NUMBER.Value;
                    }
                    //(3)
                    ENQs = (Tables)ifunc.Tables;                      //获取所有Tables
                }
                conn.Logoff();
                return ENQs;
            }
            catch (Exception exc)
            {
                throw (new Exception(exc.Message));
            }
        }


        /// <summary>
        /// 调用SAP系统函数模块
        /// </summary>
        /// <param name="strFunName">函数名称</param>
        /// <param name="strArgs">输入参数字典</param>
        /// <param name="strRetTabs">返回表结果字典</param>
        /// <param name="strResult">返回程序运行结果</param>
        /// <returns>返回表结果集</returns>
        public static DataSet InvokSAPFun(string strFunName, ListDictionary strArgs, ListDictionary strRetTabs, ref ListDictionary strResult)
        {
            try
            {
                DataSet retDST = new DataSet();
                string[] array = new string[strResult.Count];
                strResult.Keys.CopyTo(array, 0);
                Connection conn = GetSAPConn();

                if (conn.Logon(0, true))
                {
                    SAPFunctionsClass func = new SAPFunctionsClass();
                    func.Connection = conn;

                    //(0)
                    IFunction ifunc = (IFunction)func.Add(strFunName);               //调用函数模块


                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];
                    }
                    //(1)参数
                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];                                //设置参数值               
                    }
                    ifunc.Call(); //调用函数模块
                    //(2)
                    foreach (string ret in array)
                    {
                        IParameter NUMBER = (IParameter)ifunc.get_Imports(ret);      //返回程序运行结果
                        strResult[ret] = NUMBER.Value;
                    }
                    //(3)
                    Tables ENQs = (Tables)ifunc.Tables;                      //获取所有Tables
                    foreach (string tab in strRetTabs.Keys)
                    {
                        Table ENQ = (Table)ENQs.get_Item(tab);               //返回指定Tables
                        DataTable dat = ConvertTable(ENQ);
                        retDST.Tables.Add(dat);
                    }
                }
                conn.Logoff();

                return retDST;
            }
            catch (Exception exc)
            {
                throw (new Exception(exc.Message));
            }
        }

        /// <summary>
        /// 调用SAP系统函数模块
        /// </summary>
        /// <param name="strFunName">函数名称</param>
        /// <param name="strArgs">输入参数字典</param>
        /// <param name="strRetTabs">返回表结果字典</param>
        /// <param name="strResult">返回程序运行结果</param>
        /// <returns>返回表结果集</returns>
        public static void InvokSAPFun(string strFunName, ListDictionary strArgs, ref ListDictionary strResult)
        {
            try
            {
                DataSet retDST = new DataSet();
                string[] array = new string[strResult.Count];
                strResult.Keys.CopyTo(array, 0);
                Connection conn = GetSAPConn();

                if (conn.Logon(0, true))
                {
                    SAPFunctionsClass func = new SAPFunctionsClass();
                    func.Connection = conn;

                    //(0)
                    IFunction ifunc = (IFunction)func.Add(strFunName);               //调用函数模块


                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];
                    }
                    //(1)参数
                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];                                //设置参数值               
                    }
                    ifunc.Call(); //调用函数模块
                    //(2)
                    foreach (string ret in array)
                    {
                        IParameter NUMBER = (IParameter)ifunc.get_Imports(ret);      //返回程序运行结果
                        strResult[ret] = NUMBER.Value;
                    }
                }
                conn.Logoff();
            }
            catch (Exception exc)
            {
                throw (new Exception(exc.Message));
            }
        }

        ///// <summary>
        ///// 调用SAP系统函数模块
        ///// </summary>
        ///// <param name="strFunName">函数名称</param>
        ///// <param name="strArgs">输入参数字典</param>
        ///// <param name="strRetTabs">返回表结果字典</param>
        ///// <param name="strResult">返回程序运行结果</param>
        ///// <returns>返回表结果集</returns>
        //public static DataSet InvokSAPFunVB(string strFunName, ListDictionary strArgs, ListDictionary strRetTabs, ref ListDictionary strResult)
        //{
        //    try
        //    {
        //        DataSet retDST = new DataSet();
        //        string[] array = new string[strResult.Count];
        //        strResult.Keys.CopyTo(array, 0);
        //        VBSAP VBSap = new VBSAP(null, ApplicationServer, Client, SystemNumber.ToString());
        //        bool boolConn = VBSap.ConnectToSAP(User, Password, Language);
        //        if (boolConn)
        //        {
        //            VBSap.SetRFCFuncName(strFunName);
        //            foreach (string arg in strArgs.Keys)
        //            {
        //                VBSap.SetPara(arg, strArgs[arg]);
        //            }

        //            VBSap.Execute();

        //            DataTable dtTemp = new DataTable();
        //            foreach (string tab in strRetTabs.Keys)
        //            {
        //                dtTemp = VBSap.GetParaTable(strRetTabs[tab].ToString(), tab, false);
        //                retDST.Tables.Add(dtTemp);
        //            }

        //            foreach (string ret in array)
        //            {
        //                strResult[ret] = VBSap.GetPara(ret);
        //            }

        //            VBSap.DisConnectSAP();
        //        }

        //        return retDST;
        //    }
        //    catch (Exception exc)
        //    {
        //        throw (new Exception(exc.Message));
        //    }
        //}

        //public static void InvokSAPFunVB(string strFunName, ListDictionary strArgs, ref ListDictionary strResult)
        //{
        //    try
        //    {
        //        string[] array = new string[strResult.Count];
        //        strResult.Keys.CopyTo(array, 0);
        //        VBSAP VBSap = new VBSAP(null, ApplicationServer, Client, SystemNumber.ToString());
        //        bool boolConn = VBSap.ConnectToSAP(User, Password, Language);
        //        if (boolConn)
        //        {
        //            VBSap.SetRFCFuncName(strFunName);
        //            foreach (string arg in strArgs.Keys)
        //            {
        //                VBSap.SetPara(arg, strArgs[arg]);
        //            }
        //            VBSap.Execute();
        //            foreach (string ret in array)
        //            {
        //                strResult[ret] = VBSap.GetPara(ret);
        //            }
        //            VBSap.DisConnectSAP();
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        throw (new Exception(exc.Message));
        //    }
        //}

        /// <summary>
        /// 调用SAP系统函数模块
        /// </summary>
        /// <param name="strFunName">函数名称</param>
        /// <param name="strArgs">输入参数字典</param>
        /// <param name="strRetTabs">返回表结果字典</param>
        /// <param name="strResult">返回程序运行结果</param>
        /// <returns>返回表结果集</returns>
        public static DataSet InvokSAPFunTable(string strFunName, ListDictionary strArgs, ListDictionary strTableArgs, ListDictionary strRetTabs, ref ListDictionary strResult)
        {
            try
            {
                DataSet retDST = new DataSet();
                string[] array = new string[strResult.Count];
                strResult.Keys.CopyTo(array, 0);
                Connection conn = GetSAPConn();

                if (conn.Logon(0, true))
                {
                    SAPFunctionsClass func = new SAPFunctionsClass();
                    func.Connection = conn;

                    //(0)
                    IFunction ifunc = (IFunction)func.Add(strFunName);               //调用函数模块


                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];
                    }
                    //(1)参数
                    foreach (string arg in strArgs.Keys)
                    {
                        IParameter gclient = (IParameter)ifunc.get_Exports(arg);     //取得输入参数
                        gclient.Value = strArgs[arg];                                //设置参数值               
                    }
                    ifunc.Call(); //调用函数模块
                    //(2)
                    foreach (string ret in array)
                    {
                        IParameter NUMBER = (IParameter)ifunc.get_Imports(ret);      //返回程序运行结果
                        strResult[ret] = NUMBER.Value;
                    }
                    //(3)
                    Tables ENQs = (Tables)ifunc.Tables;                      //获取所有Tables
                    foreach (string tab in strRetTabs.Keys)
                    {
                        Table ENQ = (Table)ENQs.get_Item(tab);               //返回指定Tables
                        DataTable dat = ConvertTable(ENQ);
                        retDST.Tables.Add(dat);
                    }
                }
                conn.Logoff();

                return retDST;
            }
            catch (Exception exc)
            {
                throw (new Exception(exc.Message));
            }
        }

        /// <summary>
        /// 将SAP Tables转换为System.Data.DataTable
        /// </summary>
        /// <param name="tab">SAP Tables</param>
        /// <returns>System.Data.DataTable</returns>
        private static DataTable ConvertTable(Table tab)
        {
            DataTable dt = new DataTable();
            for (int j = 1; j <= tab.ColumnCount; j++)
            {
                dt.Columns.Add(tab.ColumnName[j].ToString());
            }
            try
            {
                if (tab.RowCount > 0)
                {
                    for (int i = 1; i <= tab.RowCount; i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int t = 0; t < dt.Columns.Count; t++)
                        {
                            dr[t] = tab.get_Cell(i, t + 1);
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
