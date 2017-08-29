using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using System.Collections.Specialized;
using SdlDB.Utility;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Configuration;
namespace DBSolution
{
    public partial class Form1 : Form
    {
        private string id = string.Empty;
        public Form1()
        {
            InitializeComponent();
            GridDataBind();
            BindInfo();
        }
      
        private void GridDataBind()
        {
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load("SdlDB.Settings.dll");
        //    XmlNodeList nodeList = xmlDoc.SelectSingleNode("settings").SelectSingleNode("dbxx").ChildNodes;
        //    TreeNode tdChild = null;
        //    treeView1.Nodes.Clear();
        //    foreach (XmlNode xnode in nodeList)
        //    {
        //        tdChild = new TreeNode();
        //        tdChild.Text = xnode.ChildNodes[0].InnerText.ToString();
        //        tdChild.Name = xnode.Name;
        //        tdChild.ImageIndex = 1;
        //        tdChild.SelectedImageIndex = 1;
        //        treeView1.Nodes.Add(tdChild);
        //        //XmlNodeList nls = xnode.ChildNodes[0];//继续获取xe子节点的所有子节点
        //    }
        //    //展开所有子节点
        //    treeView1.ExpandAll();

            //传参
            //ListDictionary la = new ListDictionary();
            //la.Add("EBELN","4500000979");
            //la.Add("WERKS", "2001");

            ////Table
            //ListDictionary lt = new ListDictionary();
            //lt.Add("ZEPO", "EBELN,EBELP,MATNR,MAKTX,LIFNR,NAME1,MENGE,PTEXT");
            ////结果
            //ListDictionary lr = new ListDictionary();

            ////使用SAP通信
            //DataTable dt = SAPHelper.InvokSAPFunVB("Z_SDL_ROH_MUTUAL_RC", la, lt, ref lr).Tables[0];

            ////下面方法是调用数据库
            ////DataTable dt = DemoTableAdapter.GetDemoTableDataSet("").Tables[0];

            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestB b = new TestB();
            TestA a = new TestA();
            a.print("");
            b.print("");
            a = b;
            a.print("");
        }

        public class TestA
        {
            public void print(String aa)
            {
                Console.Write("A");
            }
        }
        public class TestB : TestA
        {
            public void print(String aa)
            {
                Console.Write("B");
            }
        }
 

        private void ModifyData()
        {
            DemoTable model = DemoTableAdapter.GetDemoTableById(1);
            if (model != null)
            {
                model.Input_Date = DateTime.Now;
                model.Name = "22222";
                DemoTableAdapter.UpdateDemoTable(model);
                MessageBox.Show("修改成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("ReadPortFlag", "22");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void UNcheckAllNode(System.Windows.Forms.TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode tn in nodes)
            {
                tn.Checked = false;
                UNcheckAllNode(tn.Nodes);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                UNcheckAllNode(treeView1.Nodes);
                e.Node.Checked = true;
            }
        }

        private void pageNavigator2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //pageNavigator2.PageSize = 5;
        }

        protected void BindInfo()
        {
            //DataSet ds = Sdl_FinishedProductsSaleAdapter.GetSdl_FinishedProductsSaleSet("");
            //dataGridView1.DataSource = ds.Tables[0];
            //pageNavigator2.PageSize = 3;
            //pageNavigator2.DataSourceCount = 20;
            //pageNavigator2.BindData();
        }

        private void pageNavigator2_PageChanged(object sender, EventArgs e)
        {
            BindInfo();
        }

    }
}
