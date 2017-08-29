using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SdlDB.Data;
using System.Reflection;
using SdlDB.Entity;
using DBSolution2;

namespace DBSolution
{
    public partial class MainForm : Form
    {
        public static DateTime dt = DateTime.MinValue;
        public delegate void ShowServerStatus(bool status);
        public static Thread thread;
        public static bool isVisible;

        public MainForm()
        {
            InitializeComponent();
            string hostName = System.Net.Dns.GetHostName();
            if (SdlDB.Utility.ValidateHelper.IsHasCHZN(hostName))
            {
                ChangeComputerName ccn = new ChangeComputerName();
                DialogResult dr = ccn.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    this.Close();
                }
            }
            thread = new Thread(new ThreadStart(CheckServerStatus));
            thread.Start();
        }


        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "欢迎您，" + System.Threading.Thread.CurrentPrincipal.Identity.Name.ToString();

            ShowAccreditment("");
        }

        /// <summary>
        /// 根据父控件名称赋权限
        /// </summary>
        /// <param name="FunctionParent">父控件名称</param>
        /// <returns>无</returns>
        private void ShowAccreditment(string FunctionParent)
        {
            DataTable dt = null;
            IPrincipal principal = Thread.CurrentPrincipal;
            string userName = principal.Identity.Name;
            Sdl_Users user = Sdl_UsersAdapter.GetSdl_Users(userName);
            if (user != null)
            {
                dt = Sdl_FunctionsInRolesAdapter.GetSdl_FunctionsInRolesDataSet(user.ROLE).Tables[0];
                DataTable dtFun = Sdl_FunctionsAdapter.GetSdl_FunctionsDataSet("").Tables[0];
                for (int i = 0; i < dtFun.Rows.Count; i++)
                {
                    string controlId = dtFun.Rows[i]["FUNCTIONKEY"].ToString();
                    SetControlPropertyValue(this, controlId, "Enabled", false);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dtFun.Rows[i]["FUNCTIONID"].ToString() == dr["FUNCTIONID"].ToString())
                        {
                            SetControlPropertyValue(this, controlId, "Enabled", true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据控件名和属性名赋值
        /// </summary>
        /// <param name="ClassInstance">控件所在容器例</param>
        /// <param name="ControlName">控件名</param>
        /// <param name="PropertyName">属性名</param>
        /// <param name="Value">属性值</param>
        /// <returns>无</returns>
        public void SetControlPropertyValue(Object ClassInstance, string ControlName, string PropertyName, Object Value)
        {
            Type type = ClassInstance.GetType();

            FieldInfo fieldInfo = type.GetField(ControlName, BindingFlags.NonPublic
             | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(fieldInfo.FieldType);
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find(PropertyName, false);  //这里设为True就不用区分大小写了

                if (propertyDescriptor != null)
                {
                    Object control;

                    control = fieldInfo.GetValue(ClassInstance); //取得控件实例

                    try
                    {
                        propertyDescriptor.SetValue(control, Value);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
            }
            Application.Exit();
        }
        #endregion

        #region 系统设置

        /// <summary>
        /// 系统设置--退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定退出系统吗?", "史丹利地磅系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region 成品业务

        /// <summary>
        /// 成品业务--成品入厂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemProductEnter_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            //form1.MdiParent = this;
            //form1.Show();


        }

        ///// <summary>
        ///// 成品业务--成品出厂
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void toolStripMenuItemProductOut_Click(object sender, EventArgs e)
        //{

        //}

        #endregion

        #region 帮助

        /// <summary>
        /// 帮助--计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        /// <summary>
        /// 帮助--建议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAdvice_Click(object sender, EventArgs e)
        {
            Feedback fb = new Feedback();
            fb.ShowDialog();
        }

        /// <summary>
        /// 帮助--关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        #endregion

        private void timerForPort_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    object i = CommonOper.ExecuteSql("select getdate() ");
            //}
            //catch
            //{ }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FinishedProductsSaleEnter fps = new FinishedProductsSaleEnter();
            fps.MdiParent = this;
            fps.Show();
        }

        private void toolStripMenuItemPEnter_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsSaleEnter>(true);
        }

        private void toolStripMenuItemPOut_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsSaleExit>(true);
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemSaleOrg_Click(object sender, EventArgs e)
        {
            SaleOrgManage frmOrg = new SaleOrgManage();
            frmOrg.MdiParent = this;
            frmOrg.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmTest = new Form1();
            frmTest.MdiParent = this;
            frmTest.Show();
        }

        private void 地磅设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 编辑操作说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserGuide ug = new UserGuide();
            ug.ShowDialog();
        }

        private void toolStripMenuItemSubProEnter_Click(object sender, EventArgs e)
        {
            OpenForm<SubFinishedProductsSaleEnter>(true);
        }

        private void toolStripMenuItemSubProExit_Click(object sender, EventArgs e)
        {
            OpenForm<SubFinishedProductsSaleExit>(true);
        }

        private void toolStripMenuItemProSaleSearch_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsSaleSearch>(true);
        }

        private void toolStripMenuItemRawReturnEnter_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialReturnEnter>(true);
        }

        private void toolStripMenuItemRawReturnExit_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialReturnExit>(true);
        }

        private void toolStripMenuItemRawReturnSearch_Click(object sender, EventArgs e)
        {
            RawMaterialReturnSearch frmRawReturnSearch = new RawMaterialReturnSearch();
            frmRawReturnSearch.MdiParent = this;
            frmRawReturnSearch.Show();
        }

        private void RMPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsProcurementEnter>(true);
        }

        private void RMPEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsProcurementExit>(true);
        }

        private void 原料采购查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsProcurementSearch>(false);
        }

        private void 原材料销售入厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsSaleEnter>(true);
        }

        private void 原材料销售出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsSaleExit>(true);
        }

        private void 编辑包重ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackWeight pw = new PackWeight();
            pw.ShowDialog();
        }

        private void 赠送入厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsPresentationEnter>(true);
        }

        private void 赠送出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsPresentationExit>(true);
        }

        private void 卸货站点维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Station s = new Station();
            s.ShowDialog();
        }

        private void ProReturnRailWayEnter_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnRailwayEnter>(true);
        }

        private void ProReturnRailWayExit_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnRailwayExit>(true);
        }

        private void ProReturnMerchantEnter_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnMerchantEnter>(true);
        }

        private void ProReturnMerchantExit_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnMerchantExit>(true);
        }

        private void SubProReturnRailWayEnter_Click(object sender, EventArgs e)
        {
            OpenForm<SubProductReturnRailwayEnter>(true);
        }

        private void SubProReturnRailWayExit_Click(object sender, EventArgs e)
        {
            OpenForm<SubProductReturnRailwayExit>(true);
        }

        private void SubProReturnMerchantEnter_Click(object sender, EventArgs e)
        {
            OpenForm<SubProductReturnMerchantEnter>(true);
        }

        private void SubProReturnMerchantExit_Click(object sender, EventArgs e)
        {
            OpenForm<SubProductReturnMerchantExit>(true);
        }

        private void 原材料销售查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsSaleSearch>(false);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.ShowDialog();
        }

        private void toolStripMenuItemFunction_Click(object sender, EventArgs e)
        {
            RolesManage formRole = new RolesManage();
            formRole.MdiParent = this;
            formRole.Show();
        }

        private void 控制面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.ShowDialog();
        }

        private void toolStripbtnModifyPwd_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.ShowDialog();
        }

        private void toolStripbtnComputer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }


        private void OpenForm<T>(bool isCloseOther) where T : Form, new()
        {
            if (isCloseOther && Application.OpenForms.Count > 2)
            {
                if (MessageBox.Show("是否关闭当前界面，进入新界面?", "史丹利地磅系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = this.MdiChildren.Count() - 1; i >= 0; i--)
                    {
                        this.MdiChildren[i].Close();
                    }
                    T instance = new T();
                    instance.MdiParent = this;
                    instance.Show();
                }
            }
            else
            {
                T instance = new T();
                instance.MdiParent = this;
                instance.Show();
            }
        }

        private void toolStripMenuItemAccessoryProcuEnter_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryProcurementEnter>(true);
        }

        private void toolStripMenuItemAccessoryProcuExit_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryProcurementExit>(true);
        }

        private void toolStripMenuItemAccessorySearch_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryProcurementSearch>(false);
        }

        private void toolStripMenuItemAccessoryReturnEnter_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryReturnEnter>(true);
        }

        private void toolStripMenuItemAccessoryReturnExit_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryReturnExit>(true);
        }

        private void toolStripMenuItemAccessoryReturnSearch_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryReturnSearch>(true);
        }

        private void 维护地磅误差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadometerDiff ld = new LoadometerDiff();
            ld.ShowDialog(this);
        }

        private void 反馈建议管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FeedbackSearch>(false);
        }

        private void toolStripMenuItemPresentationSearch_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsPresentationSearch>(false);
        }

        private void toolStripMenuItemProReturnSearch_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnMerchantSearch>(false);
        }

        private void toolProReturnSearchRailway_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnRailwaySearch>(false);
        }

        private void toolStripAllotEnterS_Click(object sender, EventArgs e)
        {
            OpenForm<AllotEnterTranferOut>(true);
        }

        private void toolStripAllotExitS_Click(object sender, EventArgs e)
        {
            OpenForm<AllotExitTranferOut>(true);
        }

        private void toolStripAllotSearch_Click(object sender, EventArgs e)
        {
            OpenForm<AllotTranferOutSearch>(false);
        }

        private void toolStripAllotEnterTransferIn_Click(object sender, EventArgs e)
        {
            OpenForm<AllotEnterTranferIn>(true);
        }

        private void toolStripAllotExitTransferIn_Click(object sender, EventArgs e)
        {
            OpenForm<AllotExitTranferIn>(true);
        }

        private void toolStripAllotInSearch_Click(object sender, EventArgs e)
        {
            OpenForm<AllotTranferInSearch>(false);
        }

        private void toolStripAccessoryOutEnter_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotEnterTransferOut>(true);
        }

        private void toolStripAccessoryOutExit_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotExitTransferOut>(true);
        }

        private void toolStripAccessoryInEnter_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotEnterTransferIn>(true);
        }

        private void toolStripAccessoryInExit_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotExitTransferIn>(true);
        }

        private void toolStripAccessoryOutSearch_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotTranferOutSearch>(false);
        }

        private void toolStripAccessoryInSearch_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotTranferInSearch>(false);
        }

        private void toolStripUserManage_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.ShowDialog();
        }

        private void toolStripUserCode_Click(object sender, EventArgs e)
        {
            RolesManage formRole = new RolesManage();
            formRole.MdiParent = this;
            formRole.Show();
        }

        private void toolStripModifyPwd_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.ShowDialog();
        }

        private void toolStripNoteBook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void toolDBReadPortSetting_Click(object sender, EventArgs e)
        {
            DBReadPortSetting dbportSetting = new DBReadPortSetting();
            dbportSetting.ShowDialog();
        }

        private void 产成品销售修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsSaleManage>(false);
        }

        private void 原材料采购修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsProcurementManage>(false);
        }

        private void 原材料退货修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialReturnManage>(false);
        }

        private void 配件采购修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryProcurementManage>(false);
        }

        private void 配件退货修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryReturnManage>(false);
        }

        private void 原材料调拨调出修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<AllotTransferOutManage>(false);
        }

        private void 原材料调拨调入修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<AllotTransferInManage>(false);
        }

        private void 配件调拨调入修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotTransferInManage>(false);
        }

        private void 原材料销售修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsSaleManage>(false);
        }

        private void 成品经销商退货修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnMerchantManage>(false);
        }

        private void 成品铁运退货修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<ProductReturnRailwayManage>(false);
        }

        private void 数据维护历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<DataHistorySearch>(false);
        }

        private void 成品赠送修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsPresentationManage>(false);
        }

        private void 配件调拨调出修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<AccessoryAllotTransferOutManage>(false);
        }

        private void CheckServerStatus()
        {
            bool result;
            string text = string.Empty;
            while (true)
            {
                string sql = "select top 1 * from sdl_Users";
                result = SQLServerHelper.GetSingleSql(sql);
                ThreadFunc(result);
                Thread.Sleep(5000);
            }
        }

        private void ThreadFunc(bool status)
        {
            if (this.menuStripMainForm.InvokeRequired)
            {
                ShowServerStatus showStatus = new ShowServerStatus(ThreadFunc);
                this.Invoke(showStatus, new object[] { status });
            }
            else
            {
                if (status)
                {
                    this.toolStripStatusLabelServerStatus.Text = "服务器状态：正常";
                    this.toolStripStatusLabelServerStatus.ForeColor = Color.Green;
                    this.toolStripStatusLabelServerStatus.Image = DBSolution2.Properties.Resources.serverok;
                }
                else
                {
                    this.toolStripStatusLabelServerStatus.Text = "服务器状态：异常";
                    this.toolStripStatusLabelServerStatus.ForeColor = Color.Red;
                    this.toolStripStatusLabelServerStatus.Image = DBSolution2.Properties.Resources.serverdown;
                }
            }
        }

        //废料入厂
        private void FlotsamToolStripMenuItemEnter_Click(object sender, EventArgs e)
        {
            OpenForm<FloatsamEnter>(true);
        }
        //废料出厂
        private void FlotsamToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            OpenForm<FlotsamExit>(true);
        }
        //废料查询
        private void FlotsamToolStripMenuItemSearch_Click(object sender, EventArgs e)
        {
            OpenForm<FlotsamSearch>(true);
        }
        //维护废旧物资货物名称
        private void toolStripMenuItemFlotName_Click(object sender, EventArgs e)
        {
            FlotManage fm = new FlotManage();
            fm.ShowDialog();
        }

        private void 维护托盘标重ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayWeight tw = new TrayWeight();
            tw.ShowDialog();
        }

        private void 销售入厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishProductSaleContractEnter>(true); 
        }

        private void 销售出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishProductSaleContractExit>(true);
        }
        
        private void 合同订单修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishProductSaleContractManage>(true);
        }

        private void 采购进厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsContractEnter>(true);
        }

        private void 采购出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsContractExit>(true);
        }

        private void 合同采购查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsContractSearch>(true);
        }

        private void 合同采购修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<RawMaterialsContractManage>(true);
        }

        private void 废旧物资修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FlotsamManage>(true);
        }

        private void 仓储类型维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorageType st = new StorageType();
            st.ShowDialog();
        }

        private void 换货重车入厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeInEnter>(true);
        }

        private void 换货空车出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeInExit>(true);
        }

        private void 换货空车入厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeOutEnter>(true);
        }

        private void 换货重车出厂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeOutExit>(true);
        }

        private void 重车入厂查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeInSearch>(true);
        }

        private void 空车入厂查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm<FinishedProductsExchangeOutSearch>(true);
        }

        private void toolStripScanCoder_Click(object sender, EventArgs e)
        {
            OpenForm<ScanCode>(true);
        }
    }
}