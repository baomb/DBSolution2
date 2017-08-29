using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBSolution
{
    public partial class PageChangeControl : UserControl
    {
        private int StartNumber = 0;
        private int EndNumber;
        private int pageIndex;
        /// <summary>        
        /// 数据源       
        /// /// </summary>        
        private DataTable DataSource
        { get; set; }
        /// <summary>        
        /// 数据源记录总行数        
        /// </summary>        
        public int DataSourceCount
        { get; set; }
        /// <summary>        
        /// 当前页索引        
        /// </summary>        
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
        }
        /// <summary>        
        /// 分页页记录行数        
        /// </summary>        
        [DefaultValue(10)]
        public int PageSize
        {
            get;
            set;
        }
        /// <summary>        
        /// 总页数        
        /// </summary>        
        public int PageCount
        {
            get
            {
                try
                {
                    int iCount = DataSourceCount / PageSize;
                    if (DataSourceCount % PageSize > 0)
                    {
                        iCount = iCount + 1;
                    }
                    return iCount;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public PageChangeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 下一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolNext_Click(object sender, EventArgs e)
        {
            ToolNextClick();
        }
        /// <summary>
        /// 上一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolForward_Click(object sender, EventArgs e)
        {
            ToolForwardClick();
        }
        /// <summary>
        /// 显示首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolFirst_Click(object sender, EventArgs e)
        {
            ToolFirstClick();
        }
        /// <summary>
        /// 显示尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void ToolEnd_Click(object sender, EventArgs e)
        {
            ToolEndClick();
        }

        private void ToolSteps_TextChanged(object sender, EventArgs e)
        {
           // ToolStepsChanged();
        }


        /// <summary>
        /// 显示下一页数据
        /// </summary>
        public void ToolNextClick()
        {
            try
            {
                if (Int32.Parse(ToolLNowPage.Text) >= 1 && Int32.Parse(ToolLNowPage.Text) <= Int32.Parse(ToolPageSum.Text) &&
                    ToolSteps.Text != "")
                {

                    int i = Int32.Parse(ToolLNowPage.Text);
                    int j = Int32.Parse(ToolSteps.Text);
                    i++;
                    ToolLNowPage.Text = i.ToString();
                    EndNumber = j;
                    StartNumber = Int32.Parse(ToolSteps.Text) * (i - 1);
                    ToolForward.Enabled = true;
                }

            }
            catch
            {

            }
        }
        /// <summary>
        /// 显示上一页数据
        /// </summary>
        public void ToolForwardClick()
        {
            try
            {

                if (Int32.Parse(ToolLNowPage.Text) <= Int32.Parse(ToolPageSum.Text))
                {

                    int i = Int32.Parse(ToolLNowPage.Text);
                    int j = Int32.Parse(ToolSteps.Text);
                    i--;
                    EndNumber = j;
                    StartNumber = j * (i - 1);
                    ToolLNowPage.Text = i.ToString();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 显示第一页数据
        /// </summary>
        public void ToolFirstClick()
        {
            try
            {
                if (Int32.Parse(ToolLNowPage.Text) <= Int32.Parse(ToolPageSum.Text))
                {
                    int i = 1;
                    int j = Int32.Parse(ToolSteps.Text);
                    EndNumber = j;
                    StartNumber = 0;
                    ToolLNowPage.Text = i.ToString();
                }

            }
            catch
            {

            }

        }
        /// <summary>
        /// 显示最后一页数据
        /// </summary>
        public void ToolEndClick()
        {
            try
            {

                if (Int32.Parse(ToolLNowPage.Text) <= Int32.Parse(ToolPageSum.Text))
                {

                    int i = Int32.Parse(ToolPageSum.Text);
                    int j = Int32.Parse(ToolSteps.Text);
                    EndNumber = j;
                    StartNumber = j * (i - 1);
                    ToolLNowPage.Text = i.ToString();
                }

            }
            catch
            {

            }

        }
        /// <summary>
        /// 当前页码变更引发按键变更事件
        /// </summary>
        public void ToolLNowPageChanged()
        {
            if (DataSource != null)
            {
                if (Int32.Parse(ToolLNowPage.Text) < Int32.Parse(ToolPageSum.Text) && Int32.Parse(ToolLNowPage.Text) > 1)
                {
                    ToolNext.Enabled = true;
                    ToolForward.Enabled = true;
                }
                else if (Int32.Parse(ToolLNowPage.Text) <= 1)
                {
                    ToolLNowPage.Text = "1";
                    ToolForward.Enabled = false;
                    ToolNext.Enabled = true;
                }
                else if (Int32.Parse(ToolLNowPage.Text) >= Int32.Parse(ToolPageSum.Text))
                {
                    ToolLNowPage.Text = ToolPageSum.Text;
                    ToolForward.Enabled = true;
                    ToolNext.Enabled = false;
                }
            }
        }

        private void PageChangeControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (ToolSteps.Text != "")
                {
                    CsDataGridViewLoadControl();
                }
                else
                {
                    CsDataGridViewLoadControl();
                }
            }
        }

        /// <summary>
        /// 启动加载控件默认属性
        /// </summary>
        public void CsDataGridViewLoadControl()
        {
            ToolForward.Enabled = false;
            ToolNext.Enabled = false;
            ToolLNowPage.Text = "1";
            ToolPageSum.Text = "1";
        }

    }
}
